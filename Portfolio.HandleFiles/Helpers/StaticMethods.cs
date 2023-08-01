using Portfolio.HandleFiles.Models;
using Portfolio.HandleFiles.Exceptions;

namespace Portfolio.HandleFiles.Helpers
{
    public static class StaticMethods
    {
        public static void VerifyFileExistsAndDelete(string folder, string nameFile)
        {
            try
            {
                if (Directory.Exists(folder))
                {
                    if (string.IsNullOrEmpty(nameFile))
                        throw new HandleFileException($"Nome do arquivo não foi informado");

                    string[] files = Directory.GetFiles(folder);
                    string? file = files.Where(x => x.StartsWith(folder + nameFile))
                                       .FirstOrDefault();

                    if (file is null)
                        return;

                    if (!File.Exists(file))
                        throw new HandleFileException($"Não foi encontrado o arquivo '{nameFile}' no diretório '{folder}'");

                    File.Delete(file);
                }
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HandleFileException($"Falha ao deletar o arquivo '{nameFile}' do diretório: '{folder}'", ex);
            }
        }

        public static void DeleteFilesDirectory(string folder)
        {
            try
            {
                if (Directory.Exists(folder))
                {
                    string[] files = Directory.GetFiles(folder);
                    foreach (string file in files)
                    {
                        if (!File.Exists(file))
                            throw new HandleFileException($"Não foi encontrado o arquivo '{file}' no diretório '{folder}'");

                        File.Delete(file);
                    }
                }
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HandleFileException($"Falha ao deletar todos os arquivos do diretório: '{folder}'", ex);
            }
        }

        public static string SaveFileDirectoryFromBase64(string folder, string base64, string nameFile, List<Base64Data> base64Data)
        {
            try
            {
                int index = base64.IndexOf(",");
                string base64file = base64.Remove(0, index + 1);

                index = base64.IndexOf(";");
                string base64type = base64.Substring(0, index);
                index = base64.IndexOf("/");

                string extension = base64type.Substring(index + 1);
                Base64Data? hasMime = base64Data.Where(x => x.MimeType == extension).FirstOrDefault();
                if (hasMime is not null)
                    extension = hasMime.Extension;

                byte[] bytes = Convert.FromBase64String(base64file);

                DateTime today = DateTime.Now;
                string suffix = string.Concat("_", Guid.NewGuid().ToString());
                string name = string.Concat(nameFile, suffix);
                string path = Path.Combine(folder, name);

                if (File.Exists(path))
                    File.Delete(path);

                Directory.CreateDirectory(folder);
                File.WriteAllBytes(path + "." + extension, bytes);

                return name + "." + extension;
            }
            catch (Exception ex)
            {
                throw new HandleFileException($"Falha inesperada ao salvar o arquivo {nameFile} no diretório {folder}", ex);
            }
        }
    }
}
