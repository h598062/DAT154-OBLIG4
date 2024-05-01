using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DatabaseLibrary.Models;

public partial class Bookingdata
{
    public int Id { get; set; }

    public int RomId { get; set; }

    public DateTime Startdato { get; set; }

    public DateTime Sluttdato { get; set; }

    public int AntallPersoner { get; set; }

    public int Bruker { get; set; }

    public virtual Brukere BrukerNavigation { get; set; } = null!;

    public virtual Romdata Rom { get; set; } = null!;
    

}
