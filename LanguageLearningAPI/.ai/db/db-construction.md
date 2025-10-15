# Database Construction Document

## Overview
This document outlines the database construction for the Language Learning App, focusing on translation data and user management. It incorporates features and actions specified in other documents, including user types, relations, and actions.

## Database Type
- **Google Cloud SQL**: The database will be hosted on Google Cloud SQL, leveraging its capabilities for managing relational data.

## Tables and Relationships

### Users Table
- **UserID**: Primary key, unique identifier for each user.
- **Username**: Unique username for login.
- **PasswordHash**: Securely stored password hash.
- **UserType**: Enum to specify user roles (e.g., Admin, Learner).

### LearningPlan Table
- **PlanID**: Primary key, unique identifier for each learning plan.
- **UserID**: Foreign key relation to the Users table.
- **GroupIDs**: JSONB field for storing group IDs included in the user's learning plan.

### TranslationGroups Table
- **GroupID**: Primary key, unique identifier for each translation group.
- **GroupName**: Name of the translation group (e.g., "Weather").
- **Description**: Optional description of the group.

### TranslationPairs Table
- **PairID**: Primary key, unique identifier for each translation pair.
- **GroupID**: Foreign key relation to the TranslationGroups table.
- **PolishContent**: The word, phrase, or sentence in Polish.
- **EnglishTranslation**: The corresponding translation in English.
- **Type**: Enum to specify the type (e.g., word, phrase, sentence).

## User Actions
- **Admins**: Can perform CRUD actions on translation data and view analytics.
- **Learners**: Can manage their learning plans by assigning or unassigning groups.

## Security Considerations
- **Authentication**: Ensure secure storage and handling of user credentials.
- **Data Integrity**: Maintain referential integrity between tables to ensure consistent data.

![db.png](db.png)