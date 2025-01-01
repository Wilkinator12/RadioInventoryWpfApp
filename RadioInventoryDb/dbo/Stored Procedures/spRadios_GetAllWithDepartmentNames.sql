CREATE PROCEDURE [dbo].[spRadios_GetAllWithDepartmentNames]
AS
begin
	select [r].[Id], [d].[Name] 
	as DepartmentName, [r].[FrontLabel], [r].[InsideLabel], [r].[SerialNumber], [r].[DesignatedLabelNumber] 
	from dbo.Radios r
	inner join dbo.Departments d on r.DesignatedDepartmentId = d.Id;
end
