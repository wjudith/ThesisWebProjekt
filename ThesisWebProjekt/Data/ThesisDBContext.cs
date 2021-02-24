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

        public virtual DbSet<Models.Programme> Programme { get; set; }

        public DbSet<Lehrstuhl> Lehrstuehle { get; set; }



        public virtual DbSet<Models.Thesis> Thesis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var x = modelBuilder.Entity<Thesis>().HasData(
                new Models.Thesis() { Id = 1, Title = "Bachelorthema 1", Description = "...", Bachelor = true, Master = false, Status = Status.Free},
                new Models.Thesis() { Id = 2, Title = "Bachelorthema 2", Description = "...", Bachelor = true, Master = false, Status = Status.Filed },
                new Models.Thesis() { Id = 3, Title = "Masterthema 1", Description = "...", Bachelor = false, Master = true, Status = Status.Free, Grade = 3},
                new Models.Thesis() { Id = 4, Title = "Masterthema 2", Description = "...", Bachelor = false, Master = true, Status = Status.Free, StudentName = "Jannis", SupervisorId = 1, Grade = 1} );

            var l = modelBuilder.Entity<Lehrstuhl>().HasData(
                new Lehrstuhl() { Id = 10, Name = "BWL 10" },
                new Lehrstuhl() { Id = 11, Name = "BWL 11" },
                new Lehrstuhl() { Id = 12, Name = "BWL 12" }
                );
          

            modelBuilder.Entity<Models.Thesis>(entity =>
            {
               

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.Thesis)
                    .HasForeignKey(d => d.ProgrammeId)
                    .HasConstraintName("FK_dbo.Theses_dbo.Programmes_ProgrammeId");


 
            });
        }
        
    }
}
