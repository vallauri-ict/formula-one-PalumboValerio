CREATE TABLE [dbo].[Result] (
  [resultCode] int PRIMARY KEY,
  [raceCode] int NOT NULL DEFAULT 0,
  [driverCode] int NOT NULL DEFAULT 0,
  [teamCode] int NOT NULL DEFAULT 0,
  [number] int NOT NULL DEFAULT 0,
  [grid] varchar(200) NOT NULL DEFAULT "",
  [position] varchar(200) NOT NULL DEFAULT "",
  [poits] int NOT NULL DEFAULT 0,
  [laps] int NOT NULL DEFAULT 0,
  [time] datetime NOT NULL DEFAULT "00:00:00",
  [fastestLap] int NOT NULL DEFAULT 0,
  [fastestLapTime] datetime NOT NULL DEFAULT "00:00:00",
  [fastestLapSpeed] int NOT NULL DEFAULT 0
);