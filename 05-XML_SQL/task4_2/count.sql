select count(*) from students 
where groupId = (select groupId from groups where groupName = '20á'); 