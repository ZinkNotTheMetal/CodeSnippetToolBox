SELECT DISTINCT syso.name AS 'Stored Procedure Name'
FROM syscomments sysc
INNER JOIN sysobjects syso ON sysc.id = syso.id  
WHERE sysc.TEXT LIKE '%ImageCapture%' AND syso.xtype='P'