using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class OrderStatusOption
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? SequenceIndex { get; set; }

    public string Notes { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual ICollection<OrderStatus> OrderStatuses { get; } = new List<OrderStatus>();
}
