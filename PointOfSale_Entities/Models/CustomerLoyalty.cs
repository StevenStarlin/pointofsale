using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class CustomerLoyalty
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public decimal? LoyaltyPoints { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual ICollection<CustomerLoyaltyTransaction> CustomerLoyaltyTransactions { get; } = new List<CustomerLoyaltyTransaction>();

    public virtual Staff LastUpdatedByNavigation { get; set; }
}
