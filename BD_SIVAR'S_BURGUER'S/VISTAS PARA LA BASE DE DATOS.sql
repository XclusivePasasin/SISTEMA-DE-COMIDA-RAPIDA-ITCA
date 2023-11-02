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