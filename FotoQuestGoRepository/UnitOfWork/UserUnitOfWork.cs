using FotoQuestGoRepository.Data;

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
