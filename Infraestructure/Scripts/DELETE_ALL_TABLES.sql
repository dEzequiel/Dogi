IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Dogi].[IndividualProceeding]') AND type in (N'U'))
DROP TABLE [Dogi].[IndividualProceeding]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Dogi].[AnimalChip]') AND type in (N'U'))
DROP TABLE [Dogi].[AnimalChip]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Dogi].[AnimalCategory]') AND type in (N'U'))
DROP TABLE [Dogi].[AnimalCategory]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Dogi].[Animal]') AND type in (N'U'))
DROP TABLE [Dogi].[Animal]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Dogi].[ProceedingStatus]') AND type in (N'U'))
DROP TABLE [Dogi].[ProceedingStatus]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Dogi].[ReceptionDocument]') AND type in (N'U'))
DROP TABLE [Dogi].[ReceptionDocument]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Dogi].[Sex]') AND type in (N'U'))
DROP TABLE [Dogi].[Sex]
GO