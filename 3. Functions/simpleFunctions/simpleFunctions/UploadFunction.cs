using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.IO;

namespace simpleFunctions
{
    public class UploadFunction
    {
        [FunctionName("UploadFunction")]
        public void Run([BlobTrigger("samples-workitems/{name}", Connection = "blobPath")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
