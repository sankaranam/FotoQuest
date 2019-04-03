using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FotoQuestGo.DataSubmissionService.Interfaces
{
    public class SubmissionViewModel
    {
        /// <summary>
        /// SubmissionId
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Coordinates of location
        /// </summary>
        [Required]
        public string Coordinates { get; set; }
        /// <summary>
        /// Submission TimeStamp
        /// </summary>
        [Required]
        public DateTimeOffset? TimeStamp { get; set; }
        /// <summary>
        /// Submission related ImageMetaDataList
        /// </summary>
        [DataType("Array<ImageViewModel>")]
        [Required]
        public ICollection<ImageViewModel> ImageMetaDataList { set; get; }
        /// <summary>
        /// Submission related list of Question
        /// </summary>
        [DataType("Array<QuestionnaireViewModel>")]
        [Required]
        public ICollection<QuestionnaireViewModel> Questionnaire { get; set; }
    }
}
