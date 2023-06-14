using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class CustomerLoyaltyTransaction
{
    public int Id { get; set; }

    public int CustomerLoyaltyId { get; set; }

    public decimal? LoyaltyPointDifference { get; set; }

    public decimal? LoyaltyPointTotal { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual CustomerLoyalty CustomerLoyalty { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }
}
