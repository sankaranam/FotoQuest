using System;
using System.Collections.Generic;

namespace FotoQuestGoRepository.Models
{
    public class SubmissionData    
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Coordinates { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public ICollection<ImageDetails> ImageList { set; get; }
        public ICollection<QuestionnaireData> Questionnaire { get; set; }
    }    
}
