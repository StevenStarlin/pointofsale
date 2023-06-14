using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class Discount
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsDollarAmount { get; set; }

    public decimal Amount { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPerItem { get; set; }

    public bool? IsOrderExclusive { get; set; }

    public int? CalculationSequenceIndex { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; } = new List<OrderDiscount>();
}
