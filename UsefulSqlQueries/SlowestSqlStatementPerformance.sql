-- Returns top 10 slowest performing SQL statemetns with execution count as well as last executed time.
SELECT TOP 10
        source_code ,
        stats.total_elapsed_time / 1000000 AS seconds ,
		stats.execution_count,
        last_execution_time
FROM    sys.dm_exec_query_stats AS stats
        CROSS APPLY ( SELECT    text AS source_code
                        FROM      sys.dm_exec_sql_text(sql_handle)
                    ) AS query_text
WHERE stats.total_elapsed_time > 25000000
ORDER BY total_elapsed_time DESC