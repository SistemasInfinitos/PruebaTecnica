SELECT Personas.PrimerNombre, Documentos.DocumentoID AS CantidadOrden
FROM (Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID)
WHERE COUNT(Documentos.DocumentoID) >= 5;


SELECT Personas.PrimerNombre, COUNT(Documentos.DocumentoID) AS
CantidadOrden
FROM (Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID)
HAVING COUNT(Documentos.DocumentoID) >= 5
GROUP BY Personas.Nombre;
FROM (Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID)
GROUP BY Personas.PrimerNombre
HAVING COUNT(Documentos.DocumentoID) >= 5;
CantidadOrden
FROM (Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID)
GROUP BY Personas.PrimerNombre
HAVING COUNT(Documentos.DocumentoID) >= 5;
FROM Documentos
INNER JOIN Personas ON Documentos.PersonaIDCliente =Personas.PersonaID
GROUP BY Personas.PrimerNombre
HAVING COUNT(Documentos.DocumentoID) >= 5;
FROM Documentos D
INNER JOIN Personas P ON D.PersonaIDCliente =P.PersonaID
GROUP BY P.PrimerNombre
HAVING COUNT(D.DocumentoID) >= 5;
CantidadOrden
FROM (Ordenes
INNER JOIN Empleados ON Ordenes.EmpleadoId =
Empleados.ID)
HAVING COUNT(Ordenes.ID) >= 5
GROUP BY Empleados.Nombre;
CantidadOrden
FROM (Ordenes
INNER JOIN Empleados ON Ordenes.EmpleadoId =
Empleados.ID)
WHERE COUNT(Ordenes.ID) >= 5;
CantidadOrden
FROM (Ordenes
INNER JOIN Empleados ON Ordenes.EmpleadoId =
Empleados.ID)
GROUP BY Empleados.Nombre
HAVING COUNT(Ordenes.ID) >= 5;
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
WHERE (datediff(yy,Empleados.FechaNacimiento,GETDATE())not Between 40 and 50)
FROM Empleados
WHERE Empleados.Nombre LIKE 'Lu%';