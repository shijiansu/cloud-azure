# Lab

## Lab 1 - Web Apps - Building a Web Application on Azure Platform as a Service Offering

For "Module 1 Creating Azure App Service Web Apps"

- Create "Storage account" -> Deployment is in progress -> Click the storage resource
  - Access keys -> Connection string
  - Blob service -> Container (类似目录) -> Upload -> Select the file from "Lab resources" (其实这一步只是准备一个在线图片) 
- Create "Web App" -> Deployment is in progress -> Click the Web App
  - Settings
    - Configuration -> StorageConnectionString (类似一个环境变量, 去连接到上面的Blob)
    - Properties -> Server endpoint URL is there
- Local Terminal (cmd) -> Azure login (可以直接关联到本地的Windows账户)
  - Azure login

## Lab 2 - Functions Apps - Implement Task Processing Logic by using Azure Functions

For "Module 2 - Implement Azure functions"

- Create "Storage account"
- Create "Function App"

## Lab 9 - Logic Apps - Automate business processes with Logic Apps

For "Module 9 - Develop Logic App"

- Create "Storage account"
  - File service -> File shares -> create File share -> Upload
- Create "Logic App"
  - Construct steps
- Create "API management"
  - Associate Logic App to this API management (这个API management其实就是个API gateway了, 为这个Logic App提供一个外部接口和测试接口)

## Lab 3 - Storage - Retrieving Azure Storage resources and metadata by using the Azure Storage SDK for .NET

小总结, 由于Lab的VM的Terminal并没有安装dotnet的东西, 所以我在Azure Cloud Shell里面操作.
执行`dotnet run`的时候, 有提示错误, `The feature 'async steam' is currently in Preview and unsupported `

发现Azure Cloud Shell的dotnet SDK版本比较旧,
`dotnet --list-sdks` -> 2.2.402, 这个功能貌似3.0以上才正式支持.

编辑`BlobManager.csproj`加入
- https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version

```xml
<PropertyGroup>
   <LangVersion>preview</LangVersion>
</PropertyGroup>
```

再次执行`dotnet run`便可

这个Lab VM的安装有点问题. 现在可以通过Windows的Terminal执行`dotnet`命令了

## Lab 4 - Cosmos - Constructing a Polyglot Data Solution

- Create "SQL database"
- Create "Storage account" - upload the images and SQL backup files
- Create "Cosmos"
