If not exists(
	select * from INFORMATION_SCHEMA.TABLES
	where TABLE_NAME = N'Users')
Begin
	Create Table Users(
		UserId uniqueidentifier primary key,
		UserName nvarchar(50) not null
	)
End