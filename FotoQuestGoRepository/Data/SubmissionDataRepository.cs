using FotoQuestGoRepository.Models;

namespace FotoQuestGoRepository.Data
{
    public class SubmissionDataRepository : Repository<SubmissionData>, ISubmissionDataRepository
    {
        public SubmissionDataRepository(SubmissionDataContext context) : base(context)
        {
        }
        public SubmissionDataContext CarApiContext => Context as SubmissionDataContext;
    }
}
