USE Sween
GO
SET	ANSI_NULLS ON
GO 
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
			[Id_user] [int] NOT NULL,
			[Name] [varchar](50) NOT NULL,
			[LastName] [varchar](50) NOT NULL,
			[Email][varchar](50) NOT NULL,
			[Birthday][datetime] NOT NULL,
			[Tel][varchar](50) NOT NULL,
			[Nick][varchar](50) NOT NULL,
			[Password][varchar](50) NOT NULL,
			[Activo][bit] NOT NULL,
			[ImageURL][varchar](150) NOT NULL,
			CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
			(
				[Id_user]ASC
		    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY =OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY]
			GO

CREATE TABLE [dbo].[Messages](
			[Id_message] [int] NOT NULL,
			[View] [varchar](50) NOT NULL,
			[Type] [varchar](50) NOT NULL,
			[Contain][varchar](50) NOT NULL,
			[Reaction][varchar](50) NOT NULL,
			[Date][datetime] NOT NULL,
			[Id_user][int] NOT NULL,
			CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
			(
				[Id_message]ASC
		    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY =OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY]
			GO

CREATE TABLE [dbo].[Groups](
			[Id_group] [int] NOT NULL,
			[NameGroup] [varchar](50) NOT NULL,
			[Date] [datetime] NOT NULL,
			CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
			(
				[Id_group]ASC
		    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY =OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY]
			GO

CREATE TABLE [dbo].[UsersGroup](
			[Id_usergroup] [int] NOT NULL,
			[Id_user] [int] NOT NULL,
			[Id_group] [int] NOT NULL,
			CONSTRAINT [PK_UsersGroup] PRIMARY KEY CLUSTERED 
			(
				[Id_usergroup]ASC
		    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY =OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY]
			GO

ALTER TABLE [dbo].[Messages] ADD CONSTRAINT [FK_Messages_User] FOREIGN KEY ([Id_user])
REFERENCES [dbo].[User]([Id_user])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_User]
GO
ALTER TABLE [dbo].[UsersGroup] ADD CONSTRAINT [FK_UsersGroup_User] FOREIGN KEY ([Id_user])
REFERENCES [dbo].[User]([Id_user])
GO
ALTER TABLE [dbo].[UsersGroup] CHECK CONSTRAINT [FK_UsersGroup_User]
ALTER TABLE [dbo].[UsersGroup] ADD CONSTRAINT [FK_UsersGroup_Group] FOREIGN KEY ([Id_group])
REFERENCES [dbo].[Groups]([Id_group])
GO
ALTER TABLE [dbo].[UsersGroup] CHECK CONSTRAINT [FK_UsersGroup_Group]
