using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wigs_Salon.DAL.Models;

namespace Wigs_Salon.DAL.API
{
    public interface IAppointmentDal
    {
        void AddAppointment(Appointment appointment);
        void DeleteAppointment(int id);
        List<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        void UpdateAppointment(Appointment appointment);
        List<Appointment> GetAppointmentsByDate(DateOnly date);
        bool IsTimeSlotAvailable(DateTime dateTime, int employeeId);
        void AddServiceToAppointment(int appointmentId, int serviceId);
    }
}
