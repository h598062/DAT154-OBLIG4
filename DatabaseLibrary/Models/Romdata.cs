using System;
using System.Collections.Generic;

namespace DatabaseLibrary;

public partial class Romdata
{
    public int Id { get; set; }

    public string Kvalitet { get; set; } = null!;

    public int AntallSenger { get; set; }

    public virtual ICollection<Bookingdata> Bookingdata { get; set; } = new List<Bookingdata>();

    public virtual Prisdata KvalitetNavigation { get; set; } = null!;
}
