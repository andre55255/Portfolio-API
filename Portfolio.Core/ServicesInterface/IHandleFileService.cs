using Portfolio.HandleFiles.Models;

namespace Portfolio.Core.ServicesInterface
{
    public interface IHandleFileService
    {
        public void SaveFileUniqueBase64AtDirectory(FileBase64Model file, string entityName, string nameFile, string idEntity);
        public void UpdateFileUniqueBase64AtDirectory(FileBase64Model file, string entityName, string nameFile, string idEntity);
        public void DeleteFileUniqueAtDirectory(string entityName, string idEntity, string nameFile);
        public FileBase64Model GetUrlFileUniqueAtDirectory(string entityName, string idEntity, string nameFile, bool defaultImage = false);
    }
}
