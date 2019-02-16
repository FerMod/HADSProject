CREATE TABLE [dbo].[Usuarios] (
    [email]      NVARCHAR (50) NOT NULL,
    [nombre]     NVARCHAR (50) NOT NULL,
    [apellidos]  NVARCHAR (70) NOT NULL,
    [numconfir]  INT           NOT NULL,
    [confirmado] BIT           NOT NULL,
    [tipo]       NVARCHAR (50) NOT NULL,
    [pass]       NVARCHAR (50) NOT NULL,
    [codpass]    INT,
    CONSTRAINT [PK__Usuarios__0000000000000095] PRIMARY KEY CLUSTERED ([email] ASC)
);
