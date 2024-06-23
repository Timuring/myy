using System;
using System.Collections.Generic;

namespace service.Models;

public partial class Shift
{
    public int Shiftid { get; set; }

    public DateOnly Datestart { get; set; }

    public DateOnly Dateend { get; set; }

    public virtual ICollection<Userlist> Userlists { get; } = new List<Userlist>();
}
