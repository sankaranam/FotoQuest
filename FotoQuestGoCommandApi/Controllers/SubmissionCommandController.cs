﻿using FotoQuestGo.DataSubmissionService.Handlers;
using FotoQuestGo.DataSubmissionService.Interfaces;
using FotoQuestGoRepository.Models;
using FotoQuestGoRepository.UnitOfWork;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FotoQuestGoCommandApi.Controllers
{
    /// <summary>
    /// Submission data command controller.
    /// </summary>
    [Route("api/fotoquest/[controller]")]
    public class SubmissionCommandController : ControllerBase
    {
        private readonly ISubmissionCommandService _submissionCommandService;

        public SubmissionCommandController(ISubmissionCommandService submissionCommandService)
        {
            _submissionCommandService = submissionCommandService;
        }

        /// <summary>
        /// Submit the FotoQuest data
        /// </summary>
        /// <returns>OK</returns>
        /// <returns>BadRequest</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubmitData(SubmissionViewModel submissionViewModel)
        {
            var validationresult = _submissionCommandService.IsValid(submissionViewModel);
            if (validationresult.IsValid == false)
            {
                return BadRequest(validationresult.ErrorMessage);
            }

            await _submissionCommandService.SaveSubmission(submissionViewModel);

            return Ok();
        }
    }
}