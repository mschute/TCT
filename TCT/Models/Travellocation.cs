using System;
using System.Collections.Generic;

namespace TCT.Models;

public partial class Travellocation
{
    public int Travellocationid { get; set; }

    public string Travellocationname { get; set; } = null!;

    public string Travellocationaddress { get; set; } = null!;

    public string? Mainlandislandflag { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
