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
        public string Coordinates { get; set; }
        /// <summary>
        /// Submission TimeStamp
        /// </summary>
        public DateTimeOffset? TimeStamp { get; set; }
        /// <summary>
        /// Submission related ImageMetaDataList
        /// </summary>
        [DataType("Array<ImageViewModel>")]
        public ICollection<ImageViewModel> ImageMetaDataList { set; get; }
        /// <summary>
        /// Submission related list of Question
        /// </summary>
        [DataType("Array<QuestionnaireViewModel>")]
        public ICollection<QuestionnaireViewModel> Questionnaire { get; set; }
    }
}
