using Microsoft.Azure.Cosmos;

namespace readingCosmosDb
{
    public class CosmosDbService
    {
        private Container container;
        public CosmosDbService(CosmosClient client, string databaseName, string containerName)
        {

            container = client.GetContainer(databaseName, containerName);

        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = container.GetItemQueryIterator<Employee>("Select * from c");
            var output = new List<Employee>();
            while (employees.HasMoreResults)
            {
                var employee = await employees.ReadNextAsync();
                output.AddRange(employee.ToList());
            }
            return output;
        }
    }
}
