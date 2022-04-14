using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRMAUTO.Models
{
    public class Crminitializer : DropCreateDatabaseIfModelChanges<Crmcontext>
    {
       

    }
}