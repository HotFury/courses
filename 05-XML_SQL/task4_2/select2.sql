select studentName, groupName, chairName from students 
left join groups on students.groupId = groups.groupId
left join chairs on chairs.chairId = groups.chairId