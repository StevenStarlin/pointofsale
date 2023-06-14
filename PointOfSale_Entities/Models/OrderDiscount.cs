using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class OrderDiscount
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int DiscountId { get; set; }

    public int? ItemId { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Discount Discount { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual Order Order { get; set; }
}
