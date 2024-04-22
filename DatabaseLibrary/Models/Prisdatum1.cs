using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Migrations;

public partial class Prisdatum1
{
    public string Kvalitet { get; set; } = null!;

    public int Pris { get; set; }

    public virtual ICollection<Romdatum1> Romdatum1s { get; set; } = new List<Romdatum1>();
}
