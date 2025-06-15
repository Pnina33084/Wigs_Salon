using Wigs_Salon.BL.Models;
using System.Collections.Generic;

namespace Wigs_Salon.BL.Interfaces
{
    public interface IAppointmentService
    {
        List<AppointmentModel> GetAll();
        AppointmentModel? GetById(int id);
        void Add(AppointmentModel model);
        void Update(AppointmentModel model);
        void Delete(int id);
    }
}
