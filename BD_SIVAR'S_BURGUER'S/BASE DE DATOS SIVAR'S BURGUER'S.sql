USE[master]
CREATE DATABASE SIVAR_BURGUERS;
GO
USE [SIVAR_BURGUERS];
GO
CREATE TABLE Usuario
(
    idUsuario INT NOT NULL IDENTITY,
    Contraseña VARCHAR (50) NOT NULL,
    Nombre_Empleado VARCHAR (100) NOT NULL,
    Telefono VARCHAR(9),
	Rol VARCHAR(25),
    CONSTRAINT PK_USUARIO PRIMARY KEY(idUsuario)
);
GO
CREATE TABLE Mesa
(
    idMesa INT NOT NULL IDENTITY,
    Numero_Mesa VARCHAR(30) NOT NULL,
	Estado INT NULL,
    CONSTRAINT PK_MESA PRIMARY KEY(idMesa)
);
GO
CREATE TABLE Pago
(
    idPago INT NOT NULL IDENTITY,
    Tipo_Pago VARCHAR (20) NOT NULL,
    CONSTRAINT PK_PAGO PRIMARY KEY(idPago)
);
GO
CREATE TABLE Estado_Pedido
(
    idEstado_Pedido INT NOT NULL IDENTITY,
    Tipo_Estado VARCHAR(40),
    CONSTRAINT PK_ESTADO_PEDIDO PRIMARY KEY(idEstado_Pedido)
);
GO
CREATE TABLE Categoria
(
    idCategoria INT NOT NULL IDENTITY,
    Nombre_Categoria VARCHAR (100) NOT NULL,
    CONSTRAINT PK_CATEGORIA PRIMARY KEY(idCategoria)
);
GO
CREATE TABLE Platillo
(
    idPlatillo INT NOT NULL IDENTITY,
    Nombre_Platillo VARCHAR (120),
    Precio DECIMAL (10,2),
    Descripcion VARCHAR (255),
	idCategoria INT NULL,
    CONSTRAINT PK_PLATILLO PRIMARY KEY(idPlatillo)
);
GO
CREATE TABLE Cliente
(
    idCliente INT NOT NULL IDENTITY,
    Nombre VARCHAR (40) NOT NULL,
    Apellido VARCHAR (50) NULL,
	Genero VARCHAR(25),
    CONSTRAINT PK_CLIENTE PRIMARY KEY(idCliente)
);
GO
CREATE TABLE Pedido
(
    idPedido INT NOT NULL,
    idUsuario INT NULL,
    idCliente INT NULL,
    idMesa INT NULL,
    idEstado_Pedido INT NULL,
    Fecha  VARCHAR(20),
	Total DECIMAL(10,2),
    Hora VARCHAR(50),
	idPago INT NULL,
    CONSTRAINT PK_PEDIDO PRIMARY KEY(idPedido)
);
GO
CREATE TABLE Detalle_Pedido
(
    idDetalle_Pedido INT NOT NULL IDENTITY,
    idPlatillo INT NULL,
    idPedido INT NULL,
    Cantidad INT,
	Precio DECIMAL(10,2),
    SubTotal DECIMAL (10,2),
    CONSTRAINT PK_DETALLE_PEDIDO PRIMARY KEY(idDetalle_Pedido)
);
GO
--CREACION DE LLAVES FORANEAS
--TABLA PLATILLO 
ALTER TABLE Platillo
ADD CONSTRAINT FK_CATEGORIA_PLATILLO FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria) ON UPDATE CASCADE ON DELETE CASCADE;
GO
--TABLA PEDIDO
ALTER TABLE Pedido
ADD CONSTRAINT FK_PEDIDO_USUARIO FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario) ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE Pedido
ADD CONSTRAINT FK_PEDIDO_CLIENTE FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente) ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE Pedido
ADD CONSTRAINT FK_PEDIDO_MESA FOREIGN KEY (idMesa) REFERENCES Mesa(idMesa) ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE Pedido
ADD CONSTRAINT FK_PEDIDO_ESTADO FOREIGN KEY (idEstado_Pedido) REFERENCES Estado_Pedido(idEstado_Pedido) ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE Pedido
ADD CONSTRAINT FK_PEDIDO_PAGO FOREIGN KEY (idPago) REFERENCES Pago(idPago) ON UPDATE CASCADE ON DELETE CASCADE;
GO
--TABLA DETALLE PEDIDO
ALTER TABLE Detalle_Pedido
ADD CONSTRAINT FK_DETALLE_PEDIDO_PLATILLO FOREIGN KEY (idPlatillo) REFERENCES Platillo(idPlatillo) ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE Detalle_Pedido
ADD CONSTRAINT FK_DETALLE_PEDIDO_PEDIDOS FOREIGN KEY (idPedido) REFERENCES Pedido(idPedido) ON UPDATE CASCADE ON DELETE CASCADE;
GO
--INSERTAR DATOS GENERALES
--PAGO
INSERT INTO Pago VALUES ('Credito'),('Paypal'),('Efectivo'),('BitCoin');
--CATEGORIA
INSERT INTO Categoria VALUES ('Hamburguesas Picantes'),('Hamburguesas Clasicas'),('Bebidas Frias'),('Bebidas Calientes'),('Postres');
--USUARIO
INSERT INTO Usuario VALUES ('123','Antonio','7734-2212','Administrador'),('123','Camila','7934-2222','Mesero'),('123','Daniel','5443-4221','Cajero');
--ESTADO PEDIDO
INSERT INTO Estado_Pedido VALUES ('Pendiente'),('En Proceso'),('Entregado'),('Cancelado'),('Pagado'),('No Pagado');
--MESA
INSERT INTO Mesa  VALUES ('NUMERO 1', 1),('NUMERO 2', 1),('NUMERO 3', 1),('NUMERO 4', 1	),('NUMERO 5', 1),('DELIVERY', 1);
GO
--VISTAS PARA LA BASE DE DATOS SIVAR BURGUER'S 
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
--CREACION DE PROCEDIMENTOS ALMACENADOS NECESARIOS PARA REALIZAR REPORTES
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
SELECT p.idPedido CODIGO,CONCAT(c.Nombre,' ',c.Apellido) CLIENTE,m.Numero_Mesa MESA, P.Fecha FECHA,p.Hora HORA,ep.Tipo_Estado ESTADO FROM Pedido p 
INNER JOIN Cliente c ON p.idCliente = c.idCliente
INNER JOIN Mesa m ON p.idMesa = m.idMesa
INNER JOIN Estado_Pedido ep ON p.idEstado_Pedido = ep.idEstado_Pedido
INNER JOIN Pago pa ON p.idPago = pa.idPago
GO
SELECT * FROM V_VerPedido WHERE FECHA = '2023-11-25' AND ESTADO = 'Pendiente'
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
SELECT d.idPedido CODIGO, pa.Nombre_Platillo NOMBRE_PLATILLO, d.Cantidad CANTIDAD FROM Detalle_Pedido d
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



