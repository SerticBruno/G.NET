using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Intro.Models
{
    public record User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
