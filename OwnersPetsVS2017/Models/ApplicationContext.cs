using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OwnersPetsVS2017.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnectionSQLite")
        {
        }
        
    }
}