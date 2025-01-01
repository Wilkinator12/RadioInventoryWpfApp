CREATE TABLE [dbo].[Departments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(30) NOT NULL, 
    [FrontLabelPrefix] NVARCHAR(10) NOT NULL, 
    [InsideLabelPrefix] NVARCHAR(10) NOT NULL
)
