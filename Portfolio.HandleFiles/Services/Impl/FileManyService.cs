using Portfolio.HandleFiles.Exceptions;
using Portfolio.HandleFiles.Helpers;
using Portfolio.HandleFiles.Models;
using Portfolio.HandleFiles.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Portfolio.HandleFiles.Services.Impl
{
    public class FileManyService : IFileManyService
    {
        private FileConfigModel _config = null;

        public FileManyService(FileConfigModel config)
        {
            config.Valid();

            _config = config;
        }

        public void DeleteFilesDirectory(string galleryFiles, string mainFile, string entityName, string idEntity)
        {
            try
            {
                string[] galleryFilesArray =
                            galleryFiles != null ?
                            galleryFiles.Split(",") :
                            "".Split(",");

                string folder = GetFolder(entityName, idEntity);
                if (!Directory.Exists(folder))
                    throw new HandleFileException($"Diretório '{folder}' fornecido não foi encontrado, verifique");

                if (mainFile != null)
                    StaticMethods.VerifyFileExistsAndDelete(folder, mainFile);

                if (galleryFiles != null)
                {
                    foreach (string filename in galleryFilesArray)
                    {
                        StaticMethods.VerifyFileExistsAndDelete(folder, filename);
                    }
                }
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
                throw new HandleFileException($"Falha inesperada ao deletar arquivos informados, verifique a exceção", ex);
            }
        }

        private FileManySaveModel DeleteFilesMethodEditDirectory(List<FileBase64Model> galleryFilesSave, FileBase64Model mainFile, string entityName, string idEntity)
        {
            try
            {
                FileManySaveModel response = new FileManySaveModel();

                string folder = GetFolder(entityName, idEntity);
                if (!Directory.Exists(folder))
                    throw new HandleFileException($"Diretório '{folder}' fornecido não foi encontrado, verifique");

                if (mainFile is not null)
                {
                    if (mainFile.FileBase64.StartsWith("http"))
                    {
                        string? filenameMain = mainFile.FileBase64.Split("/").LastOrDefault();
                        response.MainName = filenameMain;
                    }
                    else
                        StaticMethods.VerifyFileExistsAndDelete(folder, mainFile.Name);
                }

                if (galleryFilesSave != null)
                {
                    foreach (FileBase64Model file in galleryFilesSave)
                    {
                        if (file.FileBase64.StartsWith("http"))
                        {
                            string? filenameGal = file.FileBase64.Split("/").LastOrDefault();
                            response.GalleryName += filenameGal;
                        }
                        else
                            StaticMethods.VerifyFileExistsAndDelete(folder, file.Name);
                    }
                }

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
                throw new HandleFileException($"Falha inesperada ao deletar arquivos para preparar edição, verifique a exceção", ex);
            }
        }

        public List<FileReturnModel> GetFilesDirectoryToBase64(string[] galleryFiles, string mainFile, string entityName, string idEntity)
        {
            try
            {
                List<FileReturnModel> response = new List<FileReturnModel>();
                string folder = GetFolder(entityName, idEntity);
                if (!Directory.Exists(folder))
                    throw new HandleFileException($"Diretório '{folder}' fornecido não foi encontrado, verifique");

                string[] files = Directory.GetFiles(folder);
                string? mainFileDir = files.Where(x => x.StartsWith(folder + mainFile))
                                          .FirstOrDefault();

                if (mainFileDir is not null && File.Exists(mainFileDir))
                {
                    string base64MainFile = BuildBase64File(mainFileDir);
                    if (string.IsNullOrEmpty(base64MainFile))
                        throw new HandleFileException($"Falha ao montar base64 de arquivo {mainFileDir} para retornar");

                    FileReturnModel fileMain = new FileReturnModel
                    {
                        Name = mainFile,
                        File = base64MainFile
                    };
                    response.Add(fileMain);
                }

                if (galleryFiles is not null)
                {
                    foreach (string filename in galleryFiles)
                    {
                        string? filePathDirectory = files.Where(x => x.StartsWith(folder + filename))
                                                        .FirstOrDefault();

                        if (filePathDirectory is not null && File.Exists(filePathDirectory))
                        {
                            string base64File = BuildBase64File(filePathDirectory);
                            if (string.IsNullOrEmpty(base64File))
                                throw new HandleFileException($"Falha ao montar base64 de arquivo {mainFileDir} para retornar");

                            FileReturnModel fileAux = new FileReturnModel
                            {
                                Name = mainFile,
                                File = base64File
                            };
                            response.Add(fileAux);
                        }
                    }
                }

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
                throw new Exception($"Falha ao gerar base64 de arquivos para retornar", ex);
            }
        }

        public List<FileReturnModel> GetFilesDirectoryToUrl(string[] galleryFiles, string mainFile, string entityName, string idEntity)
        {
            try
            {
                List<FileReturnModel> response = new List<FileReturnModel>();
                string folder = GetFolder(entityName, idEntity);
                if (!Directory.Exists(folder))
                    throw new HandleFileException($"Diretório '{folder}' fornecido não foi encontrado, verifique");

                string[] files = Directory.GetFiles(folder);
                string? mainFileDir = files.Where(x => x.StartsWith(folder + mainFile.ToUpper()))
                                          .FirstOrDefault();

                if (mainFileDir is not null && File.Exists(mainFileDir))
                {
                    string urlMainFile = BuildUrlFile(mainFileDir, idEntity, entityName);
                    if (urlMainFile is null)
                        throw new HandleFileException($"Falha ao gerar url para acesso ao arquivo {urlMainFile} de forma estática");

                    FileReturnModel fileMain = new FileReturnModel
                    {
                        Name = mainFile,
                        File = urlMainFile
                    };
                    response.Add(fileMain);
                }

                if (galleryFiles is not null)
                {
                    foreach (string filename in galleryFiles)
                    {
                        if (string.IsNullOrEmpty(filename))
                            continue;

                        string? filePathDirectory = files.Where(x => x.StartsWith(folder + filename.ToUpper()))
                                                        .FirstOrDefault();

                        if (filePathDirectory is not null && File.Exists(filePathDirectory))
                        {
                            string urlFile = BuildUrlFile(filePathDirectory, idEntity, entityName);
                            if (urlFile is null)
                                throw new HandleFileException($"Falha ao gerar url para acesso ao arquivo {filePathDirectory} de forma estática");

                            FileReturnModel fileAux = new FileReturnModel
                            {
                                Name = filename,
                                File = urlFile
                            };
                            response.Add(fileAux);
                        }
                    }
                }
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
                throw new Exception($"Falha inesperada ao gerar urls etáticas de arquivos para retornar, verifique a exceção", ex);
            }
        }

        public void PrepareFilesEditAtDirectory(string galleryFilesSave, string mainFileSave, List<FileBase64Model> galleryFilesReq, FileBase64Model mainReq, string entityName, string idEntity)
        {
            try
            {
                string[] galleryFiles =
                            galleryFilesSave != null ?
                            galleryFilesSave.Split(",") :
                            "".Split(",");

                FileManySaveModel fileDel = DeleteFilesMethodEditDirectory(galleryFilesReq,
                                                                mainReq,
                                                                entityName,
                                                                idEntity);

                if (fileDel is not null && !fileDel.MainName.Contains(mainFileSave))
                {
                    DeleteFilesDirectory(null,
                                         mainFileSave,
                                         entityName,
                                         idEntity);
                }

                List<string> galleryFilesSaves = new List<string>();
                foreach (string fileSave in galleryFiles)
                {
                    if (fileDel is not null && !fileDel.GalleryName.Contains(fileSave))
                    {
                        galleryFilesSaves.Add(fileSave);
                    }
                }
                DeleteFilesDirectory(string.Join(",", galleryFilesSaves),
                                     null,
                                     entityName,
                                     idEntity);
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
                throw new HandleFileException($"Falha ao preparar arquivos para edição da entidade '{entityName}' id '{idEntity}'", ex);
            }
        }

        public FileManySaveModel SaveFileBase64AtDirectory(List<FileBase64Model> galleryFiles, FileBase64Model fileMain, string entityName, string idEntity)
        {
            try
            {
                FileManySaveModel response = new FileManySaveModel();
                string folder = GetFolder(entityName, idEntity);

                if (fileMain != null)
                {
                    if (fileMain.FileBase64.StartsWith("http"))
                        response.MainName = fileMain.FileBase64.Split("/").LastOrDefault();
                    else
                    {
                        string fileNameSave = StaticMethods.SaveFileDirectoryFromBase64(folder, fileMain.FileBase64, DefaultNames.MainFile, _config.Base64Data);
                        if (string.IsNullOrEmpty(fileNameSave))
                            throw new HandleFileException($"Falha ao salvar o arquivo {fileMain.Name} para a entidade {entityName} de id {idEntity}");

                        response.MainName += fileNameSave;
                    }
                }

                if (galleryFiles != null)
                {
                    foreach (FileBase64Model file in galleryFiles)
                    {
                        if (file.FileBase64.StartsWith("http"))
                        {
                            string? filename = file.FileBase64.Split("/").LastOrDefault();
                            response.GalleryName += filename + ",";
                        }
                        else
                        {
                            string fileNameSave = StaticMethods.SaveFileDirectoryFromBase64(folder, file.FileBase64, file.Name, _config.Base64Data);
                            if (string.IsNullOrEmpty(fileNameSave))
                                throw new HandleFileException($"Falha ao salvar o arquivo {fileMain.Name} para a entidade {entityName} de id {idEntity}");

                            response.GalleryName += fileNameSave + ",";
                        }
                    }
                }
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
                throw new Exception($"Falha ao salvar galeria de arquivos para a entidade {entityName} de id {idEntity}", ex);
            }
        }

        public async Task<FileManySaveModel> SaveFileIFormFileAtDirectory(FileIFormFileModel formFile, string entityName, string idEntity)
        {
            try
            {
                FileManySaveModel response = new FileManySaveModel();
                response.MainName = null;

                if (formFile is null || formFile.Files.Count() <= 0)
                    throw new HandleFileException(ConstantsMessageFile.ErrorSaveManyFormFileNotInformed);

                string folder = GetFolder(entityName, idEntity);

                StaticMethods.DeleteFilesDirectory(folder);

                foreach (IFormFile file in formFile.Files)
                {
                    if (file.Length > 0)
                    {
                        string filename = $"{Guid.NewGuid().ToString("N")}_{file.FileName}";
                        string filepath = Path.Combine(folder, filename.ToUpper());

                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        using (FileStream stream = File.Create(filepath))
                        {
                            await file.CopyToAsync(stream);
                            if (response.MainName is null)
                                response.MainName = filename;
                            else
                                response.GalleryName += filename + ",";
                        }
                    }
                }
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
                throw new Exception($"Falha ao salvar galeria de arquivos via IFormFile para a entidade {entityName} de id {idEntity}", ex);
            }
        }

        private string BuildBase64File(string filePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                string extension = fileInfo.Extension.Split('.')[1];

                Base64Data? base64Data = _config.Base64Data.Where(x => x.Extension.Contains(extension)).FirstOrDefault();
                if (base64Data is null)
                    throw new HandleFileException($"Não foi encontrado um base64 dentre os informados que corresponda a extensão {extension}");

                byte[] fileBytes = File.ReadAllBytes(filePath);
                string fileBase64 = Convert.ToBase64String(fileBytes);

                string base64WithHeader = base64Data.MimeType + "," + fileBase64;
                return base64WithHeader;
            }
            catch (HandleFileException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HandleFileException($"Falha ao montar base64 de arquivo {filePath} para retornar");
            }
        }

        private string BuildUrlFile(string filePath, string idEntity, string entityName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                string urlFile = string.Concat(_config.BaseUrlApi,
                                               _config.PathAvailableStaticFile,
                                               entityName,
                                               "/Many/",
                                               idEntity,
                                               "/",
                                               fileInfo.Name);
                return urlFile;
            }
            catch (Exception ex)
            {
                throw new HandleFileException($"Falha ao gerar url para acesso ao arquivo {filePath} de forma estática", ex);
            }
        }

        private string GetFolder(string entityName, string idEntity, bool defaultImg = false)
        {
            try
            {
                string prefix = defaultImg ? "Default" : "Many";
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
