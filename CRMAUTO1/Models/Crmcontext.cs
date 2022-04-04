using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRMAUTO.Models
{
    public class Crmcontext : DbContext
    {
       
        public DbSet<client> clients { get; set; }
        public DbSet<contrat> contrats { get; set; }
        public DbSet<Facture> factures { get; set; }
        public DbSet<Modelevoiture> modelevoitures { get; set; }
        public DbSet<Categorie> categories { get; set; }
        public DbSet<voiture> voitures { get; set; }

        public System.Data.Entity.DbSet<CRMAUTO.Models.Register> Registers { get; set; }

        public System.Data.Entity.DbSet<CRMAUTO.Models.Login> Logins { get; set; }
    }
}