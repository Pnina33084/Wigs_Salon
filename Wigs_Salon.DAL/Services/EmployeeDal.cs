using System.Collections.Generic;
using System.Linq;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;

namespace Wigs_Salon.DAL.Services
{
    public class EmployeeDal : IEmployeeDal
    {
        private readonly DB_Manager _context;

        public EmployeeDal(DB_Manager context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
        public List<Appointment> GetAppointmentsByEmployee(int employeeId)
        {
            return _context.Appointments
                .Where(a => a.EmployeeId == employeeId)
                .ToList();
        }


    }
}
