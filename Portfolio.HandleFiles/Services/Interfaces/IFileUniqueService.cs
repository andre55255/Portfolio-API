using Portfolio.HandleFiles.Models;
using Microsoft.AspNetCore.Http;

namespace Portfolio.HandleFiles.Services.Interfaces
{
    public interface IFileUniqueService
    {
        public void DeleteFileAtDirectory(string entityName, string idEntity, string nameFile);

        public void SaveFileBase64AtDirectory(FileBase64Model file, string entityName, string idEntity);

        public Task SaveFileStreamAtDirectory(HttpRequest request, string entityName, string idEntity);

        public FileReturnModel GetFileUrlAtDirectory(string entityName, string idEntity, string nameFile, bool defaultImage = false);

        public FileReturnModel GetFileBase64ZipedAtDirectory(string entityName, string idEntity, string nameFile);

        public FileReturnModel GetFileBase64AtDirectory(string entityName, string idEntity, string nameFile, bool defaultImage = false);
    }
}
