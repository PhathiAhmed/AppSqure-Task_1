using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public interface IEmployee 
    {
        bool AddEmployee(Employee employee);
        List<Employee> GetEmployees();
        Employee GetId(int id);
        bool UpdateEmployee( Employee employee);
        bool DeleteEmployee(int id);
    }
    public class RpoEmployee:IEmployee
    {
        ApplicationDbContext _context;
        public RpoEmployee(ApplicationDbContext context)
        {
            _context = context;
        }
        public  List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public bool AddEmployee(Employee employee)
        {
            try 
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }
            catch ( Exception e) 
            {
                return false;
            }
            
        }
        public Employee GetId(int id) 
        {
            var employee= _context.Employees.FirstOrDefault(e =>e.Id==id);
            return employee;
        }
        public bool UpdateEmployee(Employee employee) 
        {
            try 
            {

                //_context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges(); 
                return true;
            }
            catch ( Exception e) 
            {
                return false;
            }
        }
        public bool DeleteEmployee(int id) 
        {
            try 
            {
                var employee = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            catch ( Exception e) 
            {
                return false;
            }
        }

    }
}
