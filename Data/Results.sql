CREATE TABLE [dbo].[Result] (
  [resultCode] int IDENTITY(1,1),
  [raceCode] int NOT NULL default 0,
  [driverCode] int NOT NULL default 0,
  [teamCode] int NOT NULL default 0,
  [resultPosition] varchar(200) NOT NULL default 'N.A.',
  [resultTime] varchar(200) NOT NULL default '',
  [resultNlap] int NOT NULL default 0,
  [resultPoints] int NOT NULL default 0,
  [resultFastestLap] int NOT NULL default 0,
  [resultFastestLapTime] varchar(200) NOT NULL default 0,
  PRIMARY KEY ([resultCode])
);

INSERT INTO [Result] VALUES (1, 44, 1, '1', '00:45:36', 71, 25, 44, '00:01:05');
INSERT INTO [Result] VALUES	(1, 16, 6, '6', '00:46:14', 71, 8, 44, '00:01:05');
INSERT INTO [Result] VALUES (1, 10, 7, '14', '00:50:39', 71, 0, 44, '00:01:05');
INSERT INTO [Result] VALUES (1, 26, 7, '24', '00:52:07', 71, 0, 44, '00:01:05');
INSERT INTO [Result] VALUES (3, 44, 1, '2', '00:49:03', 70, 18, 16, '00:00:59');
INSERT INTO [Result] VALUES (3, 16, 6, '1', '00:48:57', 70, 25, 16, '00:00:59');
INSERT INTO [Result] VALUES (3, 10, 7, '3', '00:49:10', 70, 15, 16, '00:00:59');
INSERT INTO [Result] VALUES (3, 26, 7, '6', '00:53:23', 70, 8, 16, '00:00:59');
INSERT INTO [Result] VALUES (9, 44, 1, '1', '00:59:29', 59, 25, 44, '00:00:42');
INSERT INTO [Result] VALUES (9, 16, 6, '3', '00:59:59', 59, 15, 44, '00:00:42');
INSERT INTO [Result] VALUES (9, 10, 7, '2', '00:59:34', 59, 18, 44, '00:00:42');
INSERT INTO [Result] VALUES (9, 26, 7, '10', '01:10:27', 59, 1, 44, '00:00:42');
INSERT INTO [Result] VALUES (11, 44, 1, '3', '01:04:36', 66, 15, 10, '00:01:01');
INSERT INTO [Result] VALUES (11, 16, 6, '1', '01:03:10', 66, 25, 10, '00:01:01');
INSERT INTO [Result] VALUES (11, 10, 7, '4', '01:04:46', 66, 12, 10, '00:01:01');
INSERT INTO [Result] VALUES (11, 26, 7, '9', '01:05:00', 66, 2, 10, '00:01:01');