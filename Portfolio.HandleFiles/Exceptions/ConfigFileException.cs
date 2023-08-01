namespace Portfolio.HandleFiles.Exceptions
{
    public class ConfigFileException : ApplicationException
    {
        public ConfigFileException(string message, Exception ex = null) : base(message, ex)
        {
        }
    }
}
