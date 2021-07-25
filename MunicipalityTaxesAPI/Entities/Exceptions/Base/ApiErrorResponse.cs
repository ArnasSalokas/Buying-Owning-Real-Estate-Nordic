namespace Core.Exceptions.Base
{
    public class ApiErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
