using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class FinalizedPurchaseOrderDocument
{
    public int Id { get; set; }

    public int PurchaseOrderId { get; set; }

    public string PurchaseOrderJson { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual PurchaseOrder PurchaseOrder { get; set; }
}
