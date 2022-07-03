use Reviews
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Reviews_AddReview
	@Shop_name nvarchar(255),
	@Text nvarchar(255),
	@CreationDate datetime
as
BEGIN
	SET	NOCOUNT OFF;
	INSERT INTO dbo.Reviews(Shop_name, Text, CreationDate)
	VALUES(@Shop_name, @Text, @CreationDate)
END