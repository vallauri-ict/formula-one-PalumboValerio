CREATE TABLE [dbo].[Team] (
[teamCode] int IDENTITY,
[teamFullName] varchar(100) NOT NULL default '',
[teamBase] varchar(100) NOT NULL default '',
[teamChief] varchar(100) NOT NULL default '',
[teamPowerUnit] varchar(100) NOT NULL default '',
[teamWorldChampionships] int NOT NULL default 0,
[teamPolePositions] int NOT NULL default 0,
[teamImage] varchar(200) NOT NULL default '',
PRIMARY KEY ([teamCode])
);

INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('Mercedes-AMG Petronas F1 Team', 'Brackley, United Kingdom', 'Toto Wolff', 'Mercedes', 6, 113);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('Aston Martin Red Bull Racing', 'Milton Keynes, United Kingdom', 'Christian Horner', 'Honda', 4, 62);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('McLaren F1 Team', 'Woking, United Kingdom', 'Andreas Seidl', 'Renault', 8, 155);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('BWT Racing Point F1 Team', 'Silverstone, United Kingdom', 'Otmar Szafnauer', 'BWT Mercedes', 0, 0);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('Renault DP World F1 Team', 'Enstone, United Kingdom', 'Cyril Abiteboul', 'Renault', 2, 20);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('Scuderia Ferrari Mission Winnow', 'Maranello, Italy', 'Mattia Binotto', 'Ferrari', 16, 221);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('Scuderia AlphaTauri Honda', 'Faenza, Italy', 'Franz Tost', 'Honda', 0, 1);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('Alfa Romeo Racing ORLEN', 'Hinwil, Switzerland', 'Frédéric Vasseur', 'Ferrari', 0, 1);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('Haas F1 Team', 'Kannapolis, United States', 'Guenther Steiner', 'Ferrari', 0, 0);
INSERT INTO [Team] (teamFullName, teamBase, teamChief, teamPowerUnit, teamWorldChampionships, teamPolePositions)
VALUES ('Williams Racing', 'Grove, United Kingdom', 'Simon Roberts', 'Mercedes', 9, 129);