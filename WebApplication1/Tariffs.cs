using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Tariffs
    {
        [Key]
        public int Speciality_code { get; set; }
        [Required]
        public string? Speciality_name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
