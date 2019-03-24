using FotoQuestGo.DataSubmissionService.Handlers;
using System;
using System.ComponentModel.DataAnnotations;

namespace FotoQuestGo.DataSubmissionService.Interfaces
{
    public class ImageQueryViewModel
    {
        /// <summary>
        /// SubmissionId
        /// </summary>
        [Required]
        public Guid? SubmissionId { get; set; }
        /// <summary>
        /// ImageId
        /// </summary>
        [Required]
        public Guid? ImageId { get; set; }
        /// <summary>
        /// FileName
        /// </summary>
        [Required]
        public string FileName { get; set; }
        [Required]
        /// <summary>
        /// ImageVersion
        /// </summary>
        [EnumDataType(typeof(ImageVersion))]
        public ImageVersion ImageVersion { get; set; }
        /// <summary>
        /// Width if ImageVersion is custom
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Height if ImageVersion is custom
        /// </summary>
        public int? Height { get; set; }
    }
}
