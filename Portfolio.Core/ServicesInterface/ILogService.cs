namespace Portfolio.Core.ServicesInterface
{
    public interface ILogService
    {
        public void Write(string message, string place, Exception? ex = null);
    }
}
