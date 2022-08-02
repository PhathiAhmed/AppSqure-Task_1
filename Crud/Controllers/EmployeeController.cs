using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Repository;
using Crud.Models;

namespace Crud.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IEmployee _iemployee;
        public EmployeeController(IEmployee iemployee)
        {
            _iemployee = iemployee;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return Ok (_iemployee.GetEmployees()) ;
        }
        [HttpPost]
        public IActionResult Add(Employee employee) 
        {
            
            return Ok(_iemployee.AddEmployee(employee));
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,Employee employee) 
        {
            var empoly = _iemployee.GetId(id);
            if (empoly == null)
                return NotFound();
            empoly.FName = employee.FName;
            empoly.LName = employee.LName;
            empoly.Address = employee.Address;
            empoly.Age = employee.Age;
            return Ok(_iemployee.UpdateEmployee(employee));
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            return Ok(_iemployee.DeleteEmployee(id));
        }
    }
}
