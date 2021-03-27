CREATE TABLE [dbo].[TeamsResult] (
  [teamResultsCode] int IDENTITY,
  [raceCode] int NOT NULL default 0,
  [teamCode] int NOT NULL default 0,
  [points] int NOT NULL default 0,
  PRIMARY KEY ([teamResultsCode])
);

INSERT INTO [TeamsResult] VALUES (1, 1, 25);
INSERT INTO [TeamsResult] VALUES (1, 6, 8);
INSERT INTO [TeamsResult] VALUES (1, 7, 0);
INSERT INTO [TeamsResult] VALUES (3, 1, 18);
INSERT INTO [TeamsResult] VALUES (3, 6, 25);
INSERT INTO [TeamsResult] VALUES (3, 7, 23);
INSERT INTO [TeamsResult] VALUES (9, 1, 25);
INSERT INTO [TeamsResult] VALUES (9, 6, 15);
INSERT INTO [TeamsResult] VALUES (9, 7, 19);
INSERT INTO [TeamsResult] VALUES (11, 1, 15);
INSERT INTO [TeamsResult] VALUES (11, 6, 25);
INSERT INTO [TeamsResult] VALUES (11, 7, 14);