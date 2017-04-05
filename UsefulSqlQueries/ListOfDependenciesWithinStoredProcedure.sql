;WITH stored_procedures AS ( 
SELECT  
oo.name AS table_name,  
ROW_NUMBER() OVER(partition by o.name,oo.name ORDER BY o.name,oo.name) AS row  
FROM sysdepends d  
INNER JOIN sysobjects o ON o.id=d.id  
INNER JOIN sysobjects oo ON oo.id=d.depid  
WHERE o.xtype = 'P' AND o.name LIKE '%SP_Name%' )  
SELECT Table_name AS 'Table Name' FROM stored_procedures  
WHERE row = 1