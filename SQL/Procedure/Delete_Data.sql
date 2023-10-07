
create Procedure [dbo].[Delete_Data]
(
@id int
)
AS
BEGIN
Delete From Product
where id=@id
END