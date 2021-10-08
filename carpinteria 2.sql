SELECT * FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'T_PRESUPUESTOS'


SELECT ORDINAL_POSITION, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'T_PRESUPUESTOS' AND ORDINAL_POSITION in (1,2,3,6)

GO
CREATE PROCEDURE SP_TIPOS_FILTROS --SP DE PRUEBA
AS
SELECT ORDINAL_POSITION posicion, COLUMN_NAME columna FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'T_PRESUPUESTOS' AND ORDINAL_POSITION in (1,2,3,6)

EXEC SP_TIPOS_FILTROS
------------------------------------------------------------------------------
--GO
--CREATE PROCEDURE SP_BORRAR_DETALLES --NO LO USE MAS LO SUME AL SP EDITAR PRESUPUESTO
--@nroPresupuesto int
--AS
--DELETE FROM T_DETALLES_PRESUPUESTO WHERE presupuesto_nro=@nroPresupuesto
------------------------------------------------------------------------------
--GO
--DROP PROCEDURE SP_BORRAR_PRESUPUESTO --SE USA BORRADO LOGICO EN SU LUGAR
--@nroPresupuesto int
--AS
--DELETE FROM T_PRESUPUESTOS WHERE presupuesto_nro=@nroPresupuesto

------------------------------------------------------------------------------
--GO
--DROP PROCEDURE SP_CONSULTAR_DETALLES --NO LO TERMINE USANDO
--@nro_presupuesto int
--AS
--select detalle_nro,n_producto PRODUCTO,precio PRECIO,cantidad CANTIDAD 
--from T_PRODUCTOS p join T_DETALLES_PRESUPUESTO d on p.id_producto=d.id_producto join T_PRESUPUESTOS pr 
--	on d.presupuesto_nro=pr.presupuesto_nro 
--where pr.presupuesto_nro=@nro_presupuesto

--EXEC SP_CONSULTAR_DETALLES 10

------------------------------------------------------------------------------
GO
ALTER PROCEDURE dbo.SP_EDITAR_PRESUPUESTO
@nro_presupuesto int,
@fecha date,
@cliente varchar(255)=null,
@descuento numeric(5,2)=null,
@fecha_baja date=null,
@total numeric(8,2)
AS
BEGIN
UPDATE T_PRESUPUESTOS
SET fecha=@fecha,cliente=@cliente,descuento=@descuento,fecha_baja=@fecha_baja,total=@total
WHERE presupuesto_nro=@nro_presupuesto
DELETE FROM T_DETALLES_PRESUPUESTO WHERE presupuesto_nro=@nro_presupuesto
END
GO
------------------------------------------------------------------------------
CREATE PROCEDURE dbo.SP_EDITAR_DETALLES_PRESUPUESTO --no lo use al final, falta resolver este tema
@nro_presupuesto int,
@detalle_nro int,
@id_producto int,
@cantidad int
AS
UPDATE T_DETALLES_PRESUPUESTO
SET detalle_nro=@detalle_nro,id_producto=@id_producto,cantidad=@cantidad
WHERE presupuesto_nro=@nro_presupuesto
GO
------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[SP_CONSULTAR_PRESUPUESTO_POR_ID]
	@nro int	
AS
BEGIN
	SELECT *
	FROM T_PRESUPUESTOS t, T_DETALLES_PRESUPUESTO t1, T_PRODUCTOS t2
	WHERE t.presupuesto_nro = t1.presupuesto_nro
	AND t1.id_producto = t2.id_producto
	AND t.presupuesto_nro = @nro;
END
GO
------------------------------------------------------
CREATE PROCEDURE SP_BAJA_PRESUPUESTO
@nroPresupuesto int
AS
UPDATE T_PRESUPUESTOS
SET fecha_baja=GETDATE()
WHERE presupuesto_nro=@nroPresupuesto
GO
---------------------------------------------------------------
GO
ALTER procedure [dbo].[SP_CONSULTAR_PRESUPUESTOS]
AS
BEGIN
	SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
	FROM T_PRESUPUESTOS
	WHERE fecha_baja is null
END
--------------------------------------------------------------
GO
CREATE procedure SP_CONSULTAR_PRESUPUESTOS_INACTIVOS
AS
BEGIN
	SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
	FROM T_PRESUPUESTOS
	WHERE fecha_baja is not null
END
--------------------------------------------------------------
GO
CREATE procedure SP_CONSULTAR_PRESUPUESTOS_CON_INACTIVOS
AS
BEGIN
	SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
	FROM T_PRESUPUESTOS
END
------------------------------------------------------------------------------
GO
CREATE PROCEDURE SP_FILTRO_NROPRESUP
@nro_presup int
AS
SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
FROM T_PRESUPUESTOS 
WHERE presupuesto_nro=@nro_presup

exec SP_FILTRO_NROPRESUP 2
------------------------------------------------------------------------------
GO
CREATE PROCEDURE SP_FILTRO_FECHA
@fechaDesde date,
@fechaHasta date
AS
SET DATEFORMAT dmy
SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
FROM T_PRESUPUESTOS 
WHERE fecha between @fechaDesde and @fechaHasta
------------------------------------------------------------------------------
GO
CREATE PROCEDURE SP_FILTRO_CLIENTE
@cliente varchar(150)
AS
SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
FROM T_PRESUPUESTOS 
WHERE cliente like @cliente+'%'

exec SP_FILTRO_CLIENTE 'cons'
------------------------------------------------------------------------------
GO
alter PROCEDURE SP_FILTRO_PRESUPUESTOS
@nro_presup int=null,
@fechaDesde date=null,
@fechaHasta date=null,
@cliente varchar(150)=null,
@tipo int=null,
@activo varchar(1)
AS
	if @tipo=0
		SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
		FROM T_PRESUPUESTOS
		WHERE 
		 ((@fechaDesde is null and @fechaHasta is  null) OR (fecha between @fechaDesde and @fechaHasta))
		 AND(@nro_presup is null OR presupuesto_nro=@nro_presup)
		 AND (@activo is null OR (@activo = 'S') OR (@activo = 'N' and fecha_baja IS  NULL))
	if @tipo=1
		SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
		FROM T_PRESUPUESTOS
		WHERE 
		 ((@fechaDesde is null and @fechaHasta is  null) OR (fecha between @fechaDesde and @fechaHasta))
		 AND(@cliente is null OR (cliente like '%' + @cliente + '%'))
		 AND (@activo is null OR (@activo = 'S') OR (@activo = 'N' and fecha_baja IS  NULL))
	if @tipo=2
		SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
		FROM T_PRESUPUESTOS
		WHERE fecha_baja is not null

select * from T_DETALLES_PRESUPUESTO
select * from T_PRESUPUESTOS
select * from T_PRODUCTOS