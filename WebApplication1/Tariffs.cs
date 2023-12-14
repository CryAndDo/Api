using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Tariffs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        public List<Timesheet> Timesheet { get; set; } = new();
    }
}
