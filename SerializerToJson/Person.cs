using System.Text.Json.Serialization;

namespace SerializerToJson
{
    public class Person
    {
        public required int Id { get; set; }
        
        public required string NationalCode { get; set; }
        
        public required string FirstName { get; set; }
        
        public required string LastName { get; set; }
        
        public DateOnly? BirthDate { get; set; }

        [JsonConverter(typeof(STJDateTimeHelper))]
        public DateTime RegisterDate { get; set; }
        
        public string? FatherName { get; set; }
        
        public bool InActive { get; set; } = false;
        
        [JsonIgnore]
        public Guid UniqueId { get; set; }
    }
}
