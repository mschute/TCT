using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TCT.Models;

public partial class TctContext : DbContext
{
    public TctContext()
    {
    }

    public TctContext(DbContextOptions<TctContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Clientcompany> Clientcompanies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Travellocation> Travellocations { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Bookingid).HasName("booking_pkey");

            entity.ToTable("booking");

            entity.Property(e => e.Bookingid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("bookingid");
            entity.Property(e => e.Clientcompanyid).HasColumnName("clientcompanyid");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Islandaccomodation).HasColumnName("islandaccomodation");
            entity.Property(e => e.Islanddays).HasColumnName("islanddays");
            entity.Property(e => e.Mainlandaccomodation).HasColumnName("mainlandaccomodation");
            entity.Property(e => e.Mainlanddays).HasColumnName("mainlanddays");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Totaldays).HasColumnName("totaldays");
            entity.Property(e => e.Totalprice)
                .HasPrecision(6, 2)
                .HasColumnName("totalprice");
            entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");

            entity.HasOne(d => d.Clientcompany).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Clientcompanyid)
                .HasConstraintName("fk_clientcompany");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("fk_customer");

            entity.HasOne(d => d.Driver).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Driverid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_driver");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Vehicleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vehicle");
        });

        modelBuilder.Entity<Clientcompany>(entity =>
        {
            entity.HasKey(e => e.Clientcompanyid).HasName("clientcompany_pkey");

            entity.ToTable("clientcompany");

            entity.Property(e => e.Clientcompanyid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("clientcompanyid");
            entity.Property(e => e.Companyaddress)
                .HasMaxLength(255)
                .HasColumnName("companyaddress");
            entity.Property(e => e.Companyemail)
                .HasMaxLength(255)
                .HasColumnName("companyemail");
            entity.Property(e => e.Companyname)
                .HasMaxLength(255)
                .HasColumnName("companyname");
            entity.Property(e => e.Companyphone)
                .HasMaxLength(15)
                .HasColumnName("companyphone");
            entity.Property(e => e.Contactname)
                .HasMaxLength(255)
                .HasColumnName("contactname");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Customerid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("customerid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Nationality)
                .HasMaxLength(150)
                .HasColumnName("nationality");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Driverid).HasName("driver_pkey");

            entity.ToTable("driver");

            entity.Property(e => e.Driverid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("driverid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Drivinglicenseno)
                .HasMaxLength(150)
                .HasColumnName("drivinglicenseno");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Serviceid).HasName("service_pkey");

            entity.ToTable("service");

            entity.Property(e => e.Serviceid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("serviceid");
            entity.Property(e => e.Bodyworkcheck)
                .HasMaxLength(255)
                .HasColumnName("bodyworkcheck");
            entity.Property(e => e.Brakessteeringcheck)
                .HasMaxLength(255)
                .HasColumnName("brakessteeringcheck");
            entity.Property(e => e.Carbatterycheck)
                .HasMaxLength(255)
                .HasColumnName("carbatterycheck");
            entity.Property(e => e.Engingeoilfiltercheck)
                .HasMaxLength(255)
                .HasColumnName("engingeoilfiltercheck");
            entity.Property(e => e.Fluidcoolantscheck)
                .HasMaxLength(255)
                .HasColumnName("fluidcoolantscheck");
            entity.Property(e => e.Fuelfiltercheck)
                .HasMaxLength(255)
                .HasColumnName("fuelfiltercheck");
            entity.Property(e => e.Lightstyresexhaustcheck)
                .HasMaxLength(255)
                .HasColumnName("lightstyresexhaustcheck");
            entity.Property(e => e.Servicedate).HasColumnName("servicedate");
            entity.Property(e => e.Servicelocationaddress)
                .HasMaxLength(255)
                .HasColumnName("servicelocationaddress");
            entity.Property(e => e.Servicelocationname)
                .HasMaxLength(255)
                .HasColumnName("servicelocationname");
            entity.Property(e => e.Servicenotes)
                .HasMaxLength(255)
                .HasColumnName("servicenotes");
            entity.Property(e => e.Serviceprice)
                .HasPrecision(7, 2)
                .HasColumnName("serviceprice");
            entity.Property(e => e.Suspensioncheck)
                .HasMaxLength(255)
                .HasColumnName("suspensioncheck");
            entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");
            entity.Property(e => e.Wheelalignbalancerotatcheck)
                .HasMaxLength(255)
                .HasColumnName("wheelalignbalancerotatcheck");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Services)
                .HasForeignKey(d => d.Vehicleid)
                .HasConstraintName("fk_vehicle");
        });

        modelBuilder.Entity<Travellocation>(entity =>
        {
            entity.HasKey(e => e.Travellocationid).HasName("travellocation_pkey");

            entity.ToTable("travellocation");

            entity.Property(e => e.Travellocationid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("travellocationid");
            entity.Property(e => e.Mainlandislandflag)
                .HasMaxLength(8)
                .HasColumnName("mainlandislandflag");
            entity.Property(e => e.Travellocationaddress)
                .HasMaxLength(255)
                .HasColumnName("travellocationaddress");
            entity.Property(e => e.Travellocationname)
                .HasMaxLength(255)
                .HasColumnName("travellocationname");

            entity.HasMany(d => d.Bookings).WithMany(p => p.Travellocations)
                .UsingEntity<Dictionary<string, object>>(
                    "Travellocationbooking",
                    r => r.HasOne<Booking>().WithMany()
                        .HasForeignKey("Bookingid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_bookingid"),
                    l => l.HasOne<Travellocation>().WithMany()
                        .HasForeignKey("Travellocationid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_travellocation"),
                    j =>
                    {
                        j.HasKey("Travellocationid", "Bookingid").HasName("travellocationbooking_pkey");
                        j.ToTable("travellocationbooking");
                        j.IndexerProperty<int>("Travellocationid").HasColumnName("travellocationid");
                        j.IndexerProperty<int>("Bookingid").HasColumnName("bookingid");
                    });
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Vehicleid).HasName("vehicle_pkey");

            entity.ToTable("vehicle");

            entity.Property(e => e.Vehicleid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("vehicleid");
            entity.Property(e => e.Gastype)
                .HasMaxLength(150)
                .HasColumnName("gastype");
            entity.Property(e => e.Heightm)
                .HasMaxLength(10)
                .HasColumnName("heightm");
            entity.Property(e => e.Lengthm)
                .HasMaxLength(10)
                .HasColumnName("lengthm");
            entity.Property(e => e.Licenseplate)
                .HasMaxLength(10)
                .HasColumnName("licenseplate");
            entity.Property(e => e.Make)
                .HasMaxLength(150)
                .HasColumnName("make");
            entity.Property(e => e.Maxload)
                .HasMaxLength(5)
                .HasColumnName("maxload");
            entity.Property(e => e.Mileage)
                .HasMaxLength(10)
                .HasColumnName("mileage");
            entity.Property(e => e.Model)
                .HasMaxLength(150)
                .HasColumnName("model");
            entity.Property(e => e.Priceperday)
                .HasPrecision(4, 2)
                .HasColumnName("priceperday");
            entity.Property(e => e.Seats)
                .HasMaxLength(3)
                .HasColumnName("seats");
            entity.Property(e => e.Servicelastdate).HasColumnName("servicelastdate");
            entity.Property(e => e.Treaddepth)
                .HasMaxLength(10)
                .HasColumnName("treaddepth");
            entity.Property(e => e.Weightkg)
                .HasMaxLength(10)
                .HasColumnName("weightkg");
            entity.Property(e => e.Widthm)
                .HasMaxLength(10)
                .HasColumnName("widthm");
            entity.Property(e => e.Wifiname)
                .HasMaxLength(150)
                .HasColumnName("wifiname");
            entity.Property(e => e.Wifipassword)
                .HasMaxLength(150)
                .HasColumnName("wifipassword");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
