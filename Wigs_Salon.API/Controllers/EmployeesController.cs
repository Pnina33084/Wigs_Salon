using Microsoft.AspNetCore.Mvc;
using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Models;

namespace Wigs_Salon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_employeeService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] EmployeeModel model)
        {
            _employeeService.Add(model);
            return CreatedAtAction(nameof(GetById), new { id = model.EmployeeId }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EmployeeModel model)
        {
            model.EmployeeId = id;
            _employeeService.Update(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return NoContent();
        }
    }
}
