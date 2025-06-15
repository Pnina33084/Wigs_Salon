using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Models;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Wigs_Salon.BL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _dal;

        public CustomerService(ICustomerDal dal) { _dal = dal; }

        public List<CustomerModel> GetAll() => _dal.GetAllCustomers()
                                                   .Select(e => new CustomerModel
                                                   {
                                                       CustomerId = e.CustomerId,
                                                       FullName = e.FullName,
                                                       PhoneNumber = e.PhoneNumber,
                                                       Notes = e.Notes
                                                   }).ToList();

        public CustomerModel? GetById(int id)
        {
            var e = _dal.GetCustomerById(id);
            if (e is null) return null;
            return new CustomerModel
            {
                CustomerId = e.CustomerId,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                Notes = e.Notes
            };
        }

        public void Add(CustomerModel m)
        {
            _dal.AddCustomer(new Customer
            {
                FullName = m.FullName,
                PhoneNumber = m.PhoneNumber,
                Notes = m.Notes
            });
        }

        public void Update(CustomerModel m)
        {
            _dal.UpdateCustomer(new Customer
            {
                CustomerId = m.CustomerId,
                FullName = m.FullName,
                PhoneNumber = m.PhoneNumber,
                Notes = m.Notes
            });
        }

        public void Delete(int id) => _dal.DeleteCustomer(id);

        public List<CustomerModel> Search(string query) => _dal.SearchCustomers(query)
            .Select(e => new CustomerModel
            {
                CustomerId = e.CustomerId,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                Notes = e.Notes
            }).ToList();
    }
}
