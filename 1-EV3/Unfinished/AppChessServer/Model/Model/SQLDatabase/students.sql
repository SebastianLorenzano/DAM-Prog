USE JARDINERIA
SELECT * FROM EMPLEADOS

DECLARE @index INT = 3
SELECT *
FROM EMPLEADOS
ORDER BY (SELECT NULL) -- Use ORDER BY (SELECT NULL) to avoid sorting if no specific order is needed
OFFSET @index - 1 ROWS      -- -1 so it starts counting index and doesn't jump it
FETCH NEXT 3 ROWS ONLY;





--CREATE DATABASE CHESS
USE CHESS
GO

CREATE TABLE USERS (
    codUser          INT IDENTITY,
    email           VARCHAR(100) NOT NULL,
    password        VARCHAR(100) NOT NULL,
    registerDate    DATE

    CONSTRAINT PK_STUDENTS PRIMARY KEY (codUser)
)

CREATE TABLE GAMES (
    codGame         INT IDENTITY,
    codUserWhites   INT,
    codUserBlacks   INT,
    gameJson        VARCHAR(MAX)

    CONSTRAINT PK_GAMES PRIMARY KEY (codGame)
)

--------------------------
GO

CREATE OR ALTER PROCEDURE AddUser(@email VARCHAR(100), @password VARCHAR(100),  @codUser
 INT OUT)
AS
BEGIN
    IF @email IS NULL OR EXISTS (SELECT 1 FROM USERS WHERE email = @email)
	    RETURN -1

    IF @password IS NULL
        RETURN -2

    SET @codUser
     = NULL
    INSERT INTO USERS (email, password)
			VALUES (@email, @password)

    SET @codUser
     = SCOPE_IDENTITY()
END

-------------------------
GO

CREATE OR ALTER PROCEDURE RemoveUser(@codUser INT)
AS
BEGIN
    IF @codUser
     <= 0
    RETURN -1

    BEGIN TRY
        BEGIN TRANSACTION

            UPDATE GAMES
               SET codUserWhites = NULL
             WHERE codUserWhites = @codUser


            UPDATE GAMES
              SET codUserBlacks = NULL
            WHERE codUserBlacks = @codUser


            DELETE FROM USERS
             WHERE codUser = @codUser

        COMMIT
    END TRY
    BEGIN CATCH
        PRINT CONCAT ('ERROR: ', ERROR_NUMBER(), CHAR(10), 
                      'LINE: ', ERROR_MESSAGE(), CHAR(10), 
                      'MESSAGE: ', ERROR_LINE())

        ROLLBACK
    END CATCH
END


GO
----------
CREATE OR ALTER PROCEDURE UpdateUserPassword(@codUser INT, @password VARCHAR(100))
AS
BEGIN
    IF @codUser <= 0
        RETURN -1
    IF @password IS NULL
        RETURN -2

    UPDATE USERS
    SET password = @password
    WHERE codUser = @codUser

END

-------------
GO
CREATE OR ALTER FUNCTION GetUserWithId(@codUser INT)
RETURNS VARCHAR
AS
BEGIN
    IF @codUser
     <= 0
        RETURN NULL
    RETURN (SELECT * FROM USERS WHERE codUser = @codUser
     FOR JSON AUTO)
END

GO



--------------------------
GO

CREATE OR ALTER PROCEDURE AddGame(@codUserWhites INT, @codUserBlacks INT,  @gameJson VARCHAR(MAX), @codGame INT OUT)
AS
BEGIN
    IF @codUserWhites IS NULL OR NOT EXISTS (SELECT 1 FROM USERS WHERE codUser = @codUserWhites)
	    RETURN -1

    IF @codUserBlacks IS NULL OR NOT EXISTS (SELECT 1 FROM USERS WHERE codUser = @codUserBlacks)
        RETURN -2
    
    IF @gameJson IS NULL
        RETURN -3

    SET @codGame = NULL
    INSERT INTO GAMES (codUserWhites, codUserBlacks, gameJson)
			VALUES (@codUserWhites, @codUserBlacks, @gameJson)

    SET @codGame = SCOPE_IDENTITY()
END

-------------------------
GO

CREATE OR ALTER PROCEDURE RemoveGame(@codGame INT)
AS
BEGIN
    IF @codGame <= 0
        RETURN -1

    DELETE FROM GAMES
    WHERE codGame = @codGame
END


GO
----------
CREATE OR ALTER PROCEDURE UpdateGameJson(@codGame INT, @gameJson VARCHAR(MAX))
AS
BEGIN
    IF @codGame <= 0
        RETURN -1

    IF @gameJson IS NULL
        RETURN -2

    UPDATE GAMES
    SET gameJson = @gameJson
    WHERE codGame = @codGame

END

-------------
GO
CREATE OR ALTER FUNCTION GetGameWithId(@codGame INT)
RETURNS VARCHAR
AS
BEGIN
    IF @codGame <= 0
        RETURN NULL
    RETURN (SELECT * FROM GAMES WHERE codGame = @codGame FOR JSON AUTO)
END

GO

