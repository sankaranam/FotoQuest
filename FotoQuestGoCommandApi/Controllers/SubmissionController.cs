using FotoQuestGoRepository.Models;
using FotoQuestGoRepository.UnitOfWork;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FotoQuestGoCommandApi.Controllers
{
    [Route("api/fotoquestgo/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionUnitOfWork _submissionUnitOfWork;

        public SubmissionController(ISubmissionUnitOfWork submissionUnitOfWork)
        {
            _submissionUnitOfWork = submissionUnitOfWork;
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public void Get()
        {
            var data = new SubmissionData();
            data.Coordinates = "0,0";
            var subId = Guid.NewGuid();
            data.Id = subId;
            data.TimeStamp = DateTimeOffset.UtcNow;
            data.UserId = Guid.NewGuid();
            data.Questionnaire = new List<QuestionnaireData> { new QuestionnaireData {
                SubmissionId = subId ,Id = Guid.NewGuid(),
                Question = "Q1",Answer="Ans1"} };
            data.ImageList = new List<ImageDetails> { new ImageDetails {SubmissionId= subId,
                Id = Guid.NewGuid(),Direction=Direction.East } };

            _submissionUnitOfWork.QuestionnaireDataRepository.AddRange(data.Questionnaire);
            _submissionUnitOfWork.ImageDetailsRepository.AddRange(data.ImageList);
            _submissionUnitOfWork.SubmissionDataRepository.Add(data);
            _submissionUnitOfWork.Complete();
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public void Submit(SubmissionData data)
        {
            _submissionUnitOfWork.QuestionnaireDataRepository.AddRange(data.Questionnaire);
            _submissionUnitOfWork.ImageDetailsRepository.AddRange(data.ImageList);
            _submissionUnitOfWork.SubmissionDataRepository.Add(data);
            _submissionUnitOfWork.Complete();
        }
    }
}