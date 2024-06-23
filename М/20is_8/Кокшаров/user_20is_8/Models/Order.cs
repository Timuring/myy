using System;
using System.Collections.Generic;

namespace RealEstateAgency.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public string Orderstatus { get; set; } = null!;

    public string Paymentstatus { get; set; } = null!;

    public string Paymentmethod { get; set; } = null!;

    public DateOnly Datecreation { get; set; }

    public string Addres { get; set; } = null!;

    public virtual ICollection<Orderpersonlist> Orderpersonlists { get; } = new List<Orderpersonlist>();
}
