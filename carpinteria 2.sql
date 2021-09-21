SELECT * FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'T_PRESUPUESTOS'


SELECT ORDINAL_POSITION, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'T_PRESUPUESTOS' AND ORDINAL_POSITION in (1,2,3,6)

ALTER PROCEDURE SP_TIPOS_FILTROS
AS
SELECT ORDINAL_POSITION posicion, COLUMN_NAME columna FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'T_PRESUPUESTOS' AND ORDINAL_POSITION in (1,2,3,6)

EXEC SP_TIPOS_FILTROS

CREATE PROCEDURE SP_FILTRO_NROPRESUP
@nro_presup int
AS
SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
FROM T_PRESUPUESTOS 
WHERE presupuesto_nro=@nro_presup

exec SP_FILTRO_NROPRESUP 2

CREATE PROCEDURE SP_FILTRO_FECHA
@fechaDesde date,
@fechaHasta date
AS
SET DATEFORMAT dmy
SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
FROM T_PRESUPUESTOS 
WHERE fecha between @fechaDesde and @fechaHasta

CREATE PROCEDURE SP_FILTRO_CLIENTE
@cliente varchar(150)
AS
SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
FROM T_PRESUPUESTOS 
WHERE cliente like @cliente+'%'

exec SP_FILTRO_CLIENTE 'cons'

CREATE PROCEDURE SP_BORRAR_DETALLES
@nroPresupuesto int
AS
DELETE FROM T_DETALLES_PRESUPUESTO WHERE presupuesto_nro=@nroPresupuesto

CREATE PROCEDURE SP_BORRAR_PRESUPUESTO
@nroPresupuesto int
AS
DELETE FROM T_PRESUPUESTOS WHERE presupuesto_nro=@nroPresupuesto

CREATE PROCEDURE SP_CONSULTAR_UN_PRESUPUESTO
@nroPresupuesto int
AS
SELECT presupuesto_nro,convert(varchar,fecha,3) fecha,cliente,descuento,fecha_baja,total 
FROM T_PRESUPUESTOS
WHERE presupuesto_nro=@nroPresupuesto

CREATE PROCEDURE dbo.SP_CONSULTAR_DETALLES
@nro_presupuesto int
AS
BEGIN
select detalle_nro,n_producto PRODUCTO,precio PRECIO,cantidad CANTIDAD 
from T_PRODUCTOS p join T_DETALLES_PRESUPUESTO d on p.id_producto=d.id_producto join T_PRESUPUESTOS pr 
	on d.presupuesto_nro=pr.presupuesto_nro 
where pr.presupuesto_nro=@nro_presupuesto
END

EXEC SP_CONSULTAR_DETALLES 10

select * from T_DETALLES_PRESUPUESTO
select * from T_PRESUPUESTOS