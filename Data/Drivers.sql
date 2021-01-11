CREATE TABLE [dbo].[Driver] (
[driverCode] int IDENTITY,
[teamCode] int NOT NULL default 1,
[countryCode] char(2) NOT NULL default 'IT',
[driverNumber] int NOT NULL default 0,
[driverFirstname] varchar(128) NOT NULL default '',
[driverLastname] varchar(128) NOT NULL default '',
[driverDateOfBirth] date NOT NULL default '19850107',
[driverPlaceOfBirth] varchar(64) NOT NULL default '',
[driverImage] varchar(200) NOT NULL default '',
PRIMARY KEY ([driverCode])
);

INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (44, 'Lewis', 'Hamilton', '19850107', 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (77, 'Valtteri', 'Bottas', '19890828', 'Finland');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (33, 'Max', 'Verstappen', '19970930', 'Belgium');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (4, 'Lando', 'Norris', '19991113', 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (23, 'Alexander', 'Albon', '19960323', 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (3, 'Daniel', 'Ricciardo', '19890701', 'Australia');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (16, 'Charles', 'Leclerc', '19971016', 'Monaco');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (18, 'Lance', 'Stroll', '19981029', 'Canada');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (11, 'Sergio', 'Perez', '19900126', 'Mexico');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (10, 'Pierre', 'Gasly', '19960207', 'France');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (55, 'Carlos', 'Sainz', '19940901', 'Spain');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (31, 'Esteban', 'Ocon', '19960917', 'Normandy');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (5, 'Sebastian', 'Vettel', '19870703', 'Germany');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (26, 'Daniil', 'Kvyat', '19940426', 'Russia');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (27, 'Nicp', 'Hulkenberg', '19870819', 'Germany');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (7, 'Kimi', 'Räikkönen', '19791017', 'Finland');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (99, 'Antonio', 'Giovinazzi', '19931214', 'Italy');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (20, 'Kevin', 'Magnussen', '19921005', 'Denmark');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (6, 'Nicholas', 'Latifi', '19950629', 'Canada');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (63, 'George', 'Russell', '19980215', 'England');
INSERT INTO [Driver] (driverNumber, driverFirstname, driverLastname, driverDateOfBirth, driverPlaceOfBirth)
VALUES (8, 'Romain', 'Grosjean', '19860417', 'Switzerland');