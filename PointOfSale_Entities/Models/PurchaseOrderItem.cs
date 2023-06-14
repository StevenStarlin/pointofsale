using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class PurchaseOrderItem
{
    public int Id { get; set; }

    public int PurchaseOrderId { get; set; }

    public int ItemId { get; set; }

    public string Sku { get; set; }

    public string ItemDescription { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Cost { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual PurchaseOrder PurchaseOrder { get; set; }
}
