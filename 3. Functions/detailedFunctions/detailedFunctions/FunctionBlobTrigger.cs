using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.IO;

namespace detailedFunctions
{
    public class FunctionBlobTrigger
    {
        [FunctionName("FunctionBlobTrigger")]
        public void Run([BlobTrigger("samples-workitems/{name}", Connection = "storageConnectionString")] Stream myBlob,
                        [Queue("messages", Connection = "storageConnectionString")] ICollector<string> outputMessages,
                         string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            /*
             * Input: Function tetiklendikten sonra; alınacak veri
             * Output: Function'un çalışması bittikten sonra; ne yapmak istiyorsunuz?
             */

            outputMessages.Add($"{name} isimli, {myBlob.Length} byte büyüklüğündeki dosya başarıyla yüklendi");
        }
    }
}
