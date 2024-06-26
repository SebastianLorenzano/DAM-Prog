USE master

DROP DATABASE CHESS
CREATE DATABASE CHESS
USE CHESS
GO

CREATE TABLE USERS (
    codUser         BIGINT IDENTITY,
    userName        VARCHAR(50) NOT NULL,
    email           VARCHAR(100) NOT NULL,
    password        VARCHAR(100) NOT NULL,
    registerDate    DATE

    CONSTRAINT PK_STUDENTS PRIMARY KEY (codUser)
)

CREATE TABLE GAMES (
    codGame         BIGINT IDENTITY,
    codUserWhites   BIGINT,
    codUserBlacks   BIGINT,
    board           VARCHAR(MAX)

    CONSTRAINT PK_GAMES PRIMARY KEY (codGame)
)


--------------------------
GO

CREATE OR ALTER PROCEDURE AddUser(@name VARCHAR(50), @email VARCHAR(100), @password VARCHAR(100),  @codUser BIGINT OUT)
AS
BEGIN
    IF @email IS NULL OR EXISTS (SELECT 1 FROM USERS WHERE email = @email)
	    RETURN -1

    IF @name IS NULL
        RETURN -2

    IF @password IS NULL
        RETURN -3

    SET @codUser = NULL
    INSERT INTO USERS (userName, email, password, registerDate)
			VALUES (@name, @email, @password, GETDATE())

    SET @codUser = SCOPE_IDENTITY()
END

/*
GO
DECLARE @codUser INT, @result INT, @userName VARCHAR(50) = 'Pepe', @email VARCHAR(100) = 'testManual1@gmail.com', @password VARCHAR(100) = '1234'
EXEC @result = AddUser @userName, @email, @password, @codUser OUT
*/


-------------------------
GO

CREATE OR ALTER PROCEDURE RemoveUser(@codUser BIGINT)
AS
BEGIN
    IF @codUser <= 0
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
CREATE OR ALTER PROCEDURE UpdateUserPassword(@codUser BIGINT, @password VARCHAR(100))
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
CREATE OR ALTER PROCEDURE GetUserWithId(@codUser BIGINT, @jsonUser VARCHAR(MAX) OUT)
AS
BEGIN
    IF @codUser IS NULL OR @codUser <= 0
        RETURN -1
    SET @jsonUser = NULL
    SELECT @jsonUser = (SELECT * FROM USERS WHERE codUser = @codUser FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER)
END 

GO
--------------------------
GO
CREATE OR ALTER PROCEDURE GetUserWithEmailAndPassword(@email VARCHAR(100), @password VARCHAR(100), @jsonUser VARCHAR(MAX) OUT)
AS
BEGIN
    SET @jsonUser = NULL
    IF @password IS NULL
        RETURN -1
    IF NOT EXISTS(SELECT 1 FROM USERS WHERE email = @email)
        RETURN -2
    SELECT @jsonUser = (SELECT * FROM USERS WHERE email = @email AND [password] = @password FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER)
    IF @jsonUser IS NULL
        RETURN -3
END


GO
--------------------------
GO

CREATE OR ALTER PROCEDURE GetCodUserWithEmail(@email VARCHAR(100), @codUser BIGINT OUT)
AS
BEGIN
    SET @codUser = NULL
    IF @email IS NULL
        RETURN -1
    SELECT @codUser = codUser FROM USERS WHERE email = @email
    IF @codUser IS NULL
        RETURN -2
END


GO
--------------------------
GO


GO
CREATE OR ALTER PROCEDURE AddGame(@codUserWhites BIGINT, @codUserBlacks BIGINT,  @board VARCHAR(MAX), @codGame BIGINT OUT)
AS
BEGIN
    IF @codUserWhites IS NULL OR NOT EXISTS (SELECT 1 FROM USERS WHERE codUser = @codUserWhites)
	    RETURN -1

    IF @codUserBlacks IS NULL OR NOT EXISTS (SELECT 1 FROM USERS WHERE codUser = @codUserBlacks)
        RETURN -2
    
    IF @board IS NULL
        RETURN -3

    SET @codGame = NULL
    INSERT INTO GAMES (codUserWhites, codUserBlacks, board)
			VALUES (@codUserWhites, @codUserBlacks, @board)

    SET @codGame = SCOPE_IDENTITY()
END

GO
DECLARE @result BIGINT, @codGame BIGINT

EXEC @result = AddGame 1, 1, 'Este es mi json', @codGame OUT
IF @result <> 0
BEGIN
    PRINT 'El procedimiento no se ha realizado correctamente'
    RETURN
END
PRINT 'El procedimiento se ha realizado correctamente'

GO
SELECT * FROM GAMES
SELECT * FROM USERS
DELETE FROM GAMES



GO
-------------------------
GO

CREATE OR ALTER PROCEDURE RemoveGame(@codGame BIGINT)
AS
BEGIN
    BEGIN TRY
        IF @codGame <= 0
            RETURN -1

        BEGIN TRAN
            UPDATE GAMES
              SET codUserWhites = NULL, codUserBlacks = NULL
            WHERE codGame = @codGame

            DELETE FROM GAMES
            WHERE codGame = @codGame
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
CREATE OR ALTER PROCEDURE UpdateGameJson(@codGame BIGINT, @board  VARCHAR(MAX))
AS
BEGIN
    IF @codGame <= 0
        RETURN -1

    IF @board IS NULL
        RETURN -2

    UPDATE GAMES
       SET board = @board
   
     WHERE codGame = @codGame

END

-------------

GO
CREATE OR ALTER PROCEDURE GetGameWithId(@codGame BIGINT, @jsonGame VARCHAR(MAX) OUT)
AS
BEGIN
    IF @codGame IS NULL OR @codGame <= 0
        RETURN -1
    SET @jsonGame = NULL
    SELECT @jsonGame = (SELECT * FROM GAMES WHERE codGame = @codGame FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER)
END

GO
--------------
GO


CREATE OR ALTER PROCEDURE GetGamesCountWithCodUser(@codUser BIGINT, @count int OUT)
AS
BEGIN
    IF @codUser <= 0 OR NOT EXISTS(SELECT 1 FROM USERS WHERE codUser = @codUser)
        RETURN -1
    
    SELECT @count = (SELECT COUNT(1) 
                       FROM GAMES 
                      WHERE codUserWhites = @codUser
                        OR  codUserBlacks = @codUser)
END

GO

DECLARE @result INT, @codUser BIGINT = 33, @count INT 
EXEC @result = GetGamesCountWithCodUser @codUser, @count OUT
IF @result <> 0
BEGIN
    PRINT 'El procedimiento no se ha realizado correctamente'
    RETURN
END
PRINT 'El procedimiento se ha realizado correctamente'
PRINT @count



GO
--------------
GO



CREATE OR ALTER PROCEDURE GetGamesWithCodUser(@codUser BIGINT, @offset INT, @max INT, @jsonGames VARCHAR(MAX) OUT)
AS
BEGIN
    IF @codUser IS NULL OR @codUser <= 0
        RETURN -1
    IF @offset IS NULL OR @offset < 0
        RETURN -2
    IF @max IS NULL OR @max <= 0
        RETURN -3
    SET @jsonGames = NULL
    SELECT @jsonGames = (SELECT * 
                           FROM GAMES 
                          WHERE codUserWhites = @codUser 
                             OR codUserBlacks = @codUser
                          ORDER BY codGame
                         OFFSET @offset ROW
                          FETCH NEXT @max ROWS ONLY
                            FOR JSON AUTO)
END



GO
------------
GO

CREATE OR ALTER PROCEDURE GetGames(@offset INT, @max INT, @gamesJson VARCHAR(MAX) OUT)
AS
BEGIN
    IF @offset < 0 OR @max <= 0
        RETURN -1
    SET @gamesJson = NULL

    SELECT @gamesJson = (SELECT *       
                           FROM GAMES
                          ORDER BY codGame
                         OFFSET @offset ROW
                          FETCH NEXT @max ROWS ONLY
                            FOR JSON AUTO)
END

GO
-------------------------
GO
/*
DECLARE @offset INT = 0, @max INT = 30, @gamesJson VARCHAR(MAX), @result INT

EXEC @result = GetGames @offset, @max, @gamesJson OUT
IF @result <> 0
BEGIN
    PRINT 'El procedimiento no se ha realizado correctamente'
    RETURN
END
PRINT 'El procedimiento se ha realizado correctamente'
SELECT @gamesJson
*/

GO
--------------------------

GO

CREATE OR ALTER PROCEDURE UpdateUserName(@codUser BIGINT, @userName VARCHAR(50))
AS
BEGIN
    IF @codUser <= 0 OR NOT EXISTS(SELECT 1 FROM USERS WHERE codUser = @codUser)
        RETURN -1
    IF @userName IS NULL
        RETURN -2
    
    UPDATE USERS
       SET userName = @userName
     WHERE codUser = @codUser
END



INSERT INTO GAMES
SELECT GAMES.codUserWhites, codUserBlacks, board
  FROM GAMES
 WHERE codUserWhites = 36


SELECT * FROM GAMES



GO
DECLARE @codUser BIGINT
SELECT @codUser = codUser FROM USERS where email = 'admin'

SELECT * FROM GAMES WHERE codUserWhites = @codUser

