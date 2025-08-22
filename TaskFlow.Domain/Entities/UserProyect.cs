using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class UserProyect : EntityBase
{
    public string? Role { get; set; } // Owner, Editor, Viewer
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool CanEdit { get; set; }
    public UserProyect() {}
    public UserProyect(Guid userId, Guid proyectId, string role)
    {
        UserId = userId;
        ProyectId = proyectId;
        Role = role;
        CanEdit = role == "Owner" || role == "Editor" ? true : false;
        CreatedAt = DateTime.UtcNow;
    }
    public required UserBase User { get; set; }
    public Guid UserId { get; }
    public required Proyect Proyect { get; set; }
    public Guid ProyectId { get; }
}
