ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FKDC] FOREIGN KEY([extC])
REFERENCES [dbo].[Country] ([countryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FKTC] FOREIGN KEY([extC])
REFERENCES [dbo].[Country] ([countryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FKTDuno] FOREIGN KEY([extFD])
REFERENCES [dbo].[Driver] ([id])

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FKTDdue] FOREIGN KEY([extSD])
REFERENCES [dbo].[Driver] ([id]);