using System.Runtime.Serialization;

namespace SerializerToJson
{
    [DataContract]
    public class Employee
    {
        public required string FirstName { get; set; }

        [DataMember] // To show property when converting to Json with Newtonsoft.Json
        public string? LastName { get; set; }
        public Department? Department { get; set; }
    }
    public class Department
    {
        public string? Name { get; set; }
        public IList<Employee> Staff { get; set; } = new List<Employee>();
    }
}
