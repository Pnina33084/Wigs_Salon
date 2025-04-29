using System;
using System.Collections.Generic;

namespace Wigs_Salon.DAL.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string WorkDays { get; set; } = null!;

    public TimeOnly StartHour { get; set; }

    public TimeOnly EndHour { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
