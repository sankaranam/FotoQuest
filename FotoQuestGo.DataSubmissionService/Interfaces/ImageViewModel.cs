using FotoQuestGoRepository.Models;
using Microsoft.AspNetCore.Http;
using System;

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
        public string FileName { get; set; }
        /// <summary>
        /// SubmissionId
        /// </summary>
        public Guid? SubmissionId { get; set; }
        /// <summary>
        /// Direction of image
        /// </summary>
        public Direction Direction { get; set; }
    }
}
