GO

ALTER TABLE [Werken] DROP CONSTRAINT [FK_Werken_Facturen_FactuurId];

GO

DROP INDEX [IX_Werken_FactuurId] ON [Werken];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Werken]') AND [c].[name] = N'FactuurId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Werken] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Werken] DROP COLUMN [FactuurId];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Facturen]') AND [c].[name] = N'BetaaldOp');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Facturen] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Facturen] DROP COLUMN [BetaaldOp];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Facturen]') AND [c].[name] = N'Btw');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Facturen] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Facturen] DROP COLUMN [Btw];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Facturen]') AND [c].[name] = N'FileName');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Facturen] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Facturen] DROP COLUMN [FileName];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Facturen]') AND [c].[name] = N'IsBetaald');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Facturen] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Facturen] DROP COLUMN [IsBetaald];

GO

ALTER TABLE [Facturen] ADD [ExtraWerklijnId] int NULL;

GO

ALTER TABLE [Facturen] ADD [IsDownloaded] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [Facturen] ADD [OfferteId] int NULL;

GO

CREATE INDEX [IX_Facturen_ExtraWerklijnId] ON [Facturen] ([ExtraWerklijnId]);

GO

CREATE INDEX [IX_Facturen_OfferteId] ON [Facturen] ([OfferteId]);

GO

ALTER TABLE [Facturen] ADD CONSTRAINT [FK_Facturen_Werken_ExtraWerklijnId] FOREIGN KEY ([ExtraWerklijnId]) REFERENCES [Werken] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Facturen] ADD CONSTRAINT [FK_Facturen_Offertes_OfferteId] FOREIGN KEY ([OfferteId]) REFERENCES [Offertes] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200616102754_facturen', N'3.1.2');

GO