CREATE TABLE [dbo].[TeamsResult] (
  [teamResultsCode] int IDENTITY,
  [raceCode] int NOT NULL default 0,
  [teamCode] int NOT NULL default 0,
  [poits] int NOT NULL default 0,
  PRIMARY KEY ([teamResultsCode])
);