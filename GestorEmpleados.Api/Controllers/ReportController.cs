using Azure.Core;
using GestorEmpleados.Api.Extensions;
using GestorEmpleados.Application.Contract;
using GestorEmpleados.Application.Dtos.PayrollResultDto;
using GestorEmpleados.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorEmpleados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IReportServices _reportServices;

        public ReportController(IReportServices reportServices)
        {
            this._reportServices = reportServices;
        }

        // GET: api/<ReportController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery] PayrollReportRequestDto request)
        {
            var result = await _reportServices.GenerateWeeklyPayrollReport(request); 
            return this.ToActionResult(result);
        }

        // GET api/<ReportController>/5
        [HttpGet("{employeeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int employeeId, [FromQuery] PayrollReportRequestDto request)
        {
            var result = await _reportServices.CalculateWeeklyPayroll(employeeId, request);
            return this.ToActionResult(result);
        }

    }
}
