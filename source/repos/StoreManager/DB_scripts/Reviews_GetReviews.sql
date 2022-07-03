use Reviews
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Reviews_GetReviews
as
BEGIN
	SET	NOCOUNT OFF;
	SELECT Id, Shop_name, Text, CreationDate FROM Reviews ORDER BY Shop_name
END