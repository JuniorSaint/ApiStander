using Api.Application.Interfaces;
using Api.Application.Services;
using Api.CrossCutting.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public static class InjectionService
    {
        public static void ConfigureDependenciesService(IServiceCollection services)
        {

            services.AddScoped<ISendEmailSerivce, SendEmailService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ILotService, LotService>();
            services.AddScoped<ISpeakerService, SpeakerService>();
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUpLoadService, UploadService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();


            services.AddAutoMapper(typeof(EntityToDtoProfile));
        }
    }
}