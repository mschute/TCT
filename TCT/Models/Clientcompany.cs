using System;
using System.Collections.Generic;

namespace TCT.Models;

public partial class Clientcompany
{
    public int Clientcompanyid { get; set; }

    public string Companyname { get; set; } = null!;

    public string? Companyaddress { get; set; }

    public string? Companyemail { get; set; }

    public string? Companyphone { get; set; }

    public string? Contactname { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
