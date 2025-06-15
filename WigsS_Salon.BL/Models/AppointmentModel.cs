using System;
using System.Collections.Generic;

namespace Wigs_Salon.BL.Models
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public int? CancellationFee { get; set; }
        public List<int>? ServiceIds { get; set; } // במקום הקשר ישיר לשירותים
    }
}
