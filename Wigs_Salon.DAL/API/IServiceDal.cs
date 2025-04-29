using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wigs_Salon.DAL.Models;

namespace Wigs_Salon.DAL.API
{
    public interface IServiceDal
    {
        void AddService(Service service);
        void DeleteService(int id);
        List<Service> GetAllServices();
        Service GetServiceById(int id);
        void UpdateService(Service service);
    }
}
