using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class Proyect : EntityBase
{
    public string? Name { get; set; }
    public List<Activity> Activities { get; set; } = new List<Activity>();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<UserBase> Users { get; set; } = new List<UserBase>();
    public Proyect() {}
    public Proyect(string name)
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }
}
