using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository customerRepository = new CustomerRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
            => customerRepository.GetCustomers();

        [HttpGet("username")]
        public IActionResult GetCustomerByUSername([FromRoute] string username)
        {
            var customer = customerRepository.GetCustomerByUsername(username);
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            customerRepository.AddCustomer(customer);
            return NoContent();
        }

        [HttpPut("username")]
        public IActionResult UpdateCustomer(string username, [FromBody] Customer customer)
        {
            var oldCustomer = customerRepository.GetCustomerByUsername(username);
            if (customer == null) return NotFound();
            customerRepository.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("username")]
        public IActionResult DeleteCustomer(string username)
        {
            var customer = customerRepository.GetCustomerByUsername(username);
            if (customer == null) return NotFound();
            customerRepository.DeleteCustomer(customer);
            return NoContent();

        }
    }
}
