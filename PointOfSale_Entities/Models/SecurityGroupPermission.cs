using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class SecurityGroupPermission
{
    public int Id { get; set; }

    public int? SecurityGroupId { get; set; }

    public int? PermissionId { get; set; }

    public bool? IsActive { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual Permission Permission { get; set; }

    public virtual SecurityGroup SecurityGroup { get; set; }
}
