using Microsoft.AspNetCore.Mvc;
using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Models;

namespace Wigs_Salon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _service.GetById(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AppointmentModel model)
        {
            _service.Add(model);
            return CreatedAtAction(nameof(GetById), new { id = model.AppointmentId }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AppointmentModel model)
        {
            model.AppointmentId = id;
            _service.Update(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
