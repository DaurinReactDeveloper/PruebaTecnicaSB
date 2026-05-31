using GestorEmpleados.Api.Extensions;
using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorEmpleados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            this._departmentServices = departmentServices;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {

            var result = await _departmentServices.GetDepartments();
            return this.ToActionResult(result);

        }

    }
}
