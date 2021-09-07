CREATE TABLE [dbo].[tTodo]
(
	[fId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [fTitle] NVARCHAR(50) NULL, 
    [fLevel] NVARCHAR(50) NULL, 
    [fDate] DATE NULL
)