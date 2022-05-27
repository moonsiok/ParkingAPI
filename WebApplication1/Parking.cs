using System.Text.Json.Serialization;

namespace WebApplication1
{
    public class Parking
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Place { get; set; } = string.Empty;
        [JsonIgnore]
        public Owner Owner {get;set;}
        public int OwnerId { get; set; }
        public Number Number    { get; set; }


    }
}
