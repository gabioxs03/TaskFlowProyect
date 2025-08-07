using Dsw2025Ej15.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManagementService _service;
        public UsersController(IUsersManagementService usersManagementService)
        {
            _service = usersManagementService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserModel.UserRequest request)
        {
            try
            {
                var user = await _service.AddUser(request);
                return Created("/user", user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _service.GetAllUsers();
                return Ok(users);
            }
            catch (ArgumentException ex)
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _service.GetUserById(id);
                return Ok(user);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpPatch("{id}/disable")]
        public async Task<IActionResult> DisableUser(Guid id)
        {
            try
            {
                var user = await _service.DisableUser(id);
                return Ok(user);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
