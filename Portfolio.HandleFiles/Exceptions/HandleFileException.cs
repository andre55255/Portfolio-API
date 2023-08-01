namespace Portfolio.HandleFiles.Exceptions
{
    public class HandleFileException : ApplicationException
    {
        public HandleFileException(string message, Exception ex = null) : base(message, ex)
        {
        }
    }
}
