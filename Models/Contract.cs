using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Proiect.Models
{
    public class Contract
    {
        public int ID { get; set; }
        [Display(Name = "Transport")]
        public int TransportID { get; set; }
        public Transport Transport { get; set; }

        [Display(Name = "Client")]
        public Client Client { get; set; }
        public int ClientID { get; set; }
        [Display(Name = "Cazare")]
        public Cazare Cazare { get; set; }
        public int CazareID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataContract { get; set; }
    }
}
