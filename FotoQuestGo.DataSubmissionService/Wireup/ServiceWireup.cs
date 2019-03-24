using FotoQuestGo.DataSubmissionService.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace FotoQuestGo.DataSubmissionService.Wireup
{
    public static class ServiceWireup
    {
        public static void WireUp(IServiceCollection services)
        {
            services.AddScoped<ISubmissionCommandService, SubmissionCommandService>();
            services.AddScoped<ISubmissionQueryService,SubmissionQueryService>();
        }
    }
}
