CREATE DATABASE PointOfSale
GO

USE PointOfSale
GO

CREATE TABLE [Staff](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[FirstName] VARCHAR(MAX),
	[MiddleName] VARCHAR(MAX),
	[LastName] VARCHAR(MAX),
	[Address1] VARCHAR(MAX),
	[Address2] VARCHAR(MAX),
	[City] VARCHAR(MAX),
	[StateProvince] VARCHAR(MAX),
	[PostalCode] VARCHAR(MAX),
	[PasswordHash] NVARCHAR(MAX),
	[Pin] VARCHAR(10),
	[Username] NVARCHAR(MAX),
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT, -- Manually update in software for this table, otherwise it's circular in EF.
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
);

CREATE TABLE [SystemLog](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[SourceTable] VARCHAR(100) NOT NULL,
	[SourceColumn] VARCHAR(100) NOT NULL,
	[InitialValue] NVARCHAR(MAX),
	[NewValue] NVARCHAR(MAX) NOT NULL,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	[Memo] NVARCHAR(MAX),
	[Severity] INT DEFAULT 0, -- Higher = bigger risk
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

/*********************************** Uncomment to recreate admin user ********************************************************/

-- CREATE System Admin User
INSERT INTO [Staff]
	(FirstName, LastName, Username, Pin, PasswordHash)
VALUES 
	('System', 'Administrator', 'admin', '2394', '21232f297a57a5a743894a0e4a801fc3'); -- defaulted to 'admin' for password

UPDATE Staff 
SET 
	MiddleName = '', 
	Address1 = '', 
	Address2 = '', 
	City = '', 
	StateProvince = '', 
	PostalCode = '', 
	LastUpdatedBy = 1

-- Log admin user firstname
INSERT INTO [SystemLog]
	(SourceTable, SourceColumn, NewValue, LastUpdatedBy, Memo, Severity)
VALUES
	('Staff', 'FirstName', 'System', 1, 'System admin user added on database setup', 5);

-- Log admin user lastname
INSERT INTO [SystemLog]
	(SourceTable, SourceColumn, NewValue, LastUpdatedBy, Memo, Severity)
VALUES
	('Staff', 'LastName', 'Administrator', 1, 'System admin user added on database setup', 5);

-- Log admin user pin
INSERT INTO [SystemLog]
	(SourceTable, SourceColumn, NewValue, LastUpdatedBy, Memo, Severity)
VALUES
	('Staff', 'Pin', '***********', 1, 'System admin user added on database setup - Pin obscured', 5);

-- Log admin user password hash
INSERT INTO [SystemLog]
	(SourceTable, SourceColumn, NewValue, LastUpdatedBy, Memo, Severity)
VALUES
	('Staff', 'PasswordHash', '***********', 1, 'System admin user added on database setup - password hash obscured', 5);

/*****************************************************************************************************************************/

CREATE TABLE [Setting](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	[SettingKey] NVARCHAR(MAX),
	[SettingValue] NVARCHAR(MAX),
	[IsActive] BIT DEFAULT 0,
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [Permission](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [SecurityGroup](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

-- Permissions assigned to a security group
CREATE TABLE [SecurityGroupPermission](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[SecurityGroupID] INT,
	[PermissionID] INT,
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([SecurityGroupID]) REFERENCES [SecurityGroup](ID),
	FOREIGN KEY ([PermissionID]) REFERENCES [Permission](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

-- Groups Assigned to a staff member
CREATE TABLE [StaffSecurityGroup](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[StaffID] INT,
	[SecurityGroupID] INT,
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([StaffID]) REFERENCES [Staff](ID),
	FOREIGN KEY ([SecurityGroupID]) REFERENCES [SecurityGroup](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [Item](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[Description] TEXT,
	[Cost] DECIMAL DEFAULT 0,
	[Price] DECIMAL,
	[IsDiscountable] BIT DEFAULT 1,
	[UPC] VARCHAR(MAX),
	[SKU] VARCHAR(100),
	[Weight] DECIMAL,
	[Height] DECIMAL,
	[Width] DECIMAL,
	[Depth] DECIMAL,
	[IsDigitalProduct] BIT,
	[SerialNumber] VARCHAR(MAX),
	[ModelNumber] VARCHAR(MAX),
	[IsActive] BIT DEFAULT 0,
	[LoyaltyPointValue] DECIMAL DEFAULT 0, -- The amount to add to loyalty points when purchased
	[IsBackOrdered] BIT DEFAULT 0,
	[BackOrderedOnDate] DATETIME,
	[VendorID] INT,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [ItemInventory](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[ItemID] INT NOT NULL,
	[Quantity] DECIMAL NOT NULL,
	[QuantityIsCount] BIT DEFAULT 1,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID),
	FOREIGN KEY ([ItemID]) REFERENCES [Item](ID)
);

CREATE TABLE [Discount](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[Code] VARCHAR(100),
	[StartDate] DATETIME,
	[EndDate] DATETIME,
	[IsDollarAmount] BIT DEFAULT 0,
	[Amount] DECIMAL NOT NULL,
	[IsActive] BIT DEFAULT 0,
	[IsPerItem] BIT DEFAULT 0, -- If 0, applies to whole order
	[IsOrderExclusive] BIT Default 0, -- Can be the only discount on order
	[CalculationSequenceIndex] INT DEFAULT 0, -- Order in which we calculate discounts
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [Table](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[NumberOfSeats] INT,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [TableDisplay](
	[ID] INT IDENTITY(1, 1) PRIMARY KEY,
	[TableID] INT,
	[DisplayXCoordinate] INT, -- Maybe break the display values out into their own table?
	[DisplayYCoordinate] INT,
	[DisplayColor] VARCHAR(10),
	FOREIGN KEY ([TableID]) REFERENCES [Table](ID)
);

CREATE TABLE [Customer](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[FirstName] VARCHAR(MAX),
	[MiddleName] VARCHAR(MAX),
	[LastName] VARCHAR(MAX),
	[Address1] VARCHAR(MAX),
	[Address2] VARCHAR(MAX),
	[City] VARCHAR(MAX),
	[StateProvince] VARCHAR(MAX),
	[PostalCode] VARCHAR(MAX),
	[IsActive] BIT DEFAULT 1,
	[IsBanned] BIT DEFAULT 0,
	[IsSuspended] BIT DEFAULT 0,
	[SuspendedUntil] DATETIME,
	[Notes] TEXT,
	[CreatedOn] DATETIME DEFAULT GETDATE(),
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [CustomerLoyalty](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[CustomerID] INT NOT NULL,
	[LoyaltyPoints] DECIMAL DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID),
	FOREIGN KEY ([CustomerID]) REFERENCES [Order](ID)
);

CREATE TABLE [CustomerLoyaltyTransaction](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[CustomerLoyaltyID] INT NOT NULL,
	[LoyaltyPointDifference] DECIMAL, -- Additional or Subtractional value
	[LoyaltyPointTotal] DECIMAL, -- Total running value, the latest of which should match CustomerLoyalty.LoyaltyPoints
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([CustomerLoyaltyID]) REFERENCES [CustomerLoyalty](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

-- Reports can be run against CreatedOn date to see how often a customer frequents the establishment.
CREATE TABLE [Order](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[TableID] INT NOT NULL,
	[CustomerID] INT,
	[CreatedOn] DATETIME DEFAULT GETDATE(),
	[DeliveredOn] DATETIME,
	[IsLayaway] BIT DEFAULT 0,
	[LayawayDueDate] DATETIME,
	[LayawayLocation] VARCHAR(100),
	[ContainsBackOrderedItems] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([TableID]) REFERENCES [Table](ID),
	FOREIGN KEY ([CustomerID]) REFERENCES [Customer](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [OrderItem](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[OrderID] INT NOT NULL,
	[ItemID] INT NOT NULL,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID),
	FOREIGN KEY ([OrderID]) REFERENCES [Order](ID)
);

CREATE TABLE [OrderDiscount](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[OrderID] INT NOT NULL,
	[DiscountID] INT NOT NULL,
	[ItemID] INT,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([OrderID]) REFERENCES [Order](ID),
	FOREIGN KEY ([DiscountID]) REFERENCES [Discount](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [FinalizedOrderDocument](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[OrderID] INT NOT NULL,
	[CustomerID] INT,
	[OrderJSON] TEXT NOT NULL,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([OrderID]) REFERENCES [Order](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

-- Possible stages of an order
CREATE TABLE [OrderStatusOption](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[SequenceIndex] INT,
	[Notes] NVARCHAR(MAX),
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

-- Used for KDS display and in-flight order audits
CREATE TABLE [OrderStatus](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[OrderID] INT NOT NULL,
	[OrderStatusOptionID] INT NOT NULL,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([OrderID]) REFERENCES [Order](ID),
	FOREIGN KEY ([OrderStatusOptionID]) REFERENCES [OrderStatusOption](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

-- Shipping, Grocery, Office
CREATE TABLE [VendorType](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

-- UPS, USPS, DHL, Fedex, etc.
CREATE TABLE [Vendor](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[VendorTypeID] INT NOT NULL,
	[Address1] VARCHAR(MAX),
	[Address2] VARCHAR(MAX),
	[City] VARCHAR(MAX),
	[StateProvince] VARCHAR(MAX),
	[PostalCode] VARCHAR(MAX),
	[Notes] NVARCHAR(MAX),
	[IsActive] BIT DEFAULT 0,
	[Website] NVARCHAR(MAX),
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID),
	FOREIGN KEY ([VendorTypeID]) REFERENCES [Vendor](ID)
);

CREATE TABLE [PurchaseOrder](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[VendorID] INT,
	[PONumber] VARCHAR(40),
	[CreatedOn] DATETIME DEFAULT GETDATE(),
	[DeliveredOn] DATETIME,
	[PaymentDueDate] DATETIME,
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([VendorID]) REFERENCES [Customer](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [PurchaseOrderItem](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[PurchaseOrderID] INT NOT NULL,
	[VendorID] INT,
	[ItemID] INT NOT NULL,
	[SKU] VARCHAR(100),
	[ItemDescription] NVARCHAR(MAX),
	[Quantity] DECIMAL,
	[Price] DECIMAL,
	[Cost] DECIMAL,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID),
	FOREIGN KEY ([PurchaseOrderID]) REFERENCES [PurchaseOrder](ID),
	FOREIGN KEY ([VendorID]) REFERENCES [Vendor](ID)
);

CREATE TABLE [FinalizedPurchaseOrderDocument](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[PurchaseOrderID] INT NOT NULL,
	[PurchaseOrderJSON] TEXT NOT NULL,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([PurchaseOrderID]) REFERENCES [PurchaseOrder](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [UnitOfMeasure](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);

CREATE TABLE [ItemRecipe](
	[ID] INT IDENTITY(1,1) PRIMARY KEY,
	[ItemID] INT,
	[ChildItemID] INT,
	[ChildItemAmount] DECIMAL,
	[UnitOfMeasureID] INT,
	[Notes] NVARCHAR(MAX),
	[IsActive] BIT DEFAULT 0,
	[LastUpdatedBy] INT NOT NULL, -- FK to Staff
	[LastUpdatedOn] DATETIME DEFAULT GETDATE(),
	FOREIGN KEY ([ItemID]) REFERENCES [Item](ID),
	FOREIGN KEY ([ChildItemID]) REFERENCES [Item](ID),
	FOREIGN KEY ([UnitOfMeasureID]) REFERENCES [UnitOfMeasure](ID),
	FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Staff](ID)
);