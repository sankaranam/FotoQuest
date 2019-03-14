using System;

namespace FotoQuestGoRepository.Models
{
    class SubmissionData    
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Coordinates { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
