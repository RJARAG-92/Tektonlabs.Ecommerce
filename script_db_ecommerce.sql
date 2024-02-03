CREATE DATABASE [db_ecommerce]
go
USE [db_ecommerce]
GO 
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[UnidadMedida] [varchar](10) NOT NULL,
	[Stock] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Moneda] [char](3) NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [varchar](300) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[FechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)
)
GO
