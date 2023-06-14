using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class PurchaseOrder
{
    public int Id { get; set; }

    public int? VendorId { get; set; }

    public string Ponumber { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? DeliveredOn { get; set; }

    public DateTime? PaymentDueDate { get; set; }

    public bool? IsActive { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual ICollection<FinalizedPurchaseOrderDocument> FinalizedPurchaseOrderDocuments { get; } = new List<FinalizedPurchaseOrderDocument>();

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; } = new List<PurchaseOrderItem>();

    public virtual Customer Vendor { get; set; }
}
