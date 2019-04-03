using FotoQuestGoRepository.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FotoQuestGo.DataSubmissionService.Interfaces
{
    public class ImageViewModel
    {
        /// <summary>
        /// Image Id
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// FileName
        /// </summary>
        [Required]
        public string FileName { get; set; }
        /// <summary>
        /// SubmissionId
        /// </summary>
        public Guid? SubmissionId { get; set; }
        /// <summary>
        /// Direction of image
        /// </summary>
        [Required]
        public Direction Direction { get; set; }
    }
}
