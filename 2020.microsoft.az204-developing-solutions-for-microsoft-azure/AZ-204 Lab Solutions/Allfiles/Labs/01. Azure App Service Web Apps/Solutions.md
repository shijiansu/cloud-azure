- (1) Create a Storage account
  - All service -> Storage Accounts -> New
    - Basics
      - Resource group: `ManagedPlatform-lod17196197`
      - Name: imgstoreshijian
      - Location: (US) East US
      - Performance: Standard
      - Account kind: StorageV2(general purpose v2)
      - Replication: Locally-redundant storage (LRS)
  - Review + Create -> Create
  - Once the resource is deployed -> Go to resource
  - Access keys
    - `Key`: `hidden`
    - `Connection string`: `hidden`
- (2) Upload a sample blob
  - Resource groups -> go to `ManagedPlatform-lod17196197` -> select the storage account created
  - Blob service -> Containers (PS: As Folder) -> + Container
    - `images` (PS: image uploads to this folder, will be listed in later WebApp API)
    - In the Public access level list, select `Blob (anonymous read access for blobs only)`
  - Go to the container created -> Upload -> select local image (tick "Overwrite if files already exist")
- (3) Create a web app (PS: for API application)
  - Create a resource -> New -> Search the Marketplace -> search Web -> Web App -> Create
    - Basics
      - Resource group: `ManagedPlatform-lod17196197`
      - Name: imagapishijian
      - Publish: Code
      - Runtime stack: .net Core 3.1 (LTS)
      - Operation System: Windows
      - Region: East US
      - Windows Plan: Create new -> Name: ManagedPlan
    - Monitoring
      - Enable Application Insights -> No
  - Review + Create -> Create
- (4) Configure the web app
  - Resource groups -> go to `ManagedPlatform-lod17196197` -> select the web app created
  - Web App
    - Settings -> Configuration -> Application settings -> New application setting
      - Name: StorageConnectionString
      - Value: above `Connection string`
      - -> Save
    - Settings -> Properties -> Copy URL: `imgapishijian.azurewebsites.net` (PS: return `Hey, App Service developers!`)
- (5) Deploy an ASP.NET web application to Web Apps
  - Copy to Solution
  - API/Controlers/ImagesController.cs

```bash
az login # login via browser
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
      "name": "LabUser-17195234@cloudslice.onmicrosoft.com",
      "type": "user"
    }
  }
]
# list all the apps resource group
az webapp list --resource-group ManagedPlatform-lod17196197
[
  {
    "appServicePlanId": "/subscriptions/813202b7-9c14-42b6-8614-7206e3317c62/resourceGroups/ManagedPlatform-lod17196197/providers/Microsoft.Web/serverfarms/ManagedPlan",
    "availabilityState": "Normal",
    "clientAffinityEnabled": true,
    "clientCertEnabled": false,
    "clientCertExclusionPaths": null,
    "cloningInfo": null,
    "containerSize": 0,
    "dailyMemoryTimeQuota": 0,
    "defaultHostName": "imgapishijian.azurewebsites.net",
    "enabled": true,
    "enabledHostNames": [
      "imgapishijian.azurewebsites.net",
      "imgapishijian.scm.azurewebsites.net"
    ],
    "hostNameSslStates": [
      {
        "hostType": "Standard",
        "ipBasedSslResult": null,
        "ipBasedSslState": "NotConfigured",
        "name": "imgapishijian.azurewebsites.net",
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
        "name": "imgapishijian.scm.azurewebsites.net",
        "sslState": "Disabled",
        "thumbprint": null,
        "toUpdate": null,
        "toUpdateIpBasedSsl": null,
        "virtualIp": null
      }
    ],
    "hostNames": [
      "imgapishijian.azurewebsites.net"
    ],
    "hostNamesDisabled": false,
    "hostingEnvironmentProfile": null,
    "httpsOnly": false,
    "hyperV": false,
    "id": "/subscriptions/813202b7-9c14-42b6-8614-7206e3317c62/resourceGroups/ManagedPlatform-lod17196197/providers/Microsoft.Web/sites/imgapishijian",
    "identity": null,
    "inProgressOperationId": null,
    "isDefaultContainer": null,
    "isXenon": false,
    "kind": "app",
    "lastModifiedTimeUtc": "2021-05-22T15:34:04.366666",
    "location": "East US",
    "maxNumberOfWorkers": null,
    "name": "imgapishijian",
    "outboundIpAddresses": "52.188.42.23,52.142.18.177,52.142.18.40,52.149.202.179,52.154.66.123,52.154.69.195,20.49.104.31",
    "possibleOutboundIpAddresses": "52.150.53.221,52.154.64.236,52.154.65.178,52.147.212.86,52.154.66.92,52.188.41.146,52.188.42.23,52.142.18.177,52.142.18.40,52.149.202.179,52.154.66.123,52.154.69.195,52.154.70.71,52.154.70.135,52.186.99.104,52.186.101.205,52.142.16.201,52.186.102.198,52.147.209.102,52.149.204.214,52.186.102.230,52.147.209.166,52.147.210.37,52.147.215.140,52.149.206.164,52.190.40.233,52.188.42.100,52.190.43.22,52.224.24.232,52.224.26.145,20.49.104.31",
    "redundancyMode": "None",
    "repositorySiteName": "imgapishijian",
    "reserved": false,
    "resourceGroup": "ManagedPlatform-lod17196197",
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
      "keyVaultReferenceIdentity": null,
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
      "publicNetworkAccess": null,
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
# find the apps that have the imgapi* prefix
az webapp list --resource-group ManagedPlatform-lod17196197 --query "[?starts_with(name, 'imgapi')]"
[
  {
    "appServicePlanId": "/subscriptions/813202b7-9c14-42b6-8614-7206e3317c62/resourceGroups/ManagedPlatform-lod17196197/providers/Microsoft.Web/serverfarms/ManagedPlan",
    "availabilityState": "Normal",
    "clientAffinityEnabled": true,
    "clientCertEnabled": false,
    "clientCertExclusionPaths": null,
    "cloningInfo": null,
    "containerSize": 0,
    "dailyMemoryTimeQuota": 0,
    "defaultHostName": "imgapishijian.azurewebsites.net",
    "enabled": true,
    "enabledHostNames": [
      "imgapishijian.azurewebsites.net",
      "imgapishijian.scm.azurewebsites.net"
    ],
    "hostNameSslStates": [
      {
        "hostType": "Standard",
        "ipBasedSslResult": null,
        "ipBasedSslState": "NotConfigured",
        "name": "imgapishijian.azurewebsites.net",
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
        "name": "imgapishijian.scm.azurewebsites.net",
        "sslState": "Disabled",
        "thumbprint": null,
        "toUpdate": null,
        "toUpdateIpBasedSsl": null,
        "virtualIp": null
      }
    ],
    "hostNames": [
      "imgapishijian.azurewebsites.net"
    ],
    "hostNamesDisabled": false,
    "hostingEnvironmentProfile": null,
    "httpsOnly": false,
    "hyperV": false,
    "id": "/subscriptions/813202b7-9c14-42b6-8614-7206e3317c62/resourceGroups/ManagedPlatform-lod17196197/providers/Microsoft.Web/sites/imgapishijian",
    "identity": null,
    "inProgressOperationId": null,
    "isDefaultContainer": null,
    "isXenon": false,
    "kind": "app",
    "lastModifiedTimeUtc": "2021-05-22T15:34:04.366666",
    "location": "East US",
    "maxNumberOfWorkers": null,
    "name": "imgapishijian",
    "outboundIpAddresses": "52.188.42.23,52.142.18.177,52.142.18.40,52.149.202.179,52.154.66.123,52.154.69.195,20.49.104.31",
    "possibleOutboundIpAddresses": "52.150.53.221,52.154.64.236,52.154.65.178,52.147.212.86,52.154.66.92,52.188.41.146,52.188.42.23,52.142.18.177,52.142.18.40,52.149.202.179,52.154.66.123,52.154.69.195,52.154.70.71,52.154.70.135,52.186.99.104,52.186.101.205,52.142.16.201,52.186.102.198,52.147.209.102,52.149.204.214,52.186.102.230,52.147.209.166,52.147.210.37,52.147.215.140,52.149.206.164,52.190.40.233,52.188.42.100,52.190.43.22,52.224.24.232,52.224.26.145,20.49.104.31",
    "redundancyMode": "None",
    "repositorySiteName": "imgapishijian",
    "reserved": false,
    "resourceGroup": "ManagedPlatform-lod17196197",
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
      "keyVaultReferenceIdentity": null,
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
      "publicNetworkAccess": null,
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
az webapp list --resource-group ManagedPlatform-lod17196197 --query "[?starts_with(name, 'imgapi')]"
[
  {
    "appServicePlanId": "/subscriptions/813202b7-9c14-42b6-8614-7206e3317c62/resourceGroups/ManagedPlatform-lod17196197/providers/Microsoft.Web/serverfarms/ManagedPlan",
    "availabilityState": "Normal",
    "clientAffinityEnabled": true,
    "clientCertEnabled": false,
    "clientCertExclusionPaths": null,
    "cloningInfo": null,
    "containerSize": 0,
    "dailyMemoryTimeQuota": 0,
    "defaultHostName": "imgapishijian.azurewebsites.net",
    "enabled": true,
    "enabledHostNames": [
      "imgapishijian.azurewebsites.net",
      "imgapishijian.scm.azurewebsites.net"
    ],
    "hostNameSslStates": [
      {
        "hostType": "Standard",
        "ipBasedSslResult": null,
        "ipBasedSslState": "NotConfigured",
        "name": "imgapishijian.azurewebsites.net",
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
        "name": "imgapishijian.scm.azurewebsites.net",
        "sslState": "Disabled",
        "thumbprint": null,
        "toUpdate": null,
        "toUpdateIpBasedSsl": null,
        "virtualIp": null
      }s
    ],
    "hostNames": [
      "imgapishijian.azurewebsites.net"
    ],
    "hostNamesDisabled": false,
    "hostingEnvironmentProfile": null,
    "httpsOnly": false,
    "hyperV": false,
    "id": "/subscriptions/813202b7-9c14-42b6-8614-7206e3317c62/resourceGroups/ManagedPlatform-lod17196197/providers/Microsoft.Web/sites/imgapishijian",
    "identity": null,
    "inProgressOperationId": null,
    "isDefaultContainer": null,
    "isXenon": false,
    "kind": "app",
    "lastModifiedTimeUtc": "2021-05-22T15:34:04.366666",
    "location": "East US",
    "maxNumberOfWorkers": null,
    "name": "imgapishijian",
    "outboundIpAddresses": "52.188.42.23,52.142.18.177,52.142.18.40,52.149.202.179,52.154.66.123,52.154.69.195,20.49.104.31",
    "possibleOutboundIpAddresses": "52.150.53.221,52.154.64.236,52.154.65.178,52.147.212.86,52.154.66.92,52.188.41.146,52.188.42.23,52.142.18.177,52.142.18.40,52.149.202.179,52.154.66.123,52.154.69.195,52.154.70.71,52.154.70.135,52.186.99.104,52.186.101.205,52.142.16.201,52.186.102.198,52.147.209.102,52.149.204.214,52.186.102.230,52.147.209.166,52.147.210.37,52.147.215.140,52.149.206.164,52.190.40.233,52.188.42.100,52.190.43.22,52.224.24.232,52.224.26.145,20.49.104.31",
    "redundancyMode": "None",
    "repositorySiteName": "imgapishijian",
    "reserved": false,
    "resourceGroup": "ManagedPlatform-lod17196197",
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
      "keyVaultReferenceIdentity": null,
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
      "publicNetworkAccess": null,
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
# render only the name
az webapp list --resource-group ManagedPlatform-lod17196197 --query "[?starts_with(name, 'imgapi')].{Name:name}" --output tsv

# cd to \Solutions\API\

# deploy the api.zip file to the web app
# the name is as previous step
az webapp deployment source config-zip --resource-group ManagedPlatform-lod17196197 --src api.zip --name imgapishijian
{
  "active": true,
  "author": "N/A",
  "author_email": "N/A",
  "complete": true,
  "deployer": "ZipDeploy",
  "end_time": "2021-05-22T15:49:54.1019415Z",
  "id": "046bd8f5791f48488940dd08c2975a3e",
  "is_readonly": true,
  "is_temp": false,
  "last_success_end_time": "2021-05-22T15:49:54.1019415Z",
  "log_url": "https://imgapishijian.scm.azurewebsites.net/api/deployments/latest/log",
  "message": "Created via a push deployment",
  "progress": "",
  "provisioningState": "Succeeded",
  "received_time": "2021-05-22T15:49:50.0246091Z",
  "site_name": "imgapishijian",
  "start_time": "2021-05-22T15:49:50.1808518Z",
  "status": 4,
  "status_text": "",
  "url": "https://imgapishijian.scm.azurewebsites.net/api/deployments/latest"
}
open https://imgapishijian.azurewebsites.net
["https://imgstoreshijian.blob.core.windows.net/images/burger.jpg"]
```

- (6) Build a front-end web application by using Azure Web Apps
  - Create a resource -> New -> Search the Marketplace -> search Web -> Web App -> Create
    - Basics
      - Resource group: `ManagedPlatform-lod17196197`
      - Name: imagwebshijian
      - Publish: Code
      - Runtime stack: .net Core 3.1 (LTS)
      - Operation System: Windows
      - Region: East US
      - Windows Plan: Create new -> Name: ManagedPlan
    - Monitoring
      - Enable Application Insights -> No
  - Review + Create -> Create
  - Go to the resource
  - Configuration -> Application settings -> New application setting
    - Add/Edit application setting
      - Name: ApiUrl
      - Value: https://imgapishijian.azurewebsites.net
      - -> Save
- (7) Deploy an ASP.NET web application to Web Apps
  - Copy to Solution
  - Web/Pages/Index.cshtml.cs

```bash
az login
az webapp list --resource-group ManagedPlatform-lod17196197
az webapp list --resource-group ManagedPlatform-lod17196197 --query "[?starts_with(name, 'imagweb')]"
az webapp list --resource-group ManagedPlatform-lod17196197 --query "[?starts_with(name, 'imagweb')].{Name:name}" --output tsv

# cd to \Solutions\Web\

az webapp deployment source config-zip --resource-group ManagedPlatform-lod17196197 --src web.zip --name imagwebshijian
{
  "active": true,
  "author": "N/A",
  "author_email": "N/A",
  "complete": true,
  "deployer": "ZipDeploy",
  "end_time": "2021-05-22T17:20:42.6588287Z",
  "id": "646ada18dfd2493cb6af961b48aca752",
  "is_readonly": true,
  "is_temp": false,
  "last_success_end_time": "2021-05-22T17:20:42.6588287Z",
  "log_url": "https://imagwebshijian.scm.azurewebsites.net/api/deployments/latest/log",
  "message": "Created via a push deployment",
  "progress": "",
  "provisioningState": "Succeeded",
  "received_time": "2021-05-22T17:20:40.1781965Z",
  "site_name": "imagwebshijian",
  "start_time": "2021-05-22T17:20:40.3656607Z",
  "status": 4,
  "status_text": "",
  "url": "https://imagwebshijian.scm.azurewebsites.net/api/deployments/latest"
}
# go to the resource -> Overview -> Browse
open https://imagwebshijian.azurewebsites.net/ # now you can use the UI to upload the image

curl https://imgapishijian.azurewebsites.net/ | jq
[
  "https://imgstoreshijian.blob.core.windows.net/images/burger.jpg",
  "https://imgstoreshijian.blob.core.windows.net/images/ed902a2071f642b4b82df98c99bf7420"
]
```

- 7. Review at the Storage Account
  - Go to imgstoreshijian -> Container -> images -> You can see 2 images there now
- 8. Clean up your subscription

```bash
# Delete resource groups
az group delete --name ManagedPlatform-lod17196197 --no-wait --yes
```

```text
Question 1
You have multiple apps running in a single App Service plan.
True or False: Each app in the service plan can have different scaling rules.
False
The App Service plan is the scale unit of the App Service apps.
If the plan is configured to run five VM instances,
then all apps in the plan run on all five instances.
If the plan is configured for autoscaling,
then all apps in the plan are scaled out together based on the autoscale settings.

Question 2
Which of the following App Service plans is available only to function apps?
Consumption
The consumption tier is only available to function apps.
It scales the functions dynamically depending on workload.

Question 3
Which of the following App Service tiers is not currently available to App Service on Linux?
Shared
App Service on Linux is only supported with Free, Basic, Standard,
and Premium app service plans and does not have a Shared tier.
You cannot create a Linux Web App in an App Service plan already hosting non-Linux Web Apps.

Question 4
Which of the following settings are not not swapped when you swap an an app?
Select three (PS: No idea...)
Handler mappings
Publishing endpoints
General settings, such as framework version, 32/64-bit, web sockets
Always On
Custom domain names
```
