CREATE TABLE [dbo].[TeamsResult] (
  [teamResultsCode] int PRIMARY KEY,
  [raceCode] int NOT NULL DEFAULT 0,
  [teamCode] int NOT NULL DEFAULT 0,
  [poits] int NOT NULL DEFAULT 0
);