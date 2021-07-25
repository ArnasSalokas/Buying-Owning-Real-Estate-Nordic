using System;
using System.Linq;

namespace MunucipalityTaxes.Helpers
{
    public static class ConsoleHelper
    {
        public static string GetMunicipality()
        {
            bool inputError = false;
            string municipalityInput;

            do
            {
                if (inputError)
                    Console.WriteLine("Error entering Municipality:");

                Console.WriteLine("Enter Municipality(only letters):");
                municipalityInput = Console.ReadLine();
                inputError = string.IsNullOrEmpty(municipalityInput) || !municipalityInput.All(char.IsLetter);
            } while (inputError);

            return municipalityInput;
        }

        public static DateTime GetDate()
        {
            bool inputError = false;
            DateTime date;

            do
            {
                if (inputError)
                    Console.WriteLine("Error entering Date:");

                Console.WriteLine("Enter Date in {yyyy-mm-dd} format:");
                string dateInput = Console.ReadLine();
                inputError = !DateTime.TryParse(dateInput, out date);
            } while (inputError);

            return date;
        }

        public static void PrintAnswer(decimal? taxRate)
        {
            string message = taxRate != null 
                ? $"\nTax Rate is: {taxRate}" 
                : "No Tax Rate was found for the entered Municipality and Date";

            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
