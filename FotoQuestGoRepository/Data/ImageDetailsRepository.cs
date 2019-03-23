using FotoQuestGoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoQuestGoRepository.Data
{
    public class ImageDetailsRepository : Repository<ImageDetails>, IImageDetailsRepository
    {
        public ImageDetailsRepository(DbContext context) : base(context)
        {
        }
    }
}
