
```bash
# Create project
cd ./Starter/EventPublisher
dotnet new console --name MessageProcessor --output .
dotnet add package Microsoft.Azure.EventGrid --version 3.2.0
dotnet build

# Modify Program.cs
open http://eventviewerstudent.azurewebsites.net/
dotnet run # will publish events

# Clean Azure resource
az login
[
  {
    "cloudName": "AzureCloud",
    "homeTenantId": "8eb87a6e-8055-4135-b69d-f19c799ec045",
    "id": "4a38dcc5-0150-4aa9-ad87-0c4dc5f55fcc",
    "isDefault": true,
    "managedByTenants": [],
    "name": "AZ-204T00-A CSR 3",
    "state": "Enabled",
    "tenantId": "8eb87a6e-8055-4135-b69d-f19c799ec045",
    "user": {
      "name": "LabUser-14656051@cloudslice.onmicrosoft.com",
      "type": "user"
    }
  }
]
az group list
[
  {
    "id": "/subscriptions/4a38dcc5-0150-4aa9-ad87-0c4dc5f55fcc/resourceGroups/PubSubEvents-lod14656051",
    "location": "westus",
    "managedBy": null,
    "name": "PubSubEvents-lod14656051",
    "properties": {
      "provisioningState": "Succeeded"
    },
    "tags": {
      "LODManaged": "lod",
      "LabInstance": "14656051",
      "LabProfile": "69289",
      "TS": "132514500690657543"
    },
    "type": "Microsoft.Resources/resourceGroups"
  }
]
AZURE_GROUP_NAME=$(az group list --query '[0].name' -o json | jq -r) # "jq -r" to unwrap the "" for the string
echo ${AZURE_GROUP_NAME}
az group delete --name ${AZURE_GROUP_NAME} --no-wait --yes
```
