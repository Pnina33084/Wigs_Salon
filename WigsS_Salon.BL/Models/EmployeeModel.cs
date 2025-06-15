using System;

namespace Wigs_Salon.BL.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string WorkDays { get; set; } = string.Empty;
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }
    }
}
