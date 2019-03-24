using AutoMapper;
using FotoQuestGo.DataSubmissionService.Interfaces;
using FotoQuestGoRepository.UnitOfWork;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FotoQuestGo.DataSubmissionService.Handlers
{
    public class SubmissionQueryService : ISubmissionQueryService
    {
        private readonly ISubmissionUnitOfWork _submissionUnitOfWork;
        private readonly IImageHandler _imageHandler;
        private readonly IMapper _mapper;

        public SubmissionQueryService(ISubmissionUnitOfWork submissionUnitOfWork, IImageHandler imageHandler, IMapper mapper)
        {
            _submissionUnitOfWork = submissionUnitOfWork;
            _imageHandler = imageHandler;
            _mapper = mapper;
        }

        public SubmissionViewModel Get(Guid Id)
        {
            var data = _submissionUnitOfWork.SubmissionDataRepository.Get(Id);
            return _mapper.Map<SubmissionViewModel>(data);
        }

        public async Task<FileData> GetFile(Guid id, string filename, ImageVersion imageVersion, int? width = 0, int? height = 0)
        {
            if (imageVersion == ImageVersion.Custom)
            {
                return await GetFileFromFolder(id, filename, width.Value, height.Value);
            }
            var size = GetSize(imageVersion);
            return await GetFileFromFolder(id, filename, size, size);
        }

        public bool Validate(ImageQueryViewModel imageQueryViewModel)
        {
            if (imageQueryViewModel.ImageVersion == ImageVersion.Custom)
            {
                if (imageQueryViewModel.Width.HasValue == false || imageQueryViewModel.Height.HasValue == false)
                {
                    return false;
                }
            }
            return _imageHandler.IsFileAvailable(imageQueryViewModel.ImageId.Value, imageQueryViewModel.FileName);
        }

        private async Task<FileData> GetFileFromFolder(Guid id, string filename, int width, int height)
        {
            var filedata = await _imageHandler.GetFileStreamAsync(id, filename);
            using (var image = Image.Load(filedata.MemoryStream))
            {
                filedata.MemoryStream.Dispose();
                image.Mutate(x => x.Resize(width, height));
                var memory = new MemoryStream();
                image.SaveAsJpeg(memory);
                memory.Position = 0;
                filedata.MemoryStream = memory;
            }
            return filedata;
        }

        private int GetSize(ImageVersion imageVersion)
        {
            var imageSizeMap = new Dictionary<ImageVersion, int> {
                { ImageVersion.Thumbnail,128},
                { ImageVersion.Small,512},
                { ImageVersion.Large,2048},
                { ImageVersion.Custom,0}
            };

            return imageSizeMap[imageVersion];
        }
    }
}
