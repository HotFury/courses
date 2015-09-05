update students set groupId = 
(select groupId from groups where groupName = '10а' and chairId = (select chairId from chairs where chairName = 'ВТП')) 
where studentName = 'Иванов'