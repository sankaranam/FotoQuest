using System;

namespace FotoQuestGoRepository.Models
{
    // image will be stored in file system. Only maping data is stored here.
    class ImageDetails
    {
        public Guid Id { get; set; }
        public Guid SubmissionId { get; set; }
    }
}
