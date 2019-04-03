using FotoQuestGoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoQuestGoRepository.Data
{
    public class SubmissionDataContext : DbContext
    {
        public SubmissionDataContext(DbContextOptions<SubmissionDataContext> options) : base(options)
        {
        }

        public DbSet<SubmissionData> Submissions { get; set; }

        public DbSet<QuestionnaireData> QuestionnaireDatas { get; set; }

        public DbSet<ImageDetails> ImageDetails { get; set; }

        public DbSet<UserDetails> UserDetails { get; set; }
    }    
}
