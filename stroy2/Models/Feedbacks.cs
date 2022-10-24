namespace stroy2.Models
{
    public class Feedbacks
    {
        public Guid Id { get; set; }
        public string? Client { get; set; }
        public string? WorkName { get; set; }
        public string? Period { get; set; }

        public string? Comment { get; set; }

        public string? Contacts { get; set; }
    }
}
