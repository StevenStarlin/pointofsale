using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class ItemRecipe
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public int? ChildItemId { get; set; }

    public decimal? ChildItemAmount { get; set; }

    public int? UnitOfMeasureId { get; set; }

    public string Notes { get; set; }

    public bool? IsActive { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual Item ChildItem { get; set; }

    public virtual Item Item { get; set; }

    public virtual Staff LastUpdatedByNavigation { get; set; }

    public virtual UnitOfMeasure UnitOfMeasure { get; set; }
}
