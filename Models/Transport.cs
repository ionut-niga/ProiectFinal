using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Transport
    {
        public int ID { get; set; }
        public string Tip { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele introdus trebuie sa fie cu litera mare"), Required, StringLength(50, MinimumLength = 3)]
        public string Firma { get; set; }
        public ICollection<Contract> Contracte { get; set; }
    }
}
