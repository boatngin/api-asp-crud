using Microsoft.AspNetCore.Mvc;
using Backapi.DTOs;
using Backapi.Models;
using Backapi.Services.Interfaces;

namespace Backapi.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("api/user")]
        public async Task<IActionResult> AddUser(User user)
        {
            var result = await _service.AddUser(user);

            return Ok(result);
        }


        [HttpPost("api/users/Datatable")]
        public async Task<IActionResult> GetUsersDatatable(
            UserDataReq rq
        )
        {
            return Ok(await _service.GetUsersDatatable(rq));
        }

        [HttpGet("api/users/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPut("api/user/{id}")]
        public async Task<IActionResult> EditUser(int id, User user)
        {
            var result = await _service.EditUser(id, user);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("api/user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _service.DeleteUser(id);

            if (!success)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Delete is ok"
            });
        }
    }
}