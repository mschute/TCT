using System;
using System.Collections.Generic;

namespace TCT.Models;

public partial class Customer
{
    public int Customerid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string? Nationality { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
