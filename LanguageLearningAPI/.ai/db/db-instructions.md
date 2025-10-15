# Database Creation Instructions

## Overview
This document provides SQL instructions to create the database tables and establish the relationships as specified in the db-construction.md file for the Language Learning App, compatible with PostgreSQL 18.

## SQL Instructions

```sql
-- Create Users Table
CREATE TABLE Users (
    UserID SERIAL PRIMARY KEY,
    Username VARCHAR(255) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    UserType VARCHAR(50) CHECK (UserType IN ('Admin', 'Learner')) NOT NULL
);

-- Create LearningPlan Table
CREATE TABLE LearningPlan (
    PlanID SERIAL PRIMARY KEY,
    UserID INT REFERENCES Users(UserID),
    GroupIDs JSONB
);

-- Create TranslationGroups Table
CREATE TABLE TranslationGroups (
    GroupID SERIAL PRIMARY KEY,
    GroupName VARCHAR(255) NOT NULL,
    Description TEXT
);

-- Create TranslationPairs Table
CREATE TABLE TranslationPairs (
    PairID SERIAL PRIMARY KEY,
    GroupID INT REFERENCES TranslationGroups(GroupID),
    PolishContent TEXT NOT NULL,
    EnglishTranslation TEXT NOT NULL,
    Type VARCHAR(50) CHECK (Type IN ('word', 'phrase', 'sentence')) NOT NULL
);
```

## Notes
- Ensure that the database is set up to support JSONB data types as used in the LearningPlan table.
- Adjust data types and constraints as necessary to fit specific PostgreSQL 18 requirements.
