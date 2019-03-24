using System;
using System.Threading.Tasks;
using FotoQuestGo.DataSubmissionService.Handlers;
using FotoQuestGo.DataSubmissionService.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FotoQuestGoQueryApi.Controllers
{
    /// <summary>
    /// Submission data query controller.
    /// </summary>
    [Route("api/fotoquest/[controller]")]
    public class SubmissionQueryController : ControllerBase
    {
        private readonly ISubmissionQueryService _submissionQueryService;

        /// <summary>
        /// Submission data query controller ctor.
        /// </summary>
        public SubmissionQueryController(ISubmissionQueryService submissionQueryService)
        {
            _submissionQueryService = submissionQueryService;
        }

        /// <summary>
        /// Get Submission data for Id
        /// </summary>
        /// <returns>OK</returns>
        /// <returns>BadRequest</returns>
        [HttpGet("{id}")]
        [EnableCors("AllowAllOrigins")]
        [ProducesResponseType(typeof(SubmissionViewModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid? id)
        {
            if (id.HasValue == false)
            {
                return BadRequest();
            }

            var submissionViewModel = _submissionQueryService.Get(id.Value);
            if (submissionViewModel == null)
            {
                return NotFound();
            }

            return Ok(submissionViewModel);
        }

        /// <summary>
        /// Get Submitted images.
        /// </summary>
        /// <returns>OK</returns>
        /// <returns>BadRequest</returns>
        /// api/fotoquest/SubmissionQuery/image
        [HttpGet("Image")]
        [EnableCors("AllowAllOrigins")]
        [ProducesResponseType(typeof(FileStreamResult),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetImage(ImageQueryViewModel imageQueryViewModel)
        {
            var isValidQuery = _submissionQueryService.Validate(imageQueryViewModel);
            if (isValidQuery == false)
            {
                return BadRequest();
            }
            var memData = await _submissionQueryService.GetFile(imageQueryViewModel.ImageId.Value, imageQueryViewModel.FileName, ImageVersion.Thumbnail, imageQueryViewModel.Width, imageQueryViewModel.Height);
            return File(memData.MemoryStream, memData.ContentType, memData.FileName);
        }
    }   
}