# Create Serverless Applications

### Choose the azure service to automate business processes

- [Choose the right integration and automation services in Azure](https://learn.microsoft.com/en-us/azure/azure-functions/functions-compare-logic-apps-ms-flow-webjobs)
- [What is Azure Logic Apps?](https://learn.microsoft.com/en-us/azure/logic-apps/logic-apps-overview)
- [Get started with Power Automate](https://learn.microsoft.com/en-us/power-automate/getting-started)
- [Power Automate](https://make.powerautomate.com/)
- [Run background tasks with WebJobs in Azure App Service](https://learn.microsoft.com/en-us/azure/app-service/webjobs-create)
- [What is Azure Functions?](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview)
- [Create a function to integrate with Azure Logic Apps](https://learn.microsoft.com/en-us/azure/azure-functions/functions-twitter-email)
- [Supported languages in Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/supported-languages)

---

### Triggers

- **Blob Storage:** Starts a function when a new or updated blob is detected.
- **Azure Cosmos DB:** Start a function when inserts and updates are detected.
- **Event Grid:** Starts a function when an event is received from Event Grid.
- **HTTP:** Starts a function with an HTTP request.
- **Microsoft Graph Events:** Starts a function in response to an incoming webhook from the Microsoft Graph. Each instance of this trigger can react to one Microsoft Graph resource type.
- **Queue Storage:** Starts a function when a new item is received on a queue. The queue message is provided as input to the function.
- **Service Bus:** Starts a function in response to messages from a Service Bus queue.
- **Timer:** Starts a function on a schedule.

### Test the function

```bash
curl "<get-function-URL>
This HTTP triggered function executed successfully. Pass a name on the query string or in the request body for a personalized response.

curl "<get-function-URL>&name=Azure"
Hello, Azure. This HTTP triggered function executed successfully.
```

```bash
curl \
--header "Content-Type: application/json" \
--header "x-functions-key: <your-function-key>" \
--request POST --data "{\"name\": \"Azure Function\"}" <your-https-url>
```

### Create a Python function in Azure from the command line
```bash 
func --version 

func init --python

func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous"

func start

```

```bash 

winget install --exact --id Microsoft.AzureCLI

az login

az group create --name "AzureFunctionsQuickstart" --location "southeastasia"

az storage account create --name "myothetstorageacc123" --location "southeastasia" --resource-group "AzureFunctionsQuickstart" --sku Standard_LRS

az functionapp create --resource-group "AzureFunctionsQuickstart" --consumption-plan-location southeastasia --runtime python --runtime-version 3.12 --functions-version 4 --name "myothetfunctionappname123" --os-type linux --storage-account "myothetstorageacc123"

```

```bash

func azure functionapp publish myothetfunctionappname123

```