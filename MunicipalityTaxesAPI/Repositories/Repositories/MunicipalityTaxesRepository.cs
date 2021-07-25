using Core.Entities;
using Repositories.Repositories.Contracts;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class MunicipalityTaxesRepository : BaseRepository<MunicipalityTax>, IMunicipalityTaxesRepository
    {
        #region Constructors

        public MunicipalityTaxesRepository(MunicipalitiesDbContext dbContext) : base(dbContext)
        {

        }

        #endregion

        #region Get

        public async Task<MunicipalityTax> GetTaxesByKey(int id) => await GetByKey(id);

        #endregion

       
    }
}
