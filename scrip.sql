alter table Personas add FechaNaciemiento datetime null
alter table Personas add Telefono varchar(10) null
alter table Personas add Correo varchar(10) null
alter table Personas add Direccion varchar(10) null

alter table Personas alter column Direccion nvarchar(100) null


create procedure SpGetPersonasByIdentificacion
@Identificacion varchar(15)
as
begin 
 select * from Personas  where Identificacion=@Identificacion
end
GO