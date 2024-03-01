using System;
using System.Collections.Generic;

namespace TCT.Models;

public partial class Vehicle
{
    public int Vehicleid { get; set; }

    public string? Licenseplate { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Gastype { get; set; }

    public string? Heightm { get; set; }

    public string? Widthm { get; set; }

    public string? Lengthm { get; set; }

    public string? Weightkg { get; set; }

    public string? Treaddepth { get; set; }

    public string? Maxload { get; set; }

    public string? Wifiname { get; set; }

    public string? Wifipassword { get; set; }

    public DateOnly? Servicelastdate { get; set; }

    public string? Mileage { get; set; }

    public string? Seats { get; set; }

    public decimal? Priceperday { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
