using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Lehrstuhl Lehrstuhl { get; set; }
        public IEnumerable<Thesis> Theses { get; set; }
    }
}
