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
SELECT u.idUsuario CODIGO,u.Nombre_Empleado	NOMBRE,u.Contraseņa CONTRASEŅA,u.Telefono NUMERO,u.Rol ROL FROM Usuario u
GO
CREATE VIEW V_Cliente
AS
SELECT c.idCliente CODIGO,c.Nombre NOMBRE,c.Apellido APELLIDO,c.Genero GENERO FROM Cliente c