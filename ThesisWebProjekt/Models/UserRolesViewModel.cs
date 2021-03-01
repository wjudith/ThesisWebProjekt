using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisWebProjekt.Models
{
    public class UserRolesViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [NotMapped]
    
        public IEnumerable<string> Roles { get; set; }
        public ICollection<Thesis> Thesis { get; set; }

    }
}
