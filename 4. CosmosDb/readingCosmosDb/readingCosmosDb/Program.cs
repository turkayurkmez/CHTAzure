
using Microsoft.Azure.Cosmos;
using readingCosmosDb;

var dbName = "HumanResourcesDb";
var containerName = "Employees";
var account = "https://bademo.documents.azure.com:443/";
var key = "Oion6neatYqHuWrbhLIXDjTBoej5xiC4hFZ6f39uaouwEGZoFvWYCZR0WazVoNFVeF8Oaw2JJOBPACDbMN3c8Q==";

var client = new CosmosClient(account, key);
var cosmosDbService = new CosmosDbService(client, dbName, containerName);
//var db = await client.CreateDatabaseAsync("xxx");
//db.Database.CreateContainerIfNotExistsAsync("yyy", "/Id");

var list = await cosmosDbService.GetEmployeesAsync();
list.ToList().ForEach(l => Console.WriteLine($"{l.Name} {l.LastName}\n"));


