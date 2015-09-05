select studentName from students as res 
left join groups on res.groupId = groups.groupId
where chairId = (select chairId from chairs where chairs.chairName = 'бро');