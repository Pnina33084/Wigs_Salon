using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wigs_Salon.DAL.Models;

namespace Wigs_Salon.DAL.API
{
    public interface IEmployeeDal
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void UpdateEmployee(Employee employee);
        List<Appointment> GetAppointmentsByEmployee(int employeeId);
    }
}
