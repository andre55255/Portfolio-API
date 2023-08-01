namespace Portfolio.HandleFiles.Exceptions
{
    public class StreamException : ApplicationException
    {
        public StreamException(string message, Exception ex = null) : base(message, ex)
        {
        }
    }
}
