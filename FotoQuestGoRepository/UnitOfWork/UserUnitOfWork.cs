using FotoQuestGoRepository.Data;
using System.Threading.Tasks;

namespace FotoQuestGoRepository.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly SubmissionDataContext _context;

        public UserUnitOfWork(SubmissionDataContext context,IUserRepository userRepository)
        {
            _context = context;
            UserRepository = userRepository;
        }
       public IUserRepository UserRepository { get; }

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
