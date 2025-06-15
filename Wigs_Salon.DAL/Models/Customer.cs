using System;
using System.Collections.Generic;

namespace Wigs_Salon.DAL.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
