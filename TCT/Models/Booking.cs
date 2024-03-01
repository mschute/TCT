using System;
using System.Collections.Generic;

namespace TCT.Models;

public partial class Booking
{
    public int Bookingid { get; set; }

    public int Vehicleid { get; set; }

    public int Driverid { get; set; }

    public int? Customerid { get; set; }

    public int? Clientcompanyid { get; set; }

    public decimal? Totalprice { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public int? Totaldays { get; set; }

    public int? Mainlanddays { get; set; }

    public int? Islanddays { get; set; }

    public int? Mainlandaccomodation { get; set; }

    public int? Islandaccomodation { get; set; }

    public virtual Clientcompany? Clientcompany { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;

    public virtual ICollection<Travellocation> Travellocations { get; set; } = new List<Travellocation>();
}
