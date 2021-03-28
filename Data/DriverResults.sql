CREATE PROCEDURE [dbo].[DriverResults]
	@id int
AS
	DECLARE @retTable TABLE(driverCode INT PRIMARY KEY, totPoints INT DEFAULT 0, averagePoints DECIMAL(18, 2), nFastestLap INT DEFAULT 0, 
	nFirstPlace INT DEFAULT 0, nSecondPlace INT DEFAULT 0, nThirdPlace INT DEFAULT 0, nPodius INT DEFAULT 0)

	DECLARE @totPoints as INT
	DECLARE @averagePoints as DECIMAL(18, 2)
	DECLARE @nFastestLap as INT
	DECLARE @nFirstPlace as INT
	DECLARE @nSecondPlace as INT
	DECLARE @nThirdPlace as INT

	SET @totPoints = 
	(
		SELECT SUM(r.resultPoints)
		FROM Result r
		WHERE r.driverCode=@id
		GROUP BY r.driverCode
	)
	SET @averagePoints = 
	(
		SELECT AVG(CAST(r.resultPoints as DECIMAL(18, 2)))
		FROM Result r
		WHERE r.driverCode=@id
		GROUP BY r.driverCode
	)
	SET @nFastestLap = 
	(
		SELECT COUNT(r.resultFastestLap) as nFastestLap
		FROM Result r
		WHERE r.driverCode=@id AND r.resultFastestLap=r.driverCode
		GROUP BY r.driverCode
	)
	SET @nFirstPlace = 
	(
		SELECT COUNT(r.resultPosition) as nFirstPlace
		FROM Result r
	    WHERE r.driverCode=@id AND r.resultPosition=1
		GROUP BY r.driverCode
	)
	SET @nSecondPlace = 
	(
		SELECT COUNT(r.resultPosition) as nSecondPlace
		FROM Result r
	    WHERE r.driverCode=@id AND r.resultPosition=2
		GROUP BY r.driverCode
	)
	SET @nThirdPlace = 
	(
		SELECT COUNT(r.resultPosition) as nThirdPlace
		FROM Result r
		WHERE r.driverCode=@id AND r.resultPosition=3
		GROUP BY r.driverCode
	)

	if(@totPoints IS NULL)
		SET @totPoints = 0

	if(@averagePoints IS NULL)
		SET @averagePoints = 0

	if(@nFastestLap IS NULL)
		SET @nFastestLap = 0

	if(@nFirstPlace IS NULL)
		SET @nFirstPlace = 0

	if(@nSecondPlace IS NULL)
		SET @nSecondPlace = 0

	if(@nThirdPlace IS NULL)
		SET @nThirdPlace = 0

	INSERT INTO @retTable (driverCode, totPoints, averagePoints, nFastestLap, 
	nFirstPlace, nSecondPlace, nThirdPlace, nPodius)
	VALUES (@id, @totPoints, @averagePoints, @nFastestLap, @nFirstPlace, @nSecondPlace, @nThirdPlace, (@nFirstPlace + @nSecondPlace + @nThirdPlace))

	SELECT * FROM @retTable
RETURN 0