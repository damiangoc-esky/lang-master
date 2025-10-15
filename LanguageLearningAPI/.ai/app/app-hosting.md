# App Hosting Plan

## Overview
This document outlines the hosting plan for the Language Learning App on Google Cloud, focusing on cost-effective solutions leveraging the free tier.

## Hosting Assumptions
- The app will be a single-page application (SPA) built with Angular.
- The backend will be developed using C# .NET Core and deployed as serverless functions.
- The database will utilize Firebase Firestore for its generous free tier and scalability.
- User authentication will be managed through Firebase Authentication.
- Analytics and monitoring will be handled by Google Analytics and Google Cloud Monitoring.

## Frontend Hosting Decision
- **Firebase Hosting**: Chosen for its seamless integration with SPAs and generous free tier. Firebase Hosting provides fast and secure hosting for static files, making it ideal for serving the Angular frontend.

## Backend Hosting
- **Google Cloud Functions**: The backend logic will be deployed as serverless functions, allowing for cost-effective scaling and management.

## Database
- **Google Cloud SQL**: Selected for its real-time capabilities and free tier, suitable for storing user data and app content.
- **Data Insertion**: Support for uploading a CSV file with Polish words and their English translations to populate the database.

## Authentication
- **Firebase Authentication**: Provides a secure and easy-to-implement solution for user management.

## Analytics and Monitoring
- **Google Analytics**: Used for tracking user interactions and app performance.
- **Google Cloud Monitoring**: Utilized for monitoring app health and performance metrics.

## CI/CD
- **GitHub Actions**: Automates the build and deployment processes, integrating well with Google Cloud services.
