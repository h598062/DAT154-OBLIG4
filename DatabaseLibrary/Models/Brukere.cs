using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Migrations;

public partial class Brukere
{
    public int Id { get; set; }

    public string Epost { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Tlf { get; set; }

    public virtual ICollection<Bookingdatum> Bookingdata { get; set; } = new List<Bookingdatum>();
}
