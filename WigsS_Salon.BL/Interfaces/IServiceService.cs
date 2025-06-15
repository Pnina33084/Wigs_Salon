using Wigs_Salon.BL.Models;
using System.Collections.Generic;

namespace Wigs_Salon.BL.Interfaces
{
    public interface IServiceService
    {
        List<ServiceModel> GetAll();
        ServiceModel? GetById(int id);
        void Add(ServiceModel model);
        void Update(ServiceModel model);
        void Delete(int id);
    }
}
