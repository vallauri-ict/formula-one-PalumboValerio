CREATE TABLE [dbo].[Circuit] (
  [circuitCode] int IDENTITY,
  [circuitRef] varchar(200) NOT NULL default '',
  [circuitName] varchar(200) NOT NULL default '',
  [circuitLocation] varchar(200) NOT NULL default '',
  [circuitCountry] varchar(200) NOT NULL default '',
  [lat] varchar(200) NOT NULL default '',
  [lng] varchar(200) NOT NULL default '',
  [alt] varchar(200) NOT NULL default '',
  [url] varchar(200) NOT NULL default '',
  PRIMARY KEY ([circuitCode])
);

INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Autodromo Internazionale Enzo e Dino Ferrari', 'Imola', 'Italy');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'AVUS', 'Berlin', 'Germany');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Bugatti Circuit', 'Le Mans', 'France');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Caesars Palace Grand Prix Circuit', 'Las Vegas', 'United States');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Autodromo Nazionale di Monza', 'Monza', 'Italy');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Pescara Circuit', 'Pescara', 'Italy');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Sochi Autodrom', 'Sochi', 'Russia');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Mugello Circuit', 'Scarperia e San Piero', 'Italy');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Circuit de Barcelona-Catalunya', 'Montmeló', 'Spain');
INSERT INTO [Circuit] (circuitRef, circuitName, circuitLocation, circuitCountry) 
VALUES ('FIA', 'Baku City Circuit', 'Baku', 'Azerbaijan');