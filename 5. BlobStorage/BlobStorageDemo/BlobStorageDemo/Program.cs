
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

var connectionString = "DefaultEndpointsProtocol=https;AccountName=badepo;AccountKey=m22GQdtNbyzQSzVq0pf8sCi9ySpk9REy6oJ3zEaJCoZ1Bm84PjpqKOhAOIRCscpMeSFmhqKX0xW7+AStqhDQlg==;EndpointSuffix=core.windows.net";

var blobContainerName = "information";
var blobName = "info.txt";

try
{
    await createContainerAndUploadBlobAsync();
    await listContainersWithBlobsAsync();
    await downloadBlobAsync();
}
catch (Exception)
{

    throw;
}

async Task downloadBlobAsync()
{
    string localFileName = "..\\..\\..\\downloaded.txt";
    BlobClient blobClient = new BlobClient(connectionString, blobContainerName, blobName);
    if (await blobClient.ExistsAsync())
    {
        var response = await blobClient.DownloadToAsync(localFileName);
        Console.WriteLine(response.Status);
    }


}

async Task listContainersWithBlobsAsync()
{
    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
    Console.WriteLine($"3. {blobServiceClient.AccountName} hesabındaki container ve blob'lar alınıyor");
    await foreach (var container in blobServiceClient.GetBlobContainersAsync())
    {
        Console.WriteLine($"---> {container.Name}");
        BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(container.Name);

        await foreach (var blobItem in blobContainerClient.GetBlobsAsync())
        {
            Console.WriteLine($"----->{blobItem.Name}");
        }
    }
}

async Task createContainerAndUploadBlobAsync()
{
    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
    BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);

    Console.WriteLine($"1. Blob container oluşturuluyor: {blobContainerName}");

    await blobContainerClient.CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);

    BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
    Console.WriteLine($"2. Blob yükleniyor: {blobClient.Name}");
    Console.WriteLine($".....> {blobClient.Uri} ");
    using FileStream fileStream = File.OpenRead(@"..\..\..\Info.txt");

    await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = "text/plain" });

}