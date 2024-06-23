using System;
using System.Collections.Generic;

namespace service.Models;

public partial class Userrole
{
    public int Userroleid { get; set; }

    public string Namerole { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
