using Application.Helpers;
using Infrastructure.Data;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBookServices, BookServices>();
        services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
        services.AddAutoMapper(typeof(MappingProfiles));

        return services;
    }
}