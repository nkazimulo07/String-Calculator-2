using String_Calculator_2.Interfaces;

namespace String_Calculator_2.Services
{
    public class ErrorHandling : IErrorHandling
    {
        public string ThrowException(string exception)
        {
            throw new Exception(exception);
        }
    }
}
