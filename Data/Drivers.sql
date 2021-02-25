CREATE TABLE [dbo].[Driver] (
[driverCode] int,
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
VALUES (44, 1, 'SM', 'Lewis', 'Hamilton', '19850107', 'England');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (77, 2, 'AF', 'Valtteri', 'Bottas', '19890828', 'Finland');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (33, 3, 'IT', 'Max', 'Verstappen', '19970930', 'Belgium');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (4, 4, 'DK', 'Lando', 'Norris', '19991113', 'England');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (23, 5, 'GL', 'Alexander', 'Albon', '19960323', 'England');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (3, 6, 'JP', 'Daniel', 'Ricciardo', '19890701', 'Australia');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (16, 7, 'MY', 'Charles', 'Leclerc', '19971016', 'Monaco');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (18, 8, 'NL', 'Lance', 'Stroll', '19981029', 'Canada');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (11, 9, 'PG', 'Sergio', 'Perez', '19900126', 'Mexico');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (10, 10, 'SD', 'Pierre', 'Gasly', '19960207', 'France');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (55, 1, 'SM', 'Carlos', 'Sainz', '19940901', 'Spain');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (31, 2, 'AF', 'Esteban', 'Ocon', '19960917', 'Normandy');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (5, 3, 'IT', 'Sebastian', 'Vettel', '19870703', 'Germany');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (26, 4, 'DK', 'Daniil', 'Kvyat', '19940426', 'Russia');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (27, 5, 'GL', 'Nicp', 'Hulkenberg', '19870819', 'Germany');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (7, 6, 'JP', 'Kimi', 'Räikkönen', '19791017', 'Finland');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (99, 7, 'MY', 'Antonio', 'Giovinazzi', '19931214', 'Italy');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (20, 8, 'NL', 'Kevin', 'Magnussen', '19921005', 'Denmark');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (6, 9, 'PG', 'Nicholas', 'Latifi', '19950629', 'Canada');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (63, 10, 'SD', 'George', 'Russell', '19980215', 'England');
INSERT INTO [Driver] (driverCode, teamCode, countryCode, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (8, 3, 'IT', 'Romain', 'Grosjean', '19860417', 'Switzerland');