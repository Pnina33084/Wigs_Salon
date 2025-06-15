using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Models;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Wigs_Salon.BL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceDal _dal;
        public ServiceService(IServiceDal dal) { _dal = dal; }

        public List<ServiceModel> GetAll() => _dal.GetAllServices()
            .Select(s => new ServiceModel
            {
                ServiceId = s.ServiceId,
                ServiceName = s.ServiceName,
                DurationMinutes = s.DurationMinutes
            }).ToList();

        public ServiceModel? GetById(int id)
        {
            var s = _dal.GetServiceById(id);
            if (s is null) return null;
            return new ServiceModel
            {
                ServiceId = s.ServiceId,
                ServiceName = s.ServiceName,
                DurationMinutes = s.DurationMinutes
            };
        }

        public void Add(ServiceModel m) => _dal.AddService(new Service
        {
            ServiceName = m.ServiceName,
            DurationMinutes = m.DurationMinutes
        });

        public void Update(ServiceModel m) => _dal.UpdateService(new Service
        {
            ServiceId = m.ServiceId,
            ServiceName = m.ServiceName,
            DurationMinutes = m.DurationMinutes
        });

        public void Delete(int id) => _dal.DeleteService(id);
    }
}
