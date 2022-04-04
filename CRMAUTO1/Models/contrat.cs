using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMAUTO.Models
{
    public class contrat
    {
        [Required]
        [Key]
        public string idcontrat { get; set; }
         
        [Display(Name = "Voiture Id ")]
         public string idvoiture { get; set; }
        [Display(Name = "Client CIN  ")]
        public string clientcin { get; set; }
        [Required]
        [Display(Name = "Cin")]
        public string cin { get; set; }
        [Required]
        [Display(Name = "Date de contrat")]
        public DateTime datecontrat { get; set; }
        [Required]
        [Display(Name = "Km de depart")]
        public string kmdepart { get; set; }
        public virtual client Client { get; set; }
        public virtual voiture Voitures { get; set; }
    }
}