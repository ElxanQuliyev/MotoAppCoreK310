USE [MotoDB]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Title], [Description], [PhotoUrl]) VALUES (1, N'Test', N'Test Desc', N'Test.photo')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
