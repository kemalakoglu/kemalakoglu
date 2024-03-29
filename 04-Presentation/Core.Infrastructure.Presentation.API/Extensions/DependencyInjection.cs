﻿using Core.Infrastructure.Application.Contract.Services;
using Core.Infrastructure.Application.Service;
using Core.Infrastructure.Application.UnitOfWork;
using Core.Infrastructure.Core.Contract;
using Core.Infrastructure.Domain.Aggregate.RefTypeValue;
using Core.Infrastructure.Domain.Aggregate.User;
using Core.Infrastructure.Domain.Context.Context;
using Core.Infrastructure.Domain.Contract.Service;
using Core.Infrastructure.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Presentation.API.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<InfrastructureContext>(o => o.UseSqlServer(connectionString));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<InfrastructureContext>()
            //    .AddDefaultTokenProviders();
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureDomainService(this IServiceCollection services)
        {
            services.AddScoped<IUserManagerService, UserStoreService>();
            services.AddScoped<IRefTypeService, RefTypeService>();
            services.AddScoped<IRefValueService, RefValueService>();
            services.AddScoped<ISignInManagerService, SignInManagerService>();
        }

        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ICoreApplicationService, CoreApplicationService>();
        }

        public static void ConfigureAttributes(this IServiceCollection services)
        {
            services.AddScoped<JWTRefreshTokenAttribute>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}