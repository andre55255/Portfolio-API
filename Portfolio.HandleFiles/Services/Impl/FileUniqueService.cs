using Portfolio.HandleFiles.Exceptions;
using Portfolio.HandleFiles.Helpers;
using Portfolio.HandleFiles.Models;
using Portfolio.HandleFiles.Services.Interfaces;
using System.IO.Compression;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace Portfolio.HandleFiles.Services.Impl
{
    public class FileUniqueService : IFileUniqueService
    {
        private FileConfigModel _config = null;

        public FileUniqueService(FileConfigModel config)
        {
            config.Valid();

            _config = config;
        }

        public void DeleteFileAtDirectory(string entityName, string idEntity, string nameFile)
        {
            try
            {
                string folder = GetFolder(entityName, idEntity);
                StaticMethods.VerifyFileExistsAndDelete(folder, nameFile.ToUpper());
            }
            catch (ConfigFileException ex)
            {
                throw ex;
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HandleFileException($"Falha inesperada ao deletar o arquivo '{nameFile}', verifique", ex);
            }
        }

        public FileReturnModel GetFileBase64AtDirectory(string entityName, string idEntity, string nameFile, bool defaultImage = false)
        {
            try
            {
                string folder = GetFolder(entityName, idEntity, defaultImage);
                if (!Directory.Exists(folder))
                    throw new HandleFileException($"Diretório '{folder}' fornecido não foi encontrado, verifique");

                string[] files = Directory.GetFiles(folder);
                string? file = files.Where(x => x.StartsWith(folder + nameFile.ToUpper())).FirstOrDefault();
                if (file is null || !File.Exists(file))
                    throw new HandleFileException($"Arquivo '{nameFile}' não foi encontrado no diretório '{folder}', verifique");

                FileInfo fileInfo = new FileInfo(file);
                string extensionFile = fileInfo.Extension.Split('.')[1];

                Base64Data? base64 = _config.Base64Data
                                           .Where(x => x.Extension
                                                        .Contains(extensionFile))
                                           .FirstOrDefault();

                if (base64 is null)
                    throw new HandleFileException($"Não foi encontrado um base64 dentre os informados que corresponda a extensão {extensionFile}");

                byte[] fileBytes = File.ReadAllBytes(file);
                string fileBase64 = Convert.ToBase64String(fileBytes);

                FileReturnModel response = new FileReturnModel
                {
                    File = base64.MimeType + "," + fileBase64,
                    Name = fileInfo.Name
                };
                return response;
            }
            catch (ConfigFileException ex)
            {
                throw ex;
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao gerar base64 de arquivo para retornar", ex);
            }
        }

        public FileReturnModel GetFileBase64ZipedAtDirectory(string entityName, string idEntity, string nameFile)
        {
            try
            {
                string folder = GetFolder(entityName, idEntity);
                if (!Directory.Exists(folder))
                    throw new HandleFileException($"Diretório '{folder}' fornecido não foi encontrado, verifique");

                string pathZiped = folder + nameFile + ".zip";
                ZipFile.CreateFromDirectory(folder, pathZiped);
                if (!File.Exists(pathZiped))
                    throw new HandleFileException($"Arquivo de retorno gerado não encontrado no caminho {pathZiped}, verifique");

                byte[] fileBytes = File.ReadAllBytes(pathZiped);
                string fileBase64 = Convert.ToBase64String(fileBytes);

                File.Delete(pathZiped);
                FileReturnModel response = new FileReturnModel
                {
                    Name = idEntity + "_" + nameFile,
                    File = TokensMimeTypes.Zip + fileBase64
                };
                return response;
            }
            catch (ConfigFileException ex)
            {
                throw ex;
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao gerar base64 de arquivo para retornar", ex);
            }
        }

        public FileReturnModel GetFileUrlAtDirectory(string entityName, string idEntity, string nameFile, bool defaultImage = false)
        {
            try
            {
                string folder = GetFolder(entityName, idEntity, defaultImage);
                if (!Directory.Exists(folder))
                    throw new HandleFileException($"Diretório '{folder}' fornecido não foi encontrado, verifique");

                string[] files = Directory.GetFiles(folder);
                string? file = files.Where(x => x.StartsWith(folder + nameFile.ToUpper())).FirstOrDefault();
                if (file is null || !File.Exists(file))
                    throw new HandleFileException($"Arquivo '{nameFile}' não foi encontrado no diretório '{folder}', verifique");

                FileInfo fileInfo = new FileInfo(file);
                string filePath = null;
                if (defaultImage)
                    filePath = string.Concat(_config.BaseUrlApi, _config.PathAvailableStaticFile, entityName, "/Default/", fileInfo.Name);
                else
                    filePath = string.Concat(_config.BaseUrlApi, _config.PathAvailableStaticFile, entityName, "/Unique/", idEntity, "/", fileInfo.Name);

                string fileName = fileInfo.Name;
                FileReturnModel response = new FileReturnModel
                {
                    File = filePath,
                    Name = fileName
                };
                return response;
            }
            catch (ConfigFileException ex)
            {
                throw ex;
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao gerar url para acesso ao arquivo {nameFile} de forma estática", ex);
            }
        }

        public void SaveFileBase64AtDirectory(FileBase64Model file, string entityName, string idEntity)
        {
            try
            {
                if (file is null || string.IsNullOrEmpty(file.FileBase64))
                    throw new HandleFileException($"Dados de base64 não informados, verifique");

                // Quer dizer que já é um item cadastrado
                if (file.FileBase64.StartsWith("http"))
                    return;

                string folder = GetFolder(entityName, idEntity);
                StaticMethods.VerifyFileExistsAndDelete(folder, file.Name.ToUpper());

                string imageNameSave = StaticMethods.SaveFileDirectoryFromBase64(folder, file.FileBase64, file.Name.ToUpper(), _config.Base64Data);
                if (string.IsNullOrEmpty(imageNameSave))
                    throw new HandleFileException($"Falha ao salvar o arquivo {file.Name} para a entidade {entityName} de id {idEntity}");
            }
            catch (ConfigFileException ex)
            {
                throw ex;
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao salvar o arquivo {file.Name} para a entidade {entityName} de id {idEntity}", ex);
            }
        }

        public async Task SaveFileStreamAtDirectory(HttpRequest request, string entityName, string idEntity)
        {
            try
            {
                if (!request.HasFormContentType ||
                    !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
                    string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
                {
                    throw new StreamException($"Status Code 415, formato de carga não é suportado, verifique.");
                }

                int bufferSize = 1024 * 4;
                MultipartReader reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body, bufferSize);
                reader.HeadersLengthLimit = int.MaxValue;
                reader.BodyLengthLimit = int.MaxValue;

                MultipartSection section = await reader.ReadNextSectionAsync();
                while (section != null)
                {
                    bool hasContentDispositionHeader =
                        ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
                            out ContentDispositionHeaderValue contentDisposition);

                    if (hasContentDispositionHeader &&
                        contentDisposition.DispositionType.Equals("form-data") &&
                        !string.IsNullOrEmpty(contentDisposition.FileName.Value))
                    {
                        var fileName = Guid.NewGuid().ToString("N") + contentDisposition.FileName.Value;
                        string folder = GetFolder(entityName, idEntity);

                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);
                        else
                        {
                            string[] files = Directory.GetFiles(folder);
                            if (files is not null && files.Length > 0)
                            {
                                foreach (string file in files)
                                {
                                    File.Delete(file);
                                }
                            }
                        }

                        var saveToPath = Path.Combine(folder, fileName.ToUpper());

                        using (FileStream targetStream = File.Create(saveToPath))
                        {
                            await section.Body.CopyToAsync(targetStream);
                        }

                        return;
                    }

                    section = await reader.ReadNextSectionAsync();
                }
                throw new HandleFileException($"Não foram encontrados arquivos para upload");
            }
            catch (StreamException ex)
            {
                throw ex;
            }
            catch (ConfigFileException ex)
            {
                throw ex;
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha inesperada ao salvar o arquivo via streaming para a entidade {entityName} de id {idEntity}", ex);
            }
        }

        private string GetFolder(string entityName, string idEntity, bool defaultImg = false)
        {
            try
            {
                string prefix = defaultImg ? "Default" : "Unique";
                string folder = Path.Combine(_config.BaseDirectory,
                                             entityName,
                                             prefix,
                                             idEntity);

                return folder + Path.DirectorySeparatorChar;
            }
            catch (Exception ex)
            {
                throw new ConfigFileException($"Falha ao montar caminho para acesso a pasta da entidade {entityName} de id {idEntity}", ex);
            }
        }
    }
}
