using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisWebProjekt.Models
{
    //übernommen
    public class Studiengang
    {
      

        public int Id { get; set; }
       
      
        public string Name { get; set; }

        public ICollection<Thesis> Thesis { get; set; }
    }
}
