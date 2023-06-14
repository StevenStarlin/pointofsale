using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class TableDisplay
{
    public int Id { get; set; }

    public int? TableId { get; set; }

    public int? DisplayXcoordinate { get; set; }

    public int? DisplayYcoordinate { get; set; }

    public string DisplayColor { get; set; }

    public virtual Table Table { get; set; }
}
