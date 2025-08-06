using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public class UserBase : EntityBase
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int PhoneNumber { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; } // Admin, User
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserBase() {}
    public UserBase(string name, string lastName, string email, int phoneNumber, string username, string password, string role)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Username = username;
        Password = password;
        Role = role;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}
