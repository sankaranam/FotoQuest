using FotoQuestGoRepository.Data;
using System.Threading.Tasks;

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

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
