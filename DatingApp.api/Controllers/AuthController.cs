using DatingApp.api.Data;
using DatingApp.api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DatingApp.api.Dtos;

namespace DatingApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        // public async Task<IActionResult> Register(string userName, string password)
        // {
        //     //validate the request
        //     userName = userName.ToLower();

        //     if(await _repo.UserExists(userName))
        //     {
        //         return BadRequest("Username already exists");
        //     }

        //     var userToCreate = new User{
        //         Name = userName
        //     };

        //     var createdUser = await _repo.Register(userToCreate,password);

        //     return StatusCode(201);

        // }

        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate the request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User{
                Name = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate,userForRegisterDto.Password);

            return StatusCode(201);

        }

    }
}