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
                     new Models.Thesis() { Id = 1, Title = "Bachelorthema 1", Description = "...", Bachelor = true, Master = false, Type = ThesisType.Bachelor, Status = Status.Free, StudentName = "Judith", Grade = 1, StudentEmail = "judithw@studmail.de", StudentId = "2845776", LehrstuhlId = 10, StudiengangId = 1 },
                     new Models.Thesis() { Id = 2, Title = "Bachelorthema 2", Description = "...", Bachelor = true, Master = false, Type = ThesisType.Bachelor, Status = Status.Filed, StudentName = "Jürgen", Grade = 4, StudentEmail = "jürgen@studmail.de", StudentId = "2343546", LehrstuhlId = 10, StudiengangId = 2 },
                     new Models.Thesis() { Id = 3, Title = "Masterthema 1", Description = "...", Bachelor = false, Master = true, Type = ThesisType.Master, Status = Status.Free, StudentName = "Helga", Grade = 5, StudentEmail = "helga@studmail.de", StudentId = "2785476", LehrstuhlId = 11, StudiengangId = 3 },
                     new Models.Thesis() { Id = 4, Title = "Masterthema 2", Description = "...", Bachelor = false, Master = true, Type = ThesisType.Master, Status = Status.Free, StudentName = "Jannis", Grade = 2, StudentEmail = "jannisbrzk@studmail.de", StudentId = "2345676", LehrstuhlId = 11, StudiengangId = 4 });
   
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
