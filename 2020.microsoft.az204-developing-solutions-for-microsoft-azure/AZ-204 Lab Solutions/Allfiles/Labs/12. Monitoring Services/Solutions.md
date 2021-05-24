- (1) Create an Application Insights resource
  - Create a resource -> Application Insights -> Create
    - Resource group -> Create new -> MonitoredAssets
    - Name: instrmshijian
    - Region: (US) East US
    - Resource Mode: Classic
  - Review + Create -> Create
  - Once the resource is deployed -> Go to resource
  - Instrumentation Key: `a215187d-d3aa-4560-8cb3-8a8faf63a827`
- (2) Create a web app by using Azure App Services resource
  - Create a resource -> Web App -> Create
    - Basics
      - Resource group: `MonitoredAssets`
      - Name: smpapishijian
      - Publish: Code
      - Runtime stack: .net Core 3.1 (LTS)
      - Operation System: Windows
      - Region: East US
      - Windows Plan: Create new -> Name: MonitoredPlan
    - Monitoring
      - Enable Application Insights -> `Yes` (the Lab subscription does not support this)
      - Application Insights: instrmshijian

```text
In the Configuration section, perform the following actions:

Select the Application settings tab.

Select Show Values to get the secrets associated with your API.

Find the value corresponding to the APPINSIGHTS_INSTRUMENTATIONKEY key. This value was set automatically when you built your Web Apps resource.
```

- (3) Configure web app autoscale options

```text
In the Scale out section, perform the following actions:

Select Custom autoscale.

In the Autoscale setting name text box, enter ComputeScaler.
In the Resource group list, select MonitoredAssets.
In the Scale mode section, select Scale based on a metric.
In the Minimum text box in the Instance limits section, enter 2.
In the Maximum text box in the Instance limits section, enter 8.
In the Default text box in the Instance limits section, enter 3.

Select Add a rule. In the Scale rule pop-up dialog, leave all boxes set to their default values, and then select Add.

Within the section, select Save.
```

> PS: More settings there, because the Lab does not go well, then stop here

```bash
# Create project
cd ./Starter/Api
dotnet new webapi --output . --name SimpleApi
dotnet add package Microsoft.ApplicationInsights --version 2.14.0
dotnet add package Microsoft.ApplicationInsights.AspNetCore --version 2.14.0
dotnet add package Microsoft.ApplicationInsights.PerfCounterCollector  --version 2.14.0
dotnet build

# Modify Startup.cs to configure the Application Insights using the provided instrumentation key
dotnet build

# if local port is occupied, Go and change Properties/launchSettings.json
# "applicationUrl": "https://localhost:5003;http://localhost:5002",
dotnet run

# Swagger
open http://localhost:5002/swagger/v1/swagger.json

open http://localhost:5002/weatherforecast
[{"date":"2020-12-05T10:51:55.215679+08:00","temperatureC":-5,"temperatureF":24,"summary":"Freezing"},{"date":"2020-12-06T10:51:55.21594+08:00","temperatureC":-16,"temperatureF":4,"summary":"Mild"},{"date":"2020-12-07T10:51:55.215941+08:00","temperatureC":19,"temperatureF":66,"summary":"Balmy"},{"date":"2020-12-08T10:51:55.215942+08:00","temperatureC":-1,"temperatureF":31,"summary":"Chilly"},{"date":"2020-12-09T10:51:55.215942+08:00","temperatureC":11,"temperatureF":51,"summary":"Cool"}]

# Deploy application to Azure
az login

AZURE_GROUP_NAME=$(az group list --query '[0].name' -o json | jq -r)
az webapp list --resource-group ${AZURE_GROUP_NAME}
[
  {
    "appServicePlanId": "/subscriptions/4a38dcc5-0150-4aa9-ad87-0c4dc5f55fcc/resourceGroups/Monitoring-lod14670525/providers/Microsoft.Web/serverfarms/Monitor",
    "availabilityState": "Normal",
    "clientAffinityEnabled": true,
    "clientCertEnabled": false,
    "clientCertExclusionPaths": null,
    "cloningInfo": null,
    "containerSize": 0,
    "dailyMemoryTimeQuota": 0,
    "defaultHostName": "smpapishijian.azurewebsites.net",
    "enabled": true,
    "enabledHostNames": [
      "smpapishijian.azurewebsites.net",
      "smpapishijian.scm.azurewebsites.net"
    ],
    "hostNameSslStates": [
      {
        "hostType": "Standard",
        "ipBasedSslResult": null,
        "ipBasedSslState": "NotConfigured",
        "name": "smpapishijian.azurewebsites.net",
        "sslState": "Disabled",
        "thumbprint": null,
        "toUpdate": null,
        "toUpdateIpBasedSsl": null,
        "virtualIp": null
      },
      {
        "hostType": "Repository",
        "ipBasedSslResult": null,
        "ipBasedSslState": "NotConfigured",
        "name": "smpapishijian.scm.azurewebsites.net",
        "sslState": "Disabled",
        "thumbprint": null,
        "toUpdate": null,
        "toUpdateIpBasedSsl": null,
        "virtualIp": null
      }
    ],
    "hostNames": [
      "smpapishijian.azurewebsites.net"
    ],
    "hostNamesDisabled": false,
    "hostingEnvironmentProfile": null,
    "httpsOnly": false,
    "hyperV": false,
    "id": "/subscriptions/4a38dcc5-0150-4aa9-ad87-0c4dc5f55fcc/resourceGroups/Monitoring-lod14670525/providers/Microsoft.Web/sites/smpapishijian",
    "identity": null,
    "inProgressOperationId": null,
    "isDefaultContainer": null,
    "isXenon": false,
    "kind": "app",
    "lastModifiedTimeUtc": "2020-12-04T02:30:21.893333",
    "location": "East US",
    "maxNumberOfWorkers": null,
    "name": "smpapishijian",
    "outboundIpAddresses": "40.76.157.252,40.76.158.11,40.76.158.107,40.76.158.137,40.76.158.154,40.76.159.206,52.151.203.219,52.151.204.62,52.151.204.196",
    "possibleOutboundIpAddresses": "40.76.157.252,40.76.158.11,40.76.158.107,40.76.158.137,40.76.158.154,40.76.159.206,52.151.203.219,52.151.204.62,52.151.204.196,52.151.200.212,52.151.201.222,52.151.201.244,52.151.202.94,52.151.202.245,52.151.202.253,52.151.203.1,52.151.203.47,52.151.202.80,52.151.203.55,52.151.203.121,52.151.202.98,52.151.202.129,52.151.202.158,52.151.203.127,52.151.203.131,52.151.203.171,52.151.203.195",
    "redundancyMode": "None",
    "repositorySiteName": "smpapishijian",
    "reserved": false,
    "resourceGroup": "Monitoring-lod14670525",
    "scmSiteAlsoStopped": false,
    "siteConfig": {
      "acrUseManagedIdentityCreds": false,
      "acrUserManagedIdentityId": null,
      "alwaysOn": null,
      "apiDefinition": null,
      "apiManagementConfig": null,
      "appCommandLine": null,
      "appSettings": null,
      "autoHealEnabled": null,
      "autoHealRules": null,
      "autoSwapSlotName": null,
      "azureMonitorLogCategories": null,
      "azureStorageAccounts": null,
      "connectionStrings": null,
      "cors": null,
      "customAppPoolIdentityAdminState": null,
      "customAppPoolIdentityTenantState": null,
      "defaultDocuments": null,
      "detailedErrorLoggingEnabled": null,
      "documentRoot": null,
      "experiments": null,
      "fileChangeAuditEnabled": null,
      "ftpsState": null,
      "functionAppScaleLimit": null,
      "functionsRuntimeScaleMonitoringEnabled": null,
      "handlerMappings": null,
      "healthCheckPath": null,
      "http20Enabled": null,
      "httpLoggingEnabled": null,
      "ipSecurityRestrictions": null,
      "javaContainer": null,
      "javaContainerVersion": null,
      "javaVersion": null,
      "limits": null,
      "linuxFxVersion": null,
      "loadBalancing": null,
      "localMySqlEnabled": null,
      "logsDirectorySizeLimit": null,
      "machineKey": null,
      "managedPipelineMode": null,
      "managedServiceIdentityId": null,
      "metadata": null,
      "minTlsVersion": null,
      "minimumElasticInstanceCount": 0,
      "netFrameworkVersion": null,
      "nodeVersion": null,
      "numberOfWorkers": null,
      "phpVersion": null,
      "powerShellVersion": null,
      "preWarmedInstanceCount": null,
      "publishingPassword": null,
      "publishingUsername": null,
      "push": null,
      "pythonVersion": null,
      "remoteDebuggingEnabled": null,
      "remoteDebuggingVersion": null,
      "requestTracingEnabled": null,
      "requestTracingExpirationTime": null,
      "routingRules": null,
      "runtimeADUser": null,
      "runtimeADUserPassword": null,
      "scmIpSecurityRestrictions": null,
      "scmIpSecurityRestrictionsUseMain": null,
      "scmMinTlsVersion": null,
      "scmType": null,
      "tracingOptions": null,
      "use32BitWorkerProcess": null,
      "virtualApplications": null,
      "vnetName": null,
      "vnetPrivatePortsCount": null,
      "vnetRouteAllEnabled": null,
      "webSocketsEnabled": null,
      "websiteTimeZone": null,
      "winAuthAdminState": null,
      "winAuthTenantState": null,
      "windowsFxVersion": null,
      "xManagedServiceIdentityId": null
    },
    "slotSwapStatus": null,
    "state": "Running",
    "suspendedTill": null,
    "tags": null,
    "targetSwapSlot": null,
    "trafficManagerHostNames": null,
    "type": "Microsoft.Web/sites",
    "usageState": "Normal"
  }
]
## Find the apps
az webapp list --resource-group ${AZURE_GROUP_NAME} --query "[?starts_with(name, 'smpapi')]"
## Find the apps and only print the name
az webapp list --resource-group ${AZURE_GROUP_NAME} --query "[?starts_with(name, 'smpapi')].{Name:name}" --output tsv
AZURE_WEBAPP_NAME=$(az webapp list --resource-group ${AZURE_GROUP_NAME} --query "[?starts_with(name, 'smpapi')].{Name:name}" --output tsv)
echo ${AZURE_WEBAPP_NAME}

cd .. # move to Starter folder
## Deploy
az webapp deployment source config-zip --resource-group ${AZURE_GROUP_NAME} --src api.zip --name ${AZURE_WEBAPP_NAME}
{
  "active": true,
  "author": "N/A",
  "author_email": "N/A",
  "complete": true,
  "deployer": "ZipDeploy",
  "end_time": "2020-12-04T03:09:49.9122084Z",
  "id": "1a35e764e5b648c7ae458019cc00452b",
  "is_readonly": true,
  "is_temp": false,
  "last_success_end_time": "2020-12-04T03:09:49.9122084Z",
  "log_url": "https://smpapishijian.scm.azurewebsites.net/api/deployments/latest/log",
  "message": "Created via a push deployment",
  "progress": "",
  "provisioningState": null,
  "received_time": "2020-12-04T03:09:43.8066804Z",
  "site_name": "smpapishijian",
  "start_time": "2020-12-04T03:09:44.4557479Z",
  "status": 4,
  "status_text": "",
  "url": "https://smpapishijian.scm.azurewebsites.net/api/deployments/latest"
}

open https://smpapishijian.azurewebsites.net/weatherforecast
```

```text
Module 11 Review Questions
Question 1
The Application Insights .NET and .NET Core SDKs ship with two built-in channels. Which channel below has the capability to store data on a local disk?
ServerTelemetryChannel
The ServerTelemetryChannel has retry policies and the capability to store data on a local disk.

Question 2
The URL ping test in Application Insights uses ICMP to check a site's availability.
False
This test is not making any use of ICMP (Internet Control Message Protocol) to check your site's availability. Instead it uses more advanced HTTP request functionality to validate whether an endpoint is responding.

Question 3
In the cloud, transient faults aren't uncommon, and an application should be designed to handle them elegantly and transparently. Which of the following are valid strategies for handling transient errors?
Retry after a delay
Cancel
Retry
Retry after a delay, Retry, and Cancel are all valid strategies for handling transient faults.
```
