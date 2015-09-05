insert into students (studentName, groupId)
values('Костоломов', 
(select groupId from groups where groupName = '30' and chairId = (select chairId from chairs where chairName = 'ИС')))