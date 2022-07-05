use Reviews
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.User_EditUserName
	@mail nvarchar(255),
	@newName nvarchar(255)
as
BEGIN
	SET	NOCOUNT OFF;
	update dbo.User_
	set Name = @newName where Mail = @mail
END