using System;
using Api.Data.Context;
using Api.Data.Repositories;
using Api.Domain.Interfaces;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public static class InjectionRepository
    {
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "ApiStander";
        private static string Password = "m2166446JR";
        private static string Port = "5432";

        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {

            // configure Connection with data base
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql($"Server={Host}; Port={Port}; Database={DBname}; Uid={User}; Pwd={Password}",
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // configure Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ILotRepository, LotRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<IListSocialMediaRepository, ListSocialMediaRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}

