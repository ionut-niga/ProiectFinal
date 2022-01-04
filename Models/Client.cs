using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;
namespace Proiect.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele introdus trebuie sa fie de forma Nume" ), Required, StringLength(50, MinimumLength = 3)]


        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele introdus trebuie sa fie de forma Prenume"), Required, StringLength(50, MinimumLength = 3)]

        public string Prenume { get; set; }
        public ICollection<Contract> Contracte { get; set; }
    }
}
