using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ThesisWebProjekt.Models
{
    public class AppUser : IdentityUser
    {
       
        public string Password { get; set; } 

        public Lehrstuhl Lehrstuhl { get; set; }
        public ICollection<Thesis> Theses { get; set; }
    }
}
