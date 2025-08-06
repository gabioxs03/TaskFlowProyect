using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos;

namespace TaskFlow.Application.Interfaces;

public interface ITasksManagementService
{
    Task<IEnumerable<TaskItemModel.TaskItemResponse>> GetTasks();
    Task<TaskItemModel.TaskItemResponse> GetTaskById(Guid id);
    Task<TaskItemModel.TaskItemResponse> AddTask(TaskItemModel.TaskItemRequest resquest);
}
