using FotoQuestGoRepository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FotoQuestGoRepository.Data
{
    public class ImageHandler : IImageHandler
    {
        public async Task SaveImage(Guid Id, IFormFile file)
        {
            var path = GetFilePath(Id, file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public async Task<FileData> GetFileStreamAsync(Guid Id, string filename)
        {
            var path = GetFilePath(Id, filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return new FileData { MemoryStream = memory, ContentType = GetContentType(path), FileName = filename };
        }

        public bool IsFileAvailable(Guid Id, string filename)
        {
            var path = GetFilePath(Id, filename);
            return File.Exists(path);
        }

        private static string GetFilePath(Guid Id, string fileName)
        {
            return Path.Combine(
                                  Directory.GetCurrentDirectory(), "images",
                                  Id.ToString() + "_" + fileName);
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"}
            };
        }
    }
}
