using FotoQuestGoRepository.Data;
using FotoQuestGoRepository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace FotoQuestGoRepository.wireup
{
    public static class RepositoryDiConfig
    {
        public static void WireUp(IServiceCollection services)
        {
            services.AddScoped<ISubmissionDataRepository, SubmissionDataRepository>();
            services.AddScoped<IQuestionnaireDataRepository, QuestionnaireDataRepository>();
            services.AddScoped<IImageDetailsRepository, ImageDetailsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ISubmissionUnitOfWork, SubmissionUnitOfWork>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
        }
    }
}
