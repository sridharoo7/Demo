using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Model;

namespace Web_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var customer = _customerService.GetCustomer(id);
                return customer == null ? NotFound($"Customer not exist with ID: {id}") : Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        //Use Put since we are updating all the customer properties
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody]Customer customer)
        {
            try
            {
                var res = _customerService.UpdateCustomer(customer,id);
                return res ? Ok("Updated") : NotFound($"Customer not exist with ID: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        //Use Patch since we are updating only the customer plan
        [HttpPatch("{id}/{plan}")]
        public IActionResult UpdateCustomerPlan(int id, string plan)
        {
            try
            {
                var res = _customerService.UpdateCustomerPlan(plan, id);
                return res ? Ok("Updated") : NotFound($"Customer not exist with ID: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }
    }
}
