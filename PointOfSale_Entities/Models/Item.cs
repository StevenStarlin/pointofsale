using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal? Cost { get; set; }

    public decimal? Price { get; set; }

    public bool? IsDiscountable { get; set; }

    public string Upc { get; set; }

    public string Sku { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public decimal? Width { get; set; }

    public decimal? Depth { get; set; }

    public bool? IsDigitalProduct { get; set; }

    public string SerialNumber { get; set; }

    public string ModelNumber { get; set; }

    public bool? IsActive { get; set; }

    public decimal? LoyaltyPointValue { get; set; }

    public bool? IsBackOrdered { get; set; }

    public DateTime? BackOrderedOnDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual ICollection<ItemInventory> ItemInventories { get; } = new List<ItemInventory>();

    public virtual ICollection<ItemRecipe> ItemRecipeChildItems { get; } = new List<ItemRecipe>();

    public virtual ICollection<ItemRecipe> ItemRecipeItems { get; } = new List<ItemRecipe>();

    public virtual Staff LastUpdatedByNavigation { get; set; }
}
