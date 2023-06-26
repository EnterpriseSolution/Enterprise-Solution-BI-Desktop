using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseSolutionBIDesktop
{
    public class Command
    {
        public static string Default_Client = System.Configuration.ConfigurationManager.AppSettings["Client"];
        public static string TableOwner = System.Configuration.ConfigurationManager.AppSettings["TableOwner"];

        

        public const string QUERY_DATABASE_SIZE = @"
                            SELECT 
                             t.NAME AS [Table Name],                             
                             SUM(p.rows) AS [Row Counts],
                             SUM(a.total_pages) AS [Total Pages], 
                             SUM(a.used_pages) AS [Used Pages], 
                             SUM(a.data_pages) AS [Data Pages],
                             (SUM(a.total_pages) * 8) / 1024 AS [Total Space(MB)], 
                             (SUM(a.used_pages) * 8) / 1024 AS [Used Space(MB)], 
                             (SUM(a.data_pages) * 8) / 1024 AS [Data Space(MB)]
                            FROM 
                             sys.tables t
                            INNER JOIN  
                             sys.indexes i ON t.OBJECT_ID = i.object_id
                            INNER JOIN 
                             sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
                            INNER JOIN 
                             sys.allocation_units a ON p.partition_id = a.container_id
                            WHERE 
                             t.NAME NOT LIKE 'dt%' AND
                             i.OBJECT_ID > 255 AND  
                             i.index_id <= 1
                            GROUP BY 
                             t.NAME, i.object_id, i.index_id, i.name 
                            ORDER BY 
                             OBJECT_NAME(i.object_id) ";
             
        public const string ALL_DATABASES = "SELECT * FROM  sys.databases WHERE database_id>4";
        public static string ALL_ROWS = "SELECT *  FROM  {0}   ";

        public const string ALL_PK = @" SELECT 
                           tc.TABLE_NAME, ccu.COLUMN_NAME
                        FROM
                            INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
                            JOIN
                            INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu
                                ON tc.CONSTRAINT_NAME = ccu.Constraint_name
                        WHERE
                            tc.TABLE_NAME = '{0}'   ";

        public const string ALL_PK_CACHE = @" SELECT 
                           tc.TABLE_NAME, ccu.COLUMN_NAME
                        FROM
                            INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
                            JOIN
                            INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu
                                ON tc.CONSTRAINT_NAME = ccu.Constraint_name    ";
    }
}
