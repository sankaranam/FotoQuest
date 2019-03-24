using FotoQuestGoRepository.Data;
using System.Threading.Tasks;

namespace FotoQuestGoRepository.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly UserContext _context;

        public UserUnitOfWork(UserContext context,IUserRepository userRepository)
        {
            _context = context;
            UserRepository = userRepository;
        }

        public IUserRepository UserRepo => throw new System.NotImplementedException();

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
