using FotoQuestGoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoQuestGoRepository.Data
{
    public class ImageDetailsRepository : Repository<ImageDetails>, IImageDetailsRepository
    {
        public ImageDetailsRepository(SubmissionDataContext context) : base(context)
        {
        }
    }
}
