using FotoQuestGoRepository.Models;

namespace FotoQuestGoRepository.Data
{
    public class UserRepository : Repository<UserDetails>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
        }
    }
}
