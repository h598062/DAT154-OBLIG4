using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Migrations;

public partial class Romdatum
{
    public int Id { get; set; }

    public string Kvalitet { get; set; } = null!;

    public int AntallSenger { get; set; }

    public virtual ICollection<Bookingdatum> Bookingdata { get; set; } = new List<Bookingdatum>();

    public virtual Prisdatum KvalitetNavigation { get; set; } = null!;
}
