using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class Order
{
    public int Id { get; set; }

    public int TableId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? DeliveredOn { get; set; }

    public bool? IsLayaway { get; set; }

    public DateTime? LayawayDueDate { get; set; }

    public string LayawayLocation { get; set; }

    public bool? ContainsBackOrderedItems { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<FinalizedOrderDocument> FinalizedOrderDocuments { get; } = new List<FinalizedOrderDocument>();

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; } = new List<OrderDiscount>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<OrderStatus> OrderStatuses { get; } = new List<OrderStatus>();

    public virtual Table Table { get; set; }
}
