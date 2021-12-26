using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Transport
    {
        public int ID { get; set; }
        public string Tip { get; set; }
        public string Firma { get; set; }
        public ICollection<Contract> Contracte { get; set; }
    }
}
