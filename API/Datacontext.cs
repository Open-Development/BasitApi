using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sampleApi
{
    public class Datacontext : DbContext
    {
        // public Datacontext() : base ("")
        // {
            
        // }

        public DbSet<Light> Lights { get; set; }      

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=.;Initial Catalog=deneme;User Id=sa;Password=1;");
    }
}