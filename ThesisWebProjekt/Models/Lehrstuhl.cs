using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThesisWebProjekt.Areas.Identity.Data;

namespace ThesisWebProjekt.Models
{
    public class Lehrstuhl
    {
        public Lehrstuhl() {
            
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        // public ICollection<AppUser> AppUsers { get; set; }

        public Lehrstuhl Lehrstuhl { get; set; }

    }
}
