using FotoQuestGoRepository.Data;
using System;
using System.Threading.Tasks;

namespace FotoQuestGoRepository.UnitOfWork
{
    public interface ISubmissionUnitOfWork : IDisposable
    {
        ISubmissionDataRepository SubmissionDataRepository { get; }
        IQuestionnaireDataRepository QuestionnaireDataRepository { get; }
        IImageDetailsRepository ImageDetailsRepository { get; }
        Task<int> CompleteAsync();
    }
}
