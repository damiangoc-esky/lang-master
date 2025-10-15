# Deployment Plan for Language Learning App

## Overview
This document outlines the deployment plan for the Language Learning App on Google Cloud, focusing on cost-effective strategies to utilize the free tier and minimize expenses.

## Deployment Steps

### 1. Set Up Google Cloud Project
- **Create a Google Cloud Project**: Set up a new project in the Google Cloud Console.
- **Enable Billing**: Ensure billing is enabled to access the free tier.
- **Activate APIs**: Enable necessary APIs, including Cloud SQL, Cloud Functions, and Firebase.

### 2. Database Setup
- **Google Cloud SQL**: Deploy the database using the smallest instance size to stay within the free tier.
- **Database Configuration**: Set up the database schema as specified in the db-instructions.md file, ensuring the correct order of table creation.

### 3. Backend Deployment
- **Google Cloud Functions**: Deploy the .NET Core backend as serverless functions.
- **API Gateway**: Use API Gateway to manage and secure API endpoints.

### 4. Frontend Deployment
- **Firebase Hosting**: Deploy the Angular frontend using Firebase Hosting for fast and secure delivery.

### 5. Authentication and Security
- **Firebase Authentication**: Implement user authentication using Firebase Authentication.
- **IAM Roles**: Configure IAM roles and permissions to secure resources.

### 6. Monitoring and Analytics
- **Google Cloud Monitoring**: Set up monitoring to track application performance and usage.
- **Google Analytics**: Integrate Google Analytics for user interaction tracking.

### 7. CI/CD Pipeline
- **GitHub Actions**: Set up a CI/CD pipeline using GitHub Actions to automate build and deployment processes.

## Cost Management
- **Monitor Usage**: Regularly monitor resource usage to stay within the free tier limits.
- **Optimize Resources**: Optimize function execution and database queries to minimize costs.
- **Use Free Tier**: Leverage Google Cloud's free tier offerings for Cloud SQL, Cloud Functions, and Firebase.

## Adjustments to Existing Documents
- **Tech Stack**: Ensure the tech stack aligns with the deployment plan, focusing on free tier usage.
- **API Specification**: Verify that API endpoints are optimized for serverless deployment.

## Conclusion
By following this deployment plan, the Language Learning App can be effectively deployed on Google Cloud with minimal costs, leveraging the free tier and optimizing resource usage.
