namespace Portfolio.Communication.CustomExceptions
{
    public class AuthencationAppException : ApplicationException
    {
        public AuthencationAppException(string message = null, Exception ex = null) : base(message, ex)
        {
        }
    }
}
