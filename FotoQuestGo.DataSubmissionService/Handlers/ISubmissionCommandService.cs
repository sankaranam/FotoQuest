using System.Threading.Tasks;
using FotoQuestGo.DataSubmissionService.Interfaces;

namespace FotoQuestGo.DataSubmissionService.Handlers
{
    public interface ISubmissionCommandService
    {
        Task SaveSubmission(SubmissionViewModel submissionViewModel);
        ValidationResult IsValid(SubmissionViewModel submissionViewModel);
    }
}