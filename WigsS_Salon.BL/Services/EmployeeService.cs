using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Models;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Wigs_Salon.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDal _dal;
        public EmployeeService(IEmployeeDal dal) { _dal = dal; }

        public List<EmployeeModel> GetAll() => _dal.GetAllEmployees()
            .Select(e => new EmployeeModel
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Role = e.Role,
                WorkDays = e.WorkDays,
                StartHour = e.StartHour,
                EndHour = e.EndHour
            }).ToList();

        public EmployeeModel? GetById(int id)
        {
            var e = _dal.GetEmployeeById(id);
            if (e is null) return null;
            return new EmployeeModel
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Role = e.Role,
                WorkDays = e.WorkDays,
                StartHour = e.StartHour,
                EndHour = e.EndHour
            };
        }

        public void Add(EmployeeModel m)
        {
            _dal.AddEmployee(new Employee
            {
                Name = m.Name,
                Role = m.Role,
                WorkDays = m.WorkDays,
                StartHour = m.StartHour,
                EndHour = m.EndHour
            });
        }

        public void Update(EmployeeModel m)
        {
            _dal.UpdateEmployee(new Employee
            {
                EmployeeId = m.EmployeeId,
                Name = m.Name,
                Role = m.Role,
                WorkDays = m.WorkDays,
                StartHour = m.StartHour,
                EndHour = m.EndHour
            });
        }

        public void Delete(int id) => _dal.DeleteEmployee(id);
    }
}
