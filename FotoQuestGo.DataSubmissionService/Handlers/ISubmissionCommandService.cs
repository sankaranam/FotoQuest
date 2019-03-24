using System.Collections.Generic;
using System.Threading.Tasks;
using FotoQuestGo.DataSubmissionService.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FotoQuestGo.DataSubmissionService.Handlers
{
    public interface ISubmissionCommandService
    {
        Task<SubmissionViewModel> SaveSubmission(SubmissionViewModel submissionViewModel, ICollection<IFormFile> files);
        ValidationResult IsValid(SubmissionViewModel submissionViewModel);
    }
}