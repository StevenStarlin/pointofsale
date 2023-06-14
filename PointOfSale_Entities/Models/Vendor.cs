using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class Vendor
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int VendorTypeId { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string City { get; set; }

    public string StateProvince { get; set; }

    public string PostalCode { get; set; }

    public string Notes { get; set; }

    public bool? IsActive { get; set; }

    public string Website { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual VendorType VendorType { get; set; }
}
