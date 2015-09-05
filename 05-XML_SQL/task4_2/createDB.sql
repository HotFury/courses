create table task4.dbo.faculties (
	[faculcyId] int primary key identity(1,1) not null,
	[faculcyName] nvarchar(50) not null)
create table task4.dbo.chairs(
	[chairId] int primary key identity (1,1) not null,
	[chairName] nvarchar(50) not null,
	[faculcyId] int not null,
	foreign key ([faculcyId]) references [faculties](faculcyId) ON DELETE CASCADE ON UPDATE CASCADE)
create table task4.dbo.groups(
	[groupId] int primary key identity (1,1) not null,
	[groupName] nvarchar(20) not null,
	[chairId] int not null,
	foreign key ([chairId]) references [chairs](chairId) ON DELETE CASCADE ON UPDATE CASCADE)
create table task4.dbo.students (
	[studentId] int primary key identity (1,1) not null,
	[studentName] nvarchar(50) not null,
	[groupId] int not null,
	foreign key ([groupId]) references [groups](groupId) ON DELETE CASCADE ON UPDATE CASCADE)
	

	
