using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class Team : EntityBase
{
    public string? Name { get; set; }
    public ICollection<UserBase> Members { get; set; } = new List<UserBase>();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Team() {}
    public Team(string name)
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }
}
