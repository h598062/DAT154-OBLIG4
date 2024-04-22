using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Romdata1
{
    public int Id { get; set; }

    public string Kvalitet { get; set; } = null!;

    public int AntallSenger { get; set; }

    public virtual ICollection<Bookingdata1> Bookingdata1s { get; set; } = new List<Bookingdata1>();

    public virtual Prisdata1 KvalitetNavigation { get; set; } = null!;
}
