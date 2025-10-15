# Step 3: Backend Deployment

## Overview
This document provides detailed instructions for deploying the .NET Core backend on Google Cloud Functions.

## Instructions

### Deploy Google Cloud Functions
1. **Prepare the Backend Code**:
   - Ensure your .NET Core backend code is ready for deployment.
   - Package the code using `dotnet publish`.
2. **Deploy to Cloud Functions**:
   - Use the Google Cloud SDK to deploy the functions.
   - Run the following command:
     ```bash
     gcloud functions deploy FUNCTION_NAME --runtime dotnet3 --trigger-http --allow-unauthenticated
     ```
   - Replace `FUNCTION_NAME` with the name of your function.

### API Gateway
1. **Set Up API Gateway**:
   - Navigate to "API Gateway" in the Google Cloud Console.
   - Create a new API and configure it to route requests to your Cloud Functions.

## Conclusion
By following these steps, you will have the backend deployed on Google Cloud Functions, accessible via API Gateway.
