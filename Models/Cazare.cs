using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Cazare
    {
        public int ID { get; set; }
        public int DestinatieID { get; set; }
        public string Tip { get; set; }
        public string Nume { get; set; }
        public ICollection<Contract> Contracte { get; set; }
    }
}
