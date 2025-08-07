using Dsw2025Ej15.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Api.Controllers;

[Route("api/tasks")]
[ApiController]
public class TasksItemsController : ControllerBase   
{
    private readonly ITasksManagementService _service;
    public TasksItemsController(ITasksManagementService tasksManagementService)
    {
        _service = tasksManagementService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        try
        {
            var tasks = await _service.GetTasks();
            return Ok(tasks);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        try
        {
            var task = await _service.GetTaskById(id);
            return Ok(task);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] TaskItemModel.TaskItemRequest request)
    {
        try
        {
            var task = await _service.AddTask(request);
            return Created("/task", task);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
