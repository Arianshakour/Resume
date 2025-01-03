using Microsoft.CodeAnalysis.CSharp.Syntax;
using Resume.Bus.Services.Implementation;
using Resume.Bus.Services.Interfaces;
using Resume.DLA.Repositories.Implementation;
using Resume.DLA.Repositories.Interfaces;

namespace Resume.MVC.Configuratoins
{
	public static class DiContainer
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactUsRespository, ContactUsRespository>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IAboutMeRespository, AboutMeRespository>();
            services.AddScoped<IAboutMeService, AboutMeService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IEducationRepository, EducationRepository>();
			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IJobService, JobService>();
		}
    }
}
