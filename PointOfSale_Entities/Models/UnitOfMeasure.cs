using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class UnitOfMeasure
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool? IsActive { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual ICollection<ItemRecipe> ItemRecipes { get; } = new List<ItemRecipe>();

    public virtual Staff LastUpdatedByNavigation { get; set; }
}
