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

CREATE OR ALTER PROCEDURE AddUser(@email VARCHAR(100), @password VARCHAR(100),  @id INT OUT)
AS
BEGIN
    IF @email IS NULL OR EXISTS (SELECT 1 FROM USERS WHERE email = @email)
	    RETURN -1

    IF @password IS NULL
        RETURN -2

    SET @id = NULL
    INSERT INTO USERS (email, password)
			VALUES (@email, @password)

    SET @id = SCOPE_IDENTITY()
END

-------------------------
GO

CREATE OR ALTER PROCEDURE RemoveUser(@id INT)
AS
BEGIN
    IF @id <= 0
    RETURN -1

    BEGIN TRY
        BEGIN TRANSACTION

            UPDATE GAMES
               SET codUserWhites = NULL
             WHERE codUserWhites = @id

            UPDATE GAMES
              SET codUserBlacks = NULL
            WHERE codUserBlacks = @id

            DELETE FROM USERS
             WHERE codUser = @id
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
CREATE OR ALTER PROCEDURE UpdateUserPassword(@id INT, @password VARCHAR(100))
AS
BEGIN
    IF @id <= 0
        RETURN -1

    UPDATE USERS
    SET password = @password
    WHERE codUser = @id
END

GO
CREATE OR ALTER FUNCTION GetUserWithId(@id INT)
RETURNS JSON
AS
BEGIN
    IF @id <= 0
        RETURN NULL
    RETURN (SELECT * FROM USERS WHERE codUser = @id FOR JSON AUTO)
END

GO