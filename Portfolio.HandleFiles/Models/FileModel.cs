using Microsoft.AspNetCore.Http;

namespace Portfolio.HandleFiles.Models
{
    public class FileReturnModel
    {
        public string File { get; set; } = null;
        public string Name { get; set; } = null;
    }

    public class FileManySaveModel
    {
        public string MainName { get; set; } = "";
        public string GalleryName { get; set; } = "";
    }

    public class FileBase64Model
    {
        public string FileBase64 { get; set; } = null;
        public string Name { get; set; } = null;
    }

    public class FileIFormFileModel
    {
        public List<IFormFile> Files { get; set; } = null;
    }
}
