using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class Table
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? NumberOfSeats { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<TableDisplay> TableDisplays { get; } = new List<TableDisplay>();
}
