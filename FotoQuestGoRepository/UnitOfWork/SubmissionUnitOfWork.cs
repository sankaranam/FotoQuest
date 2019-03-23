using FotoQuestGoRepository.Data;

namespace FotoQuestGoRepository.UnitOfWork
{
    public class SubmissionUnitOfWork : ISubmissionUnitOfWork
    {
        private readonly SubmissionDataContext _context;

        public SubmissionUnitOfWork(SubmissionDataContext context, ISubmissionDataRepository submissionDataRepository, IQuestionnaireDataRepository questionnaireDataRepository, IImageDetailsRepository imageDetailsRepository)
        {
            _context = context;
            SubmissionDataRepository = submissionDataRepository;
            QuestionnaireDataRepository = questionnaireDataRepository;
            ImageDetailsRepository = imageDetailsRepository;
        }

        public ISubmissionDataRepository SubmissionDataRepository { get; }
        public IQuestionnaireDataRepository QuestionnaireDataRepository { get; }
        public IImageDetailsRepository ImageDetailsRepository { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
