CREATE TABLE [dbo].[Result] (
  [resultCode] int IDENTITY,
  [raceCode] int NOT NULL default 0,
  [driverCode] int NOT NULL default 0,
  [teamCode] int NOT NULL default 0,
  [number] int NOT NULL default 0,
  [grid] varchar(200) NOT NULL default '',
  [position] varchar(200) NOT NULL default '',
  [poits] int NOT NULL default 0,
  [laps] int NOT NULL default 0,
  [time] int NOT NULL default 0,
  [fastestLap] int NOT NULL default 0,
  [fastestLapTime] int NOT NULL default 0,
  [fastestLapSpeed] int NOT NULL default 0,
  PRIMARY KEY ([resultCode])
);