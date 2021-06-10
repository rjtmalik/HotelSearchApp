## Project Structure
The project is composed of 
- HotelSearchApp
The Api application that exposes the endpoint for performing hotel search.

- HotelSearchApp.Services
The Class Library is the brain of the application and all logic resides in it.

- HotelSearchApp.DAL
The Class Library provides the abstractions for interating with the Database, in this case, file system by mounting the file into docker container.

- HotelSearchApp.Services.Tests.Unit
The xunit test library for unit testing cases in the Services.

- HotelSearchApp.Tests.Contract
The Nunit test library for implementing consumer driven contract tests.

## How To Run
- Navigate to the root directory and then to folder data, and update the file hotelsrates.json. This file will be mounted in the container from this location.
- Navigate to the root directory, and build from the Docker file

`docker build -t hotelsapi .`
`docker container run --mount type=bind,source='C:\Users\ramalik\source\repos\HotelFilterApp\data',target='/app/data' -d -p 8012:80 hotelsapi`

## Search endpoint
`GET http://localhost:8012/api/hotels/7294/arrivalDate/1458003600/prices`

## Security
The application would be secured following the OAUTH 2.0 security protocol. The Authorization server selected in Microsoft Azure AD. The developer can update the values in the app settings file after registering in Azure AD.
[Steps](https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-v2-aspnet-core-web-api)

The endpoints in the controller are not annotated yet.

### Further Improvement
- Implement policy based authorization on the endpoints.
- Add more tests to cover the contract testing of all endpoints.
- Use Terraform to create the the infrastructure.
- Add versioning to the endpoints for easier maintanence and release.
- Implement CICD pipeline with Github actions when a pull request is merged.