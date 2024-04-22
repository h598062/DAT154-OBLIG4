using System;
using System.Collections.Generic;

namespace DatabaseLibrary;

public partial class Prisdata
{
    public string Kvalitet { get; set; } = null!;

    public int Pris { get; set; }

    public virtual ICollection<Romdata> Romdata { get; set; } = new List<Romdata>();
}
