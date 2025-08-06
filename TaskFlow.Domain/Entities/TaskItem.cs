using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class TaskItem : EntityBase
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TaskItemPriority Priority { get; set; }
    public TaskItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public TaskItem() {}
    public TaskItem(string title, string description, TaskItemPriority priority, Guid userId)
    {
        Title = title;
        Description = description;
        Status = TaskItemStatus.Pending;
        Priority = priority;
        CreatedAt = DateTime.UtcNow;
        UserId = userId;
    }
    public Guid UserId { get; }
}
