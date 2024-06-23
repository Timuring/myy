using System;
using System.Collections.Generic;

namespace service.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public DateOnly Datecreation { get; set; }

    public string Orderstatus { get; set; } = null!;

    public string Paymentstatus { get; set; } = null!;

    public string Carelement { get; set; } = null!;

    public string Details { get; set; } = null!;

    public int Amountdamage { get; set; }

    public string Liquids { get; set; } = null!;

    public virtual ICollection<Orderuserlist> Orderuserlists { get; } = new List<Orderuserlist>();
}
