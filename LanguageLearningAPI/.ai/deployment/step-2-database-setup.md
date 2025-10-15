# Step 2: Database Setup

## Overview
This document provides detailed instructions for setting up the database on Google Cloud SQL, including configuration and schema setup.

## Instructions

### Deploy Google Cloud SQL
1. **Access Cloud SQL**:
   - Go to the [Google Cloud Console](https://console.cloud.google.com/).
   - Navigate to "SQL" in the left-hand menu.
2. **Create a New Instance**:
   - Click "Create Instance".
   - Choose "PostgreSQL" as the database engine.
   - Select the smallest instance size to stay within the free tier.
   - Configure instance settings and click "Create".

### Database Configuration
1. **Set Up Database Schema**:
   - Connect to the instance using the Cloud SQL client or a third-party tool.
   - Execute the SQL instructions from `db-instructions.md` to set up the schema, ensuring the correct order of table creation.

## Conclusion
By following these steps, you will have a Google Cloud SQL instance set up with the necessary schema for the Language Learning App.
