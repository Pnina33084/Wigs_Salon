using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wigs_Salon.DAL.Models;

namespace Wigs_Salon.DAL.API
{
    public interface ICustomerDal
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(int id);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        List<Customer> SearchCustomers(string query);
    }
}
