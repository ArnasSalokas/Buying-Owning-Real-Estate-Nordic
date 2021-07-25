using MunicipalityTaxes.Services;
using MunucipalityTaxes.Helpers;

namespace MunucipalityTaxes
{
    class MuniplicityTaxCalculator
    {
        static void Main(string[] args)
        {
            var muniplicityTaxesService = new MunicipalityTaxesService();
            Calculate(muniplicityTaxesService);
        }

        private static void Calculate(MunicipalityTaxesService muniplicityTaxesService)
        {
            var municipality = ConsoleHelper.GetMunicipality();
            var date = ConsoleHelper.GetDate();

            var taxRate = muniplicityTaxesService.GetTaxRate(municipality, date);

            ConsoleHelper.PrintAnswer(taxRate);
        }
    }
}
