using System;
using System.Collections.Generic;

namespace DatabaseLibrary.Models;

public partial class Brukere
{
    public int Id { get; set; }

    public string Epost { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Tlf { get; set; }
    
    public string? AspNetUser_Id { get; set; }

    public virtual ICollection<Bookingdata> Bookingdata { get; set; } = new List<Bookingdata>();
    
}
