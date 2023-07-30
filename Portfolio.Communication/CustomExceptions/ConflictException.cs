namespace Portfolio.Communication.CustomExceptions
{
    public class ConflictException : ApplicationException
    {
        public ConflictException(string message, Exception ex = null) : base(message, ex) { }
    }
}
