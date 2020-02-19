If not exists(
	select * from INFORMATION_SCHEMA.TABLES
	where TABLE_NAME = N'Categories')
Begin
	Create Table Categories(
		CategoryId int primary key identity,
		CategoryName nvarchar(50) not null
	)
End