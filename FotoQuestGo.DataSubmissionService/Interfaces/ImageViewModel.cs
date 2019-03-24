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
        /// File
        /// </summary>
        public IFormFile File { get; set; }
        /// <summary>
        /// SubmissionId
        /// </summary>
        public Guid? SubmissionId { get; set; }
        /// <summary>
        /// Direction North=0, East=1, South=2, West=3, Ground=4
        /// </summary>
        public Direction Direction { get; set; }
    }
}
