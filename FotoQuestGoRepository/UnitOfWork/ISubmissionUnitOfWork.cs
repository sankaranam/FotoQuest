using FotoQuestGoRepository.Data;
using System;

namespace FotoQuestGoRepository.UnitOfWork
{
    public interface ISubmissionUnitOfWork : IDisposable
    {
        ISubmissionDataRepository SubmissionDataRepository { get; }
        IQuestionnaireDataRepository QuestionnaireDataRepository { get; }
        IImageDetailsRepository ImageDetailsRepository { get; }
        int Complete();
    }
}
