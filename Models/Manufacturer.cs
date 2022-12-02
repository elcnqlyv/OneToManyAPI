namespace OneToManyAPI.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Country { get; set; }
    
        public List<Engine> Engines { get; set; }
    }
}
