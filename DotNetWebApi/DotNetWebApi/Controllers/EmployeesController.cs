using DotNetWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        { 
          var list = _context.Employees.ToList();
          return Ok(list);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee request)
        {
            request.Id = Guid.NewGuid();
            _context.Employees.Add(request);
            _context.SaveChanges();
            return Ok();
        }

        [Route("{id:Guid}")]
        [HttpGet]
        public IActionResult GetEmployee([FromRoute]Guid? id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null) 
            {
               return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")] 
        public IActionResult UpdateEmployee([FromRoute]Guid? id, Employee updateRequestModel)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateRequestModel.Name;
            employee.Email = updateRequestModel.Email;
            employee.Salary = updateRequestModel.Salary;
            employee.Phone = updateRequestModel.Phone;
            employee.Department = updateRequestModel.Department;
            _context.Employees.Update(employee);
            _context.SaveChanges(); 
            return Ok();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteEmployee([FromRoute] Guid? id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok();
        }
    }
}
