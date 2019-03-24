using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FotoQuestGoRepository.UnitOfWork
{
    public interface IImageHandler
    {
        bool IsFileAvailable(Guid Id, string filename);
        Task SaveImage(Guid Id, IFormFile file);
        Task<FileData> GetFileStreamAsync(Guid Id, string filename);
    }

    public class FileData
    {
        public MemoryStream MemoryStream { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}