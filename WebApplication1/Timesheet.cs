using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Timesheet
    {
        public int Id { get; set; }
        public string? FIO { get; set; }
        public string? Workshop_name { get; set; }
        public int Speciality_code {  get; set; }
        public string? Speciality { get; set; }
        public int Number_of_days_worked { get; set; }
        public double Zarplata {  get; set; }
        public double Retention { get; set; }
        public double Amount_due {  get; set; }

        public Timesheet(int id, string? fIO, string? workshop_name, int speciality_code, string? speciality, int number_of_days_worked, double zarplata)
        {
            Id = id;
            FIO = fIO;
            Workshop_name = workshop_name;
            Speciality_code = speciality_code;
            Speciality = speciality;
            Number_of_days_worked = number_of_days_worked;
            Zarplata = zarplata;
            Retention = RetentionChet();
            Amount_due = Amount_dueChet();
        }

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
