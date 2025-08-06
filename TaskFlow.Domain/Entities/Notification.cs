using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class Notification : EntityBase
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public bool IsRead { get; set; }
    public NotificationType NotificationType { get; set; }
    public DateTime CreatedAt { get; set; }
    public Notification() {}
    public Notification(string title, string message, NotificationType notificationType, Guid taskId)
    {
        Title = title;
        Message = message;
        IsRead = false;
        NotificationType = notificationType;
        CreatedAt = DateTime.UtcNow;
        TaskItemId = taskId;
    }
    public Guid TaskItemId { get; }
}
