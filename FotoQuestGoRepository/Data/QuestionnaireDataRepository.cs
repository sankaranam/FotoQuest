using FotoQuestGoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoQuestGoRepository.Data
{
    public class QuestionnaireDataRepository : Repository<QuestionnaireData>, IQuestionnaireDataRepository
    {
        public QuestionnaireDataRepository(SubmissionDataContext context) : base(context)
        {
        }
    }
}
