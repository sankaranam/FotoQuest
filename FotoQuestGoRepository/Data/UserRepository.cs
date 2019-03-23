using FotoQuestGoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoQuestGoRepository.Data
{
    public class UserRepository : Repository<UserDetails>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
        }
    }
}
