using Core.Extensions;
using System;

namespace Core.Exceptions.Base
{
    public class MunicipalitiesException : Exception
    {
        public Enum Code { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }

        // Used for thrown errors
        public MunicipalitiesException(Enum code)
            : base(code.GetDescription())
        {
            Code = code;
            Message = code.GetDescription();
        }

        // Used for errors that are caught in try catch
        public MunicipalitiesException(Enum code, Exception ex)
            : base(code.GetDescription())
        {
            Code = code;
            Message = code.GetDescription();
            ExceptionMessage = ex.Message;
            StackTrace = ex.StackTrace;
        }
    }
}
