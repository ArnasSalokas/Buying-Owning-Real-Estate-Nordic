using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MunicipalityTaxes.Entities
{
    public partial class MunicipalitiesDbContext : DbContext
    {
        public DbSet<MunicipalityTax> MunicipalityTaxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MunicipalitiesDb"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
