using Azure.Core;
using Dsw2025Ej15.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Services;

public class UsersManagementService : IUsersManagementService
{
    private readonly IRepository _repository;
    public UsersManagementService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserModel.UserResponse> AddUser(UserModel.UserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LastName) ||
            string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.PhoneNumber.ToString())
            || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password)
            || string.IsNullOrWhiteSpace(request.Role))
        {
            throw new ArgumentException("Valores para el producto no válidos");
        }
        var user = new UserBase(request.Name, request.LastName, request.Email,
            request.PhoneNumber, request.Username, request.Password, request.Role);
        await _repository.Add(user);
        return new UserModel.UserResponse(
            user.Id,
            user.Name!,
            user.LastName!,
            user.Email!,
            user.PhoneNumber,
            user.Username!,
            user.Role!,
            user.IsActive,
            user.CreatedAt
        );
    }
    public async Task<IEnumerable<UserModel.UserResponse>> GetAllUsers()
    {
        var users = await _repository.GetFiltered<UserBase>(u => u.IsActive);
        if (users == null || !users.Any()) throw new ArgumentException("No hay usuarios activos.");
        return users.Select(u => new UserModel.UserResponse(
            u.Id,
            u.Name!,
            u.LastName!,
            u.Email!,
            u.PhoneNumber,
            u.Username!,
            u.Role!,
            u.IsActive,
            u.CreatedAt
        ));
    }
    public async Task<UserModel.UserResponse> GetUserById(Guid id)
    {
        var user = await _repository.GetById<UserBase>(id);
        if (user == null || !user.IsActive) throw new EntityNotFoundException("Usuario no encontrado o inactivo.");
        return new UserModel.UserResponse(
            user.Id,
            user.Name!,
            user.LastName!,
            user.Email!,
            user.PhoneNumber,
            user.Username!,
            user.Role!,
            user.IsActive,
            user.CreatedAt
        );
    }
    public async Task<UserModel.UserResponse> DisableUser(Guid id)
    {
        var user = await _repository.GetById<UserBase>(id);
        if (user == null || !user.IsActive) throw new EntityNotFoundException("Usuario no encontrado o ya inactivo.");
        
        user.IsActive = false;
        await _repository.Update(user);
        
        return new UserModel.UserResponse(
            user.Id,
            user.Name!,
            user.LastName!,
            user.Email!,
            user.PhoneNumber,
            user.Username!,
            user.Role!,
            user.IsActive,
            user.CreatedAt
        );
    }
}
