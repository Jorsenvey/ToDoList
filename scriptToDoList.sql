IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TasksList]') AND type in (N'U'))
ALTER TABLE [dbo].[TasksList] DROP CONSTRAINT IF EXISTS [FK_TasksList_TaskStatus_IdTaskStatus]
GO
/****** Object:  Index [Idx_TaskDescriptionStatus]    Script Date: 22/02/2023 10:10:26 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskStatus]') AND type in (N'U'))
ALTER TABLE [dbo].[TaskStatus] DROP CONSTRAINT IF EXISTS [Idx_TaskDescriptionStatus]
GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 22/02/2023 10:10:26 p. m. ******/
DROP TABLE IF EXISTS [dbo].[TaskStatus]
GO
/****** Object:  Table [dbo].[TasksList]    Script Date: 22/02/2023 10:10:26 p. m. ******/
DROP TABLE IF EXISTS [dbo].[TasksList]
GO
/****** Object:  Table [dbo].[TasksList]    Script Date: 22/02/2023 10:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TasksList](
	[IdTask] [int] IDENTITY(1,1) NOT NULL,
	[DescriptionTask] [varchar](50) NOT NULL,
	[IdEstatusTask] [int] NOT NULL,
 CONSTRAINT [PK_TasksList] PRIMARY KEY CLUSTERED 
(
	[IdTask] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 22/02/2023 10:10:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[IdTaskStatus] [int] NOT NULL,
	[TaskDescriptionStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TaskStatus] PRIMARY KEY CLUSTERED 
(
	[IdTaskStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TasksList] ON 

INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (1, N'Probar Back', 1)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (2, N'Probar el Update EstatusTask', 0)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (3, N'dos noches de trasnocho jeje', 2)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (4, N'Acostar a los hijos', 0)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (5, N'4234242', 2)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (6, N'Prueba de add task false 2', 0)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (7, N'Ajustar estilos check', 0)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (8, N'Editar Estados', 1)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (9, N'Prueba metodo update descripción', 0)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (10, N'prueba input text', 0)
INSERT [dbo].[TasksList] ([IdTask], [DescriptionTask], [IdEstatusTask]) VALUES (11, N'last test', 0)
SET IDENTITY_INSERT [dbo].[TasksList] OFF
GO
INSERT [dbo].[TaskStatus] ([IdTaskStatus], [TaskDescriptionStatus]) VALUES (2, N'Deleted')
INSERT [dbo].[TaskStatus] ([IdTaskStatus], [TaskDescriptionStatus]) VALUES (1, N'Done')
INSERT [dbo].[TaskStatus] ([IdTaskStatus], [TaskDescriptionStatus]) VALUES (0, N'NotDone')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Idx_TaskDescriptionStatus]    Script Date: 22/02/2023 10:10:27 p. m. ******/
ALTER TABLE [dbo].[TaskStatus] ADD  CONSTRAINT [Idx_TaskDescriptionStatus] UNIQUE NONCLUSTERED 
(
	[TaskDescriptionStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TasksList]  WITH CHECK ADD  CONSTRAINT [FK_TasksList_TaskStatus_IdTaskStatus] FOREIGN KEY([IdEstatusTask])
REFERENCES [dbo].[TaskStatus] ([IdTaskStatus])
GO
ALTER TABLE [dbo].[TasksList] CHECK CONSTRAINT [FK_TasksList_TaskStatus_IdTaskStatus]
GO
