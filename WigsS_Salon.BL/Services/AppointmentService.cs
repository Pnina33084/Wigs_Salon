using Wigs_Salon.BL.Interfaces;
using Wigs_Salon.BL.Models;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Wigs_Salon.BL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentDal _dal;

        public AppointmentService(IAppointmentDal dal)
        {
            _dal = dal;
        }

        public List<AppointmentModel> GetAll()
        {
            return _dal.GetAllAppointments()
                       .Select(a => MapToModel(a))
                       .ToList();
        }

        public AppointmentModel? GetById(int id)
        {
            var a = _dal.GetAppointmentById(id);
            return a is null ? null : MapToModel(a);
        }

        public void Add(AppointmentModel model)
        {
            _dal.AddAppointment(MapToEntity(model));
        }

        public void Update(AppointmentModel model)
        {
            _dal.UpdateAppointment(MapToEntity(model));
        }

        public void Delete(int id)
        {
            _dal.DeleteAppointment(id);
        }

        private Appointment MapToEntity(AppointmentModel m) => new()
        {
            AppointmentId = m.AppointmentId,
            CustomerId = m.CustomerId,
            EmployeeId = m.EmployeeId,
            AppointmentDate = m.AppointmentDate,
            AppointmentTime = m.AppointmentTime,
            CancellationFee = m.CancellationFee ?? 0
        };

        private AppointmentModel MapToModel(Appointment e) => new()
        {
            AppointmentId = e.AppointmentId,
            CustomerId = e.CustomerId,
            EmployeeId = e.EmployeeId,
            AppointmentDate = e.AppointmentDate,
            AppointmentTime = e.AppointmentTime,
            CancellationFee = e.CancellationFee
        };
    }
}
