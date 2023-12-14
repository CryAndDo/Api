using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class ModelDB : DbContext
    {
        public ModelDB(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tariffs> Tariffs { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<User>? Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timesheet>().HasData(
                new Timesheet { Name="Hugga",  FIO= "Ivanov Ivan Ivanovich", Speciality="Svarchik", Number_of_days_worked=4, Zarplata=40, Retention=0.13, Amount_due=0, Id=1, },
                new Timesheet { Name= "Hugga1",  FIO= "Kuzmik Ruslan Ahmetovich", Speciality= "Operator", Number_of_days_worked=3, Zarplata = 51, Retention = 0.13, Amount_due = 0, Id =2},
                new Timesheet { Name = "Hugga2", FIO = "Popik Ostap Erjanovich", Speciality = "Operator", Number_of_days_worked = 2, Zarplata = 34, Retention = 0.13, Amount_due = 0, Id = 3 },
                new Timesheet { Name = "Hugga3", FIO = "Qwerty Grigoriy Pulsatorovich", Speciality = "Konsyltant", Number_of_days_worked = 1, Zarplata = 20, Retention = 0.13, Amount_due = 0, Id = 4 },
                new Timesheet { Name = "Hugga4", FIO = "Alkan Bender Buhmetovich", Speciality = "Konsyltant", Number_of_days_worked = 5, Zarplata = 100, Retention = 0.13, Amount_due = 0, Id = 5 },
                new Timesheet { Name = "Hugga5", FIO = "Tookich Nikolay Rehmatovich", Speciality = "Programmist", Zarplata = 200, Retention = 0.13, Amount_due = 0, Id = 6 },
                new Timesheet { Name = "Hugga6", FIO = "Cinovitov Gender Mishovich", Speciality = "Programmist", Zarplata = 120, Retention = 0.13, Amount_due = 0, Id = 7 },
                new Timesheet { Name = "Hugga7", FIO = "Shlypa Ivanov Ivanovich", Speciality = "Guitarist", Zarplata = 24, Retention = 0.13, Amount_due = 0, Id = 8 },
                new Timesheet { Name = "Hugga8",  Speciality = "Guitarist", Zarplata = 84, Retention = 0.13, Amount_due = 0, Id = 9 },
                new Timesheet { Name = "Hugga9",  Speciality = "Vocalist", Zarplata = 30, Retention = 0.13, Amount_due = 0, Id = 10 },
                new Timesheet {  Speciality = "Vocalist", Zarplata = 45, Retention = 0.13, Amount_due = 0, Id = 11 },
                new Timesheet {  Speciality = "Musicant", Zarplata = 14, Retention = 0.13, Amount_due = 0, Id = 12 },
                new Timesheet {  Speciality = "Musicant", Zarplata = 7, Retention = 0.13, Amount_due = 0, Id = 13 },
                new Timesheet {   Speciality = "Musicant", Zarplata = 63, Retention = 0.13, Amount_due = 0, Id = 14 },
                new Timesheet {  Speciality = "Musicant", Zarplata = 21, Retention = 0.13, Amount_due = 0, Id = 15 }
                );
            modelBuilder.Entity<Tariffs>().HasData(
                new Tariffs { Id = 1, Name = "Svarchik", Price = 10,  },
                new Tariffs { Id = 2, Name = "Operator", Price = 17 },
                 new Tariffs { Id = 3, Name = "Konsyltant", Price = 20 },
                 new Tariffs { Id = 4, Name = "Programmist", Price = 40 },
                 new Tariffs { Id = 5, Name = "Guitarist", Price = 12 },
                 new Tariffs { Id = 7, Name = "Vocalist", Price = 15 },
                new Tariffs { Id = 8, Name = "Musicant", Price = 7 }
                );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, EMail = "Z@gmail.com", Password = "123" });
        }
    }
}
