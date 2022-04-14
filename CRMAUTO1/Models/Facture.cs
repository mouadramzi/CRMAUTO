using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMAUTO.Models
{
    public class Facture
    {
        [Required] [Key]
          public string idfacture { get; set; }
        [Required]
        [Display(Name = "CIN")]
        public string cin { get; set; }
        [Required]
        [Display(Name = "Montant")]
        public int Montant { get; set; }
        [Required]
        
        
        [Display(Name = " Nom de Modele")]
        public string modele { get; set; }
        [Display(Name = "Nom de categorie")]
        public string categorie { get; set; }
        public virtual contrat Contrats { get; set; }

    }
}