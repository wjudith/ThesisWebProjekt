using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisWebProjekt.Models
{
    public partial class Programme
    {
        //Test
        public Programme()
        {
            Thesis = new HashSet<Thesis>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public ICollection<Thesis> Thesis { get; set; }
    }
}
