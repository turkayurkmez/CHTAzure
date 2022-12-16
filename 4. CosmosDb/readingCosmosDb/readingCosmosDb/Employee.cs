using Newtonsoft.Json;

namespace readingCosmosDb
{
    public class Employee
    {
        [JsonProperty("employeeId")]
        public int EmployeeId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lastname")]
        public string LastName { get; set; }


    }
}
