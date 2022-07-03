use Reviews
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Reviews_EditReview
	@Id int,
	@Change nvarchar(255)
as
BEGIN
	SET	NOCOUNT OFF;
	update dbo.Reviews
	set Text = @Change where id = @Id
END