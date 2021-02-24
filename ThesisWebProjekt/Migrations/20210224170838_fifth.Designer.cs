﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThesisWebProjekt.Data;

namespace ThesisWebProjekt.Migrations
{
    [DbContext(typeof(ThesisDBContext))]
    [Migration("20210224170838_fifth")]
    partial class fifth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("LehrstuhlId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("LehrstuhlId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.Lehrstuhl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lehrstuehle");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Name = "BWL 10"
                        },
                        new
                        {
                            Id = 11,
                            Name = "BWL 11"
                        },
                        new
                        {
                            Id = 12,
                            Name = "BWL 12"
                        });
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.Programme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Programme");
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.Thesis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bachelor")
                        .HasColumnType("bit");

                    b.Property<string>("BetreuerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ContentVal")
                        .HasColumnType("int");

                    b.Property<int?>("ContentWt")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DifficultyVal")
                        .HasColumnType("int");

                    b.Property<int?>("DifficultyWt")
                        .HasColumnType("int");

                    b.Property<string>("Evaluation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Filing")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Grade")
                        .HasColumnType("float");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LayoutVal")
                        .HasColumnType("int");

                    b.Property<int?>("LayoutWt")
                        .HasColumnType("int");

                    b.Property<int?>("LiteratureVal")
                        .HasColumnType("int");

                    b.Property<int?>("LiteratureWt")
                        .HasColumnType("int");

                    b.Property<bool>("Master")
                        .HasColumnType("bit");

                    b.Property<int?>("NoveltyVal")
                        .HasColumnType("int");

                    b.Property<int?>("NoveltyWt")
                        .HasColumnType("int");

                    b.Property<int?>("ProgrammeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Registration")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RichnessVal")
                        .HasColumnType("int");

                    b.Property<int?>("RichnessWt")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Strengths")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StructureVal")
                        .HasColumnType("int");

                    b.Property<int?>("StructureWt")
                        .HasColumnType("int");

                    b.Property<string>("StudentEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StyleVal")
                        .HasColumnType("int");

                    b.Property<int?>("StyleWt")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Weaknesses")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BetreuerId");

                    b.HasIndex("ProgrammeId");

                    b.ToTable("Thesis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bachelor = true,
                            ContentWt = 30,
                            Description = "...",
                            DifficultyWt = 5,
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LayoutWt = 15,
                            LiteratureWt = 10,
                            Master = false,
                            NoveltyWt = 10,
                            RichnessWt = 10,
                            Status = 0,
                            StructureWt = 10,
                            StyleWt = 10,
                            Title = "Bachelorthema 1"
                        },
                        new
                        {
                            Id = 2,
                            Bachelor = true,
                            ContentWt = 30,
                            Description = "...",
                            DifficultyWt = 5,
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LayoutWt = 15,
                            LiteratureWt = 10,
                            Master = false,
                            NoveltyWt = 10,
                            RichnessWt = 10,
                            Status = 3,
                            StructureWt = 10,
                            StyleWt = 10,
                            Title = "Bachelorthema 2"
                        },
                        new
                        {
                            Id = 3,
                            Bachelor = false,
                            ContentWt = 30,
                            Description = "...",
                            DifficultyWt = 5,
                            Grade = 3.0,
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LayoutWt = 15,
                            LiteratureWt = 10,
                            Master = true,
                            NoveltyWt = 10,
                            RichnessWt = 10,
                            Status = 0,
                            StructureWt = 10,
                            StyleWt = 10,
                            Title = "Masterthema 1"
                        },
                        new
                        {
                            Id = 4,
                            Bachelor = false,
                            ContentWt = 30,
                            Description = "...",
                            DifficultyWt = 5,
                            Grade = 1.0,
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LayoutWt = 15,
                            LiteratureWt = 10,
                            Master = true,
                            NoveltyWt = 10,
                            RichnessWt = 10,
                            Status = 0,
                            StructureWt = 10,
                            StudentName = "Jannis",
                            StyleWt = 10,
                            SupervisorId = 1,
                            Title = "Masterthema 2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ThesisWebProjekt.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ThesisWebProjekt.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThesisWebProjekt.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ThesisWebProjekt.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.AppUser", b =>
                {
                    b.HasOne("ThesisWebProjekt.Models.Lehrstuhl", "Lehrstuhl")
                        .WithMany("AppUsers")
                        .HasForeignKey("LehrstuhlId");

                    b.Navigation("Lehrstuhl");
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.Thesis", b =>
                {
                    b.HasOne("ThesisWebProjekt.Models.AppUser", "Betreuer")
                        .WithMany("Theses")
                        .HasForeignKey("BetreuerId");

                    b.HasOne("ThesisWebProjekt.Models.Programme", "Programme")
                        .WithMany("Thesis")
                        .HasForeignKey("ProgrammeId")
                        .HasConstraintName("FK_dbo.Theses_dbo.Programmes_ProgrammeId");

                    b.Navigation("Betreuer");

                    b.Navigation("Programme");
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.AppUser", b =>
                {
                    b.Navigation("Theses");
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.Lehrstuhl", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.Programme", b =>
                {
                    b.Navigation("Thesis");
                });
#pragma warning restore 612, 618
        }
    }
}
