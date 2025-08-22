using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class Activity : EntityBase
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ActivityPriority Priority { get; set; }
    public ActivityStatus Status { get; set; }
    public List<SubActivity> SubActivities { get; set; } = new List<SubActivity>();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public Activity() {}
    public Activity(string title, string description, ActivityPriority priority, Guid proyectId, List<SubActivity>? subActivities = null)
    {
        Title = title;
        Description = description;
        Status = ActivityStatus.Pending;
        Priority = priority;
        CreatedAt = DateTime.UtcNow;
        SubActivities = subActivities ?? [];
        ProyectId = proyectId;
    }
    public Guid ProyectId { get; }
}
