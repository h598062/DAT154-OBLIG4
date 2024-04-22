using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Migrations;

public partial class Prisdatum
{
    public string Kvalitet { get; set; } = null!;

    public int Pris { get; set; }

    public virtual ICollection<Romdatum> Romdata { get; set; } = new List<Romdatum>();
}
