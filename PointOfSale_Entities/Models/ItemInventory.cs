using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class ItemInventory
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public decimal Quantity { get; set; }

    public bool? QuantityIsCount { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Item Item { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }
}
