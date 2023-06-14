using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class StaffSecurityGroup
{
    public int Id { get; set; }

    public int? StaffId { get; set; }

    public int? SecurityGroupId { get; set; }

    public bool? IsActive { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual SecurityGroup SecurityGroup { get; set; }

    public virtual Staff Staff { get; set; }
}
