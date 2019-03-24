using AutoMapper;
using FotoQuestGo.DataSubmissionService.Interfaces;
using FotoQuestGoRepository.Models;
using FotoQuestGoRepository.UnitOfWork;
using System.Collections.Generic;
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
            return new ValidationResult { IsValid = true , ErrorMessage = string.Empty};
        }

        public async Task SaveSubmission(SubmissionViewModel submissionViewModel)
        {
            var data = _mapper.Map<SubmissionData>(submissionViewModel);

            var imageList = new List<ImageDetails>();
            foreach (var imageFile in submissionViewModel.ImageList)
            {
                var image = _mapper.Map<ImageDetails>(imageFile);
                image.FileName = imageFile.File.FileName;
                await _imageHandler.SaveImage(imageFile.Id.Value,imageFile.File);
            }

            await _submissionUnitOfWork.QuestionnaireDataRepository.AddRangeAsync(data.Questionnaire);
            await _submissionUnitOfWork.ImageDetailsRepository.AddRangeAsync(data.ImageList);
            await _submissionUnitOfWork.SubmissionDataRepository.AddAsync(data);
            await _submissionUnitOfWork.CompleteAsync();
        }
    }
}
