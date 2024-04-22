using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Migrations;

public partial class Romdatum1
{
    public int Id { get; set; }

    public string Kvalitet { get; set; } = null!;

    public int AntallSenger { get; set; }

    public virtual ICollection<Bookingdatum1> Bookingdatum1s { get; set; } = new List<Bookingdatum1>();

    public virtual Prisdatum1 KvalitetNavigation { get; set; } = null!;
}
