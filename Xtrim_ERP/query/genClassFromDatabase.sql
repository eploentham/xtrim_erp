set @schema := 'tulip_export';
set @table := 'airline';
SET group_concat_max_len = 2048;
SELECT 
    concat('public class ', @table, '\n{\n', GROUP_CONCAT(a.property_ SEPARATOR '\n'), '\n}') class_
FROM 
    (select
        CONCAT(
        '\tpublic ',
        case 
            when DATA_TYPE = 'bigint' then 'long'
            when DATA_TYPE = 'BINARY' then 'byte[]'
            when DATA_TYPE = 'bit' then 'bool'
            when DATA_TYPE = 'char' then 'String'
            when DATA_TYPE = 'date' then 'DateTime'
            when DATA_TYPE = 'datetime' then 'DateTime'
            when DATA_TYPE = 'datetime2' then 'DateTime'
            when DATA_TYPE = 'datetimeoffset' then 'DateTimeOffset'
            when DATA_TYPE = 'decimal' then 'decimal'
            when DATA_TYPE = 'double' then 'double'
            when DATA_TYPE = 'float' then 'float'
            when DATA_TYPE = 'image' then 'byte[]'
            when DATA_TYPE = 'int' then 'int'
            when DATA_TYPE = 'money' then 'decimal'
            when DATA_TYPE = 'nchar' then 'char'
            when DATA_TYPE = 'ntext' then 'string'
            when DATA_TYPE = 'numeric' then 'decimal'
            when DATA_TYPE = 'nvarchar' then 'string'
            when DATA_TYPE = 'real' then 'double'
            when DATA_TYPE = 'smalldatetime' then 'DateTime'
            when DATA_TYPE = 'smallint' then 'short'
            when DATA_TYPE = 'smallmoney' then 'decimal'
            when DATA_TYPE = 'text' then 'string'
            when DATA_TYPE = 'time' then 'TimeSpan'
            when DATA_TYPE = 'timestamp' then 'DateTime'
            when DATA_TYPE = 'tinyint' then 'bool'
            when DATA_TYPE = 'uniqueidentifier' then 'Guid'
            when DATA_TYPE = 'varbinary' then 'byte[]'
            when DATA_TYPE = 'varchar' then 'string'
            WHEN DATA_TYPE = 'longtext' THEN 'string'
            else '_UNKNOWN_'
        end, ' ', 
        COLUMN_NAME, ' {get; set;}') as property_
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE table_name = @table AND table_schema = @schema) a
;