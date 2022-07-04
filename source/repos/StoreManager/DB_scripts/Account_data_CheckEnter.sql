use Reviews
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Account_data_CheckEnter
	@log nvarchar(255),
	@pas nvarchar(255),
	@role nvarchar(255) output
as
BEGIN

	--declare @role nvarchar(255) output

	declare @Login nvarchar(20)
	declare @Pass nvarchar(20)
	set @Login = (select Login from Account_data where Login = @log)
	set @Pass = (select Password from Account_data where Login = @Login)
	if (@Pass = @pas)
	set @role= (select Role from Account_data where Password = @Pass)
	select @role

	--else return 0


END

DROP procedure dbo.Account_data_CheckEnter
go