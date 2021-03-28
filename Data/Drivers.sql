CREATE TABLE [dbo].[Driver] (
[driverCode] int NOT NULL default 0,
[teamCode] int NOT NULL default 1,
[countryCode] char(2) NOT NULL default 'IT',
[driverFirstname] varchar(128) NOT NULL default '',
[driverLastname] varchar(128) NOT NULL default '',
[driverDateOfBirth] date NOT NULL default '19850107',
[driverPlaceOfBirth] varchar(64) NOT NULL default '',
[driverImage] varchar(200) NOT NULL default '',
PRIMARY KEY ([driverCode])
);

INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (44, 1, 'EN', 'Lewis', 'Hamilton', '19850107', 'England');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (77, 2, 'FI', 'Valtteri', 'Bottas', '19890828', 'Finland');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (33, 3, 'BE', 'Max', 'Verstappen', '19970930', 'Belgium');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (4, 1, 'EN', 'Lando', 'Norris', '19991113', 'England');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (23, 1, 'EN', 'Alexander', 'Albon', '19960323', 'England');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (3, 4, 'AU', 'Daniel', 'Ricciardo', '19890701', 'Australia');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (16, 6, 'MC',  'Charles', 'Leclerc', '19971016', 'Monaco');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (18, 9, 'CA', 'Lance', 'Stroll', '19981029', 'Canada');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (11, 9, 'CA', 'Sergio', 'Perez', '19900126', 'Mexico');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (10, 7, 'FR', 'Pierre', 'Gasly', '19960207', 'France');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (55, 7, 'FR', 'Carlos', 'Sainz', '19940901', 'Spain');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (31, 6, 'IT', 'Esteban', 'Ocon', '19960917', 'Normandy');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (5, 6, 'IT', 'Sebastian', 'Vettel', '19870703', 'Germany');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (26, 7, 'RU', 'Daniil', 'Kvyat', '19940426', 'Russia');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (27, 7, 'RU', 'Nicp', 'Hulkenberg', '19870819', 'Germany');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (7, 7, 'RU', 'Kimi', 'Räikkönen', '19791017', 'Finland');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (99, 6, 'IT', 'Antonio', 'Giovinazzi', '19931214', 'Italy');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (20, 6, 'IT', 'Kevin', 'Magnussen', '19921005', 'Denmark');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (6, 9, 'CA', 'Nicholas', 'Latifi', '19950629', 'Canada');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (63, 1, 'EN', 'George', 'Russell', '19980215', 'England');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (8, 8, 'CH', 'Romain', 'Grosjean', '19860417', 'Switzerland');