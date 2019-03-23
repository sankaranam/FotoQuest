using System;

namespace FotoQuestGoRepository.Models
{
    public class QuestionnaireData
    {
        public Guid Id { get; set; }
        public Guid SubmissionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
