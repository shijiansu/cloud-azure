# AZ-204 Lab work

## Course

- 20201103 to 20201204

## Lecture note

Because there is privilege issue, so would not be bundled into this project.

For the local version, please refer to `book\Azure\Microsoft Certified Azure Developer Associate\Microsoft.AZ-204 Developing Solutions for Microsoft Azure`.

## Source code

- <https://github.com/MicrosoftLearning/AZ-204-DevelopingSolutionsforMicrosoftAzure>
- <https://github.com/Azure-Samples> (there are lots of examples of Azure with code)

## How to set up local development environment

```bash
# https://portal.azure.com # Azure console

# Pre-condition
## https://docs.microsoft.com/en-us/dotnet/core/install/macos
## .NET Core Version - 5.0 requires High Sierra (10.13+)
brew update
brew install mono-libgdiplus
## .NET
## https://formulae.brew.sh/cask/dotnet
brew install --cask dotnet
## Azure CLI
brew install azure-cli
## Azure Functions Core Tools
## https://github.com/Azure/azure-functions-core-tools
brew tap azure/functions
brew install azure-functions-core-tools@3
```

## Cloud Shell的.NET版本问题

执行`dotnet run`的时候, 有提示错误, `The feature 'async steam' is currently in Preview and unsupported `. 发现Azure Cloud Shell的dotnet SDK版本比较旧, `dotnet --list-sdks` -> 2.2.402, 有些功能3.0以上才正式支持.

- https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version

编辑 `xxx.csproj` 加入 `<LangVersion>preview</LangVersion>`

```xml
<PropertyGroup>
   <LangVersion>preview</LangVersion>
</PropertyGroup>
```
