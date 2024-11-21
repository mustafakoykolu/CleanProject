using AutoMapper;
using CleanProject.Application.MappingProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace CleanProject.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices (this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new LeaveTypeProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper ();
        services.AddSingleton(mapper);
        services.AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;

    }

}
