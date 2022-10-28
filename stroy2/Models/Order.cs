namespace stroy2.Models
{
    public class Order
    {
        public Guid Id { get; set; }
       
        public string? Work { get; set; }
        public string? Locality { get; set; }

        public string? Volume { get; set; }

        public string? Material { get; set; }

    }
}
