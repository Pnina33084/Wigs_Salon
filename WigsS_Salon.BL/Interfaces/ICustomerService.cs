using Wigs_Salon.BL.Models;
using System.Collections.Generic;

namespace Wigs_Salon.BL.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerModel> GetAll();
        CustomerModel? GetById(int id);
        void Add(CustomerModel model);
        void Update(CustomerModel model);
        void Delete(int id);
        List<CustomerModel> Search(string query);
    }
}
