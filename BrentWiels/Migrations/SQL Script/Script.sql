IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Adressen] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [StraatNaam] nvarchar(max) NULL,
    [HuisNummer] nvarchar(max) NULL,
    [BusNummer] nvarchar(max) NULL,
    [Postcode] nvarchar(max) NULL,
    [Gemeente] nvarchar(max) NULL,
    CONSTRAINT [PK_Adressen] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Contacten] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [Email] nvarchar(max) NULL,
    [TelefoonNummer] nvarchar(max) NULL,
    [BtwNummer] nvarchar(max) NULL,
    CONSTRAINT [PK_Contacten] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Omschrijvingen] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [Omschrijving] nvarchar(max) NULL,
    [IsFavoriet] bit NOT NULL,
    CONSTRAINT [PK_Omschrijvingen] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Klanten] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [AdresId] int NULL,
    [ContactId] int NULL,
    [Naam] nvarchar(max) NULL,
    CONSTRAINT [PK_Klanten] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Klanten_Adressen_AdresId] FOREIGN KEY ([AdresId]) REFERENCES [Adressen] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Klanten_Contacten_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Contacten] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Facturen] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [FileName] nvarchar(max) NULL,
    [KlantId] int NULL,
    [Btw] decimal(18,2) NOT NULL,
    [FactuurNummer] nvarchar(max) NULL,
    [IsBetaald] bit NOT NULL,
    [BetaaldOp] datetime2 NOT NULL,
    CONSTRAINT [PK_Facturen] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Facturen_Klanten_KlantId] FOREIGN KEY ([KlantId]) REFERENCES [Klanten] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Offertes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [OfferteNummer] nvarchar(max) NULL,
    [VervalDatum] datetime2 NOT NULL,
    [VersieNummer] int NOT NULL,
    [FileName] nvarchar(max) NULL,
    [KlantId] int NULL,
    [Btw] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Offertes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Offertes_Klanten_KlantId] FOREIGN KEY ([KlantId]) REFERENCES [Klanten] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Werken] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [OmschrijvingId] int NULL,
    [NettoPrijs] decimal(18,2) NOT NULL,
    [PercentageWinst] decimal(18,2) NOT NULL,
    [FactuurId] int NULL,
    [OfferteId] int NULL,
    CONSTRAINT [PK_Werken] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Werken_Facturen_FactuurId] FOREIGN KEY ([FactuurId]) REFERENCES [Facturen] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Werken_Offertes_OfferteId] FOREIGN KEY ([OfferteId]) REFERENCES [Offertes] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Werken_Omschrijvingen_OmschrijvingId] FOREIGN KEY ([OmschrijvingId]) REFERENCES [Omschrijvingen] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Facturen_KlantId] ON [Facturen] ([KlantId]);

GO

CREATE INDEX [IX_Klanten_AdresId] ON [Klanten] ([AdresId]);

GO

CREATE INDEX [IX_Klanten_ContactId] ON [Klanten] ([ContactId]);

GO

CREATE INDEX [IX_Offertes_KlantId] ON [Offertes] ([KlantId]);

GO

CREATE INDEX [IX_Werken_FactuurId] ON [Werken] ([FactuurId]);

GO

CREATE INDEX [IX_Werken_OfferteId] ON [Werken] ([OfferteId]);

GO

CREATE INDEX [IX_Werken_OmschrijvingId] ON [Werken] ([OmschrijvingId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191128172002_init', N'3.0.0');

GO
