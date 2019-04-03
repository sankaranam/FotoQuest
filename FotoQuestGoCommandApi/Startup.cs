using AutoMapper;
using FotoQuestGo.DataSubmissionService.Interfaces;
using FotoQuestGo.DataSubmissionService.Wireup;
using FotoQuestGoRepository.Data;
using FotoQuestGoRepository.wireup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FotoQuestGoCommandApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {        

            var connectionString = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<SubmissionDataContext>(options => options.UseSqlServer(connectionString));
            RepositoryDiConfig.WireUp(services);
            ServiceWireup.WireUp(services);
            services.AddAutoMapper(typeof(UserProfile));
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FotoQuest Go Command API", Version = "v1" });
                c.IncludeXmlComments(System.IO.Path.Combine(System.AppContext.BaseDirectory, "FotoQuestGoCommandApi.xml"));
                c.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FotoQuest Go Command API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var submissionService = serviceScope.ServiceProvider.GetService<SubmissionDataContext>();
                submissionService.Database.EnsureCreated();
            }           
        }
    }
}
