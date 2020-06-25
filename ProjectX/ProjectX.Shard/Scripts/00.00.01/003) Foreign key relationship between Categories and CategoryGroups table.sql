If not exists(
	select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS
	where CONSTRAINT_NAME = N'FK_CategoryGroups_Categories')
Begin
	Alter table CategoryGroups with check add constraint FK_CategoryGroups_Categories
	foreign key (CategoryId) references Categories(CategoryId)
End