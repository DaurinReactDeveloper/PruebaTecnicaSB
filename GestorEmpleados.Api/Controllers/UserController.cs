using GestorEmpleados.Api.Extensions;
using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Dtos.EmployeeDto;
using GestorEmpleados.Application.Dtos.UserDto;
using GestorEmpleados.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorEmpleados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;
        private readonly IJwtServices _jwtServices;
        private readonly IRoleServices _roleServices;

        public UserController(IUserServices userServices, IJwtServices jwtServices, IRoleServices roleServices)
        {
            this._userServices = userServices;
            _jwtServices = jwtServices;
            _roleServices = roleServices;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var result = await _userServices.GetUsers();
            return this.ToActionResult(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{*email}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Get(string email)
        {
            var result = await _userServices.GetUserByEmail(email);
            return this.ToActionResult(result);
        }

        [HttpPost("Login")] 
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var result = await _userServices.Login(loginDto.Email, loginDto.Password);
            var rolId = await _roleServices.GetRoleById(result.Data.RoleId);

            if (result.ResultType == MessageType.Success && result.Data != null)
            {
                var user = result.Data;
                var role = rolId.Data;
                var token = _jwtServices.GenerateToken(user.Email, role.RoleName);
                result.Data = new
                {
                    Usuario = user,
                    Token = token
                };
            }


            return this.ToActionResult(result);
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] UserAddDto modelDto)
        {
            var result = await _userServices.Add(modelDto);
            return this.ToActionResult(result);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] UserUpdateDto modelDto)
        {
            var result = await _userServices.Update(modelDto);
            return this.ToActionResult(result);
        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromBody] UserRemoveDto modelDto)
        {
            var result = await _userServices.Remove(modelDto);
            return this.ToActionResult(result);
        }
    }
}
