using Microsoft.AspNetCore.Mvc;
using ModelValidation.Data;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            return Ok(existingEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = employee.Id }, employee);
        }
    }
}
