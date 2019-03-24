using System;
using System.Threading.Tasks;
using FotoQuestGo.DataSubmissionService.Interfaces;
using FotoQuestGoRepository.UnitOfWork;

namespace FotoQuestGo.DataSubmissionService.Handlers
{
    public interface ISubmissionQueryService
    {
        Task<FileData> GetFile(Guid ImageId,string filename, ImageVersion imageVersion, int? width = 0, int? height = 0);
        SubmissionViewModel Get(Guid Id);
        bool Validate(ImageQueryViewModel imageQueryViewModel);
    }
}