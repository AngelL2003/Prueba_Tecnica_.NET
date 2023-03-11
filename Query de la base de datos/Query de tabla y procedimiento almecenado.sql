CREATE TABLE Persona(
Id_Persona INT PRIMARY KEY IDENTITY,
Nombres VARCHAR(100),
Apellidos VARCHAR(100),
Fecha_Nacimiento DATE,
Sexo char(1)
);
INSERT INTO Persona VALUES ('JUAN Camilo','Moreno Pardo','0000/00/00','M')

---PROCEDIMIENTOS ALMACENADOS 
--------------------------MOSTRAR 
CREATE PROC MostrarPersonas
AS
SELECT * FROM Persona
GO
--------------------------INSERTAR 
CREATE PROC InsertarPersonas
@Nombres VARCHAR (100),
@Apellidos VARCHAR (100),
@Fecha_Nacimiento DATE,
@Sexo CHAR(1)
AS
INSERT INTO Persona VALUES (@Nombres,@Apellidos,@Fecha_Nacimiento,@Sexo)
GO
------------------------ELIMINAR
CREATE PROC EliminarPersonas
@Id_Personas INT
AS
DELETE FROM Persona WHERE Id_Persona=@Id_Personas
GO
------------------EDITAR
ALTER PROC EditarRegistros
@Id_Persona INT,
@Nombres VARCHAR (100),
@Apellidos VARCHAR (100),
@Fecha_Nacimiento DATE,
@Sexo CHAR(1)
as
UPDATE Persona SET Nombres=@Nombres, Apellidos=@Apellidos, @Fecha_Nacimiento=@Fecha_Nacimiento, Sexo=@Sexo WHERE Id_Persona=@Id_Persona
