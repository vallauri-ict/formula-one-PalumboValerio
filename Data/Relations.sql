ALTER TABLE [dbo].[Driver]  WITH CHECK ADD CONSTRAINT [FK_Driver_Country] FOREIGN KEY([countryCode]) REFERENCES [dbo].[Country] ([countryCode]);

ALTER TABLE [dbo].[Driver] WITH CHECK ADD CONSTRAINT [FK_Driver_Team] FOREIGN KEY ([teamCode]) REFERENCES [dbo].[Team] ([teamCode]);

ALTER TABLE [dbo].[TeamsResult] WITH CHECK ADD CONSTRAINT [FK_TeamsResult_Team] FOREIGN KEY ([teamCode]) REFERENCES [dbo].[Team] ([teamCode]);

ALTER TABLE [dbo].[TeamsResult] WITH CHECK ADD CONSTRAINT [FK_TeamsResult_Race] FOREIGN KEY ([raceCode]) REFERENCES [dbo].[Race] ([raceCode]);

ALTER TABLE [dbo].[Result] WITH CHECK ADD CONSTRAINT [FK_Result_Race] FOREIGN KEY ([raceCode]) REFERENCES [dbo].[Race] ([raceCode]);

ALTER TABLE [dbo].[Race] WITH CHECK ADD CONSTRAINT [FK_Race_Circuit] FOREIGN KEY ([circuitCode]) REFERENCES [dbo].[Circuit] ([circuitCode]);

ALTER TABLE [dbo].[Result] WITH CHECK ADD CONSTRAINT [FK_Result_Driver] FOREIGN KEY ([driverCode]) REFERENCES [dbo].[Driver] ([driverCode]);

ALTER TABLE [dbo].[Result] WITH CHECK ADD CONSTRAINT [FK_Result_Team] FOREIGN KEY ([teamCode]) REFERENCES [dbo].[Team] ([teamCode]);