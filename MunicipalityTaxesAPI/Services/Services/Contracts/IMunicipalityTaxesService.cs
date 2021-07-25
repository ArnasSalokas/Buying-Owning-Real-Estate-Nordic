using Core.Entities;
using Core.Enums;
using Models.MunicipalityTaxes;
using System;
using System.Threading.Tasks;

namespace Services.Services.Contracts
{
    public interface IMunicipalityTaxesService
    {
        public TaxDateRanges GetTaxesDates(DateTime startDate, TaxPeriodEnum period);
        Task<MunicipalityTax> AddTax(AddMunicipalityTaxRequest model);
        Task<MunicipalityTax> UpdateTax(UpdateMunicipalityTaxRequest model);
    }
}
