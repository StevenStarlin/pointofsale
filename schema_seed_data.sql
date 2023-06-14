-- Load seed data for dev

-- Setting
	INSERT INTO [Setting] ([LastUpdatedBy], [LastUpdatedOn], [SettingKey], [SettingValue], [IsActive])
		VALUES (1, GETDATE(), 'Theme', 'Dark', 1);

-- UnitOfMeasure
	INSERT INTO [UnitOfMeasure] ([Name], [IsActive], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('lbs', 1, 1, GETDATE());

-- VendorType
	INSERT INTO [VendorType] ([Name], [IsActive], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('Shipping', 1, 1, GETDATE());

-- Vendor
	INSERT INTO [Vendor] ([Name], [VendorTypeID], [Address1], [Address2], [City], 
					[StateProvince], [PostalCode], [Notes], [IsActive], [Website], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('USPS', 1, '123 North St.', 'Suite 2', 'Detroit', 'Michigan', 
					'48127', 'Not a great option', 1, 'https://google.com', 1, GETDATE());

-- Permission
	INSERT INTO [Permission] ([Name], [IsActive], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('LogIn', 1, 1, GETDATE());

-- SecurityGroup
	INSERT INTO SecurityGroup ([Name], [IsActive], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('Administrator', 1, 1, GETDATE());

-- SecurityGroupPermission
	INSERT INTO SecurityGroupPermission ([SecurityGroupID], [PermissionID], [IsActive], [LastUpdatedBy], [LastUpdatedOn])
		VALUES (1, 1, 1, 1, GETDATE());

-- StaffSecurityGroup
	INSERT INTO [StaffSecurityGroup] ([StaffID], [SecurityGroupID], [IsActive], [LastUpdatedBy], [LastUpdatedOn])
		VALUES (1, 1, 1, 1, GETDATE());

-- OrderStatusOption
	INSERT INTO [OrderStatusOption] ([Name], [SequenceIndex], [Notes], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('Created', 1, 'Red Shirt Guy', 1, GETDATE());

-- Table
	INSERT INTO [Table] ([Name], [NumberOfSeats], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('Table 1', 4, 1, GETDATE());

-- TableDisplay
	INSERT INTO [TableDisplay] ([TableId], [DisplayXCoordinate], [DisplayYCoordinate], [DisplayColor])
		VALUES (1, 15, 15, '#acacac');

-- Discount
	INSERT INTO [Discount] ([Name], [Code], [StartDate], [EndDate], [IsDollarAmount], [Amount], [IsActive],
								[IsPerItem], [IsOrderExclusive], [CalculationSequenceIndex], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('Holiday Sale', 'Holiday22', GETDATE(), '2023-01-17', 1, 15.00, 1, 0, 1, 1, 1, GETDATE());

-- Customer
	INSERT INTO [Customer] ([FirstName], [MiddleName], [LastName], [Address1], [City], 
								[StateProvince], [PostalCode], [IsActive], [IsBanned], [IsSuspended],
								[Notes], [CreatedOn], [LastUpdatedBy], [LastUpdatedOn])
		VALUES ('Jay', 'Jonah', 'Jameson', '123 Main St.', 'Lansing', 'MI', '12345', 1, 0, 0, 
					'They are person', GETDATE(), 1, GETDATE());