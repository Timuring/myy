using System;
using System.Collections.Generic;

namespace service.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Status { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Middlename { get; set; }

    public int? Userroleid { get; set; }

    public virtual ICollection<Orderuserlist> Orderuserlists { get; } = new List<Orderuserlist>();

    public virtual ICollection<Userlist> Userlists { get; } = new List<Userlist>();

    public virtual Userrole? Userrole { get; set; }
}
