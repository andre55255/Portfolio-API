namespace Portfolio.Communication.CustomExceptions
{
    public class EmailException : ApplicationException
    {
        public EmailException(string message = null, Exception ex = null) : base(message, ex) { }
    }
}
