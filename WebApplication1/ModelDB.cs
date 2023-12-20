using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1
{
    public class ModelDB : DbContext
    {
        public ModelDB(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Tariffs> Tariffs { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<User>? Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Tariffs one = new Tariffs { Speciality_code = 2, Speciality_name = "Operator", Price = 17 };
            Tariffs two = new Tariffs { Speciality_code = 3, Speciality_name = "Konsyltant", Price = 20 };
            Tariffs three = new Tariffs { Speciality_code = 4, Speciality_name = "Programmist", Price = 40 };
            Tariffs four = new Tariffs { Speciality_code = 5, Speciality_name = "Guitarist", Price = 12 };
            Tariffs five = new Tariffs { Speciality_code = 6, Speciality_name = "Vocalist", Price = 15 };
            Tariffs six = new Tariffs { Speciality_code = 7, Speciality_name = "Musicant", Price = 7 };

            modelBuilder.Entity<Tariffs>().HasData(one, two, three, four, five, six);

            modelBuilder.Entity<Timesheet>().HasData(
                new Timesheet ( 1, "Ivanov Ivan Ivanovich","Hugga",1, "Svarchik", 4, 40)
                //new Timesheet (2, "Kuzmik Ruslan Ahmetovich",two,  "Hugga1",     "Operator", 3,  51),
                //new Timesheet(3, "Popik Ostap Erjanovich",three, "Hugga2",  "Operator",  2,  34),
                //new Timesheet(4,  "Qwerty Grigoriy Pulsatorovich",four, "Hugga3",  "Konsyltant", 1, 20),
                //new Timesheet(5,  "Alkan Bender Buhmetovich",five, "Hugga4",  "Konsyltant",  5,  100 ),
                //new Timesheet(6,  "Tookich Nikolay Rehmatovich",six, "Hugga5",  "Programmist",2,  200  ),
                //new Timesheet(7,   "Cinovitov Gender Mishovich",one, "Hugga6", "Programmist",  120, 34),
                //new Timesheet(8,   "Shlypa Ivanov Ivanovich", two, "Hugga7", "Guitarist", 24, 34 ),
                //new Timesheet (9,   "Kymachev Igor Sergeevich",three,"Hugga8",  "Guitarist",  84,12),
                //new Timesheet (10,  "Shyrpatov Ivan Alexeevich",three, "Hugga9",   "Vocalist", 30, 2 ),
                //new Timesheet (11,  "Abdylganiev Stepan Ruslanovich",one,"Hugga10",  "Vocalist", 45, 3 ),
                //new Timesheet (12, "Geshtald Voktor Zaochkovuich",one, "Hugg11", "Musicant", 14, 32),
                //new Timesheet (13, "Alkash Sergey Sergeech",one,  "Hugg12", "Musicant", 7, 123 ),
                //new Timesheet (14, "Ivanov Ivan Ivanovich",one,  "Hugg13", "Musicant", 63, 32 ),
                //new Timesheet(15,"Putan Oleg Reno",three,  "Hugg14", "Musicant", 21,12 )
                );

            
           modelBuilder.Entity<User>().HasData(
                new User { Id = 1, EMail = "Z@gmail.com", Password = "123" });
        }
    }
}
