delete from students where studentId = 
(select id from 
(select studentId as id from students where studentName = 'Сидоров') as res);