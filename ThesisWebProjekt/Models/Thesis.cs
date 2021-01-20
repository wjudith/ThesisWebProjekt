using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisWebProjekt.Models
{
    public enum Status
    {
        [Display(Name = "Frei")]
        Free = 0,
        [Display(Name = "Vorgemerkt")]
        Reserved = 1,
        [Display(Name = "Angemeldet")]
        Registered = 2,
        [Display(Name = "Abgegeben")]
        Filed = 3,
        [Display(Name = "Bewertet")]
        Graded = 4
    }

    public enum ThesisType
    {
        [Display(Name = "Bachelor")]
        Bachelor = 0,
        [Display(Name = "Master")]
        Master = 1
    }

    public enum Grade
    {
        [Display(Name = "1 (sehr gut)")]
        VeryGood = 1,
        [Display(Name = "2 (gut)")]
        Good = 2,
        [Display(Name = "3 (befriedigend)")]
        Satisfying = 3,
        [Display(Name = "4 (ausreichend)")]
        Sufficient = 4,
        [Display(Name = "5 (mangelhaft)")]
        Insufficient = 5
    }

    public enum GradeFine
    {
        [Display(Name = "1,0")]
        VeryGood = 1,
        [Display(Name = "2 (gut)")]
        Good = 2,
        [Display(Name = "3 (befriedigend)")]
        Satisfying = 3,
        [Display(Name = "4 (ausreichend)")]
        Sufficient = 4,
        [Display(Name = "5 (mangelhaft)")]
        Insufficient = 5
    }

    public partial class Thesis : DbContext
    {
        public int Id { get; set; }
        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Der Titel muss angegeben werden.")]
        public string Title { get; set; }
        [Display(Name = "Beschreibung")]
        public string Description { get; set; }
        [Display(Name = "Bachelor")]
        public bool Bachelor { get; set; }
        [Display(Name = "Master")]
        public bool Master { get; set; }
        [Display(Name = "Status")]
        public Status Status { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }  
        [Display(Name = "E-Mail")]
        public string StudentEmail { get; set; }
        [Display(Name = "Matrikelnummer")]
        public string StudentId { get; set; }
        [Display(Name = "Anmeldedatum")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Registration { get; set; }
        [Display(Name = "Abgabedatum")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Filing { get; set; }
        [Display(Name = "Thesistyp")]
        public ThesisType? Type { get; set; }
        [Display(Name = "Zusammenfassung")]
        public string Summary { get; set; }
        [Display(Name = "Stärken")]
        public string Strengths { get; set; }
        [Display(Name = "Schwächen")]
        public string Weaknesses { get; set; }
        [Display(Name = "Bewertung")]
        public string Evaluation { get; set; }
        [Display(Name = "Inhalt")]
        public int? ContentVal { get; set; }
        [Display(Name = "Gestaltung")]
        public int? LayoutVal { get; set; }
        [Display(Name = "Aufbau")]
        public int? StructureVal { get; set; }
        [Display(Name = "Sprache")]
        public int? StyleVal { get; set; }
        [Display(Name = "Literatur")]
        public int? LiteratureVal { get; set; }
        [Display(Name = "Schwierigkeitsgrad")]
        public int? DifficultyVal { get; set; }
        [Display(Name = "Neuigkeitsgrad")]
        public int? NoveltyVal { get; set; }
        [Display(Name = "Themenerfassung")]
        public int? RichnessVal { get; set; }
        [Display(Name = "Inhalt Gewichtung")]
        public int? ContentWt { get; set; } = 30;
        [Display(Name = "Gestaltung Gewichtung")]
        public int? LayoutWt { get; set; } = 15;
        [Display(Name = "Aufbau Gewichtung")]
        public int? StructureWt { get; set; } = 10;
        [Display(Name = "Sprache Gewichtung")]
        public int? StyleWt { get; set; } = 10;
        [Display(Name = "Literatur Gewichtung")]
        public int? LiteratureWt { get; set; } = 10;
        [Display(Name = "Schwierigkeitsgrad Gewichtung")]
        public int? DifficultyWt { get; set; } = 5;
        [Display(Name = "Neuigkeitsgrad Gewichtung")]
        public int? NoveltyWt { get; set; } = 10;
        [Display(Name = "Themenerfassung Gewichtung")]
        public int? RichnessWt { get; set; } = 10;
        [Display(Name = "Note")]
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public double? Grade { get; set; }
        [Display(Name = "Studiengang")]
        public int? ProgrammeId { get; set; }
        [Display(Name = "Betreuer/-in")]
        public int? SupervisorId { get; set; }
        [Required]
        [Display(Name = "Zuletzt geändert")]
        public DateTime LastModified { get; set; }
         
        public Programme Programme { get; set; }


//        public Supervisor Supervisor { get; set; }
    }
}
