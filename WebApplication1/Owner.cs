namespace WebApplication1
{
    public class Owner
    {   
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
     
        public List<Parking> Parkings { get; set; }
    }
}
