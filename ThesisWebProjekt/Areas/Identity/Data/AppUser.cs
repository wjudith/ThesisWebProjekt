using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ThesisWebProjekt.Models;

namespace ThesisWebProjekt.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser
    {
        public int Id { get; set; }

// bei 1:1 steht das drin, bei 1:n nicht zwingend nötig
//        public Lehrstuhl Lehrstuhl { get; set; }

        public IEnumerable<Thesis> Theses { get; set; }
    }
}
