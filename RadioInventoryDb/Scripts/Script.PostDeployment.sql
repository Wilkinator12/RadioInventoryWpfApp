/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


if not exists (select 1 from dbo.Departments)
begin
    insert into dbo.Departments (Name, FrontLabelPrefix, InsideLabelPrefix)
    values ('AD', 'AD', 'AD'),('Camera', 'Cam', 'Ca'), 
    ('Playback', 'PB', 'PB'), ('Lighting', 'LX', 'LX'),
    ('Grips', 'Grips', 'Gr'), ('SPFX', 'SPFX', 'SF'), 
    ('Make-Up', 'MU', 'MU'), ('Hair', 'Hair', 'H'), 
    ('Costumes', 'Costumes', 'Co'), ('Set Decoration', 'Set Dec', 'SD'), 
    ('Props', 'Props', 'Pr'), ('Construction', 'Constr', 'Cs'), 
    ('Paint', 'Paint', 'P'), ('Greens', 'Greens', 'Gn'),
    ('VFX', 'VFX', 'VF'), ('Sound', 'Sound', 'S'), 
    ('Transport', 'Tr', 'Tr'), ('Locations', 'Locs', 'L'), 
    ('Background Coordinator', 'BG', 'BG'), ('First-Aid', 'FA', 'FA'), 
    ('First-Aid / Craft Service', 'FACS', 'CS'), ('COVID', 'COV', 'CV'), 
    ('Catering', 'Cat', 'Ct'), ('Picture Cars', 'PC', 'PC'),
    ('Crane Tech', 'Crane Tech', 'CT'), ('Stunts', 'Stunts', 'St')
end