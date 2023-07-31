namespace Portfolio.Communication.CustomExceptions
{
    public class SignInException : ApplicationException
    {
        public SignInException(string message, Exception ex = null) : base(message, ex)
        {
        }
    }
}
