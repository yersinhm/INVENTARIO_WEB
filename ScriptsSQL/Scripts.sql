USE [PRUEBA]
GO
/****** Object:  Table [dbo].[MOV_INVENTARIO]    Script Date: 8/07/2025 19:30:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOV_INVENTARIO](
	[COD_CIA] [varchar](5) NOT NULL,
	[COMPANIA_VENTA_3] [varchar](5) NOT NULL,
	[ALMACEN_VENTA] [varchar](10) NOT NULL,
	[TIPO_MOVIMIENTO] [varchar](2) NOT NULL,
	[TIPO_DOCUMENTO] [varchar](2) NOT NULL,
	[NRO_DOCUMENTO] [varchar](50) NOT NULL,
	[COD_ITEM_2] [varchar](50) NOT NULL,
	[PROVEEDOR] [varchar](100) NULL,
	[ALMACEN_DESTINO] [varchar](50) NULL,
	[CANTIDAD] [int] NULL,
	[DOC_REF_1] [varchar](50) NULL,
	[DOC_REF_2] [varchar](50) NULL,
	[DOC_REF_3] [varchar](50) NULL,
	[DOC_REF_4] [varchar](50) NULL,
	[DOC_REF_5] [varchar](50) NULL,
	[FECHA_TRANSACCION] [date] NULL,
 CONSTRAINT [PK_MOV_INVENTARIO] PRIMARY KEY CLUSTERED 
(
	[COD_CIA] ASC,
	[COMPANIA_VENTA_3] ASC,
	[ALMACEN_VENTA] ASC,
	[TIPO_MOVIMIENTO] ASC,
	[TIPO_DOCUMENTO] ASC,
	[NRO_DOCUMENTO] ASC,
	[COD_ITEM_2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_MovInventario]    Script Date: 8/07/2025 19:30:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualizar_MovInventario]
    @COD_CIA varchar(5),
    @COMPANIA_VENTA_3 varchar(5),
    @ALMACEN_VENTA varchar(10),
    @TIPO_MOVIMIENTO varchar(2),
    @TIPO_DOCUMENTO varchar(2),
    @NRO_DOCUMENTO varchar(50),
    @COD_ITEM_2 varchar(50),
    @PROVEEDOR varchar(100) = NULL,
    @ALMACEN_DESTINO varchar(50) = NULL,
    @CANTIDAD int = NULL,
    @DOC_REF_1 varchar(50) = NULL,
    @DOC_REF_2 varchar(50) = NULL,
    @DOC_REF_3 varchar(50) = NULL,
    @DOC_REF_4 varchar(50) = NULL,
    @DOC_REF_5 varchar(50) = NULL,
    @FECHA_TRANSACCION DATE = NULL
AS
BEGIN
    UPDATE MOV_INVENTARIO
    SET
        PROVEEDOR = @PROVEEDOR,
        ALMACEN_DESTINO = @ALMACEN_DESTINO,
        CANTIDAD = @CANTIDAD,
        DOC_REF_1 = @DOC_REF_1,
        DOC_REF_2 = @DOC_REF_2,
        DOC_REF_3 = @DOC_REF_3,
        DOC_REF_4 = @DOC_REF_4,
        DOC_REF_5 = @DOC_REF_5,
        FECHA_TRANSACCION = @FECHA_TRANSACCION
    WHERE
        COD_CIA = @COD_CIA AND
        COMPANIA_VENTA_3 = @COMPANIA_VENTA_3 AND
        ALMACEN_VENTA = @ALMACEN_VENTA AND
        TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO AND
        TIPO_DOCUMENTO = @TIPO_DOCUMENTO AND
        NRO_DOCUMENTO = @NRO_DOCUMENTO AND
        COD_ITEM_2 = @COD_ITEM_2;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Consultar_MovInventario]    Script Date: 8/07/2025 19:30:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Consultar_MovInventario]
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @TipoMovimiento VARCHAR(2) = NULL,
    @NroDocumento VARCHAR(50) = NULL
AS
BEGIN
    SELECT *
    FROM MOV_INVENTARIO
    WHERE
        (@FechaInicio IS NULL OR FECHA_TRANSACCION >= @FechaInicio) AND
        (@FechaFin IS NULL OR FECHA_TRANSACCION <= @FechaFin) AND
        (@TipoMovimiento IS NULL OR TIPO_MOVIMIENTO = @TipoMovimiento) AND
        (@NroDocumento IS NULL OR NRO_DOCUMENTO = @NroDocumento);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_MovInventario]    Script Date: 8/07/2025 19:30:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Eliminar_MovInventario]
    @COD_CIA varchar(5),
    @COMPANIA_VENTA_3 varchar(5),
    @ALMACEN_VENTA varchar(10),
    @TIPO_MOVIMIENTO varchar(2),
    @TIPO_DOCUMENTO varchar(2),
    @NRO_DOCUMENTO varchar(50),
    @COD_ITEM_2 varchar(50)
AS
BEGIN
    DELETE FROM MOV_INVENTARIO
    WHERE
        COD_CIA = @COD_CIA AND
        COMPANIA_VENTA_3 = @COMPANIA_VENTA_3 AND
        ALMACEN_VENTA = @ALMACEN_VENTA AND
        TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO AND
        TIPO_DOCUMENTO = @TIPO_DOCUMENTO AND
        NRO_DOCUMENTO = @NRO_DOCUMENTO AND
        COD_ITEM_2 = @COD_ITEM_2;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insertar_MovInventario]    Script Date: 8/07/2025 19:30:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insertar_MovInventario]
    @COD_CIA varchar(5),
    @COMPANIA_VENTA_3 varchar(5),
    @ALMACEN_VENTA varchar(10),
    @TIPO_MOVIMIENTO varchar(2),
    @TIPO_DOCUMENTO varchar(2),
    @NRO_DOCUMENTO varchar(50),
    @COD_ITEM_2 varchar(50),
    @PROVEEDOR varchar(100) = NULL,
    @ALMACEN_DESTINO varchar(50) = NULL,
    @CANTIDAD int = NULL,
    @DOC_REF_1 varchar(50) = NULL,
    @DOC_REF_2 varchar(50) = NULL,
    @DOC_REF_3 varchar(50) = NULL,
    @DOC_REF_4 varchar(50) = NULL,
    @DOC_REF_5 varchar(50) = NULL,
    @FECHA_TRANSACCION DATE = NULL
AS
BEGIN
    INSERT INTO MOV_INVENTARIO VALUES (
        @COD_CIA, @COMPANIA_VENTA_3, @ALMACEN_VENTA,
        @TIPO_MOVIMIENTO, @TIPO_DOCUMENTO, @NRO_DOCUMENTO, @COD_ITEM_2,
        @PROVEEDOR, @ALMACEN_DESTINO, @CANTIDAD,
        @DOC_REF_1, @DOC_REF_2, @DOC_REF_3, @DOC_REF_4, @DOC_REF_5,
        @FECHA_TRANSACCION
    );
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_MovInventario_PorId]    Script Date: 8/07/2025 19:30:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_MovInventario_PorId]
    @COD_CIA varchar(5),
    @COMPANIA_VENTA_3 varchar(5),
    @ALMACEN_VENTA varchar(10),
    @TIPO_MOVIMIENTO varchar(2),
    @TIPO_DOCUMENTO varchar(2),
    @NRO_DOCUMENTO varchar(50),
    @COD_ITEM_2 varchar(50)
AS
BEGIN
    SELECT *
    FROM MOV_INVENTARIO
    WHERE COD_CIA = @COD_CIA
      AND COMPANIA_VENTA_3 = @COMPANIA_VENTA_3
      AND ALMACEN_VENTA = @ALMACEN_VENTA
      AND TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO
      AND TIPO_DOCUMENTO = @TIPO_DOCUMENTO
      AND NRO_DOCUMENTO = @NRO_DOCUMENTO
      AND COD_ITEM_2 = @COD_ITEM_2
END
GO
