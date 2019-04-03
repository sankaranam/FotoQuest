using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Question { get; set; }
        /// <summary>
        /// Answer
        /// </summary>
        [Required]
        public string Answer { get; set; }
    }
}
