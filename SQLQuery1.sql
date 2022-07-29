SELECT Personas.PrimerNombre, Documentos.DocumentoID AS CantidadOrden
FROM (Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID)
WHERE COUNT(Documentos.DocumentoID) >= 5;


SELECT Personas.PrimerNombre, COUNT(Documentos.DocumentoID) AS
CantidadOrden
FROM (Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID)
HAVING COUNT(Documentos.DocumentoID) >= 5
GROUP BY Personas.Nombre;SELECT Personas.PrimerNombre--, COUNT(Documentos.DocumentoID) AS CantidadOrden
FROM (Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID)
GROUP BY Personas.PrimerNombre
HAVING COUNT(Documentos.DocumentoID) >= 5;SELECT Personas.PrimerNombre, SUM(Documentos.DocumentoID) AS
CantidadOrden
FROM (Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID)
GROUP BY Personas.PrimerNombre
HAVING COUNT(Documentos.DocumentoID) >= 5;SELECT Personas.PrimerNombre, COUNT(Documentos.DocumentoID) AS CantidadOrden
FROM Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID
GROUP BY Personas.PrimerNombre
HAVING COUNT(Documentos.DocumentoID) >= 5;SELECT P.PrimerNombre, COUNT(D.DocumentoID) AS CantidadOrden
FROM Documentos D
INNER JOIN Personas P ON D.PersonaIDCliente =P.PersonaID
GROUP BY P.PrimerNombre
HAVING COUNT(D.DocumentoID) >= 5;SELECT * FROM PersonasSELECT * FROM DocumentosCreate table Empleados(ID [int] IDENTITY(1,1) NOT NULL,Nombre [varchar](150) NULL,Apellido [varchar](150) NULL,FechaNacimiento date null,Teléfono [varchar](10) NULL)--ALTER TABLE Empleados ALTER COLUMN FechaNacimiento DATETIME nullCreate table Ordenes(ID [int] IDENTITY(1,1) NOT NULL,EmpleadoID int NULL,DetalleOrdenID int  null)SELECT Empleados.Nombre, COUNT(Ordenes.ID) AS
CantidadOrden
FROM (Ordenes
INNER JOIN Empleados ON Ordenes.EmpleadoId =
Empleados.ID)
HAVING COUNT(Ordenes.ID) >= 5
GROUP BY Empleados.Nombre;SELECT Empleados.Nombre, Ordenes.OrdenId AS
CantidadOrden
FROM (Ordenes
INNER JOIN Empleados ON Ordenes.EmpleadoId =
Empleados.ID)
WHERE COUNT(Ordenes.ID) >= 5;SELECT Empleados.Nombre, SUM(Ordenes.ID) AS
CantidadOrden
FROM (Ordenes
INNER JOIN Empleados ON Ordenes.EmpleadoId =
Empleados.ID)
GROUP BY Empleados.Nombre
HAVING COUNT(Ordenes.ID) >= 5;select * from Empleadosselect * from OrdenesSELECT Empleados.Nombre, COUNT(Ordenes.ID) AS
CantidadOrden
FROM (Ordenes
INNER JOIN Empleados ON Ordenes.EmpleadoId =
Empleados.ID)
GROUP BY Empleados.Nombre
HAVING COUNT(Ordenes.ID) >= 5;

a.
 SELECT Empleados.Nombre, Empleados.Apellido,datediff(yy,Empleados.FechaNacimiento,GETDATE())edad
FROM Empleados
WHERE (datediff(yy,Empleados.FechaNacimiento,GETDATE())not in (40,50))

b. 
SELECT Empleados.Nombre, Empleados.Apellido,datediff(yy,Empleados.FechaNacimiento,GETDATE())edad
FROM Empleados
WHERE (datediff(dd,Empleados.FechaNacimiento,GETDATE())> 40 and(datediff(dd,Empleados.FechaNacimiento,GETDATE()) < 50))

--c. 
SELECT Empleados.Nombre, Empleados.Apellido,datediff(yy,Empleados.FechaNacimiento,GETDATE())edad
FROM Empleados
WHERE (datediff(yy,Empleados.FechaNacimiento,GETDATE()) < 40 and (datediff(yy,Empleados.FechaNacimiento,GETDATE()) > 50))

--d. 
SELECT Empleados.Nombre, Empleados.Apellido,datediff(yy,Empleados.FechaNacimiento,GETDATE())edad
FROM Empleados
WHERE (datediff(yy,Empleados.FechaNacimiento,GETDATE())not Between 40 and 50)SELECT Empleados.Nombre
FROM Empleados
WHERE Empleados.Nombre LIKE 'Lu%';

a
SELECT Empleados.Nombre, ISNULL(Count(Ordenes.ID),0)
as CantidadOrden
FROM Empleados, Ordenes
WHERE Empleados.ID = Ordenes.EmpleadoID
Group By Empleados.Nombre;b SELECT Empleados.Nombre,(ISNULL(Count(Ordenes.ID),0)) as CantidadOrden
FROM Empleados INNER JOIN Ordenes ON Empleados.ID =Ordenes.EmpleadoID
Group By Empleados.Nombre;cSELECT Empleado.Nombre,
ISNULL(Count(Orden.ID),0)) as CantidadOrden
FROM Empleado RIGHT JOIN Orden ON Empleado.ID =
Orden.EmpleadoID
Group By Empleado.Nombre;