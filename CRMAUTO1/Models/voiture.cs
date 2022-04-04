using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMAUTO.Models
{
    public class voiture
    { 
        [Required]
        [Display(Name = "Matriculation")]
        [Key]
        public string matricule { get; set; }
        [Required]
        [Display(Name = "Kilometrage")]
        public string kilometrage { get; set; }
        [Required]
        [Display(Name = "Annee ")]
        public int annee { get; set; }
        [Required]
        [Display(Name = "Carburant")]
        public string carburant { get; set; }
        [Required]
        [Display(Name = "Puissance fiscale")]
        public string puissance { get; set; }
        [Required]
        [Display(Name = "Numero ")]
        public string datecontrat { get; set; }
        public virtual ICollection<contrat> Contrats { get; set; }






    }
}