if not exists(
	select * from  INFORMATION_SCHEMA.TABLES 
	where TABLE_NAME = 'CategoryGroups')
begin
	create table CategoryGroups(
	CategoryGroupId int primary key identity,
	CategoryGroupName nvarchar(50) not null,
	CategoryId int not null
	)
end