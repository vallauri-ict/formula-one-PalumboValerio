CREATE TABLE [dbo].[Circuit] (
  [circuitCode] int PRIMARY KEY,
  [circuitRef] varchar(200) NOT NULL,
  [name] varchar(200) NOT NULL DEFAULT "",
  [location] varchar(200) NOT NULL DEFAULT "",
  [country] varchar(200) NOT NULL DEFAULT "",
  [lat] varchar(200) NOT NULL DEFAULT "",
  [lng] varchar(200) NOT NULL DEFAULT "",
  [alt] varchar(200) NOT NULL DEFAULT "",
  [url] varchar(200) NOT NULL DEFAULT ""
);