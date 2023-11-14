USE [SIVAR_BURGUERS];
GO
--VISTAS PARA LA BASE DE DATOS SIVAR BURGUER'S (DAE)
CREATE VIEW V_Platillo
AS
SELECT p.idPlatillo CODIGO,p.Nombre_Platillo NOMBRE,p.Precio PRECIO,p.Descripcion DESCRIPCION,c.Nombre_Categoria CATEGORIA FROM Platillo p
INNER JOIN Categoria c ON p.idCategoria = c.idCategoria
GO
CREATE VIEW V_Categoria
AS
SELECT c.idCategoria CODIGO,c.Nombre_Categoria NOMBRE_CATEGORIA FROM Categoria c
GO
CREATE VIEW V_Usuario
AS 
SELECT u.idUsuario CODIGO,u.Nombre_Empleado	NOMBRE,u.Contraseña CONTRASEÑA,u.Telefono NUMERO,u.Rol ROL FROM Usuario u
GO
CREATE VIEW V_Cliente
AS
SELECT c.idCliente CODIGO,c.Nombre NOMBRE,c.Apellido APELLIDO,c.Genero GENERO FROM Cliente c
GO
CREATE VIEW V_Mesa
AS
SELECT m.idMesa CODIGO,m.Numero_Mesa NUMERO_MESA,m.Estado ESTADO FROM Mesa m
GO
CREATE VIEW V_Pedido
AS
SELECT p.idPedido CODIGO,u.Nombre_Empleado USUARIO, CONCAT(c.Nombre,'',c.Apellido) CLIENTE,m.Numero_Mesa MESA,e.Tipo_Estado ESTADO,p.Fecha FECHA, p.Hora HORA,p.Total TOTAL,pa.Tipo_Pago PAGO FROM Pedido p
INNER JOIN Mesa m ON p.idMesa = m.idMesa
INNER JOIN Cliente c ON p.idCliente = p.idCliente
INNER JOIN Estado_Pedido e ON p.idEstado_Pedido = e.idEstado_Pedido
INNER JOIN Pago pa ON p.idPago = pa.idPago
INNER JOIN Usuario u ON p.idUsuario = u.idUsuario
GO
CREATE VIEW V_DetallePedido
AS
SELECT dp.idDetalle_Pedido CODIGO,pl.Nombre_Platillo PLATILLO, dp.Cantidad CANTIDAD, dp.Precio	PRECIO,	(dp.Cantidad * dp.Precio) SUBTOTAL FROM Detalle_Pedido dp
INNER JOIN Pedido p ON dp.idPedido = p.idPedido
INNER JOIN Platillo pl ON dp.idPlatillo = pl.idPlatillo
GO
CREATE PROCEDURE BuscarPedidosPorFechaYEstado
    @fecha_pedido DATE,
    @id_estado_pedido INT
AS
BEGIN
    SELECT *
    FROM Pedido
    WHERE Fecha = @fecha_pedido AND idEstado_Pedido = @id_estado_pedido;
END
GO
EXEC BuscarPedidosPorFechaYEstado '2023-10-31',1;
GO
CREATE VIEW V_VerPedido
AS
SELECT p.idPedido CODIGO,CONCAT(c.Nombre,' ',c.Apellido) CLIENTE,m.Numero_Mesa MESA, P.Fecha FECHA,p.Hora HORA,ep.Tipo_Estado ESTADO,ep.idEstado_Pedido CLAVE FROM Pedido p 
INNER JOIN Cliente c ON p.idCliente = c.idCliente
INNER JOIN Mesa m ON p.idMesa = m.idMesa
INNER JOIN Estado_Pedido ep ON p.idEstado_Pedido = ep.idEstado_Pedido
INNER JOIN Pago pa ON p.idPago = pa.idPago
GO
CREATE PROCEDURE ObtenerDatosFactura
    @idPedido INT
AS
BEGIN
    SELECT
        P.idPedido AS CODIGO,
        C.Nombre AS CLIENTE,
        P.Fecha AS FECHA,
        P.Hora AS HORA,
        M.Numero_Mesa AS MESA,
        DP.Cantidad AS CANTIDAD,
        PL.Nombre_Platillo AS DESCRIPCION,
        PL.Precio AS PRECIO,
        DP.SubTotal AS SUBTOTAL,
        P.Total AS TOTAL
    FROM Pedido AS P
    INNER JOIN Cliente AS C ON P.idCliente = C.idCliente
    INNER JOIN Mesa AS M ON P.idMesa = M.idMesa
    INNER JOIN Detalle_Pedido AS DP ON P.idPedido = DP.idPedido
    INNER JOIN Platillo AS PL ON DP.idPlatillo = PL.idPlatillo
    WHERE P.idPedido = @idPedido;
END;

GO 
CREATE VIEW V_VerPedidosCobro
AS
SELECT p.idPedido CODIGO, CONCAT(c.Nombre,' ',c.Apellido) CLIENTE,p.Fecha FECHA,p.Hora HORA,m.Numero_Mesa MESA,ep.Tipo_Estado ESTADO,pa.Tipo_Pago PAGO, p.Total TOTAL FROM Pedido p
INNER JOIN Cliente c ON p.idCliente = c.idCliente
INNER JOIN Mesa m ON p.idMesa = m.idMesa
INNER JOIN Estado_Pedido ep ON p.idEstado_Pedido = ep.idEstado_Pedido
INNER JOIN Pago pa ON p.idPago = pa.idPago
GO
CREATE VIEW V_VerPedidoMesero
AS
SELECT p.idPedido CODIGO,CONCAT(c.Nombre,' ',c.Apellido) CLIENTE,m.Numero_Mesa MESA, P.Fecha FECHA,p.Hora HORA,ep.Tipo_Estado ESTADO FROM Pedido p 
INNER JOIN Cliente c ON p.idCliente = c.idCliente
INNER JOIN Mesa m ON p.idMesa = m.idMesa
INNER JOIN Estado_Pedido ep ON p.idEstado_Pedido = ep.idEstado_Pedido
INNER JOIN Pago pa ON p.idPago = pa.idPago
GO
CREATE VIEW V_DetallesPlatillosPedidos
AS
SELECT d.idPedido CODIGO, pa.Nombre_Platillo NOMBRE_PLATILLO, d.Cantidad CANTIDA,p.Hora HORA,CONCAT(c.Nombre,' ',c.Apellido) CLIENTE FROM Detalle_Pedido d
INNER JOIN Platillo pa ON d.idPlatillo = pa.idPlatillo
LEFT JOIN Pedido p ON d.idPedido = p.idPedido
LEFT JOIN Cliente c ON p.idCliente = c.idCliente;
GO
CREATE PROCEDURE ObtenerPedidosPorDiaActualizado
    @FechaConsulta VARCHAR(20) 
AS
BEGIN
   SELECT
    P.idPedido AS CODIGO,
    U.Nombre_Empleado AS USUARIO,
    P.Fecha AS FECHA,
    P.Total AS SUBTOTAL
FROM
    Pedido AS P
JOIN
    Usuario AS U ON P.idUsuario = U.idUsuario
WHERE
    P.idEstado_Pedido = 5
    AND P.Fecha = @FechaConsulta;	

SELECT
    SUM(P.Total) AS TOTAL_FINAL
FROM
    Pedido AS P
WHERE
    P.idEstado_Pedido = 5
    AND P.Fecha = @FechaConsulta;
END
GO
CREATE PROCEDURE GenerarReporteVentasSemanales
    @FechaInicio VARCHAR(20),
    @FechaFin VARCHAR(20)
AS
BEGIN
    SELECT
        P.idPedido AS Codigo_Pedido,
        U.Nombre_Empleado AS Nombre_Usuario,
        P.Fecha AS Fecha,
        DP.SubTotal AS Subtotal
    FROM Pedido AS P
    INNER JOIN Usuario AS U ON P.idUsuario = U.idUsuario
    INNER JOIN Detalle_Pedido AS DP ON P.idPedido = DP.idPedido
    WHERE P.Fecha BETWEEN @FechaInicio AND @FechaFin
END
GO
CREATE PROCEDURE GenerarReportePedidosPorCategoria
    @NombreCategoria VARCHAR(100)
AS
BEGIN
    SELECT
        P.idPedido AS Codigo_Pedido,
        U.Nombre_Empleado AS Nombre_Usuario,
        P.Fecha AS Fecha,
        DP.Cantidad AS Cantidad,
        DP.Precio AS Precio,
        DP.SubTotal AS Subtotal
    FROM Pedido AS P
    INNER JOIN Usuario AS U ON P.idUsuario = U.idUsuario
    INNER JOIN Detalle_Pedido AS DP ON P.idPedido = DP.idPedido
    INNER JOIN Platillo AS PL ON DP.idPlatillo = PL.idPlatillo
    INNER JOIN Categoria AS C ON PL.idCategoria = C.idCategoria
    WHERE C.Nombre_Categoria = @NombreCategoria;
END