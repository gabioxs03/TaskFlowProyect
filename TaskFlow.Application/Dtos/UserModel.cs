using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.Dtos;

public static class UserModel
{
    public record UserRequest(
        string Name,
        string LastName,
        string Email,
        int PhoneNumber,
        string Username,
        string Password,
        string Role
    );
    public record UserResponse(
        Guid Id,
        string Name,
        string LastName,
        string Email,
        int PhoneNumber,
        string Username,
        string Role,
        bool IsActive,
        DateTime CreatedAt
    );
}
