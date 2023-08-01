namespace ortfolio.HandleFiles.Models
{
    public class ResultModel
    {
        public bool Success { get; private set; } = false;
        public string Message { get; private set; } = null;
        public string NameFile { get; private set; } = null;

        private ResultModel(bool success = false, string message = null, string nameFile = null)
        {
            Success = success;
            Message = message;
            NameFile = nameFile;
        }

        public static ResultModel Ok(string nameFile = null, string message = null)
        {
            return new ResultModel(true, message, nameFile);
        }

        public static ResultModel Fail(string message, string nameFile = null)
        {
            return new ResultModel(false, message, nameFile);
        }
    }
}
