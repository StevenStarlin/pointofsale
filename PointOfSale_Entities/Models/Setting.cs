using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class Setting
{
    public int Id { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string SettingKey { get; set; }

    public string SettingValue { get; set; }

    public bool? IsActive { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }
}
