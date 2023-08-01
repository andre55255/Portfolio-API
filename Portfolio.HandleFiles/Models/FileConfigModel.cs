using Portfolio.HandleFiles.Exceptions;

namespace Portfolio.HandleFiles.Models
{
    public class FileConfigModel
    {
        public string BaseDirectory { get; set; } = null;
        public string BaseUrlApi { get; set; } = null;
        public string PathAvailableStaticFile { get; set; } = null;
        public List<Base64Data> Base64Data { get; set; } = null;

        public void Valid()
        {
            try
            {
                if (string.IsNullOrEmpty(BaseDirectory))
                    throw new ConfigFileException($"Diretório base não informado na instância do serviço, verifique");

                if (string.IsNullOrEmpty(BaseUrlApi))
                    throw new ConfigFileException($"Url base não informado na instância do serviço, verifique");

                if (string.IsNullOrEmpty(PathAvailableStaticFile))
                    throw new ConfigFileException($"Rota para acesso estático ao arquivo não informado, verifique");

                if (!Directory.Exists(BaseDirectory))
                    throw new ConfigFileException($"Diretório '{BaseDirectory}' fornecido não foi encontrado, verifique");

                if (Base64Data is null)
                    throw new ConfigFileException($"Dados de base64 não informados, verifique");
            }
            catch (ConfigFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ConfigFileException($"Falha ao validar configurações fornecidas, verifique a exceção", ex);
            }
        }
    }

    public class Base64Data
    {
        public string Extension { get; set; } = null; // Separado por vírgula
        public string MimeType { get; set; } = null;
    }
}
