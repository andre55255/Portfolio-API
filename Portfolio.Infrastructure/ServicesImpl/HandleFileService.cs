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

        public HandleFileService(IFileUniqueService fileUniqueService, ILogService logService, IHttpContextAccessor httpContextAccessor)
        {
            _fileUniqueService = new FileUniqueService(GetConfigsFileService());
            _logService = logService;
            _httpContextAccessor = httpContextAccessor;
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
                FileConfigModel config = new FileConfigModel
                {
                    BaseDirectory = Path.Combine(Path.GetFullPath("Directory")),
                    PathAvailableStaticFile = "/Static/",
                    BaseUrlApi = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}",
                    Base64Data = new List<Base64Data>
                    {
                        new Base64Data
                        {
                            Extension = "xls,xlsx",
                            MimeType = "data:application/vnd.ms-excel;base64"
                        },
                        new Base64Data
                        {
                            Extension = "png",
                            MimeType = "data:image/png;base64"
                        },
                        new Base64Data
                        {
                            Extension = "jpg",
                            MimeType = "data:image/jpg;base64"
                        },
                        new Base64Data
                        {
                            Extension = "jpeg",
                            MimeType = "data:image/jpeg;base64"
                        }
                    }
                };
                return config;
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
    }
}
