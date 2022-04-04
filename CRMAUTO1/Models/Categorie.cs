using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMAUTO.Models
{
    public class Categorie
    {
        [Required]
        [Key]
        public int  CategorieId { get; set; }
  
        [Required]
        [Display(Name = "Nom de categorie :")]
        public string Nom_categorie { get; set; }
        [Required]
        [Display(Name = "voiture id :")]
        public string voitureid { get; set; }
        [Display(Name = "modele voiture  :")]
        public int modele_voiture { get; set; }

        public virtual ICollection<voiture> Voitures { get; set; }
        public virtual ICollection<Modelevoiture> Modelevoitures { get; set; }

    }
}