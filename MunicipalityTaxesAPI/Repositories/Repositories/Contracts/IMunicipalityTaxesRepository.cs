using Core.Entities;
using System.Threading.Tasks;

namespace Repositories.Repositories.Contracts
{
    public interface IMunicipalityTaxesRepository : IBaseRepository<MunicipalityTax>
    {
        Task<MunicipalityTax> GetTaxesByKey(int id);
    }
}
