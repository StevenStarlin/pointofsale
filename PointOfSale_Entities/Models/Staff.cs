using System;
using System.Collections.Generic;

namespace PointOfSale_Entities.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string City { get; set; }

    public string StateProvince { get; set; }

    public string PostalCode { get; set; }

    public string PasswordHash { get; set; }

    public string Pin { get; set; }

    public string Username { get; set; }

    public bool? IsActive { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual ICollection<CustomerLoyalty> CustomerLoyalties { get; } = new List<CustomerLoyalty>();

    public virtual ICollection<CustomerLoyaltyTransaction> CustomerLoyaltyTransactions { get; } = new List<CustomerLoyaltyTransaction>();

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<Discount> Discounts { get; } = new List<Discount>();

    public virtual ICollection<FinalizedOrderDocument> FinalizedOrderDocuments { get; } = new List<FinalizedOrderDocument>();

    public virtual ICollection<FinalizedPurchaseOrderDocument> FinalizedPurchaseOrderDocuments { get; } = new List<FinalizedPurchaseOrderDocument>();

    public virtual ICollection<ItemInventory> ItemInventories { get; } = new List<ItemInventory>();

    public virtual ICollection<ItemRecipe> ItemRecipes { get; } = new List<ItemRecipe>();

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; } = new List<OrderDiscount>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<OrderStatusOption> OrderStatusOptions { get; } = new List<OrderStatusOption>();

    public virtual ICollection<OrderStatus> OrderStatuses { get; } = new List<OrderStatus>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; } = new List<PurchaseOrderItem>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    public virtual ICollection<SecurityGroupPermission> SecurityGroupPermissions { get; } = new List<SecurityGroupPermission>();

    public virtual ICollection<SecurityGroup> SecurityGroups { get; } = new List<SecurityGroup>();

    public virtual ICollection<Setting> Settings { get; } = new List<Setting>();

    public virtual ICollection<StaffSecurityGroup> StaffSecurityGroupLastUpdatedByNavigations { get; } = new List<StaffSecurityGroup>();

    public virtual ICollection<StaffSecurityGroup> StaffSecurityGroupStaffs { get; } = new List<StaffSecurityGroup>();

    public virtual ICollection<SystemLog> SystemLogs { get; } = new List<SystemLog>();

    public virtual ICollection<Table> Tables { get; } = new List<Table>();

    public virtual ICollection<UnitOfMeasure> UnitOfMeasures { get; } = new List<UnitOfMeasure>();

    public virtual ICollection<VendorType> VendorTypes { get; } = new List<VendorType>();

    public virtual ICollection<Vendor> Vendors { get; } = new List<Vendor>();
}
