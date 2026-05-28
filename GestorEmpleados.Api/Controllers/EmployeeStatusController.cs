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
    public class EmployeeStatusController : ControllerBase
    {

        private readonly IEmployeeStatusServices _employeeStatusServices;

        public EmployeeStatusController(IEmployeeStatusServices employeeStatusServices)
        {
            this._employeeStatusServices = employeeStatusServices;
        }

        // GET: api/<EmployeeStatusController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeStatusServices.GetEmployeeStatuses();
            return this.ToActionResult(result);
        }

    }
}
