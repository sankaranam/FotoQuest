using AutoMapper;
using FotoQuestGo.DataSubmissionService.Interfaces;
using FotoQuestGoRepository.Models;
using FotoQuestGoRepository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.DataSubmissionService.Handlers
{

    public class SubmissionCommandService : ISubmissionCommandService
    {
        private readonly ISubmissionUnitOfWork _submissionUnitOfWork;
        private readonly IImageHandler _imageHandler;
        private readonly IMapper _mapper;

        public SubmissionCommandService(ISubmissionUnitOfWork submissionUnitOfWork, IImageHandler imageHandler, IMapper mapper)
        {
            _submissionUnitOfWork = submissionUnitOfWork;
            _imageHandler = imageHandler;
            _mapper = mapper;
        }

        public ValidationResult IsValid(SubmissionViewModel submissionViewModel)
        {
            //TODO need to add validation here
            return new ValidationResult { IsValid = true , ErrorMessage = string.Empty};
        }

        public async Task<SubmissionViewModel> SaveSubmission(SubmissionViewModel submissionViewModel, ICollection<IFormFile> files)
        {
            var data = _mapper.Map<SubmissionData>(submissionViewModel);

            var detailsList = data.ImageList.ToList();
            foreach (var file in files)
            {
                var image = detailsList.First(x=>x.FileName == file.Name);
                var imageDetailResult = await _submissionUnitOfWork.ImageDetailsRepository.AddAsync(image);
                await _imageHandler.SaveImage(imageDetailResult.Id,file);
            }
            await _submissionUnitOfWork.QuestionnaireDataRepository.AddRangeAsync(data.Questionnaire);            
            var submissionData = await _submissionUnitOfWork.SubmissionDataRepository.AddAsync(data);
            await _submissionUnitOfWork.CompleteAsync();

            return _mapper.Map<SubmissionViewModel>(submissionData);
        }
    }
}
