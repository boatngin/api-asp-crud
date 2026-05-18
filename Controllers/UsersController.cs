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

        
    }
}