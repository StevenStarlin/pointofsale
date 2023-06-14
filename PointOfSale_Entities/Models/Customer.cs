using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string City { get; set; }

    public string StateProvince { get; set; }

    public string PostalCode { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsBanned { get; set; }

    public bool? IsSuspended { get; set; }

    public DateTime? SuspendedUntil { get; set; }

    public string Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();
}
