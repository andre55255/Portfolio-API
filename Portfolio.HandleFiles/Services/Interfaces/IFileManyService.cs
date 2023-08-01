using Portfolio.HandleFiles.Models;

namespace Portfolio.HandleFiles.Services.Interfaces
{
    public interface IFileManyService
    {
        public FileManySaveModel SaveFileBase64AtDirectory(List<FileBase64Model> galleryFiles, FileBase64Model fileMain, string entityName, string idEntity);

        public Task<FileManySaveModel> SaveFileIFormFileAtDirectory(FileIFormFileModel formFile, string entityName, string idEntity);

        public List<FileReturnModel> GetFilesDirectoryToUrl(string[] galleryFiles, string mainFile, string entityName, string idEntity);

        public void DeleteFilesDirectory(string galleryFiles, string mainFile, string entityName, string idEntity);

        public void PrepareFilesEditAtDirectory(string galleryFilesSave, string mainFileSave, List<FileBase64Model> galleryFilesReq, FileBase64Model mainReq, string entityName, string idEntity);

        public List<FileReturnModel> GetFilesDirectoryToBase64(string[] galleryFiles, string mainFile, string entityName, string idEntity);
    }
}
