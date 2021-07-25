using MunicipalityTaxes.Entities;
using System;
using System.Linq;

namespace MunicipalityTaxes.Services
{
    public class MunicipalityTaxesService
    {
        private readonly MunicipalitiesDbContext context;
        public MunicipalityTaxesService()
        {
            context = new MunicipalitiesDbContext();
        }

        public decimal? GetTaxRate(string municipality, DateTime date)
        {
            var entity = context.MunicipalityTaxes
                .Where(mt => mt.Municipality.ToLower() == municipality.ToLower()
                    && mt.StartDate <= date
                    && mt.EndDate >= date)
                .OrderBy(mt => mt.Period)
                .ThenByDescending(mt => mt.LastUpdated)
                .FirstOrDefault();

            if (entity == null)
                return null;

            return entity.TaxRate;
        }
    }
}
