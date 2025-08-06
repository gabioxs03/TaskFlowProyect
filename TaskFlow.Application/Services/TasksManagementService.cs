using Dsw2025Ej15.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Services;

public class TasksManagementService : ITasksManagementService
{
    private readonly IRepository _repository;
    public TasksManagementService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TaskItemModel.TaskItemResponse>> GetTasks()
    {
        var tasks = await _repository.GetFiltered<TaskItem>(t => t.Status != TaskItemStatus.Completed);
        if (tasks == null || !tasks.Any()) throw new ArgumentException("No hay tareas creadas.");
        return tasks!.Select(t => new TaskItemModel.TaskItemResponse(
            t.Id,
            t.Title!,
            t.Description!,
            t.Status.ToString(),
            t.Priority.ToString(),
            t.CreatedAt,
            t.UserId
        ));
    }
    public async Task<TaskItemModel.TaskItemResponse> GetTaskById(Guid id)
    {
        var task = await _repository.GetById<TaskItem>(id);
        if (task == null) throw new EntityNotFoundException($"No se encontró una tarea con id: {id}.");
        return new TaskItemModel.TaskItemResponse(
            task.Id,
            task.Title!,
            task.Description!,
            task.Status.ToString(),
            task.Priority.ToString(),
            task.CreatedAt,
            task.UserId
        );
    }
    public async Task<TaskItemModel.TaskItemResponse> AddTask(TaskItemModel.TaskItemRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Description)
            || request.UserId == Guid.Empty || string.IsNullOrWhiteSpace(request.Priority.ToString()))
        {
            throw new ArgumentException("Valores para la tarea no válidos");
        }
        var task = new TaskItem(request.Title, request.Description, request.Priority, request.UserId);
        await _repository.Add(task);
        return new TaskItemModel.TaskItemResponse(
            task.Id,
            task.Title!,
            task.Description!,
            task.Status.ToString(),
            task.Priority.ToString(),
            task.CreatedAt,
            task.UserId
        );
    }
}
