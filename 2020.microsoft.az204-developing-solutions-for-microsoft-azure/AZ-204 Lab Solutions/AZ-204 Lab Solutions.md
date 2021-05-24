# Course

- 20201103 to 20201204

# Lecture note

Please refer to `course+certification\Cloud Computing\Azure\2020.Microsoft.AZ-204 Developing Solutions for Microsoft Azure`.

# AZ-204 Lab

- Lab - https://github.com/MicrosoftLearning/AZ-204-DevelopingSolutionsforMicrosoftAzure
- Examples of Azure with code - https://github.com/Azure-Samples

# How to set up local development environment for the Lab

- Azure console: https://portal.azure.com
```bash
# https://docs.microsoft.com/en-us/dotnet/core/install/macos
# .NET Core Version - 5.0 requires High Sierra (10.13+)
brew update
brew install mono-libgdiplus
# .Net SDK
# do not use this, the lab is with 3.1
## brew install dotnet-sdk
## dotnet --info # 5.0.1
# https://github.com/isen-ng/homebrew-dotnet-sdk-versions
brew tap isen-ng/dotnet-sdk-versions
brew install --cask dotnet-sdk3-1-400
## brew uninstall --zap --cask dotnet-sdk3-1-400
dotnet --list-sdks

# Azure CLI
brew install azure-cli

# Azure Functions Core Tools - https://github.com/Azure/azure-functions-core-tools
brew tap azure/functions
brew install azure-functions-core-tools@3 # work at .NET 3.1
brew upgrade azure-functions-core-tools@3

# HTTP tool for Lab testing
dotnet tool install -g Microsoft.dotnet-httprepl --version 3.1.0
cat << \EOF >> ~/.zprofile
# Add .NET Core SDK tools
export PATH="$PATH:/Users/shijiansu/.dotnet/tools"
EOF
zsh -l # make it available for current session. 
```

PS: Create Storage Account first in Azure to store Applications
