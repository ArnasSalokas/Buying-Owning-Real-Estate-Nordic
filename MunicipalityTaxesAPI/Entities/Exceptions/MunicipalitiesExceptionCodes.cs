using System.ComponentModel;

namespace Core.Exceptions
{
    public static class MunicipalitiesExceptionCodes
    {
        public enum Base
        {
            [Description("Unknown error")]
            UnknownError = 10000,

            [Description("Entity not found")]
            NotFound = 10001,

            [Description("Error adding entity")]
            ErrorAdding = 10002,

            [Description("Error updating entity")]
            ErrorUpdating = 10003,
        }

        public enum MunicipalityTax
        {
            [Description("Municipality must have a value")]
            MunicipalityEmpty = 20000,

            [Description("Period must be one of daily, weekly, monthly, yearly values")]
            PeriodInvalid = 20001,
        }
    }
}
