namespace stroy2.Models
{
    public class Consult
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } // имя пользователя
        public string? LastName { get; set; } // фамилия пользователя
        public string? Email { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public string? Letter { get; set; }
    }
}
