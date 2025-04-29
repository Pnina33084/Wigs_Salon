using System;
using System.Collections.Generic;

namespace Wigs_Salon.DAL.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public int? CancellationFee { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
