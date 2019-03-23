using FotoQuestGoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoQuestGoRepository.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<UserDetails> users { get; set; }
    }
}
