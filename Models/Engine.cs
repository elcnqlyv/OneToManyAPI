namespace OneToManyAPI.Models
{
    public class Engine
    {
        public int Id { get; set; } 
        public string Name { get; set;}
        public double Volume { get; set; }

        public Manufacturer Manufacturer { get; set; }  

    }
}
