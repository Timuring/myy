using System;
using System.Collections.Generic;

namespace RealEstateAgency.Models;

public partial class Person
{
    public int Personid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Middlename { get; set; }

    public string Personrole { get; set; } = null!;

    public virtual ICollection<Orderpersonlist> Orderpersonlists { get; } = new List<Orderpersonlist>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
