using Azure.Identity;
using Azure.Storage.Blobs;

string clientId = "0dabb46f-ec08-4a1f-8a5e-e6a3945bdec8";
string tenantId = "714700c6-10e2-4ca4-b315-06d7fe91ee94";
string clientSecret = "UIE8Q~IGulDBlHJRKja_5VK1VRFt7QCFl302_dkt";

string blobUrl = "https://badepo.blob.core.windows.net/images/turkayurkmez.jpg";

ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
BlobClient blobClient = new BlobClient(new Uri(blobUrl), clientSecretCredential);
await blobClient.DownloadToAsync("me.jpg");
Console.WriteLine("Download completed....");

