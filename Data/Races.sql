CREATE TABLE [dbo].[Race] (
  [raceCode] int PRIMARY KEY,
  [year] datetime NOT NULL DEFAULT "2020",
  [round] int NOT NULL DEFAULT 0,
  [circuitCode] int NOT NULL DEFAULT 0,
  [name] varchar(200) NOT NULL DEFAULT "",
  [date] date NOT NULL DEFAULT "01/10/2020",
  [time] datetime NOT NULL DEFAULT "00:00:00",
  [url] varchar(200) NOT NULL DEFAULT ""
);