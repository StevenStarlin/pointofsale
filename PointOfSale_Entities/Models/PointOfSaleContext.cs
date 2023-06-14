using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PointOfSale_Entities.Models;

public partial class PointOfSaleContext : DbContext
{
    public PointOfSaleContext()
    {
    }

    public PointOfSaleContext(DbContextOptions<PointOfSaleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerLoyalty> CustomerLoyalties { get; set; }

    public virtual DbSet<CustomerLoyaltyTransaction> CustomerLoyaltyTransactions { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<FinalizedOrderDocument> FinalizedOrderDocuments { get; set; }

    public virtual DbSet<FinalizedPurchaseOrderDocument> FinalizedPurchaseOrderDocuments { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemInventory> ItemInventories { get; set; }

    public virtual DbSet<ItemRecipe> ItemRecipes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDiscount> OrderDiscounts { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<OrderStatusOption> OrderStatusOptions { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<SecurityGroup> SecurityGroups { get; set; }

    public virtual DbSet<SecurityGroupPermission> SecurityGroupPermissions { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffSecurityGroup> StaffSecurityGroups { get; set; }

    public virtual DbSet<SystemLog> SystemLogs { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<TableDisplay> TableDisplays { get; set; }

    public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VendorType> VendorTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PointOfSale;Trusted_Connection=True;TrustServerCertificate=True;User ID=articulous;Password=2Skulled");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC274332D352");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address1).IsUnicode(false);
            entity.Property(e => e.Address2).IsUnicode(false);
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName).IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsBanned).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsSuspended).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastName).IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MiddleName).IsUnicode(false);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PostalCode).IsUnicode(false);
            entity.Property(e => e.StateProvince).IsUnicode(false);
            entity.Property(e => e.SuspendedUntil).HasColumnType("datetime");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__LastUp__6D0D32F4");
        });

        modelBuilder.Entity<CustomerLoyalty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC27A719F79D");

            entity.ToTable("CustomerLoyalty");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoyaltyPoints)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.CustomerLoyalties)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerL__LastU__71D1E811");
        });

        modelBuilder.Entity<CustomerLoyaltyTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC2736221DBE");

            entity.ToTable("CustomerLoyaltyTransaction");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerLoyaltyId).HasColumnName("CustomerLoyaltyID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoyaltyPointDifference).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.LoyaltyPointTotal).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CustomerLoyalty).WithMany(p => p.CustomerLoyaltyTransactions)
                .HasForeignKey(d => d.CustomerLoyaltyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerL__Custo__75A278F5");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.CustomerLoyaltyTransactions)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerL__LastU__76969D2E");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC27AB2EA5CA");

            entity.ToTable("Discount");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CalculationSequenceIndex).HasDefaultValueSql("((0))");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDollarAmount).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsOrderExclusive).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsPerItem).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Discount__LastUp__5EBF139D");
        });

        modelBuilder.Entity<FinalizedOrderDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Finalize__3214EC2772531166");

            entity.ToTable("FinalizedOrderDocument");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderJson)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("OrderJSON");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.FinalizedOrderDocuments)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Finalized__LastU__0D7A0286");

            entity.HasOne(d => d.Order).WithMany(p => p.FinalizedOrderDocuments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Finalized__Order__0C85DE4D");
        });

        modelBuilder.Entity<FinalizedPurchaseOrderDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Finalize__3214EC27A7142AB9");

            entity.ToTable("FinalizedPurchaseOrderDocument");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");
            entity.Property(e => e.PurchaseOrderJson)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("PurchaseOrderJSON");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.FinalizedPurchaseOrderDocuments)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Finalized__LastU__2FCF1A8A");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.FinalizedPurchaseOrderDocuments)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Finalized__Purch__2EDAF651");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Item__3214EC277647D13C");

            entity.ToTable("Item");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BackOrderedOnDate).HasColumnType("datetime");
            entity.Property(e => e.Cost)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Depth).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsBackOrdered).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDiscountable).HasDefaultValueSql("((1))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoyaltyPointValue)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ModelNumber).IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SerialNumber).IsUnicode(false);
            entity.Property(e => e.Sku)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.Upc)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Item__LastUpdate__5070F446");
        });

        modelBuilder.Entity<ItemInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemInve__3214EC27E0688F1C");

            entity.ToTable("ItemInventory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.QuantityIsCount).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemInventories)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemInven__ItemI__5629CD9C");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.ItemInventories)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemInven__LastU__5535A963");
        });

        modelBuilder.Entity<ItemRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemReci__3214EC27BCE2BF17");

            entity.ToTable("ItemRecipe");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChildItemAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ChildItemId).HasColumnName("ChildItemID");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UnitOfMeasureId).HasColumnName("UnitOfMeasureID");

            entity.HasOne(d => d.ChildItem).WithMany(p => p.ItemRecipeChildItems)
                .HasForeignKey(d => d.ChildItemId)
                .HasConstraintName("FK__ItemRecip__Child__3A4CA8FD");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemRecipeItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__ItemRecip__ItemI__395884C4");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.ItemRecipes)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemRecip__LastU__3C34F16F");

            entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.ItemRecipes)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .HasConstraintName("FK__ItemRecip__UnitO__3B40CD36");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC279A95AA32");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContainsBackOrderedItems).HasDefaultValueSql("((0))");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveredOn).HasColumnType("datetime");
            entity.Property(e => e.IsLayaway).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LayawayDueDate).HasColumnType("datetime");
            entity.Property(e => e.LayawayLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__7E37BEF6");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__LastUpdat__7F2BE32F");

            entity.HasOne(d => d.Table).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__TableID__7D439ABD");
        });

        modelBuilder.Entity<OrderDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDis__3214EC277A1D7257");

            entity.ToTable("OrderDiscount");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Discount).WithMany(p => p.OrderDiscounts)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDisc__Disco__07C12930");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.OrderDiscounts)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDisc__LastU__08B54D69");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDiscounts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDisc__Order__06CD04F7");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC276836D2D6");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__LastU__02FC7413");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__58D1301D");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC274F4C9B8E");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderStatusOptionId).HasColumnName("OrderStatusOptionID");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.OrderStatuses)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderStat__LastU__17036CC0");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderStatuses)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderStat__Order__151B244E");

            entity.HasOne(d => d.OrderStatusOption).WithMany(p => p.OrderStatuses)
                .HasForeignKey(d => d.OrderStatusOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderStat__Order__160F4887");
        });

        modelBuilder.Entity<OrderStatusOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC27B3230B8D");

            entity.ToTable("OrderStatusOption");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.OrderStatusOptions)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderStat__LastU__114A936A");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC2725BB9DB1");

            entity.ToTable("Permission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permissio__LastU__35BCFE0A");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC2706C281BC");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeliveredOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentDueDate).HasColumnType("datetime");
            entity.Property(e => e.Ponumber)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PONumber");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__LastU__2739D489");

            entity.HasOne(d => d.Vendor).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__PurchaseO__Vendo__2645B050");
        });

        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC27B9C4EAA8");

            entity.ToTable("PurchaseOrderItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Sku)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SKU");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__LastU__2B0A656D");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__Purch__59C55456");
        });

        modelBuilder.Entity<SecurityGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Security__3214EC27870265A5");

            entity.ToTable("SecurityGroup");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.SecurityGroups)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SecurityG__LastU__3A81B327");
        });

        modelBuilder.Entity<SecurityGroupPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Security__3214EC270B8E3BC8");

            entity.ToTable("SecurityGroupPermission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.SecurityGroupId).HasColumnName("SecurityGroupID");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.SecurityGroupPermissions)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SecurityG__LastU__412EB0B6");

            entity.HasOne(d => d.Permission).WithMany(p => p.SecurityGroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__SecurityG__Permi__403A8C7D");

            entity.HasOne(d => d.SecurityGroup).WithMany(p => p.SecurityGroupPermissions)
                .HasForeignKey(d => d.SecurityGroupId)
                .HasConstraintName("FK__SecurityG__Secur__3F466844");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Setting__3214EC27AE385381");

            entity.ToTable("Setting");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Settings)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Setting__LastUpd__30F848ED");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Staff__3214EC27B270ED4C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address1).IsUnicode(false);
            entity.Property(e => e.Address2).IsUnicode(false);
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.FirstName).IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastName).IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.MiddleName).IsUnicode(false);
            entity.Property(e => e.Pin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode).IsUnicode(false);
            entity.Property(e => e.StateProvince).IsUnicode(false);
        });

        modelBuilder.Entity<StaffSecurityGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StaffSec__3214EC2775FD9163");

            entity.ToTable("StaffSecurityGroup");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SecurityGroupId).HasColumnName("SecurityGroupID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.StaffSecurityGroupLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StaffSecu__LastU__47DBAE45");

            entity.HasOne(d => d.SecurityGroup).WithMany(p => p.StaffSecurityGroups)
                .HasForeignKey(d => d.SecurityGroupId)
                .HasConstraintName("FK__StaffSecu__Secur__46E78A0C");

            entity.HasOne(d => d.Staff).WithMany(p => p.StaffSecurityGroupStaffs)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__StaffSecu__Staff__45F365D3");
        });

        modelBuilder.Entity<SystemLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SystemLo__3214EC2724775F6E");

            entity.ToTable("SystemLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NewValue).IsRequired();
            entity.Property(e => e.Severity).HasDefaultValueSql("((0))");
            entity.Property(e => e.SourceColumn)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SourceTable)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.SystemLogs)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SystemLog__LastU__2B3F6F97");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC27DD848DCD");

            entity.ToTable("Table");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Tables)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Table__LastUpdat__628FA481");
        });

        modelBuilder.Entity<TableDisplay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TableDis__3214EC276B35C867");

            entity.ToTable("TableDisplay");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DisplayColor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DisplayXcoordinate).HasColumnName("DisplayXCoordinate");
            entity.Property(e => e.DisplayYcoordinate).HasColumnName("DisplayYCoordinate");
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Table).WithMany(p => p.TableDisplays)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__TableDisp__Table__656C112C");
        });

        modelBuilder.Entity<UnitOfMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UnitOfMe__3214EC270B837B31");

            entity.ToTable("UnitOfMeasure");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.UnitOfMeasures)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UnitOfMea__LastU__3493CFA7");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vendor__3214EC2700040D81");

            entity.ToTable("Vendor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address1).IsUnicode(false);
            entity.Property(e => e.Address2).IsUnicode(false);
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode).IsUnicode(false);
            entity.Property(e => e.StateProvince).IsUnicode(false);
            entity.Property(e => e.VendorTypeId).HasColumnName("VendorTypeID");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vendor__LastUpda__208CD6FA");

            entity.HasOne(d => d.VendorType).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.VendorTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vendor__VendorTy__57DD0BE4");
        });

        modelBuilder.Entity<VendorType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VendorTy__3214EC27F28DFC2F");

            entity.ToTable("VendorType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastUpdatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.VendorTypes)
                .HasForeignKey(d => d.LastUpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VendorTyp__LastU__1BC821DD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
