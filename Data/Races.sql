CREATE TABLE [dbo].[Race] (
  [raceCode] int IDENTITY,
  [circuitCode] int NOT NULL default 1,
  [raceYear] int NOT NULL default 2021,
  [raceRound] int NOT NULL default 1,
  [raceName] varchar(200) NOT NULL default '',
  [raceDate] date NOT NULL default '20210101',
  [raceTime] varchar(10) NOT NULL default '1h30m',
  [raceURL] varchar(200) NOT NULL default '',
  PRIMARY KEY ([raceCode])
);

INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 3, 'European Grand Prix', '20201011', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 2, 'Emilia Romagna Grand Prix', '20210807', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 5, 'French Grand Prix', '20210402', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 2, 'German Grand Prix', '20210918', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 3, 'Pescara Grand Prix', '20211215', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 4, 'Russian Grand Prix', '20210214', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 3, 'Italian Grand Prix', '20210703', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 5, 'Tuscan Grand Prix', '20210629', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 4, 'United States Grand Prix', '20210531', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 3, 'Spanish Grand Prix', '20210127', '1h30m');
INSERT INTO [Race] (raceYear, raceRound, raceName, raceDate, raceTime) 
VALUES (2021, 3, 'Azerbaijan Grand Prix', '20211202', '1h30m');