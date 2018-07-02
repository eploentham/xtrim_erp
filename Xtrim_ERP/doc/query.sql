ALTER TABLE f_check_exam AUTO_INCREMENT = 1420000000;
ALTER TABLE f_importer_type AUTO_INCREMENT = 1410000000;
ALTER TABLE b_position AUTO_INCREMENT = 1400000000;
ALTER TABLE b_customer_remark AUTO_INCREMENT = 1390000000;
ALTER TABLE b_customer_tax_invoice AUTO_INCREMENT = 1380000000;
ALTER TABLE b_address_type AUTO_INCREMENT = 1370000000;

ALTER TABLE b_pre_fix AUTO_INCREMENT = 1200000000;
ALTER TABLE t_expenses_draw AUTO_INCREMENT = 1520000000;
ALTER TABLE t_expenses_draw_detail AUTO_INCREMENT = 1530000000;
ALTER TABLE b_expenses_cat AUTO_INCREMENT = 1470000000;
ALTER TABLE b_expenses_draw_type AUTO_INCREMENT = 1510000000;
ALTER TABLE b_expenses_grp AUTO_INCREMENT = 1490000000;
ALTER TABLE b_expenses_type AUTO_INCREMENT = 1480000000;
ALTER TABLE f_item_group AUTO_INCREMENT = 1540000000;
ALTER TABLE items_subtype AUTO_INCREMENT = 1550000000;
ALTER TABLE f_method_payment AUTO_INCREMENT = 1560000000;
ALTER TABLE b_bank_book AUTO_INCREMENT = 1570000000;
ALTER TABLE t_reserve_pay AUTO_INCREMENT = 1580000000;
ALTER TABLE t_expenses_pay AUTO_INCREMENT = 1590000000;
ALTER TABLE t_expenses_pay_detail AUTO_INCREMENT = 1600000000;



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

61-06-05
UPDATE `xtrim_erp`.`b_inco_terms` SET `inco_terms_name_t`='DDP' WHERE `inco_terms_id`='56';
UPDATE `xtrim_erp`.`b_inco_terms` SET `inco_terms_name_t`='DDU' WHERE `inco_terms_id`='57';
UPDATE `xtrim_erp`.`b_inco_terms` SET `inco_terms_name_t`='EX-WORK' WHERE `inco_terms_id`='58';
UPDATE `xtrim_erp`.`b_inco_terms` SET `inco_terms_name_t`='FCA' WHERE `inco_terms_id`='59';
UPDATE `xtrim_erp`.`b_inco_terms` SET `inco_terms_name_t`='FOB' WHERE `inco_terms_id`='60';


61-06-06
ALTER TABLE `xtrim_erp`.`b_customer` 
ADD COLUMN `insr_id` INT NULL AFTER `web_site3`;

# doc_type_id, doc_type_code, doc_type_name, active, status_combo
1430000019, ไม่ต้อง, ORIGIANL, 1, BL_TYPE
1430000020, ต้อง, TELEX RELEASE, 1, BL_TYPE
1430000021, ต้อง, SURRENDER B/L, 1, BL_TYPE
1430000022, ต้อง, EXPRESS B/L, 1, BL_TYPE
1430000023, ต้อง, SEA WAYBILL, 1, BL_TYPE

ALTER TABLE `xtrim_erp`.`t_job_import_inv` 
ADD COLUMN `insr_id` INT NULL AFTER `active`;

ALTER TABLE `xtrim_erp`.`b_contact` 
ADD COLUMN `status_insr_email` VARCHAR(255) NULL AFTER `table_id`;
update b_contact
set status_insr_email = '0'


61-06-07
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('1', 'ORIGINAL', '1', 'type_of_bl');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('2', 'TELEX RELEASE', '1', 'type_of_bl');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('3', 'SURRENDER B/L', '1', 'type_of_bl');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('4', 'EXPRESS B/L', '1', 'type_of_bl');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('5', 'SEA WAYBILL', '1', 'type_of_bl');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('1', 'FORM D', '1', 'check_list_4_1');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('2', 'FORM E', '1', 'check_list_4_1');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('3', 'FORM AK', '1', 'check_list_4_1');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('4', 'FOMR JTAPA', '1', 'check_list_4_1');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('1', 'BOI', '1', 'check_list_4_2');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('1', 'สมอ', '1', 'check_list_5');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('2', 'อย', '1', 'check_list_5');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('3', 'วัตถุมีพิษ', '1', 'check_list_5');
INSERT INTO `xtrim_erp`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('4', 'กรมวิชาการเกษตร', '1', 'check_list_5');


CREATE TABLE `xtrim_erp`.`t_job_import_check_list` (
  `import_check_list_id` INT NOT NULL AUTO_INCREMENT,
  `job_import_id` INT NULL,
  `status_original` VARCHAR(255) NULL COMMENT 'INVOICE+PACKING LIST',
  `check_list_date` VARCHAR(255) NULL COMMENT 'INVOICE+PACKING LIST',
  `type_of_bl` INT NULL COMMENT 'Type of BL',
  `email_do` VARCHAR(255) NULL COMMENT 'จดหมายแลก DO',
  `privi1_id` INT NULL COMMENT 'เอกสารสิทธิประโยชน์',
  `privi2_id` INT NULL COMMENT 'เอกสารสิทธิประโยชน์',
  `privi1_date` VARCHAR(255) NULL COMMENT 'เอกสารสิทธิประโยชน์',
  `privi2_date` VARCHAR(255) NULL COMMENT 'เอกสารสิทธิประโยชน์',
  `privi1_desc` VARCHAR(255) NULL COMMENT 'เอกสารสิทธิประโยชน์',
  `privi2_desc` VARCHAR(255) NULL COMMENT 'เอกสารสิทธิประโยชน์',
  `doc_authen1_id` INT NULL COMMENT 'ใบอนุญาติ',
  `doc_authen2_id` INT NULL COMMENT 'ใบอนุญาติ',
  `doc_authen3_id` INT NULL COMMENT 'ใบอนุญาติ',
  `doc_authen1_date` VARCHAR(255) NULL COMMENT 'ใบอนุญาติ',
  `doc_authen2_date` VARCHAR(255) NULL COMMENT 'ใบอนุญาติ',
  `doc_authen3_date` VARCHAR(255) NULL COMMENT 'ใบอนุญาติ',
  `enter_bl` VARCHAR(255) NULL COMMENT 'Enter BL',
  `insurance_atten` VARCHAR(255) CHARACTER SET 'ascii' NULL COMMENT 'แจ้งประกัน',
  `email_do1` VARCHAR(255) NULL COMMENT 'รับจดหมายแลก DO',
  `email_do1_date` VARCHAR(255) NULL COMMENT 'รับจดหมายแลก DO',
  `do_date_send` VARCHAR(255) NULL COMMENT 'วันแลกDO/วันรับกลับ',
  `date_date_receive` VARCHAR(255) NULL COMMENT 'วันแลกDO/วันรับกลับ',
  `date_tax_send` VARCHAR(255) NULL COMMENT 'วันแจ้งยอดภาษี/รับPRQ',
  `date_tax_receive` VARCHAR(255) NULL COMMENT 'วันแจ้งยอดภาษี/รับPRQ',
  `exp1_date_send` VARCHAR(255) NULL COMMENT 'ค่าใช้จ่ายแลก D/O สายเรือ/รับ PRQ',
  `exp1_date_receive` VARCHAR(255) NULL COMMENT 'ค่าใช้จ่ายแลก D/O สายเรือ/รับ PRQ',
  `exp2_date_send` VARCHAR(255) NULL COMMENT 'ค่าใช้จ่ายค่าภาระท่าเรือ/รับ PRQ',
  `exp2_date_receive` VARCHAR(255) NULL COMMENT 'ค่าใช้จ่ายค่าภาระท่าเรือ/รับ PRQ',
  `receipt_date` VARCHAR(255) NULL COMMENT 'ส่งใบเสร็จ / รับสำเนาเซ็นต์รับกลับ',
  `receipt_copy_date` VARCHAR(255) NULL COMMENT 'ส่งใบเสร็จ / รับสำเนาเซ็นต์รับกลับ',
  `accept_tender` VARCHAR(255) NULL COMMENT 'ACCPET TENDER',
  `advance_billing` VARCHAR(255) NULL COMMENT 'ADVANCE BILLING',
  `approve_date` VARCHAR(255) NULL COMMENT 'APPROVE',
  `parent1` VARCHAR(255) NULL COMMENT 'PARENT',
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  PRIMARY KEY (`import_check_list_id`))
ENGINE = MyISAM
COMMENT = 'id=142';

CREATE TABLE `xtrim_erp`.`t_job_import_check_exam` (
  `job_import_check_exam_id` INT NOT NULL AUTO_INCREMENT,
  `job_import_id` INT NULL,
  `status_open_goods` VARCHAR(255) NULL COMMENT 'เปิดสินค้าตรวจ\n0=default; 1=ไม่ได้เปิด; 2=เปิดตรวจ',
  `qty_open_goods` VARCHAR(255) NULL COMMENT 'จำนวนที่เปิดตรวจ',
  `number_open_goods` VARCHAR(255) NULL COMMENT 'เลขหมายหีบห่อที่เปิดตรวจ',
  `status_layout_goods` VARCHAR(255) NULL COMMENT 'สภาพหีบห่อสินค้า\n0=default;1=ดี; 2=ไม่ดี',
  `qty_bad_goods` VARCHAR(255) NULL COMMENT 'จำนวนหีบห่อที่ไม่ดี',
  `number_bad_goods` VARCHAR(255) NULL COMMENT 'เลขหมายหีบห่อที่ไม่ดี',
  `bad_goods_desc` VARCHAR(255) NULL COMMENT 'บรรบาย',
  `attend_corrupt` VARCHAR(255) NULL COMMENT 'แจ้งความเสียหายกับใคร',
  `status_corrupt_goods` VARCHAR(255) NULL COMMENT 'สรุปสินค้าเสียหรือไม\n0=default;1=ไม่;2=เสียหาย',
  `dmc_no` VARCHAR(255) NULL COMMENT 'SURVEYOR / DMC NO.',
  `date_dmc` VARCHAR(255) NULL COMMENT 'วันส่ง SURVEYOR  ให้ลูกค้า',
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  `sort1` VARCHAR(255) NULL,
  PRIMARY KEY (`job_import_check_exam_id`))
ENGINE = MyISAM
COMMENT = 'id=143';

CREATE TABLE `xtrim_erp`.`t_job_import_image` (
  `job_import_image_id` INT NOT NULL AUTO_INCREMENT,
  `job_import_id` INT NULL,
  `path_pic` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `status_pic` VARCHAR(255) NULL,
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  `sort1` VARCHAR(255) NULL,
  PRIMARY KEY (`job_import_image_id`))
ENGINE = MyISAM
COMMENT = 'id=144';

ALTER TABLE `xtrim_erp`.`t_job_import_check_exam` 

COMMENT = 'id=143\nบันทึกข้อมูกตรวจปล่อย' ;


61-06-09
ALTER TABLE `xtrim_erp`.`t_job_import_check_list` 
CHANGE COLUMN `date_date_receive` `do_date_receive` VARCHAR(255) NULL DEFAULT NULL COMMENT 'วันแลกDO/วันรับกลับ' ,
CHANGE COLUMN `date_tax_send` `tax_date_send` VARCHAR(255) NULL DEFAULT NULL COMMENT 'วันแจ้งยอดภาษี/รับPRQ' ;

ALTER TABLE `xtrim_erp`.`t_job_import_check_list` 
CHANGE COLUMN `date_tax_receive` `tax_date_receive` VARCHAR(255) NULL DEFAULT NULL COMMENT 'วันแจ้งยอดภาษี/รับPRQ' ;

ALTER TABLE `xtrim_erp`.`t_job_import_inv` 
ADD COLUMN `status_send_email` VARCHAR(255) NULL AFTER `insr_id`,
ADD COLUMN `send_email_staff_id` INT NULL AFTER `status_send_email`,
ADD COLUMN `send_email_date` VARCHAR(255) NULL AFTER `send_email_staff_id`;

ALTER TABLE `xtrim_erp`.`t_job_import_check_exam` 
CHANGE COLUMN `date_dmc` `dmc_date` VARCHAR(255) NULL DEFAULT NULL COMMENT 'วันส่ง SURVEYOR  ให้ลูกค้า' ;

ALTER TABLE `xtrim_erp`.`t_job_import_check_exam` 
ADD COLUMN `custom_date` VARCHAR(255) NULL AFTER `sort1`,
ADD COLUMN `transport_date` VARCHAR(255) NULL AFTER `custom_date`;


61-06-10
CREATE TABLE `t_job_import_container_list` (
  `job_import_container_id` int(11) NOT NULL,
  `job_import_id` int(11) DEFAULT NULL,
  `container_no` varchar(255) DEFAULT NULL,
  `doc_type_id_container` int(11) DEFAULT NULL,
  `seal` varchar(255) DEFAULT NULL,
  `row1` varchar(255) DEFAULT NULL,
  `remark` varchar(255) DEFAULT NULL,
  `active` varchar(255) DEFAULT NULL,
  `date_create` varchar(255) DEFAULT NULL,
  `date_modi` varchar(255) DEFAULT NULL,
  `date_cancel` varchar(255) DEFAULT NULL,
  `user_create` varchar(255) DEFAULT NULL,
  `user_modi` varchar(255) DEFAULT NULL,
  `user_cancel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`job_import_container_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='id=144';

CREATE TABLE `t_job_import_delivery` (
  `job_import_delivery_id` int(11) NOT NULL AUTO_INCREMENT,
  `job_import_id` varchar(255) DEFAULT NULL,
  `row1` varchar(255) DEFAULT NULL,
  `delivery_doc_no` varchar(255) DEFAULT NULL,
  `car_type_id` int(11) DEFAULT NULL,
  `transporter_id` int(11) DEFAULT NULL,
  `place_id` int(11) DEFAULT NULL,
  `packages` varchar(255) DEFAULT NULL,
  `unit_package_id` int(11) DEFAULT NULL,
  `gw` varchar(255) DEFAULT NULL,
  `unit_gw_id` int(11) DEFAULT NULL,
  `volume1` varchar(255) DEFAULT NULL,
  `unit_volume1_id` int(11) DEFAULT NULL,
  `job_import_delivery1_id` int(11) DEFAULT NULL,
  `container_no` varchar(255) DEFAULT NULL,
  `doc_type_namet_container` varchar(255) DEFAULT NULL,
  `seal` varchar(255) DEFAULT NULL,
  `yard_container` varchar(255) DEFAULT NULL,
  `remark` varchar(255) DEFAULT NULL,
  `active` varchar(255) DEFAULT NULL,
  `date_create` varchar(255) DEFAULT NULL,
  `date_modi` varchar(255) DEFAULT NULL,
  `date_cancel` varchar(255) DEFAULT NULL,
  `user_create` varchar(255) DEFAULT NULL,
  `user_modi` varchar(255) DEFAULT NULL,
  `user_cancel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`job_import_delivery_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='id=145';

61-06-11
ALTER TABLE `xtrim_erp`.`b_customer` 
ADD COLUMN `status_truck` VARCHAR(255) NULL AFTER `insr_id`;


61-06-12
ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
ADD COLUMN `deli_package` VARCHAR(255) NULL AFTER `unit_volume1_id`,
ADD COLUMN `deli_gw` VARCHAR(255) NULL AFTER `deli_package`,
ADD COLUMN `deli_volume` VARCHAR(255) NULL AFTER `delifw`,
ADD COLUMN `deli_imp_id` INT NULL AFTER `deli_volume`,
ADD COLUMN `deli_imp_addr` VARCHAR(255) NULL AFTER `deli_imp_id`,
ADD COLUMN `deli_unit_package_id` INT NULL AFTER `deli_imp_addr`,
ADD COLUMN `deli_unit_gw_id` INT NULL AFTER `deli_unit_package_id`,
ADD COLUMN `deli_unit_volume_id` INT NULL AFTER `deli_unit_gw_id`,
ADD COLUMN `deli_deli_truck_cop_id` INT NULL COMMENT 'บริษัทรับขนส่ง :' AFTER `deli_unit_volume_id`,
ADD COLUMN `deli_place_addr_id` INT NULL COMMENT 'สถานที่ส่งของ :' AFTER `truck_cop_id`,
ADD COLUMN `deli_place_addr_name_t` VARCHAR(255) NULL COMMENT 'สถานที่ส่งของ :' AFTER `place_addr_id`,
ADD COLUMN `deli_yard_id` INT NULL COMMENT 'ลานคืนตู้ :' AFTER `place_addr_name_t`;

ALTER TABLE `xtrim_erp`.`b_customer` 
ADD COLUMN `status_container_yard` VARCHAR(255) NULL AFTER `status_truck`;
ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
ADD COLUMN `deli_truck_id` INT NULL COMMENT 'ชนิดรถ :' AFTER `deli_yard_id`;

ALTER TABLE `xtrim_erp`.`t_job_import_bl` 
ADD COLUMN `deli_yard_addr_name_t` VARCHAR(255) NULL AFTER `deli_truck_id`;

CREATE TABLE `xtrim_erp`.`t_job_import_container` (
  `job_import_container_id` INT NOT NULL AUTO_INCREMENT,
  `job_import_id` INT NULL,
  `container_no` VARCHAR(255) NULL,
  `container_doct_type_id` INT NULL,
  `seal` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  PRIMARY KEY (`job_import_container_id`));

ALTER TABLE `xtrim_erp`.`b_address` 
ADD COLUMN `status_place_addr` VARCHAR(255) NULL AFTER `map_pic_path`,
ADD COLUMN `status_container_yard` VARCHAR(255) NULL AFTER `status_place_addr`;

61-06-13
ALTER TABLE `xtrim_erp`.`t_job_import` 
ADD COLUMN `container_yard1_id` INT NULL AFTER `bl`,
ADD COLUMN `container_yard2_id` INT NULL AFTER `container_yard1_id`,
ADD COLUMN `container_yard3_id` INT NULL AFTER `container_yard2_id`,
ADD COLUMN `container_yard4_id` INT NULL AFTER `container_yard3_id`,
ADD COLUMN `container_yard5_id` INT NULL AFTER `container_yard4_id`,
ADD COLUMN `container_yard1_addr` VARCHAR(255) NULL AFTER `container_yard5_id`,
ADD COLUMN `container_yard2_addr` VARCHAR(255) NULL AFTER `container_yard1_addr`,
ADD COLUMN `container_yard3_addr` VARCHAR(255) NULL AFTER `container_yard2_addr`,
ADD COLUMN `container_yard4_addr` VARCHAR(255) NULL AFTER `container_yard3_addr`,
ADD COLUMN `container_yard5_addr` VARCHAR(255) NULL AFTER `container_yard4_addr`,
ADD COLUMN `time_open_close1` VARCHAR(255) NULL AFTER `container_yard5_addr`,
ADD COLUMN `time_open_close2` VARCHAR(255) NULL AFTER `time_open_close1`,
ADD COLUMN `time_open_close3` VARCHAR(255) NULL AFTER `time_open_close2`,
ADD COLUMN `time_open_close4` VARCHAR(255) NULL AFTER `time_open_close3`,
ADD COLUMN `time_open_close5` VARCHAR(255) NULL AFTER `time_open_close4`,
ADD COLUMN `time_open_close_over_time1` VARCHAR(255) NULL AFTER `time_open_close5`,
ADD COLUMN `time_open_close_over_time2` VARCHAR(255) NULL AFTER `time_open_close_over_time1`,
ADD COLUMN `time_open_close_over_time3` VARCHAR(255) NULL AFTER `time_open_close_over_time2`,
ADD COLUMN `time_open_close_over_time4` VARCHAR(255) NULL AFTER `time_open_close_over_time3`,
ADD COLUMN `time_open_close_over_time5` VARCHAR(255) NULL AFTER `time_open_close_over_time4`;



61-06-19
ALTER TABLE `xtrim_erp`.`b_expenses` 
CHANGE COLUMN `expenses_id` `item_id` INT(11) NOT NULL AUTO_INCREMENT ,
CHANGE COLUMN `expenses_code` `item_code` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `expenses_name_t` `item_name_t` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `expenses_name_e` `item_name_e` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `expense_cat_id` `item_cat_id` INT(11) NULL DEFAULT NULL ,
CHANGE COLUMN `expense_type_id` `item_type_sub_id` INT(11) NULL DEFAULT NULL , RENAME TO  `xtrim_erp`.`b_items` ;

ALTER TABLE `xtrim_erp`.`b_expenses_type` 
CHANGE COLUMN `expenses_type_id` `item_type_id` INT(11) NOT NULL AUTO_INCREMENT ,
CHANGE COLUMN `expenses_type_code` `item_type_code` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `expenses_type_name_t` `item_type_name_t` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `expenses_type_name_e` `item_type_name_e` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL , RENAME TO  `xtrim_erp`.`b_items_type` ;

61-06-21
ALTER TABLE `xtrim_erp`.`b_company` 
ADD COLUMN `cash_draw_doc` INT NULL AFTER `eaddr4`,
ADD COLUMN `year_curr` VARCHAR(255) NULL AFTER `cash_draw_doc`;

61-06-30
ALTER TABLE `xtrim_erp`.`b_items` 
ADD COLUMN `price1` DECIMAL(17,2) NULL AFTER `status_invoice`,
ADD COLUMN `price2` DECIMAL(17,2) NULL AFTER `price1`,
ADD COLUMN `price3` DECIMAL(17,2) NULL AFTER `price2`,
ADD COLUMN `price4` DECIMAL(17,2) NULL AFTER `price3`,
ADD COLUMN `price5` DECIMAL(17,2) NULL AFTER `price4`;

61-07-01
ALTER TABLE `xtrim_erp`.`b_items` 
ADD COLUMN `unit_id` INT NULL AFTER `price5`;
ALTER TABLE `xtrim_erp`.`b_company_bank` 
ADD COLUMN `bank_id` INT NULL AFTER `active`;



select  itmts.item_type_sub_name_t, mtp.method_payment_name_t, sum(edd.amount) as amt
from t_expenses_draw_detail edd
inner join b_items itm on edd.expenses_id = itm.item_id
inner join b_items_type_sub itmts on itm.item_type_sub_id = itmts.item_type_sub_id
inner join b_method_payment mtp on itm.method_payment_id = mtp.method_payment_id
group by itmts.item_type_sub_name_t, mtp.method_payment_name_t




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