using AutoMapper;
using BLL.Contracts.DTObjects;
using BLL.Contracts.Managers;
using BLL.Contracts.Services;
using BLL.Implementations.Managers;
using BLL.Implementations.Services;
using DAL.Contracts.Repositories;
using DAL.Core;
using DAL.Implementations.Repositories;
using DI.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class ComponentRegistrar
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            services
                .AddScoped<ISendInvitesRequestValidationService<SendInvitesDto>, SendInvitesRequestValidationService>();
            services.AddScoped<ISmsService, SmsService>();

            services.ConfigureAutoMapper();

            return services;
        }

        private static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<SendInvitesMappingProfile>();
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            return services;
        }
    }
}
