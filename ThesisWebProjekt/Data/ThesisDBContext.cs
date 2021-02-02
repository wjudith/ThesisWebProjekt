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

//        public virtual DbSet<Models.Supervisor> Supervisor { get; set; }

        public virtual DbSet<Models.Thesis> Thesis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            var x = modelBuilder.Entity<Thesis>().HasData(
                new Thesis() { Id = 1, Title = "Bachelorthema 1", Description = "...", Bachelor = true, Master = false, Status = Status.Free},
                new Thesis() { Id = 2, Title = "Bachelorthema 2", Description = "...", Bachelor = true, Master = false, Status = Status.Filed },
                new Thesis() { Id = 3, Title = "Masterthema 1", Description = "...", Bachelor = false, Master = true, Status = Status.Free }
                );
            //modelBuilder.Entity<Models.Programme>(entity =>
            //{
            //    entity.Property(e => e.Name).IsRequired();
            //});

            //modelBuilder.Entity<Models.Supervisor>(entity =>
            //{
            //    entity.Property(e => e.EMail)
            //        .IsRequired()
            //        .HasColumnName("eMail")
            //        .HasDefaultValueSql("('')");

            //    entity.Property(e => e.FirstName).IsRequired();

            //    entity.Property(e => e.LastName).IsRequired();
            //});

            modelBuilder.Entity<Models.Thesis>(entity =>
            {
                //entity.Property(e => e.Description).IsRequired();

                //entity.Property(e => e.Filing).HasColumnType("datetime");

                //entity.Property(e => e.LastModified).HasColumnType("datetime");

                //entity.Property(e => e.Registration).HasColumnType("datetime");

                //entity.Property(e => e.StudentEmail).HasColumnName("StudentEMail");

                //entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.Thesis)
                    .HasForeignKey(d => d.ProgrammeId)
                    .HasConstraintName("FK_dbo.Theses_dbo.Programmes_ProgrammeId");

 /*               entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.Thesis)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("FK_dbo.Theses_dbo.Supervisors_SupervisorId");  
 */
            });
        }
        
    }
}
