USE JARDINERIA
SELECT * FROM EMPLEADOS

DECLARE @index INT = 3
SELECT *
FROM EMPLEADOS
ORDER BY (SELECT NULL) -- Use ORDER BY (SELECT NULL) to avoid sorting if no specific order is needed
OFFSET @index - 1 ROWS      -- -1 so it starts counting index and doesn't jump it
FETCH NEXT 3 ROWS ONLY;





USE STUDENTS


CREATE TABLE STUDENTS (
    studentId      INT IDENTITY,
    name           VARCHAR(100) NOT NULL,
    age            TINYINT,
    description    VARCHAR(200)


    CONSTRAINT PK_STUDENTS PRIMARY KEY (studentId)
)

--------------------------
GO

CREATE OR ALTER PROCEDURE AddStudents(@name VARCHAR(100), @age TINYINT, @description VARCHAR(200), @id INT OUT)
AS
BEGIN
    IF @name IS NULL OR @description IS NULL
    BEGIN
		PRINT 'Faltan parámetros obligatorios.'
	    RETURN -1
	END

    SET @id = NULL
    INSERT INTO STUDENTS (name, age, description)
			VALUES (@name, @age, @description)

    SET @id = SCOPE_IDENTITY()
END

-------------------------
GO

CREATE OR ALTER PROCEDURE GetStudentWithIndex(@index INT, @name VARCHAR(100) OUT, @age TINYINT OUT, @description VARCHAR(200) OUT)
AS
BEGIN
    IF @index IS NULL
    BEGIN
        RETURN -1
    END

    SELECT @name = name,
           @age = age,
           @description = description
      FROM STUDENTS
     WHERE ROW_NUMBER() - 1 = @index            -- ROW_NUMBER() starts at 1
     ORDER BY studentId 

END

