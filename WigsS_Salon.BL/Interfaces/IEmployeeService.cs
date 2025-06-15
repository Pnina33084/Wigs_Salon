using Wigs_Salon.BL.Models;
using System.Collections.Generic;

namespace Wigs_Salon.BL.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetAll();
        EmployeeModel? GetById(int id);
        void Add(EmployeeModel model);
        void Update(EmployeeModel model);
        void Delete(int id);
    }
}
