using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisWebProjekt.Models
{
    //übernommen nur Betreuer +
    public class VM_ThesisShort
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
        public string StudentName { get; set; }
        public DateTime? Registration { get; set; }
        public DateTime? Filing { get; set; }
        public ThesisType? Type { get; set; }
        public string Betreuer { get; set; }
        public DateTime LastModified { get; set; }
    }
}
