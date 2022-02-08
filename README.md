# ExamenTecnico

1-Crear base de datos "db_ExamenTecnico"

CREATE DATABASE db_ExamenTecnico


2-Crear tabla "tbl_Notas"

CREATE TABLE [dbo].[tbl_Notas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Contenido] [nvarchar](max) NULL,
	[Tema] [nvarchar](max) NULL,
	[Fecha] [datetime2](7) NULL,
 CONSTRAINT [PK_tbl_Notas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


3-Actualizar archivo appsettings.json con el nombre de su servidor de sqlServer

"ConnectionStrings": {
    "DefaultConnection": "Server=<servidorsqlserver>;Database=db_ExamenTecnico;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
