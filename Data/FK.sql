ALTER TABLE [dbo].[Driver] ADD FOREIGN KEY ([countryCode]) REFERENCES [dbo].[Country] ([countryCode]);

ALTER TABLE [dbo].[Driver] ADD FOREIGN KEY ([teamCode]) REFERENCES [dbo].[Team] ([teamCode]);

ALTER TABLE [dbo].[TeamsResult] ADD FOREIGN KEY ([teamCode]) REFERENCES [dbo].[Team] ([teamCode]);

ALTER TABLE [dbo].[TeamsResult] ADD FOREIGN KEY ([raceCode]) REFERENCES [dbo].[Race] ([teamCode]);

ALTER TABLE [dbo].[Result] ADD FOREIGN KEY ([raceCode]) REFERENCES [dbo].[Race] ([raceCode]);

ALTER TABLE [dbo].[Race] ADD FOREIGN KEY ([circuitCode]) REFERENCES [dbo].[Circuit] ([circuitCode]);

ALTER TABLE [dbo].[Result] ADD FOREIGN KEY ([driverCode]) REFERENCES [dbo].[Driver] ([driverCode]);

ALTER TABLE [dbo].[Result] ADD FOREIGN KEY ([teamCode]) REFERENCES [dbo].[Team] ([teamCode]);