# Dapr POC Version 1.0

This example shows a basic idea about how we can use pub/sub, state management, secrets and observability building blocks in Dapr.

This project has got two services
- Order
- Dispatch

For more information, visit the [article](https://www.linkedin.com/pulse/dapr-action-krishna-raj-d?lipi=urn%3Ali%3Apage%3Ad_flagship3_profile_view_base_recent_activity_details_shares%3BsN5vxCz6RkulewfE%2BLg6mQ%3D%3D&licu=urn%3Ali%3Acontrol%3Ad_flagship3_profile_view_base_recent_activity_details_shares-article_description) explaining this workflow

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

## Azure Service Bus
- Create a topic called "order"
- Add the root shared access policy connection string in the `\Wow.DaprBlock.Poc\components\wowpublish.yaml` Message Broker Placeholder.
- Dispatch subscription will create automatically by Dapr when you run your Dispatch service.

## Postman
- Publish an order - http://localhost:5005/order/createorder POST
- Get the order subscription - http://localhost:5000/dapr/subscribe GET
- Create state management - http://localhost:5005/state/createstate POST
- Get the state management value - http://localhost:5000/state/{state-key} GET
- Get secret - http://localhost:3501/v1.0/secrets/wowsecret/{secret-key} GET

Reference: https://docs.dapr.io/getting-started/install-dapr-cli/