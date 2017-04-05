CREATE NONCLUSTERED INDEX IndexName ON dbo.BatchDetail( Col1, Col2 )

DROP INDEX IndexName ON dbo.TableName 

-- Rebuild All Indexes
EXEC sp_MSforeachtable @command1="print '?' DBCC DBREINDEX ('?', ' ', 80)"  
GO  
EXEC sp_updatestats  
GO