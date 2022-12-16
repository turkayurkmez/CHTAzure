using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace detailedFunctions
{
    public class FunctionCron
    {
        [FunctionName("FunctionCron")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        }
    }
}
