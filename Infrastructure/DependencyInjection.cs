﻿global using Domain.Abstraction;
global using Domain.Models;

using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<UserDbContext>(options =>
            { 
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")); 
            });

            return services;
        }
    }
}
