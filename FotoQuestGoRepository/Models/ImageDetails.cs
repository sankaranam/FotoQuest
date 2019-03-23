using System;

namespace FotoQuestGoRepository.Models
{
    // image will be stored in file system. Only maping data is stored here.
    public class ImageDetails
    {
        public Guid Id { get; set; }
        public Guid SubmissionId { get; set; }
        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West,
        Ground
    }
}
