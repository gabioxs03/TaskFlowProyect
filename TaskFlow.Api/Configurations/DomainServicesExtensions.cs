using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;
using TaskFlow.Data;
using TaskFlow.Data.Repositories;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Api.Configurations;

public static class DomainServicesConfigurationExtension
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskFlowContext>(options =>
        {

            services.AddDbContext<TaskFlowContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("TaskFlowEntities")));
            /*options.UseSeeding((c, t) =>
                {
                    ((Dsw2025Ej15Context)c).Seedwork<Category>("Sources\\categories.json");
                    ((Dsw2025Ej15Context)c).Seedwork<SubCategory>("Sources\\sub-categories.json");
                    ((Dsw2025Ej15Context)c).Seedwork<Product>("Sources\\products.json");
                });*/
        });
        services.AddScoped<IRepository, EfRepository>();
        services.AddTransient<ITasksManagementService, TasksManagementService>();
        services.AddTransient<IUsersManagementService, UsersManagementService>();

        return services;
    }
}
