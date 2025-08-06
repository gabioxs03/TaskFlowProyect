
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;
using TaskFlow.Data;
using TaskFlow.Data.Repositories;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TaskFlowContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TaskFlowEntities"))
            );

            builder.Services.AddScoped<IRepository, EfRepository>();
            builder.Services.AddTransient<ITasksManagementService, TasksManagementService>();
            builder.Services.AddTransient<IUsersManagementService, UsersManagementService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
