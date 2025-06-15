using Microsoft.AspNetCore.Mvc;
using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Models;

namespace Wigs_Salon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_customerService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] CustomerModel model)
        {
            _customerService.Add(model);
            return CreatedAtAction(nameof(GetById), new { id = model.CustomerId }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CustomerModel model)
        {
            model.CustomerId = id;
            _customerService.Update(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return NoContent();
        }
    }
}
