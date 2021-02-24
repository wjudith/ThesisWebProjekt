using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisWebProjekt.Models
{
    //übernommen
    public partial class Programme
    {
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
