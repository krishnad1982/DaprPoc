# Dapr POC Verison 1.0

This example shows a basic idea about how we can use pub/sub, state management, secrets and observability building blocks in Dapr
This project has got two services
- Order
- Dispatch

For more information, visit the article explaining this workflow

- `pub/sub` publish sub using Dapr and Azure service bus.
- `state management` iState management using Dapr and Redis
- `secrets` Secrets in Dapr using local json file
- `observability` Observability in Dapr using zipkin

## Running Demo

- Install Dapr
- Run the below command from order service's root folder (in the powershell/cmd)  
- ``` dapr run --app-id order-app --app-port 5005 --dapr-http-port 3501 --components-path ../components dotnet run```
- Run the below command from dispatch service's root folder (in the powershell/cmd)
- ```dapr run --app-id dispatch-app --app-port 5000 --dapr-http-port 3500 --components-path ../components dotnet run```

Reference: https://docs.dapr.io/getting-started/install-dapr-cli/