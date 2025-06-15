using System.Collections.Generic;
using System.Linq;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;

namespace Wigs_Salon.DAL.Services
{
    public class ServiceDal : IServiceDal
    {
        private readonly DB_Manager _context;

        public ServiceDal(DB_Manager context)
        {
            _context = context;
        }

        public List<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(s => s.ServiceId == id);
        }

        public void AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var service = _context.Services.FirstOrDefault(s => s.ServiceId == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}
