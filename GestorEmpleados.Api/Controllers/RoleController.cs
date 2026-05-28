using GestorEmpleados.Api.Extensions;
using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorEmpleados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleServices _roleServices;

        public RoleController(IRoleServices roleServices)
        {
            this._roleServices = roleServices;
        }

        // GET: api/<RoleController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var result = await _roleServices.GetRoleAll();
            return this.ToActionResult(result);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _roleServices.GetRoleById(id);
            return this.ToActionResult(result);
        }

    }
}
