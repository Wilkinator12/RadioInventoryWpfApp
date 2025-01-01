CREATE PROCEDURE [dbo].[spRadios_GetHighestDesignatedLabelNumber]
	@departmentId int
AS
begin
	select isnull(max(r.DesignatedLabelNumber), 0)
	from dbo.Radios r
	where r.DesignatedDepartmentId = @departmentId;
end
