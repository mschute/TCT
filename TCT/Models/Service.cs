using System;
using System.Collections.Generic;

namespace TCT.Models;

public partial class Service
{
    public int Serviceid { get; set; }

    public int? Vehicleid { get; set; }

    public string? Servicelocationname { get; set; }

    public string? Servicelocationaddress { get; set; }

    public DateOnly? Servicedate { get; set; }

    public string? Engingeoilfiltercheck { get; set; }

    public string? Fuelfiltercheck { get; set; }

    public string? Bodyworkcheck { get; set; }

    public string? Lightstyresexhaustcheck { get; set; }

    public string? Brakessteeringcheck { get; set; }

    public string? Fluidcoolantscheck { get; set; }

    public string? Suspensioncheck { get; set; }

    public string? Carbatterycheck { get; set; }

    public string? Wheelalignbalancerotatcheck { get; set; }

    public string? Servicenotes { get; set; }

    public decimal? Serviceprice { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
