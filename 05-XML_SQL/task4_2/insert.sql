insert into students (studentName, groupId)
values('����������', 
(select groupId from groups where groupName = '30' and chairId = (select chairId from chairs where chairName = '��')))