using System;

namespace FotoQuestGo.DataSubmissionService.Interfaces
{
    public class QuestionnaireViewModel
    {
        /// <summary>
        /// Questionnaire Id
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// SubmissionId
        /// </summary>
        public Guid? SubmissionId { get; set; }
        /// <summary>
        /// Question
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// Answer
        /// </summary>
        public string Answer { get; set; }
    }
}
