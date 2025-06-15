using System.Collections.Generic;
using System.Linq;
using Wigs_Salon.DAL.API;
using Wigs_Salon.DAL.Models;

namespace Wigs_Salon.DAL.Services
{
    public class AppointmentDal : IAppointmentDal
    {
        private readonly DB_Manager _context;

        public AppointmentDal(DB_Manager context)
        {
            _context = context;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }
        public List<Appointment> GetAppointmentsByDate(DateOnly date)
        {
            return _context.Appointments
                .Where(a => a.AppointmentDate == date)
                .ToList();
        }


        public bool IsTimeSlotAvailable(DateTime dateTime, int employeeId)
        {
            var dateOnly = DateOnly.FromDateTime(dateTime);  // המרה ל DateOnly מה DateTime
            var timeOnly = TimeOnly.FromDateTime(dateTime);  // המרה ל TimeOnly מה DateTime

            return !_context.Appointments
                .Any(a => a.AppointmentDate == dateOnly && a.AppointmentTime == timeOnly && a.EmployeeId == employeeId);
        }
        public void AddServiceToAppointment(int appointmentId, int serviceId)
        {
            var appointment = _context.Appointments.Find(appointmentId);
            var service = _context.Services.Find(serviceId);
            if (appointment != null && service != null)
            {
                appointment.Services.Add(service);
                _context.SaveChanges();
            }
        }


    }
}
