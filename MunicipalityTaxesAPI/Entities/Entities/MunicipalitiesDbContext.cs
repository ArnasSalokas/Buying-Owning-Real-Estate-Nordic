using Microsoft.EntityFrameworkCore;

namespace Core.Entities
{
    public partial class MunicipalitiesDbContext : DbContext
    {
        public MunicipalitiesDbContext(DbContextOptions<MunicipalitiesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MunicipalityTax> MunicipalityTaxes { get; set; }
    }
}
