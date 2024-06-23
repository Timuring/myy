using System;
using System.Collections.Generic;

namespace RealEstateAgency.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Status { get; set; }

    public int Userroleid { get; set; }

    public int Personid { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Userlist> Userlists { get; } = new List<Userlist>();

    public virtual Userrole Userrole { get; set; } = null!;
}
