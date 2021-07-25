using Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MunicipalityTax
    {
        [Key]
        public int Id { get; set; }
        public string Municipality { get; set; }
        public decimal TaxRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaxPeriodEnum Period { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
