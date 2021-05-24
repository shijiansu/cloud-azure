- (1) Create a Storage account
  - All service -> Storage Accounts -> New
    - Basics
      - Resource group -> Create new -> `StorageMedia`
      - Name: mediastorshijian <- storage account name
      - Location: (US) East US
      - Performance: Standard
      - Account kind: StorageV2(general purpose v2)
      - Replication: Read-access geo-redundant storage (RA-GRS)
  - Review + Create -> Create
  - Once the resource is deployed -> Go to resource
  - Endpoint -> Blob service
    - `Resource ID`: `hidden`
    - `Blob service`: `hidden` <- blob service endpoint
  - Access keys
    - `Key`: `hidden` <- storage account key
    - `Connection string`: `hidden`
- (2) Upload a blob into a container
  - mediastorshijian -> Container -> + Container
    - Name: raster-graphics
    - Public access level: Private (no anonymous access)
  - mediastorshijian -> Container -> + Container
    - Name: compressed-audio
    - Public access level: Private (no anonymous access)
  - Upload graph.jpg to raster-graphics
- (3) Access containers by using the .NET SDK

```bash
dotnet new console --name BlobManager --output .
dotnet add package Azure.Storage.Blobs --version 12.0.0
dotnet build

# write Program.cs
    private const string blobServiceEndpoint = "<primary-blob-service-endpoint>";
    private const string storageAccountName = "<storage-account-name>";
    private const string storageAccountKey = "<key>";
# to
    private const string blobServiceEndpoint = "https://mediastorshijian.blob.core.windows.net/";
    private const string storageAccountName = "mediastorshijian";
    private const string storageAccountKey = "NcCZuBfI4MOd9tWeuifr/7iSsD8lxHBtZhhTs1N9ADWxTcfeUCXGEwSLj7cOUFZATizbsMDmESxHL9XDq2IDqg==";

dotnet run
Connected to Azure Storage Account
Account name:	mediastorshijian
Account kind:	StorageV2
Account sku:	StandardGrs
Container:	compressed-audio
Container:	raster-graphics
Searching:	raster-graphics
Existing Blob:	graph.jpg
New Container:	vector-graphics
Blob Found:	graph.svg
Blob Url:	https://mediastorshijian.blob.core.windows.net/vector-graphics/graph.svg
```

- (4) Upload a blob into a container
  - vector-graphics -> Change access level -> Blob (anonymous read access for blobs only)
  - Upload graph.svg to vector-graphics (created by the code)

```bash
dotnet run
open https://mediastorshijian.blob.core.windows.net/vector-graphics/graph.svg
```

- (5) Delete a resource group

```bash
az group delete --name StorageMedia --no-wait --yes
```

```text
Module 3 Review Questions
Question 1
Which of the following types of blobs are designed to store text and binary data?
Block blob
Block blobs store text and binary data, up to about 4.7 TB. Block blobs are made up of blocks of data that can be managed individually.

Question 2
There are three access tiers for block blob data: hot, cold, and archive. New storage accounts are created in which tier by default?
Hot
The Hot access tier, which is optimized for frequent access of objects in the storage account. New storage accounts are created in the hot tier by default.

Question 3
All data written to Azure Storage is automatically encrypted using SSL.
False
All data (including metadata) written to Azure Storage is automatically encrypted using Storage Service Encryption (SSE).

Question 4
Which of the following redundancy options will protect your data in the event of a region-wide outage?
Select two
Read-access geo-redundant storage (RA-GRS)
Geo-redundant storage (GRS)
GRS and RA-GRS will protect your data in case of a region-wide outage. LRS provides protection at the node level within a data center. ZRS provides protection at the data center level (zonal or non-zonal).
```
