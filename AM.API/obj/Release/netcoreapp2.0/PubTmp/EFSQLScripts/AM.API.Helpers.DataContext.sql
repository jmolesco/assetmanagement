IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525034136_InitialCreate')
BEGIN
    CREATE TABLE [Manufacturers] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [Name] nvarchar(50) NULL,
        CONSTRAINT [PK_Manufacturers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525034136_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180525034136_InitialCreate', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525035756_CreatedCategoryTable')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [Name] nvarchar(20) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525035756_CreatedCategoryTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180525035756_CreatedCategoryTable', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525045830_CreatedModelSizesSupplierTables')
BEGIN
    CREATE TABLE [HardDiskSizes] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [Size] nvarchar(5) NULL,
        CONSTRAINT [PK_HardDiskSizes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525045830_CreatedModelSizesSupplierTables')
BEGIN
    CREATE TABLE [MemorySizes] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [Size] nvarchar(5) NULL,
        CONSTRAINT [PK_MemorySizes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525045830_CreatedModelSizesSupplierTables')
BEGIN
    CREATE TABLE [Models] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [Name] nvarchar(30) NULL,
        CONSTRAINT [PK_Models] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525045830_CreatedModelSizesSupplierTables')
BEGIN
    CREATE TABLE [Suppliers] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [Name] nvarchar(100) NULL,
        CONSTRAINT [PK_Suppliers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525045830_CreatedModelSizesSupplierTables')
BEGIN
    CREATE TABLE [VideoCardSizes] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [Size] nvarchar(5) NULL,
        CONSTRAINT [PK_VideoCardSizes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180525045830_CreatedModelSizesSupplierTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180525045830_CreatedModelSizesSupplierTables', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180528122756_AddedProcessorTable')
BEGIN
    CREATE TABLE [Processors] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [Name] nvarchar(30) NULL,
        CONSTRAINT [PK_Processors] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180528122756_AddedProcessorTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180528122756_AddedProcessorTable', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE TABLE [Assets] (
        [Id] int NOT NULL IDENTITY,
        [Adapter] nvarchar(20) NULL,
        [AssetTag] nvarchar(20) NULL,
        [AssignedTo] nvarchar(50) NULL,
        [Battery] nvarchar(20) NULL,
        [CategoryId] int NULL,
        [DRNo] nvarchar(15) NULL,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [DeliveryDate] date NULL,
        [HardDiskId] int NULL,
        [HostName] nvarchar(20) NULL,
        [IPAddress] nvarchar(20) NULL,
        [MacAddress] nvarchar(20) NULL,
        [ManufacturerId] int NULL,
        [MemoryId] int NULL,
        [ModelId] int NULL,
        [PONo] nvarchar(15) NULL,
        [ProcessorId] int NULL,
        [SINo] nvarchar(15) NULL,
        [SerialNo] nvarchar(20) NULL,
        [Status] int NULL,
        [SupplierId] int NULL,
        [VideoCardId] int NULL,
        CONSTRAINT [PK_Assets] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Assets_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Assets_HardDiskSizes_HardDiskId] FOREIGN KEY ([HardDiskId]) REFERENCES [HardDiskSizes] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Assets_Manufacturers_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [Manufacturers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Assets_MemorySizes_MemoryId] FOREIGN KEY ([MemoryId]) REFERENCES [MemorySizes] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Assets_Models_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [Models] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Assets_Processors_ProcessorId] FOREIGN KEY ([ProcessorId]) REFERENCES [Processors] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Assets_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Assets_VideoCardSizes_VideoCardId] FOREIGN KEY ([VideoCardId]) REFERENCES [VideoCardSizes] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE INDEX [IX_Assets_CategoryId] ON [Assets] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE INDEX [IX_Assets_HardDiskId] ON [Assets] ([HardDiskId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE INDEX [IX_Assets_ManufacturerId] ON [Assets] ([ManufacturerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE INDEX [IX_Assets_MemoryId] ON [Assets] ([MemoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE INDEX [IX_Assets_ModelId] ON [Assets] ([ModelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE INDEX [IX_Assets_ProcessorId] ON [Assets] ([ProcessorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE INDEX [IX_Assets_SupplierId] ON [Assets] ([SupplierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    CREATE INDEX [IX_Assets_VideoCardId] ON [Assets] ([VideoCardId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529035744_AddedAssetTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180529035744_AddedAssetTable', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529041318_RenamedHostNameToName')
BEGIN
    EXEC sp_rename N'Assets.HostName', N'Name', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529041318_RenamedHostNameToName')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180529041318_RenamedHostNameToName', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_VideoCardSizes_Id] ON [VideoCardSizes] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_VideoCardSizes_Size] ON [VideoCardSizes] ([Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_VideoCardSizes_Id_Size] ON [VideoCardSizes] ([Id], [Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Suppliers_Id] ON [Suppliers] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Suppliers_Name] ON [Suppliers] ([Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Suppliers_Id_Name] ON [Suppliers] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Processors_Id] ON [Processors] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Processors_Name] ON [Processors] ([Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Processors_Id_Name] ON [Processors] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Models_Id] ON [Models] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Models_Name] ON [Models] ([Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Models_Id_Name] ON [Models] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_MemorySizes_Id] ON [MemorySizes] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_MemorySizes_Size] ON [MemorySizes] ([Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_MemorySizes_Id_Size] ON [MemorySizes] ([Id], [Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Manufacturers_Id] ON [Manufacturers] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Manufacturers_Name] ON [Manufacturers] ([Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Manufacturers_Id_Name] ON [Manufacturers] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_HardDiskSizes_Id] ON [HardDiskSizes] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_HardDiskSizes_Size] ON [HardDiskSizes] ([Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_HardDiskSizes_Id_Size] ON [HardDiskSizes] ([Id], [Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Categories_Id] ON [Categories] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Categories_Name] ON [Categories] ([Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Categories_Id_Name] ON [Categories] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Assets_Id] ON [Assets] ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Assets_SerialNo_AssetTag_Name] ON [Assets] ([SerialNo], [AssetTag], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    CREATE INDEX [IX_Assets_Id_SerialNo_AssetTag_Name] ON [Assets] ([Id], [SerialNo], [AssetTag], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180529082412_AddedIndexColumns')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180529082412_AddedIndexColumns', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100546_ModifiedAssetTable')
BEGIN
    DROP INDEX [IX_Assets_SerialNo_AssetTag_Name] ON [Assets];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100546_ModifiedAssetTable')
BEGIN
    DROP INDEX [IX_Assets_Id_SerialNo_AssetTag_Name] ON [Assets];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100546_ModifiedAssetTable')
BEGIN
    ALTER TABLE [Assets] ADD [Notes] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100546_ModifiedAssetTable')
BEGIN
    ALTER TABLE [Assets] ADD [PurchaseCost] decimal(18, 2) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100546_ModifiedAssetTable')
BEGIN
    ALTER TABLE [Assets] ADD [PurchaseDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100546_ModifiedAssetTable')
BEGIN
    ALTER TABLE [Assets] ADD [Warranty] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100546_ModifiedAssetTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180530100546_ModifiedAssetTable', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100736_ModifiedPurchaseDateType')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Assets') AND [c].[name] = N'PurchaseDate');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Assets] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Assets] ALTER COLUMN [PurchaseDate] date NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530100736_ModifiedPurchaseDateType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180530100736_ModifiedPurchaseDateType', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    ALTER TABLE [Assets] DROP CONSTRAINT [FK_Assets_Models_ModelId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_VideoCardSizes_Size] ON [VideoCardSizes];
    DROP INDEX [IX_VideoCardSizes_Id_Size] ON [VideoCardSizes];
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'VideoCardSizes') AND [c].[name] = N'Size');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [VideoCardSizes] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [VideoCardSizes] ALTER COLUMN [Size] nvarchar(5) NOT NULL;
    CREATE INDEX [IX_VideoCardSizes_Size] ON [VideoCardSizes] ([Size]);
    CREATE INDEX [IX_VideoCardSizes_Id_Size] ON [VideoCardSizes] ([Id], [Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_Suppliers_Name] ON [Suppliers];
    DROP INDEX [IX_Suppliers_Id_Name] ON [Suppliers];
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Suppliers') AND [c].[name] = N'Name');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Suppliers] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Suppliers] ALTER COLUMN [Name] nvarchar(100) NOT NULL;
    CREATE INDEX [IX_Suppliers_Name] ON [Suppliers] ([Name]);
    CREATE INDEX [IX_Suppliers_Id_Name] ON [Suppliers] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_Processors_Name] ON [Processors];
    DROP INDEX [IX_Processors_Id_Name] ON [Processors];
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Processors') AND [c].[name] = N'Name');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Processors] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Processors] ALTER COLUMN [Name] nvarchar(30) NOT NULL;
    CREATE INDEX [IX_Processors_Name] ON [Processors] ([Name]);
    CREATE INDEX [IX_Processors_Id_Name] ON [Processors] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_Models_Name] ON [Models];
    DROP INDEX [IX_Models_Id_Name] ON [Models];
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Models') AND [c].[name] = N'Name');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Models] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Models] ALTER COLUMN [Name] nvarchar(30) NOT NULL;
    CREATE INDEX [IX_Models_Name] ON [Models] ([Name]);
    CREATE INDEX [IX_Models_Id_Name] ON [Models] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_MemorySizes_Size] ON [MemorySizes];
    DROP INDEX [IX_MemorySizes_Id_Size] ON [MemorySizes];
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'MemorySizes') AND [c].[name] = N'Size');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [MemorySizes] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [MemorySizes] ALTER COLUMN [Size] nvarchar(5) NOT NULL;
    CREATE INDEX [IX_MemorySizes_Size] ON [MemorySizes] ([Size]);
    CREATE INDEX [IX_MemorySizes_Id_Size] ON [MemorySizes] ([Id], [Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_Manufacturers_Name] ON [Manufacturers];
    DROP INDEX [IX_Manufacturers_Id_Name] ON [Manufacturers];
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Manufacturers') AND [c].[name] = N'Name');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Manufacturers] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Manufacturers] ALTER COLUMN [Name] nvarchar(50) NOT NULL;
    CREATE INDEX [IX_Manufacturers_Name] ON [Manufacturers] ([Name]);
    CREATE INDEX [IX_Manufacturers_Id_Name] ON [Manufacturers] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_HardDiskSizes_Size] ON [HardDiskSizes];
    DROP INDEX [IX_HardDiskSizes_Id_Size] ON [HardDiskSizes];
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'HardDiskSizes') AND [c].[name] = N'Size');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [HardDiskSizes] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [HardDiskSizes] ALTER COLUMN [Size] nvarchar(5) NOT NULL;
    CREATE INDEX [IX_HardDiskSizes_Size] ON [HardDiskSizes] ([Size]);
    CREATE INDEX [IX_HardDiskSizes_Id_Size] ON [HardDiskSizes] ([Id], [Size]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_Categories_Name] ON [Categories];
    DROP INDEX [IX_Categories_Id_Name] ON [Categories];
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Categories') AND [c].[name] = N'Name');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Categories] ALTER COLUMN [Name] nvarchar(20) NOT NULL;
    CREATE INDEX [IX_Categories_Name] ON [Categories] ([Name]);
    CREATE INDEX [IX_Categories_Id_Name] ON [Categories] ([Id], [Name]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Assets') AND [c].[name] = N'Status');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Assets] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Assets] ALTER COLUMN [Status] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Assets') AND [c].[name] = N'Name');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Assets] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Assets] ALTER COLUMN [Name] nvarchar(20) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DROP INDEX [IX_Assets_ModelId] ON [Assets];
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Assets') AND [c].[name] = N'ModelId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Assets] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Assets] ALTER COLUMN [ModelId] int NOT NULL;
    CREATE INDEX [IX_Assets_ModelId] ON [Assets] ([ModelId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'Assets') AND [c].[name] = N'AssetTag');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Assets] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Assets] ALTER COLUMN [AssetTag] nvarchar(20) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    ALTER TABLE [Assets] ADD CONSTRAINT [FK_Assets_Models_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [Models] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180530103146_AddedRequiredAttributes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180530103146_AddedRequiredAttributes', N'2.0.3-rtm-10026');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180718044530_AddedUserTable')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [DateCreated] datetime2 NULL DEFAULT (getdate()),
        [DateUpdated] datetime2 NULL,
        [FullName] nvarchar(60) NULL,
        [PasswordHash] varbinary(max) NULL,
        [PasswordSalt] varbinary(max) NULL,
        [UserName] nvarchar(20) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180718044530_AddedUserTable')
BEGIN
    CREATE INDEX [IX_Users_UserName] ON [Users] ([UserName]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180718044530_AddedUserTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180718044530_AddedUserTable', N'2.0.3-rtm-10026');
END;

GO

