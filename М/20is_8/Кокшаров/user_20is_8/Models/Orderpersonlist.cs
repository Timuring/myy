using System;
using System.Collections.Generic;

namespace RealEstateAgency.Models;

public partial class Orderpersonlist
{
    public int Orderuserlistid { get; set; }

    public int Personrid { get; set; }

    public int Orderid { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Person Personr { get; set; } = null!;
}
