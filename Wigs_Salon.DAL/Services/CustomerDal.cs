using System.Collections.Generic;
using System.Linq;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;

namespace Wigs_Salon.DAL.Services
{
    public class CustomerDal : ICustomerDal
    {
        private readonly DB_Manager _context;

        public CustomerDal(DB_Manager context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
        public List<Customer> SearchCustomers(string query)
        {
            return _context.Customers
                .Where(c => c.FullName.Contains(query) || c.PhoneNumber.Contains(query))
                .ToList();
        }

    }
}
