using System.Text.Json.Serialization;

namespace WebApplication1
{
    public class Number
    {
        public int Id { get; set; }
        public int fines { get; set; }
        [JsonIgnore]
        public Parking Parking { get; set; }
        public int ParkingId { get; set; }
    }
}
