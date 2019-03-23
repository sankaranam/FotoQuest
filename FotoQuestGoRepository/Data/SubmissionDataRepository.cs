using FotoQuestGoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoQuestGoRepository.Data
{
    public class SubmissionDataRepository : Repository<SubmissionData>, ISubmissionDataRepository
    {
        public SubmissionDataRepository(DbContext context) : base(context)
        {
        }
        public SubmissionDataContext CarApiContext => Context as SubmissionDataContext;
    }

    public class UserRepository : Repository<UserDetails>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
