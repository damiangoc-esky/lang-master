# Technology Stack Specification

## Overview
This document outlines the technology stack chosen for the development of the Language Learning App, highlighting the reasons for each choice.

## Backend
- **Language**: C#
- **Framework**: .NET Core
  - Chosen for its high performance, scalability, and cross-platform capabilities.
- **Database**: Google Cloud SQL
  - Selected for its robust support for complex queries and transactions, essential for managing language learning content and user data.
- **ORM**: Entity Framework Core
  - Provides a streamlined approach to database interactions and supports LINQ for querying.

## Frontend
- **Framework**: Angular
  - Offers a powerful component-based architecture, making it ideal for building dynamic and interactive user interfaces.
- **Styling**: SCSS
  - Chosen for its advanced features over traditional CSS, allowing for more maintainable and scalable stylesheets.

## DevOps
- **Version Control**: Git
  - Utilized for source code management and collaboration.
- **CI/CD**: GitHub Actions
  - Automates the build, test, and deployment processes, ensuring rapid and reliable delivery of updates.
- **Hosting**: Google Cloud
  - Provides a scalable and secure environment for hosting both the backend and frontend applications.

## Additional Tools
- **CSV Handling**: Implement functionality to upload and parse CSV files for populating the database with Polish words and their English translations.
- **Testing**: xUnit for backend, Jasmine/Karma for frontend
  - Ensures code quality and reliability through automated testing.
- **Containerization**: Docker
  - Facilitates consistent development and deployment environments across different stages.
