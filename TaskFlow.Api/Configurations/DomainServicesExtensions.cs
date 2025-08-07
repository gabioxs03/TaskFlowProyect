using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;
using TaskFlow.Data;
using TaskFlow.Data.Helpers;
using TaskFlow.Data.Repositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Api.Configurations;

public static class DomainServicesConfigurationExtension
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskFlowContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("TaskFlowEntities"));
            /*options.UseSeeding((c, t) =>
            {
                ((TaskFlowContext)c).Seedwork<UserBase>("Sources\\users.json");

            });*/
        });
        services.AddScoped<IRepository, EfRepository>();
        services.AddTransient<ITasksManagementService, TasksManagementService>();
        services.AddTransient<IUsersManagementService, UsersManagementService>();

        return services;
    }
}
