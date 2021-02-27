using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisWebProjekt.Models
{
    public class Lehrstuhl
    {
        public Lehrstuhl()
        {
          
        }


        //jeder Lehrstuhl hat ID , Name , und Verweis auf jew. Appuser (Lehrstuhl ist quasi das geforderte Supervisor Model)
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public  ICollection<AppUser> AppUsers { get; set; }
    }
    
}
