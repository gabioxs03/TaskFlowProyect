using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class SubActivity : EntityBase
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public SubActivity() {}
    public SubActivity(string title, Guid activityId, string description = "")
    {
        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        ActivityId = activityId;
    }
    public Guid ActivityId { get; }
}
