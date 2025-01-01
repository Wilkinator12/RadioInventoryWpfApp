CREATE PROCEDURE [dbo].[spRadios_GetAll]
AS
begin
	select [Id], [DesignatedDepartmentId], [FrontLabel], [InsideLabel], [SerialNumber], [DesignatedLabelNumber]
	from dbo.Radios;
end
