using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Timesheet
    {
        [Key]
        public int Id { get; set; }
        public string? FIO { get; set; }
        
        public string? Name { get; set; }
        [Required]
        public string Speciality { get; set; }
        public int Number_of_days_worked { get; set; }
        [Required]
        public double Zarplata {  get; set; }
        [Required]
        public double Retention { get; set; }
        [Required]
        public double Amount_due {  get; set; }
        public Tariffs? Tariffs { get; set; }
        public double RetentionChet()
        {
            Retention = Zarplata * 0.13;
            return Retention;
        }
        public double Amount_dueChet()
        {
            return Zarplata - Retention;
        }
    }
}
