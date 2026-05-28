using GestorEmpleados.Api.Extensions;
using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Dtos.EmployeeDto;
using GestorEmpleados.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorEmpleados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeServices _employeeServices;


        public EmployeeController(IEmployeeServices employeeServices)
        {
            this._employeeServices = employeeServices;
        }

  
        // GET: api/<EmployeeController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeServices.GetEmployees();
            return this.ToActionResult(result);
        }


        // GET: api/<EmployeeController>
        [HttpGet("ssn/{SocialSecurityNumber}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(string SocialSecurityNumber)
        {
            var result = await _employeeServices.GetEmployeeBySSN(SocialSecurityNumber);
            return this.ToActionResult(result);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeServices.GetEmployeeById(id);
            return this.ToActionResult(result);
        }

        // GET: api/Employee/Filter
        [HttpGet("Filter")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByFilter([FromQuery] EmployeeFilterDto filterDto)
        {
            var result = await _employeeServices.GetEmployeeByFilter(
                filterDto.Name,
                filterDto.DepartmentId,
                filterDto.EmployeeStatusId
            );
            return this.ToActionResult(result);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] EmployeeAddDto modelDto)
        {
            var result = await _employeeServices.Add(modelDto);
            return this.ToActionResult(result);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] EmployeeUpdateDto modelDto)
        {
            var result = await _employeeServices.Update(modelDto);
            return this.ToActionResult(result);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromBody] EmployeeRemoveDto modelDto)
        {
            var result = await _employeeServices.Remove(modelDto);
            return this.ToActionResult(result);
        }

    }
}
