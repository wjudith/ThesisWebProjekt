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
    [Migration("20210122144904_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ThesisWebProjekt.Models.Programme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

                    b.Property<bool>("Bachelor")
                        .HasColumnType("bit");

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
                        });
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.Thesis", b =>
                {
                    b.HasOne("ThesisWebProjekt.Models.Programme", "Programme")
                        .WithMany("Thesis")
                        .HasForeignKey("ProgrammeId")
                        .HasConstraintName("FK_dbo.Theses_dbo.Programmes_ProgrammeId");

                    b.Navigation("Programme");
                });

            modelBuilder.Entity("ThesisWebProjekt.Models.Programme", b =>
                {
                    b.Navigation("Thesis");
                });
#pragma warning restore 612, 618
        }
    }
}
