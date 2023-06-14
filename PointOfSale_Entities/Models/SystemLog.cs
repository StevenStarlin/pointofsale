using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class SystemLog
{
    public int Id { get; set; }

    public string SourceTable { get; set; }

    public string SourceColumn { get; set; }

    public string InitialValue { get; set; }

    public string NewValue { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string Memo { get; set; }

    public int? Severity { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }
}
