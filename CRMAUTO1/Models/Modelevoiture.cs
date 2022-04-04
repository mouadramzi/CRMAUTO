using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMAUTO.Models
{
    public class Modelevoiture
    {
        [Required]
        [Key]
 
        public int  idmodele { get; set; }
        [Required]
        [Display(Name = "Nom de modele :")]
        public string Nom_modele { get; set; }
        [Display(Name = "Nom de Categorie :")]
        public string Nom_categorie { get; set; }
        [Required]
        [Display(Name = "Nombre puissance :")]
        public int puissance { get; set; }
        public virtual Categorie Categories { get; set; }
    }
}