using Core.Enums;
using System;

namespace Models.MunicipalityTaxes
{
    public class UpdateMunicipalityTaxRequest
    {
        public int Id { get; set; }
        public string Municipality { get; set; }
        public decimal TaxRate { get; set; }
        public DateTime StartDate { get; set; }
        public TaxPeriodEnum Period { get; set; }
    }
}
