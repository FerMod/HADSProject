-- Script Date: 05/02/2015 17:00  - ErikEJ.SqlCeScripting version 3.5.2.45
-- Database information:
-- Locale Identifier: 2057
-- Encryption Mode: 
-- Case Sensitive: False
-- Database: BDTAREAS.sdf
-- ServerVersion: 4.0.8876.1
-- DatabaseSize: 276 KB
-- Created: 05/02/2015 17:00

-- User Table information:
-- Number of tables: 9
-- Asignaturas: 5 row(s)
-- EstudiantesGrupo: 6 row(s)
-- EstudiantesTareas: 15 row(s)
-- GruposClase: 6 row(s)
-- GruposTrabajo: 10 row(s)
-- ProfesoresGrupo: 6 row(s)
-- TareasGenericas: 14 row(s)
-- TareasPersonales: 1 row(s)
-- Usuarios: 10 row(s)

CREATE TABLE [Usuarios] (
    [email]      NVARCHAR (50) NOT NULL,
    [nombre]     NVARCHAR (50) NOT NULL,
    [apellidos]  NVARCHAR (70) NOT NULL,
    [numconfir]  INT           NOT NULL,
    [confirmado] BIT           NOT NULL DEFAULT 0,
    [tipo]       NVARCHAR (50) NOT NULL,
    [pass]       NVARCHAR (50) NOT NULL,
    [codpass]    INT
);
GO
CREATE TABLE [TareasPersonales] (
  [Codigo] int IDENTITY (2,1) NOT NULL
, [Descripción] nvarchar(50) NULL
, [HEstimadas] int NULL
, [HReales] int NULL
, [Email] nvarchar(50) NULL
);
GO
CREATE TABLE [TareasGenericas] (
  [Codigo] nvarchar(50) NOT NULL
, [Descripcion] nvarchar(50) NULL
, [CodAsig] nvarchar(50) NULL
, [HEstimadas] int NULL
, [Explotacion] bit NULL
, [TipoTarea] nvarchar(50) NULL
);
GO
CREATE TABLE [ProfesoresGrupo] (
  [email] nvarchar(50) NOT NULL
, [codigogrupo] nvarchar(50) NOT NULL
);
GO
CREATE TABLE [GruposTrabajo] (
  [codigo] nvarchar(2) NOT NULL
, [descripcion] nvarchar(50) NULL
, [numeroalumnos] int NULL
, [asignatura] nvarchar(50) NULL
);
GO
CREATE TABLE [GruposClase] (
  [codigo] nvarchar(50) NOT NULL
, [Descripcion] nvarchar(50) NULL
, [codigoasig] nvarchar(50) NULL
);
GO
CREATE TABLE [EstudiantesTareas] (
  [Email] nvarchar(50) NOT NULL
, [CodTarea] nvarchar(50) NOT NULL
, [HEstimadas] int NULL
, [HReales] int NULL
);
GO
CREATE TABLE [EstudiantesGrupo] (
  [Email] nvarchar(50) NOT NULL
, [Grupo] nvarchar(50) NOT NULL
, [Falta] datetime NULL
);
GO
CREATE TABLE [Asignaturas] (
  [codigo] nvarchar(50) NOT NULL
, [Nombre] nvarchar(50) NULL
);
GO

INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'blanco@ehu.es', N'JM ', N'Blanco', 123, 1, N'Profesor', N'blanco',0)
INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'goni@ehu.es', N'A ', N'Goñi', 123, 1, N'Profesor', N'goni',0)
INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'inigo.mendialdua@ehu.es', N'Inigo', N'Mendialdua Beitia', 3166334, 1, N'Profesor', N'sgta',0)
INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'inigo.mendialdua@ehu.eus', N'Inigo', N'Mendialdua Beitia', 7375059, 1, N'Profesor', N'sgta',0)
INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'jose@ikasle.ehu.es', N'Jose', N'Miguel', 123, 1, N'Alumno', N'jose',0)
INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'luis@ikasle.ehu.es', N'Luis', N'Luis', 123, 1, N'Alumno', N'luis',0)
INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'nerea@ikasle.ehu.es', N'Nerea', N'Nerea', 123, 1, N'Alumno', N'nerea',0)
INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'pepe@ikasle.ehu.es', N'Pepe', N'Pepe', 123, 1, N'Alumno', N'pepe',0)
INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (N'vadillo@ehu.es', N'JA', N'Vadillo', 1711744, 1, N'Profesor', N'vadillo',0)
SET IDENTITY_INSERT [TareasPersonales] ON;
GO
INSERT INTO [TareasPersonales] ([Codigo],[Descripción],[HEstimadas],[HReales],[Email]) VALUES (1,N'Envio de correos electrónicos desde ASP.NET',4,6,N'pepe@ikasle.ehu.es');
GO
SET IDENTITY_INSERT [TareasPersonales] OFF;
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'EDA07-Ej1',N'Ejercicio sobre listas ligadas',N'EDA1',3,1,N'Ejercicio');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'EDA13',N'examen',N'EDA1',12,1,N'Examen');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'EX-123',N'examen',N'EDA1',3,1,N'Examen');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'GIS-Lab4',N'ddfdfdf',N'HAS',6,1,N'Laboratorio');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'HAS08-Lab10',N'aaaa',N'HAS',10,1,N'Laboratorio');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'HAS08-Lab12',N'Laboratorio 12 de la asignatura',N'HAS',12,1,N'Laboratorio');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'HAS08-Test5',N'Test 5 de la asignatura',N'HAS',3,0,N'examen');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'HAS11-LAB4',N'lalalalal',N'HAS',20,1,N'Laboratorio');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'ISO-Lab1',N'prueba',N'ISO',12,1,N'Ejercicio');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'Lab4',N'lelelelelelelel',N'HAS',12,1,N'Laboratorio');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'SEG08-Test12',N'Test 12 de la asignatura',N'SEG',3,0,N'Examen');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'SEG08-Trabajo20',N'Tareas del trabajo 20 de la asignatura',N'SEG',10,0,N'Trabajo');
GO
INSERT INTO [TareasGenericas] ([Codigo],[Descripcion],[CodAsig],[HEstimadas],[Explotacion],[TipoTarea]) VALUES (N'Test1',N'10 preguntas ....',N'HAS',1,0,N'Examen');
GO
INSERT INTO [ProfesoresGrupo] ([email],[codigogrupo]) VALUES (N'blanco@ehu.es',N'HAS01');
GO
INSERT INTO [ProfesoresGrupo] ([email],[codigogrupo]) VALUES (N'blanco@ehu.es',N'SEG01');
GO
INSERT INTO [ProfesoresGrupo] ([email],[codigogrupo]) VALUES (N'goni@ehu.es',N'ISO01');
GO
INSERT INTO [ProfesoresGrupo] ([email],[codigogrupo]) VALUES (N'vadillo@ehu.es',N'EDA16');
GO
INSERT INTO [ProfesoresGrupo] ([email],[codigogrupo]) VALUES (N'vadillo@ehu.es',N'HAS01');
GO
INSERT INTO [ProfesoresGrupo] ([email],[codigogrupo]) VALUES (N'zubi@ehu.es',N'ADSI01');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'1',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'10',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'2',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'3',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'4',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'5',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'6',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'7',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'8',NULL,2,N'HAS');
GO
INSERT INTO [GruposTrabajo] ([codigo],[descripcion],[numeroalumnos],[asignatura]) VALUES (N'9',NULL,2,N'HAS');
GO
INSERT INTO [GruposClase] ([codigo],[Descripcion],[codigoasig]) VALUES (N'ADSI01',NULL,N'ADSI');
GO
INSERT INTO [GruposClase] ([codigo],[Descripcion],[codigoasig]) VALUES (N'EDA16',N'Castellano tarde primer cuatrimestre',N'EDA1');
GO
INSERT INTO [GruposClase] ([codigo],[Descripcion],[codigoasig]) VALUES (N'HAS01',N'Castellano segundo cuatrimestre',N'HAS');
GO
INSERT INTO [GruposClase] ([codigo],[Descripcion],[codigoasig]) VALUES (N'HAS31',N'Euskera Primer cuatrimestre',N'HAS');
GO
INSERT INTO [GruposClase] ([codigo],[Descripcion],[codigoasig]) VALUES (N'ISO01',N'Castellano Segundo',N'ISO');
GO
INSERT INTO [GruposClase] ([codigo],[Descripcion],[codigoasig]) VALUES (N'SEG01',N'Castellano primer cuatrimestre',N'SEG');
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'jose@ikasle.ehu.es',N'ADSI-Test1',2,1);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'EDA07-Ej1',2,2);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'EDA13',4,6);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'EX-123',3,12);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'GIS-Lab4',6,9);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'HAS08-Lab10',23,12);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'HAS08-Lab12',12,12);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'HAS08-Lab13',50,20);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'HAS08-Test5',12,13);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'HAS08-Trabajo1',12,12);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'HAS11-LAB4',20,40);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'HAS13-Lab4',4,6);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'Lab4',12,23);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'SEG08-Test12',3,2);
GO
INSERT INTO [EstudiantesTareas] ([Email],[CodTarea],[HEstimadas],[HReales]) VALUES (N'pepe@ikasle.ehu.es',N'Test1',1,2);
GO
INSERT INTO [EstudiantesGrupo] ([Email],[Grupo],[Falta]) VALUES (N'jon@ikasle.ehu.es',N'HAS01',{ts '2008-02-12 00:00:00.000'});
GO
INSERT INTO [EstudiantesGrupo] ([Email],[Grupo],[Falta]) VALUES (N'jose@ikasle.ehu.es',N'ADSI01',{ts '2008-02-13 00:00:00.000'});
GO
INSERT INTO [EstudiantesGrupo] ([Email],[Grupo],[Falta]) VALUES (N'jose@ikasle.ehu.es',N'ISO01',{ts '2008-02-13 00:00:00.000'});
GO
INSERT INTO [EstudiantesGrupo] ([Email],[Grupo],[Falta]) VALUES (N'pepe@ikasle.ehu.es',N'EDA16',{ts '2008-02-12 00:00:00.000'});
GO
INSERT INTO [EstudiantesGrupo] ([Email],[Grupo],[Falta]) VALUES (N'pepe@ikasle.ehu.es',N'HAS01',{ts '2008-02-12 00:00:00.000'});
GO
INSERT INTO [EstudiantesGrupo] ([Email],[Grupo],[Falta]) VALUES (N'pepe@ikasle.ehu.es',N'SEG01',{ts '2008-02-12 00:00:00.000'});
GO
INSERT INTO [Asignaturas] ([codigo],[Nombre]) VALUES (N'ADSI',N'Análisis y Diseño de SI');
GO
INSERT INTO [Asignaturas] ([codigo],[Nombre]) VALUES (N'EDA1',N'Estructuras de Datos y Algoritmos I');
GO
INSERT INTO [Asignaturas] ([codigo],[Nombre]) VALUES (N'HAS',N'Herramientas Avanzadas de SW');
GO
INSERT INTO [Asignaturas] ([codigo],[Nombre]) VALUES (N'ISO',N'Ingeniería del Software');
GO
INSERT INTO [Asignaturas] ([codigo],[Nombre]) VALUES (N'SEG',N'Seguridad Informática');
GO
ALTER TABLE [Usuarios] ADD CONSTRAINT [PK__Usuarios__0000000000000095] PRIMARY KEY ([email]);
GO
ALTER TABLE [TareasPersonales] ADD CONSTRAINT [PK__TareasPersonales__000000000000007B] PRIMARY KEY ([Codigo]);
GO
ALTER TABLE [TareasGenericas] ADD CONSTRAINT [PK__TareasGenericas__0000000000000068] PRIMARY KEY ([Codigo]);
GO
ALTER TABLE [ProfesoresGrupo] ADD CONSTRAINT [PK__ProfesoresGrupo__0000000000000056] PRIMARY KEY ([email],[codigogrupo]);
GO
ALTER TABLE [GruposTrabajo] ADD CONSTRAINT [PK__GruposTrabajo__0000000000000046] PRIMARY KEY ([codigo]);
GO
ALTER TABLE [GruposClase] ADD CONSTRAINT [PK__GruposClase__0000000000000038] PRIMARY KEY ([codigo]);
GO
ALTER TABLE [EstudiantesTareas] ADD CONSTRAINT [PK__EstudiantesTareas__0000000000000029] PRIMARY KEY ([Email],[CodTarea]);
GO
ALTER TABLE [EstudiantesGrupo] ADD CONSTRAINT [PK__EstudiantesGrupo__0000000000000018] PRIMARY KEY ([Email],[Grupo]);
GO
ALTER TABLE [Asignaturas] ADD CONSTRAINT [PK__Asignaturas__0000000000000006] PRIMARY KEY ([codigo]);
GO
CREATE UNIQUE INDEX [PrimaryKey] ON [TareasGenericas] ([Codigo] ASC);
GO
CREATE INDEX [codigogrupo] ON [ProfesoresGrupo] ([codigogrupo] ASC);
GO
CREATE INDEX [email] ON [ProfesoresGrupo] ([email] ASC);
GO
CREATE INDEX [CodTarea] ON [EstudiantesTareas] ([CodTarea] ASC);
GO
CREATE INDEX [Email] ON [EstudiantesTareas] ([Email] ASC);
GO
CREATE INDEX [email] ON [EstudiantesGrupo] ([Email] ASC);
GO
CREATE INDEX [grupo] ON [EstudiantesGrupo] ([Grupo] ASC);
GO
