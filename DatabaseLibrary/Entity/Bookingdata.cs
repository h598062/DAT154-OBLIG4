using System;
using System.Collections.Generic;

namespace DatabaseLibrary;

public partial class Bookingdata
{
    public int Id { get; set; }

    public int RomId { get; set; }

    public DateTime Startdato { get; set; }

    public DateTime Sluttdato { get; set; }

    public int AntallPersoner { get; set; }

    public string Bruker { get; set; } = null!;

    public virtual Romdata Rom { get; set; } = null!;
}
