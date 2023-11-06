USE[master]
CREATE DATABASE SIVAR_BURGUERS;
GO
USE [SIVAR_BURGUERS];
GO


CREATE TABLE Usuario
(
    idUsuario INT NOT NULL IDENTITY,
    Contraseņa VARCHAR (50) NOT NULL,
    Nombre_Empleado VARCHAR (100) NOT NULL,
    Telefono VARCHAR(9),
	Rol VARCHAR(25),
    CONSTRAINT PK_USUARIO PRIMARY KEY(idUsuario)
);

CREATE TABLE Mesa
(
    idMesa INT NOT NULL IDENTITY,
    Numero_Mesa VARCHAR(30) NOT NULL,
	Estado INT NULL,
    CONSTRAINT PK_MESA PRIMARY KEY(idMesa)
);

CREATE TABLE Pago
(
    idPago INT NOT NULL IDENTITY,
    Tipo_Pago VARCHAR (20) NOT NULL,
    CONSTRAINT PK_PAGO PRIMARY KEY(idPago)
);

CREATE TABLE Estado_Pedido
(
    idEstado_Pedido INT NOT NULL IDENTITY,
    Tipo_Estado VARCHAR(40),
    CONSTRAINT PK_ESTADO_PEDIDO PRIMARY KEY(idEstado_Pedido)
);

CREATE TABLE Categoria
(
    idCategoria INT NOT NULL IDENTITY,
    Nombre_Categoria VARCHAR (100) NOT NULL,
    CONSTRAINT PK_CATEGORIA PRIMARY KEY(idCategoria)
);

CREATE TABLE Platillo
(
    idPlatillo INT NOT NULL IDENTITY,
    Nombre_Platillo VARCHAR (120),
    Precio DECIMAL (10,2),
    Descripcion VARCHAR (255),
	idCategoria INT NULL,
    CONSTRAINT PK_PLATILLO PRIMARY KEY(idPlatillo)
);

CREATE TABLE Cliente
(
    idCliente INT NOT NULL IDENTITY,
    Nombre VARCHAR (40) NOT NULL,
    Apellido VARCHAR (50) NULL,
	Genero VARCHAR(25),
    CONSTRAINT PK_CLIENTE PRIMARY KEY(idCliente)
);

CREATE TABLE Pedido
(
    idPedido INT NOT NULL,
    idUsuario INT NULL,
    idCliente INT NULL,
    idMesa INT NULL,
    idEstado_Pedido INT NULL,
    Fecha  VARCHAR(20),
	Total DECIMAL,
    Hora VARCHAR(50),
	idPago INT NULL,
    CONSTRAINT PK_PEDIDO PRIMARY KEY(idPedido)
);

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

--Llaves Foraneas

--Tabla Platillo 
ALTER TABLE Platillo
ADD CONSTRAINT FK_CATEGORIA_PLATILLO FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria) ON UPDATE CASCADE ON DELETE CASCADE;
GO
--Tabla Pedido
ALTER TABLE Pedido
ADD CONSTRAINT FK_PEDIDO_USUARIO FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario) ON UPDATE CASCADE ON DELETE CASCADE;
GO
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
--Tabla Detalle Pedido
ALTER TABLE Detalle_Pedido
ADD CONSTRAINT FK_DETALLE_PEDIDO_PLATILLO FOREIGN KEY (idPlatillo) REFERENCES Platillo(idPlatillo) ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE Detalle_Pedido
ADD CONSTRAINT FK_DETALLE_PEDIDO_PEDIDOS FOREIGN KEY (idPedido) REFERENCES Pedido(idPedido) ON UPDATE CASCADE ON DELETE CASCADE;
GO


--INSERTAR DATOS
--PAGO
INSERT INTO Pago VALUES ('Credito'),('Paypal'),('Efectivo');
--CATEGORIA
INSERT INTO Categoria VALUES ('Hamburguesas Picantes');
--USUARIO
INSERT INTO Usuario VALUES ('123','Antonio','7734-2212','Administrador')
--ESTADO PEDIDO
INSERT INTO Estado_Pedido VALUES ('Pendiente'),('En Proceso'),('Entregado'),('Cancelado'),('Pagado'),('No Pagado');
--MESA
INSERT INTO Mesa  VALUES ('NUMERO 1', 1);
--PEDIDO
--UPDATE Pedido SET idEstado_Pedido =   WHERE idPedido =  

INSERT INTO Pedido (idPedido,Fecha, idEstado_Pedido)
VALUES (2,'2023-10-31', 1);

--INSERT INTO Pedido (idPedido, idUsuario, idCliente, idMesa, idEstado_Pedido, Fecha, Total, Hora, idPago)
--VALUES (1, 1, 2, 1, 1, '2023-11-05', 50.00, '10:30 AM', 1);

SELECT * FROM Pedido


DECLARE @Fecha AS DATE = '2023-10-31'; 
DECLARE @EstadoPedido AS INT = 1; 
SELECT * FROM Pedido WHERE Fecha = @Fecha AND idEstado_Pedido = @EstadoPedido

SELECT * FROM Pedido WHERE Fecha = '2023-10-31' AND idEstado_Pedido = 1;