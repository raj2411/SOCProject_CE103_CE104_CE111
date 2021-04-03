using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace SOC_WebApplication1.Models
{
    public class DatabaseContext:DbContext 
    {
        public DatabaseContext() : base("DefaultConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
    
}