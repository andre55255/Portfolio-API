using Portfolio.Core.ServicesInterface;
using System.Text;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class LogService : ILogService
    {
        public void Write(string message, string place, Exception? ex = null)
        {
            try
            {
                string msg = ex == null ? "INFO  " : "ERROR:  " + $"Local: {place}. Message: {ex.Message}.";
                if (ex != null)
                    msg += $"Inner msg: {ex.InnerException.Message}. Stack Trace: {ex.StackTrace}";

                WriteMessageInFile($"{msg}");
            }
            catch (Exception) { }
        }

        private static void ValidateDateLog(string path)
        {
            try
            {
                FileStream fileStream = null;
                StreamReader reader = null;
                using (fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    fileStream.Close();
                    using (reader = new StreamReader(path))
                    {
                        string line = reader.ReadLine();
                        string date = line.Split('-')[0];
                        DateTime? dateArchive = DateTime.Parse(date.Trim());
                        if (!dateArchive.HasValue)
                            return;

                        reader.Close();
                        if (dateArchive.Value.Date < DateTime.Now.Date)
                        {
                            if (!File.Exists(path))
                                return;

                            string pathDestinyArchived = Path.GetFullPath("Logs") + @"\archived\";
                            Directory.CreateDirectory(pathDestinyArchived);
                            string filePathDestiny = pathDestinyArchived + dateArchive.Value.ToString("yyyyMMdd") + ".txt";
                            File.Copy(path, filePathDestiny);
                            File.Delete(path);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private static void WriteMessageInFile(string msg)
        {
            try
            {
                string path = Path.GetFullPath("Logs");
                string archive = path + "log.txt";
                ValidateDateLog(archive);
                FileStream fileStream = null;
                StreamWriter streamWriter = null;
                using (fileStream = File.Open(archive, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fileStream.Close();
                    using (streamWriter = new StreamWriter(archive, true, Encoding.UTF8))
                    {
                        streamWriter.WriteLine(DateTime.Now.ToString() + " - " + msg);
                    }
                    streamWriter.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void Write(string msg)
        {
            try
            {
                WriteMessageInFile(msg);
            }
            catch (Exception)
            {
            }
        }
    }
}
