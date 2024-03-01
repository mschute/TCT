using System;
using System.Collections.Generic;

namespace TCT.Models;

public partial class Driver
{
    public int Driverid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string? Drivinglicenseno { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
