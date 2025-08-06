using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos;

namespace TaskFlow.Application.Interfaces;

public interface IUsersManagementService
{
    Task<UserModel.UserResponse> AddUser(UserModel.UserRequest request);
    Task<IEnumerable<UserModel.UserResponse>> GetAllUsers();
    Task<UserModel.UserResponse> GetUserById(Guid id);
    Task<UserModel.UserResponse> DisableUser(Guid id);
}
