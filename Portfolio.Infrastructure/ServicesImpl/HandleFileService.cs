using Microsoft.AspNetCore.Http;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Core.ServicesInterface;
using Portfolio.HandleFiles.Exceptions;
using Portfolio.HandleFiles.Models;
using Portfolio.HandleFiles.Services.Impl;
using Portfolio.HandleFiles.Services.Interfaces;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class HandleFileService : IHandleFileService
    {
        private readonly IFileUniqueService _fileUniqueService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogService _logService;

        public HandleFileService(ILogService logService, IHttpContextAccessor httpContextAccessor)
        {
            _logService = logService;
            _httpContextAccessor = httpContextAccessor;
            _fileUniqueService = new FileUniqueService(GetConfigsFileService());
        }

        public void DeleteFileUniqueAtDirectory(string entityName, string idEntity, string nameFile)
        {
            try
            {
                _fileUniqueService.DeleteFileAtDirectory(entityName, idEntity, nameFile);
            }
            catch (HandleFileException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao deletar arquivo da entidade {idEntity} - {entityName} com o nome {nameFile}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao deletar arquivo da entidade {idEntity} - {entityName} com o nome {nameFile}");
            }
        }

        public FileBase64Model GetUrlFileUniqueAtDirectory(string entityName, string idEntity, string nameFile, bool defaultImage = false)
        {
            try
            {
                FileReturnModel returnFile = _fileUniqueService.GetFileUrlAtDirectory(entityName, idEntity, nameFile);
                if (returnFile == null)
                    return null;

                return new FileBase64Model
                {
                    Name = returnFile.Name,
                    FileBase64 = returnFile.File
                };
            }
            catch (HandleFileException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar url estática do arquivo da entidade {idEntity} - {entityName} com o nome {nameFile}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar url estática do arquivo da entidade {idEntity} - {entityName} com o nome {nameFile}");
            }
        }

        public void SaveFileUniqueBase64AtDirectory(FileBase64Model file, string entityName, string nameFile, string idEntity)
        {
            try
            {
                if (file == null || string.IsNullOrEmpty(file.FileBase64) || string.IsNullOrEmpty(idEntity))
                    return;

                file.Name = nameFile;
                _fileUniqueService.SaveFileBase64AtDirectory(file, entityName, idEntity);
            }
            catch (HandleFileException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao salvar arquivo da entidade {idEntity} - {entityName} com o nome {nameFile}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao salvar arquivo da entidade {idEntity} - {entityName} com o nome {nameFile}");
            }
        }

        public void UpdateFileUniqueBase64AtDirectory(FileBase64Model file, string entityName, string nameFile, string idEntity)
        {
            try
            {
                if (file == null || string.IsNullOrEmpty(file.FileBase64))
                    return;

                DeleteFileUniqueAtDirectory(entityName, nameFile, idEntity);

                file.Name = nameFile;
                SaveFileUniqueBase64AtDirectory(file, entityName, nameFile, idEntity);
            }
            catch (HandleFileException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao editar arquivo da entidade {idEntity} - {entityName} com o nome {nameFile}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao editar arquivo da entidade {idEntity} - {entityName} com o nome {nameFile}");
            }
        }

        private FileConfigModel GetConfigsFileService()
        {
            try
            {
                List<Base64Data> list = BuildListBase64();

                FileConfigModel config = new FileConfigModel
                {
                    BaseDirectory = Path.Combine(Path.GetFullPath("Directory")),
                    PathAvailableStaticFile = "/Static/",
                    BaseUrlApi = _httpContextAccessor != null && 
                                 _httpContextAccessor.HttpContext != null && 
                                 _httpContextAccessor.HttpContext.Request != null ? 
                                    $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}" : 
                                    "",
                    Base64Data = list
                };
                return config;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (ConfigFileException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao criar arquivo de configuração de serviço de arquivo", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao criar arquivo de configuração de serviço de arquivo");
            }
        }

        private List<Base64Data> GetAllBase64FromReadFileTxt()
        {
            try
            {
                string filepath = Path.Combine(Path.GetFullPath("Content"), "Configs", "MimeTypesBase64HandleFileService.txt");
                if (!File.Exists(filepath))
                    throw new ConfigFileException($"Não foi encontrado o arquivo {filepath} para leitura, verifique");
                
                List<Base64Data> response = new List<Base64Data>();
                using (FileStream fs = File.Open(filepath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string readLine = sr.ReadLine();
                            if (string.IsNullOrEmpty(readLine))
                                continue;

                            string[] register = readLine.Split("|");
                            if (register == null || register.Length <= 1)
                                continue;

                            response.Add(new Base64Data
                            {
                                Extension = register[0],
                                MimeType = register[1]
                            });
                        }
                    }
                }
                return response;
            }
            catch (ConfigFileException ex)
            {
                _logService.Write(ex.Message, this.GetPlace(), ex);
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao ler lista de mime types do arquivo de configuração na api", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao ler lista de mime types do arquivo de configuração na api");
            }
        }

        private List<Base64Data> BuildListBase64()
        {
            return new List<Base64Data>()
            {
                new Base64Data
                {
                    Extension = "xls",
                    MimeType = "data:application/vnd.ms-excel;base64"
                },
                new Base64Data
                {
                    Extension = "xlsx",
                    MimeType = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64"
                },
                new Base64Data
                {
                    Extension = "png",
                    MimeType = "data:image/png;base64"
                },
                new Base64Data
                {
                    Extension = "jpg,jpeg",
                    MimeType = "data:image/jpeg;base64"
                },
                new Base64Data
                {
                    MimeType = "data:image/gif;base64",
                    Extension = "gif"
                },
                new Base64Data
                {
                    MimeType = "data:application/pdf;base64",
                    Extension = "pdf"
                },
                new Base64Data
                {
                    MimeType = "data:application/msword;base64",
                    Extension = "doc"
                },
                new Base64Data
                {
                    MimeType = "data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64",
                    Extension = "docx"
                },
                new Base64Data
                {
                    MimeType = "data:application/vnd.ms-powerpoint;base64",
                    Extension = "ppt"
                },
                new Base64Data
                {
                    MimeType = "data:application/vnd.openxmlformats-officedocument.presentationml.presentation;base64",
                    Extension = "pptx"
                },
                new Base64Data
                {
                    MimeType = "data:video/mp4;base64",
                    Extension = "mp4"
                },
                new Base64Data
                {
                    MimeType = "data:video/x-msvideo;base64",
                    Extension = "avi"
                },
                new Base64Data
                {
                    MimeType = "data:video/quicktime;base64",
                    Extension = "mov"
                },
                new Base64Data
                {
                    MimeType = "data:text/plain;base64",
                    Extension = "txt"
                },
                new Base64Data
                {
                    MimeType = "data:text/html;base64",
                    Extension = "html"
                },
                new Base64Data
                {
                    MimeType = "data:text/css;base64",
                    Extension = "css"
                },
                new Base64Data
                {
                    MimeType = "data:application/javascript;base64",
                    Extension = "js"
                },
                new Base64Data
                {
                    MimeType = "data:text/xml;base64",
                    Extension = "xml"
                },
                new Base64Data 
                {
                    MimeType = "data:text/csv;base64",
                    Extension = "csv"
                },
                new Base64Data
                {
                    MimeType = "data:application/zip;base64",
                    Extension = "zip"
                }
            };
        }
    }
}
