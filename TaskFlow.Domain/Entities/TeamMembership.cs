using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class TeamMembership : EntityBase
{
    public string? Role { get; set; } // Admin, Member, Viewer
    public DateTime JoinedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool CanEdit { get; set; }
    public TeamMembership() {}
    public TeamMembership(Guid userId, Guid teamId, string role)
    {
        UserId = userId;
        TeamId = teamId;
        Role = role;
        CanEdit = role == "Admin" || role == "Member" ? true : false;
        JoinedAt = DateTime.UtcNow;
    }
    public required UserBase User { get; set; }
    public Guid UserId { get; }
    public required Team Team { get; set; }
    public Guid TeamId { get; }
}
