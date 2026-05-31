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
    public class EmployeeTypeController : ControllerBase
    {

        private readonly IEmployeeTypeServices _employeeTypeServices;

        public EmployeeTypeController(IEmployeeTypeServices employeeTypeServices)
        {
            this._employeeTypeServices = employeeTypeServices;
        }

        // GET: api/<EmployeeTypeController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeTypeServices.GetEmployeeTypes();
            return this.ToActionResult(result);
        }

    }
}
