-- Make sure you are selected on the correct database
-- Returns top 10 slowest performing slowed procedures with execution count as well as last executed time.
SELECT TOP ( 10 )
        p.name AS [SP Name] ,
        CONVERT(DECIMAL(5,3), ((qs.total_elapsed_time / CONVERT(DECIMAL(38, 0), qs.execution_count)) / 1000000)) AS [avg_elapsed_time_seconds] ,
        qs.execution_count ,
        ISNULL(qs.execution_count / DATEDIFF(Second, qs.cached_time, GETDATE()),
               0) AS [Calls/Second] ,
        qs.total_worker_time / qs.execution_count AS [AvgWorkerTime] ,
        qs.total_worker_time AS [TotalWorkerTime] ,
             qs.last_execution_time,
        qs.cached_time
FROM    sys.procedures AS p WITH ( NOLOCK )
        INNER JOIN sys.dm_exec_procedure_stats AS qs WITH ( NOLOCK ) ON p.[object_id] = qs.[object_id]
WHERE   qs.database_id = DB_ID()
        AND qs.total_elapsed_time > 25000000
ORDER BY avg_elapsed_time_seconds DESC
OPTION  ( RECOMPILE );
