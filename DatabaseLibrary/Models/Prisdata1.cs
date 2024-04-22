using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Prisdata1
{
    public string Kvalitet { get; set; } = null!;

    public int Pris { get; set; }

    public virtual ICollection<Romdata1> Romdata1s { get; set; } = new List<Romdata1>();
}
