CREATE PROCEDURE dbo.User_EditUserMail
	@mail nvarchar(255),
	@newMail nvarchar(255)
as
BEGIN
	SET	NOCOUNT OFF;
	update dbo.User_
	set Mail = @newMail where Mail = @mail
END