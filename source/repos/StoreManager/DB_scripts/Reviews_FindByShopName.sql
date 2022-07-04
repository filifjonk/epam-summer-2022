SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Reviews_FindByShopName
	@name varchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * from dbo.Reviews where Shop_name like @name+'%'
END
GO