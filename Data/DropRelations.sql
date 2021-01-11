ALTER TABLE [dbo].[Driver] DROP CONSTRAINT [FK_Driver_Country];

ALTER TABLE [dbo].[Driver] DROP CONSTRAINT [FK_Driver_Team];

ALTER TABLE [dbo].[TeamsResult] DROP CONSTRAINT [FK_TeamsResult_Team];

ALTER TABLE [dbo].[TeamsResult] DROP CONSTRAINT [FK_TeamsResult_Race];

ALTER TABLE [dbo].[Result] DROP CONSTRAINT [FK_Result_Race];

ALTER TABLE [dbo].[Race] DROP CONSTRAINT [FK_Race_Circuit];

ALTER TABLE [dbo].[Result] DROP CONSTRAINT [FK_Result_Driver];

ALTER TABLE [dbo].[Result] DROP CONSTRAINT [FK_Result_Team];