using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ThesisWebProjekt.Models
{
    //eigene Klasse Appuser basiert aer auf IdentityUser!
    public class AppUser : IdentityUser
    {
       
        public string Password { get; set; } 
        // 1:n Beziehung zw. Lehrstuhl und AppUser
        public Lehrstuhl Lehrstuhl { get; set; }
        public ICollection<Thesis> Theses { get; set; }
    }
}
