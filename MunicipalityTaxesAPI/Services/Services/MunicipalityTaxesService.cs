using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Exceptions.Base;
using Models.MunicipalityTaxes;
using Repositories.Repositories.Contracts;
using Services.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MunicipalityTaxesService : IMunicipalityTaxesService
    {
        private readonly IMunicipalityTaxesRepository _municipalityTaxesRepository;

        #region Constructors

        public MunicipalityTaxesService(IMunicipalityTaxesRepository municipalityTaxesRepository)
        {
            _municipalityTaxesRepository = municipalityTaxesRepository;
        }

        #endregion


        #region Add

        /// <summary>
        /// Does not allow duplicates. Check is done on the Database level
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MunicipalityTax> AddTax(AddMunicipalityTaxRequest model)
        {
            // Validation could be done using FluentValidation
            if (string.IsNullOrEmpty(model.Municipality))
                throw new MunicipalitiesException(MunicipalitiesExceptionCodes.MunicipalityTax.MunicipalityEmpty);

            if (!Enum.IsDefined(typeof(TaxPeriodEnum), model.Period))
                throw new MunicipalitiesException(MunicipalitiesExceptionCodes.MunicipalityTax.PeriodInvalid);

            var taxDateRanges = GetTaxesDates(model.StartDate, model.Period);

            var entity = new MunicipalityTax()
            {
                Municipality = model.Municipality.ToLower(),
                TaxRate = model.TaxRate,
                StartDate = taxDateRanges.StartDate,
                EndDate = taxDateRanges.EndDate,
                Period = model.Period,
                LastUpdated = DateTime.Now
            };

            await _municipalityTaxesRepository.Add(entity);
            return entity;
        }

        #endregion

        #region Update

        public async Task<MunicipalityTax> UpdateTax(UpdateMunicipalityTaxRequest model)
        {
            // Validation could be done using FluentValidation
            if (string.IsNullOrEmpty(model.Municipality))
                throw new MunicipalitiesException(MunicipalitiesExceptionCodes.MunicipalityTax.MunicipalityEmpty);

            if (!Enum.IsDefined(typeof(TaxPeriodEnum), model.Period))
                throw new MunicipalitiesException(MunicipalitiesExceptionCodes.MunicipalityTax.PeriodInvalid);

            var entity = await _municipalityTaxesRepository.GetTaxesByKey(model.Id);

            if (entity == null)
                throw new MunicipalitiesException(MunicipalitiesExceptionCodes.Base.NotFound);

            var taxDateRanges = GetTaxesDates(model.StartDate, model.Period);

            entity.Municipality = model.Municipality.ToLower();
            entity.TaxRate = model.TaxRate;
            entity.StartDate = taxDateRanges.StartDate;
            entity.EndDate = taxDateRanges.EndDate;
            entity.Period = model.Period;
            entity.LastUpdated = DateTime.Now;

            await _municipalityTaxesRepository.Update(entity);
            return entity;
        }

        #endregion

        #region Helper Methods

        public TaxDateRanges GetTaxesDates(DateTime startDate, TaxPeriodEnum period)
        {
            var result = new TaxDateRanges();

            switch (period)
            {
                case TaxPeriodEnum.Daily:
                    result.StartDate = startDate;
                    result.EndDate = startDate;
                    break;
                case TaxPeriodEnum.Weekly:
                    // Since no description was given about the weekly implementation, I decided to allow
                    // Adding weekly taxes from any given day
                    result.StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
                    result.EndDate = startDate.AddDays(6);
                    break;
                case TaxPeriodEnum.Monthly:
                    result.StartDate = new DateTime(startDate.Year, startDate.Month, 1);
                    result.EndDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));
                    break;
                case TaxPeriodEnum.Yearly:
                    result.StartDate = new DateTime(startDate.Year, 1, 1);
                    result.EndDate = new DateTime(startDate.Year, 12, 31);
                    break;
            }

            return result;
        }

        #endregion
    }
}
