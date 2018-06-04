ALTER TABLE f_check_exam AUTO_INCREMENT = 1420000000;
ALTER TABLE f_importer_type AUTO_INCREMENT = 1410000000;
ALTER TABLE b_position AUTO_INCREMENT = 1400000000;
ALTER TABLE b_customer_remark AUTO_INCREMENT = 1390000000;
ALTER TABLE b_customer_tax_invoice AUTO_INCREMENT = 1380000000;
ALTER TABLE b_address_type AUTO_INCREMENT = 1370000000;

ALTER TABLE b_pre_fix AUTO_INCREMENT = 1200000000;

INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('ไม่ต้อง', 'ORIGIANL', '1', 'BL_TYPE');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('ต้อง', 'TELEX RELEASE', '1', 'BL_TYPE');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('ต้อง', 'SURRENDER B/L', '1', 'BL_TYPE');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('ต้อง', 'EXPRESS B/L', '1', 'BL_TYPE');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('ต้อง', 'SEA WAYBILL', '1', 'BL_TYPE');


18-06-03
ALTER TABLE `xtrim_erp`.`b_port_of_loading` 
ADD COLUMN `cntrycode` VARCHAR(255) NULL AFTER `sort1`;

ALTER TABLE `xtrim_erp`.`t_job_import` 
CHANGE COLUMN `remark` `remark3` VARCHAR(2000) NULL DEFAULT NULL ,
ADD COLUMN `remark4` VARCHAR(255) NULL AFTER `imp_date`,
ADD COLUMN `remark5` VARCHAR(255) NULL AFTER `remark4`,
ADD COLUMN `remark6` VARCHAR(255) NULL AFTER `remark5`,
ADD COLUMN `marsk1` VARCHAR(255) NULL AFTER `remark6`,
ADD COLUMN `marsk2` VARCHAR(255) NULL AFTER `marsk1`,
ADD COLUMN `marsk3` VARCHAR(255) NULL AFTER `marsk2`,
ADD COLUMN `marsk4` VARCHAR(255) NULL AFTER `marsk3`,
ADD COLUMN `marsk5` VARCHAR(255) NULL AFTER `marsk4`,
ADD COLUMN `marsk6` VARCHAR(255) NULL AFTER `marsk5`;

ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
CHANGE COLUMN `total_packages` `packages_total` VARCHAR(255) NULL DEFAULT NULL COMMENT 'nopkg' ,
CHANGE COLUMN `unit_package_id` `unit_package1_id` INT(11) NULL DEFAULT NULL COMMENT 'pkgunit' ,
ADD COLUMN `packages1` VARCHAR(255) NULL AFTER `bl`,
ADD COLUMN `packages2` VARCHAR(255) NULL AFTER `packages1`,
ADD COLUMN `packages3` VARCHAR(255) NULL AFTER `packages2`,
ADD COLUMN `packages4` VARCHAR(255) NULL AFTER `packages3`,
ADD COLUMN `packages5` VARCHAR(255) NULL AFTER `packages4`,
ADD COLUMN `unit_package2_id` INT NULL AFTER `packages5`,
ADD COLUMN `unit_package3_id` INT NULL AFTER `unit_package2_id`,
ADD COLUMN `unit_package4_id` INT NULL AFTER `unit_package3_id`,
ADD COLUMN `unit_package5_id` INT NULL AFTER `unit_package4_id`;

ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
CHANGE COLUMN `gw_total` `gw_total1` VARCHAR(255) NULL DEFAULT NULL ;

ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
ADD COLUMN `container1` VARCHAR(255) NULL AFTER `gw_total`,
ADD COLUMN `container2` VARCHAR(255) NULL AFTER `container1`,
ADD COLUMN `container3` VARCHAR(255) NULL AFTER `container2`,
ADD COLUMN `container4` VARCHAR(255) NULL AFTER `container3`,
ADD COLUMN `container5` VARCHAR(255) NULL AFTER `container4`,
ADD COLUMN `container6` VARCHAR(255) NULL AFTER `container5`,
ADD COLUMN `container1_doc_type_id` VARCHAR(255) NULL AFTER `container6`,
ADD COLUMN `container2_doc_type_id` VARCHAR(255) NULL AFTER `container1_doc_type_id`,
ADD COLUMN `container3_doc_type_id` VARCHAR(255) NULL AFTER `container2_doc_type_id`,
ADD COLUMN `container4_doc_type_id` VARCHAR(255) NULL AFTER `container3_doc_type_id`,
ADD COLUMN `container5_doc_type_id` VARCHAR(255) NULL AFTER `container4_doc_type_id`,
ADD COLUMN `container6_doc_type_id` VARCHAR(255) NULL AFTER `container5_doc_type_id`;

ALTER TABLE `xtrim_erp`.`t_job_import` 
ADD COLUMN `bl` VARCHAR(255) NULL AFTER `marsk6`;

61-06-04
ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
ADD COLUMN `bl_type` VARCHAR(255) NULL AFTER `container6_doc_type_id`,
ADD COLUMN `consignmnt_id` INT NULL AFTER `bl_type`;

ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
CHANGE COLUMN `consignmnt_id` `consignmnt_id` INT(11) NULL DEFAULT NULL COMMENT 'country code' ;

ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
ADD COLUMN `unit_volume1_id` INT NULL AFTER `consignmnt_id`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `GenCSharpModel1`(in pTableName VARCHAR(255) )
BEGIN
DECLARE vClassName varchar(255);
declare vClassCode mediumtext;
declare v_codeChunk varchar(1024);
DECLARE v_finished INTEGER DEFAULT 0;
DEClARE code_cursor CURSOR FOR
    SELECT code FROM temp1; 

DECLARE CONTINUE HANDLER 
        FOR NOT FOUND SET v_finished = 1;

set vClassCode ='';
/* Make class name*/
    SELECT (CASE WHEN col1 = col2 THEN col1 ELSE concat(col1,col2)  END) into vClassName
    FROM(
    SELECT CONCAT(UCASE(MID(ColumnName1,1,1)),LCASE(MID(ColumnName1,2))) as col1,
    CONCAT(UCASE(MID(ColumnName2,1,1)),LCASE(MID(ColumnName2,2))) as col2
    FROM
    (SELECT SUBSTRING_INDEX(pTableName, '_', -1) as ColumnName2,
        SUBSTRING_INDEX(pTableName, '_', 1) as ColumnName1) A) B;

    /*store all properties into temp table*/
    CREATE TEMPORARY TABLE IF NOT EXISTS  temp1 ENGINE=MyISAM  
    as (
    select concat( 'public ', ColumnType , ' ' , FieldName,' { get; set; }') code
    FROM(
    SELECT (CASE WHEN col1 = col2 THEN col1 ELSE concat(col1,col2)  END) AS FieldName, 
    case DATA_TYPE 
            when 'bigint' then 'long'
            when 'binary' then 'byte[]'
            when 'bit' then 'bool'
            when 'char' then 'String'
            when 'date' then 'DateTime'
            when 'datetime' then 'DateTime'
            when 'datetime2' then 'DateTime'
            when 'datetimeoffset' then 'DateTimeOffset'
            when 'decimal' then 'Decimal'
            when 'double' then 'Double'
            when 'float' then 'float'
            when 'image' then 'byte[]'
            when 'int' then 'int'
            when 'money' then 'Decimal'
            when 'nchar' then 'char'
            when 'ntext' then 'String'
            when 'numeric' then 'Decimal'
            when 'nvarchar' then 'String'
            when 'real' then 'Double'
            when 'smalldatetime' then 'DateTime'
            when 'smallint' then 'short'
            when 'mediumint' then 'INT'
            when 'smallmoney' then 'Decimal'
            when 'text' then 'String'
            when 'time' then 'TimeSpan'
            when 'timestamp' then 'DateTime'
            when 'tinyint' then 'byte'
            when 'uniqueidentifier' then 'Guid'
            when 'varbinary' then 'byte[]'
            when 'varchar' then 'String'
            when 'year' THEN 'UINT'
            else 'UNKNOWN_' + DATA_TYPE
        end ColumnType
    FROM(
    select COLUMN_NAME as col1,    COLUMN_NAME as col2, DATA_TYPE, COLUMN_TYPE
     FROM INFORMATION_SCHEMA.COLUMNS  WHERE table_name = pTableName) B)C);

    set vClassCode = '';
    /* concat all properties*/
    OPEN code_cursor;

            get_code: LOOP

                FETCH code_cursor INTO v_codeChunk;

                IF v_finished = 1 THEN
                    LEAVE get_code;
                END IF;

                -- build code
                select  CONCAT(vClassCode,'\r\n', v_codeChunk) into  vClassCode ;

            END LOOP get_code;

        CLOSE code_cursor;

drop table temp1;
/*make class*/
select concat('public class ',vClassName,'\r\n{', vClassCode,'\r\n}');
END