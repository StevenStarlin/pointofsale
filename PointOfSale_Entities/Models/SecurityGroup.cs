using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class SecurityGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool? IsActive { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual ICollection<SecurityGroupPermission> SecurityGroupPermissions { get; } = new List<SecurityGroupPermission>();

    public virtual ICollection<StaffSecurityGroup> StaffSecurityGroups { get; } = new List<StaffSecurityGroup>();
}
