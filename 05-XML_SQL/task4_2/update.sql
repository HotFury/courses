update students set groupId = 
(select groupId from groups where groupName = '10�' and chairId = (select chairId from chairs where chairName = '���')) 
where studentName = '������'