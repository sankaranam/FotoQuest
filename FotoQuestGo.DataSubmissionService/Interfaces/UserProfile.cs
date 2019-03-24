using AutoMapper;
using FotoQuestGoRepository.Models;

namespace FotoQuestGo.DataSubmissionService.Interfaces
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SubmissionData, SubmissionViewModel>();
            CreateMap<ImageDetails, ImageViewModel>();
            CreateMap<QuestionnaireData, QuestionnaireViewModel>();
            CreateMap<UserDetails, UserViewModel>();

            CreateMap<SubmissionViewModel, SubmissionData>();
            CreateMap< ImageViewModel,ImageDetails>();
            CreateMap< QuestionnaireViewModel,QuestionnaireData>();
            CreateMap< UserViewModel,UserDetails>();
        }
    }
}
