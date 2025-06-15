using Microsoft.AspNetCore.Mvc;
using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Models;

namespace Wigs_Salon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_serviceService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _serviceService.GetById(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] ServiceModel model)
        {
            _serviceService.Add(model);
            return CreatedAtAction(nameof(GetById), new { id = model.ServiceId }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ServiceModel model)
        {
            model.ServiceId = id;
            _serviceService.Update(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _serviceService.Delete(id);
            return NoContent();
        }
    }
}
