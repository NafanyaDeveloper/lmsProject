
using LMS.AUTH.Interfaces;
using LMS.AUTH.Services;
using LMS.CORE.EF;
using LMS.CORE.Repositories;
using LMS.CORE.Services;
using LMS.DATA.Entities;
using LMS.DATA.Repositories;
using LMS.DATA.Supervisor;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.API.Configurations
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.
                AddTransient<IAdministrationRepository, AdministrationRepository>()
                .AddTransient<IAdministrationRoleRepository, AdministrationRoleRepository>()
                .AddTransient<IAnswerRepository, AnswerRepository>()
                .AddTransient<IBlockRepository, BlockRepository>()
                .AddTransient<IBlockTypeRepository, BlockTypeRepository>()
                .AddTransient<ICourseRepository, CourseRepository>()
                .AddTransient<IDirectionRepository, DirectionRepository>()
                .AddTransient<IGroupRepository, GroupRepository>()
                .AddTransient<IPageRepository, PageRepository>()
                .AddTransient<IParticipantRepository, ParticipantRepository>()
                .AddTransient<IParticipantRoleRepository, ParticipantRoleRepository>()
                .AddTransient<IQuestionRepository, QuestionRepository>()
                .AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddSupervisor(this IServiceCollection services)
        {
            services.AddTransient<ILMSSupervisor, LMSSupervisor>();

            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .Build());
            });

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IFileLoader, FileLoader>()
                .AddTransient<IJwtGenerator, JwtGenerator>()
                .AddTransient<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<LMSContext>()
                .AddDefaultTokenProviders();

            return services;
        }


    }
}
