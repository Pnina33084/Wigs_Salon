using System;
using System.Collections.Generic;

namespace Wigs_Salon.DAL.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public int DurationMinutes { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
