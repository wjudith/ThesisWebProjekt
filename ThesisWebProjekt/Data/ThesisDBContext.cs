using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThesisWebProjekt.Models;

namespace ThesisWebProjekt.Data
{
    public class ThesisDBContext : IdentityDbContext<AppUser>
    {      
        public ThesisDBContext (DbContextOptions<ThesisDBContext> options)
            : base(options)
        {
        }
       




        //Database Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var x = modelBuilder.Entity<Thesis>().HasData(
                     new Models.Thesis() { Id = 1, Title = "Bachelorthema 1", Description = "...", Bachelor = true, Master = false, Type = ThesisType.Bachelor, Status = Status.Free, StudentName = "Judith", Grade = 1, StudentEmail = "judith@studmail.de", StudentId = "2845776", LehrstuhlId = 10, StudiengangId = 1, Registration = new DateTime(2020, 09, 22), Filing = new DateTime(2021, 01, 20) },
                     new Models.Thesis() { Id = 2, Title = "Bachelorthema 2", Description = "...", Bachelor = true, Master = false, Type = ThesisType.Bachelor, Status = Status.Filed, StudentName = "Jürgen", Grade = 4, StudentEmail = "jürgen@studmail.de", StudentId = "2343546", LehrstuhlId = 10, StudiengangId = 2, Registration = new DateTime(2020, 12, 12), Filing = new DateTime(2021, 05, 12) },
                     new Models.Thesis() { Id = 3, Title = "Masterthema 1", Description = "...", Bachelor = false, Master = true, Type = ThesisType.Master, Status = Status.Free, StudentName = "Helga", Grade = 5, StudentEmail = "helga@studmail.de", StudentId = "2785476", LehrstuhlId = 11, StudiengangId = 3, Registration = new DateTime(2020, 11, 18), Filing = new DateTime(2021, 04, 13) },
                     new Models.Thesis() { Id = 4, Title = "Masterthema 2", Description = "...", Bachelor = false, Master = true, Type = ThesisType.Master, Status = Status.Reserved, StudentName = "Jannis", Grade = 2, StudentEmail = "jannis@studmail.de", StudentId = "2345698", LehrstuhlId = 12, StudiengangId = 4, Registration = new DateTime(2021, 01, 03), Filing = new DateTime(2021, 05, 20) },
                      new Models.Thesis() { Id = 5, Title = "Masterthema 3", Description = "...", Bachelor = false, Master = true, Type = ThesisType.Master, Status = Status.Registered, StudentName = "Paul", Grade = 5, StudentEmail = "Paul@studmail.de", StudentId = "5645474", LehrstuhlId = 11, StudiengangId = 3, Registration = new DateTime(2020, 03, 18), Filing = new DateTime(2021, 04, 13) },
                     new Models.Thesis() { Id = 6, Title = "Masterthema 4", Description = "...", Bachelor = false, Master = true, Type = ThesisType.Master, Status = Status.Graded, StudentName = "Hanna", Grade = 2, StudentEmail = "Hanna@studmail.de", StudentId = "2652148", LehrstuhlId = 12, StudiengangId = 1, Registration = new DateTime(2021, 01, 03), Filing = new DateTime(2021, 02, 20) });

            var y = modelBuilder.Entity<Lehrstuhl>().HasData(
                new Lehrstuhl() { Id = 10, Name = "BWL 10" },
                new Lehrstuhl() { Id = 11, Name = "BWL 11" },
                new Lehrstuhl() { Id = 12, Name = "BWL 12" }     
                );

            var z = modelBuilder.Entity<Studiengang>().HasData(
                new Studiengang() { Id = 1, Name = "Bachelor Wirtschaftsinformatik" },
                new Studiengang() { Id = 2, Name = "Bachelor Wirtschaftswissenschaften" },
                new Studiengang() { Id = 3, Name = "Master Wirtschaftswissenschaften" },
                new Studiengang() { Id = 4, Name = "Master Wirtschaftsinformatik" }
                );

  /*          modelBuilder.Entity<Models.Thesis>(entity =>
            {
               

                entity.HasOne(d => d.Studiengang)
                    .WithMany(p => p.Thesis)
                    .HasForeignKey(d => d.Studiengang)
                    .HasConstraintName("FK_dbo.Theses_dbo.Studiengang_StudiengangId");


 
            }); */
        }

        public DbSet<Studiengang> Studiengang { get; set; }

        public DbSet<Lehrstuhl> Lehrstuhl { get; set; }

        public DbSet<Thesis> Thesis { get; set; }
        public DbSet<AppUser> Betreuer { get; set; }


    }
}
