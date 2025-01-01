CREATE TABLE [dbo].[Radios]
(
	[Id] INT NOT NULL  IDENTITY, 
    [DesignatedDepartmentId] INT NOT NULL, 
    [FrontLabel] NVARCHAR(50) NOT NULL, 
    [InsideLabel] NVARCHAR(50) NOT NULL, 
    [SerialNumber] NVARCHAR(50) NOT NULL, 
    [DesignatedLabelNumber] INT NOT NULL, 
    CONSTRAINT [FK_Radios_Departments] FOREIGN KEY ([DesignatedDepartmentId]) REFERENCES [Departments]([Id]), 
    PRIMARY KEY ([Id])
)
