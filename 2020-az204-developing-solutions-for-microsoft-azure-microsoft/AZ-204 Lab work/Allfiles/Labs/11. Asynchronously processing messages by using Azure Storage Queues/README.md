# Module 11 (CSR) - Asynchronously processing messages by using Azure Storage Queues

```bash
# Create project
cd ./Starter/MessageProcessor
dotnet new console --name MessageProcessor --output .
dotnet add package Azure.Storage.Queues --version 12.0.0
dotnet build

# Modify Program.cs
dotnet run # will print out below
# ---Account Metadata---
# Account Uri:	https://asyncstorshijian.queue.core.windows.net/messagequeue

# Modify Program.cs - 添加读取message的代码
dotnet run # 现在是没有message被获得的
# 在Azure Portal -> Storage Account -> Storage Explorer -> QUEUES -> messagequeue手动添加message
dotnet run # 打印该message

# Modify Program.cs - 添加删除message的代码
dotnet run # 打印该message并删除, 之后再Azure Portal里面看不到该message了

# Modify Program.cs - 添加发送message的代码
dotnet run # 发送message到queue里面

# Clean Azure resource
az login
[
  {
    "cloudName": "AzureCloud",
    "homeTenantId": "8eb87a6e-8055-4135-b69d-f19c799ec045",
    "id": "813202b7-9c14-42b6-8614-7206e3317c62",
    "isDefault": true,
    "managedByTenants": [],
    "name": "AZ-204T00-A CSR 1",
    "state": "Enabled",
    "tenantId": "8eb87a6e-8055-4135-b69d-f19c799ec045",
    "user": {
      "name": "LabUser-14656929@cloudslice.onmicrosoft.com",
      "type": "user"
    }
  }
]
AZURE_GROUP_NAME=$(az group list --query '[0].name' -o json | jq -r) # "jq -r" to unwrap the "" for the string
echo ${AZURE_GROUP_NAME}
az group delete --name ${AZURE_GROUP_NAME} --no-wait --yes
```
