CREATE TABLE `t_expenses_draw` (
  `expenses_draw_id` int(11) NOT NULL AUTO_INCREMENT,
  `expenses_draw_code` varchar(255) DEFAULT NULL COMMENT 'เลขที่ใบเบิก',
  `expenses_draw_date` varchar(255) DEFAULT NULL,
  `job_id` int(11) DEFAULT NULL,
  `job_code` varchar(255) DEFAULT NULL,
  `draw_date` varchar(255) DEFAULT NULL COMMENT 'วันที่ต้องการใช้เงิน',
  `remark` varchar(255) DEFAULT NULL,
  `active` varchar(255) DEFAULT NULL,
  `date_create` varchar(255) DEFAULT NULL,
  `date_modi` varchar(255) DEFAULT NULL,
  `date_cancel` varchar(255) DEFAULT NULL,
  `user_create` varchar(255) DEFAULT NULL,
  `user_modi` varchar(255) DEFAULT NULL,
  `user_cancel` varchar(255) DEFAULT NULL,
  `staff_id` varchar(255) DEFAULT NULL,
  `desc1` varchar(255) DEFAULT NULL,
  `status_appv` varchar(255) DEFAULT NULL,
  `status_email` varchar(255) DEFAULT NULL,
  `amount` decimal(17,2) DEFAULT NULL,
  PRIMARY KEY (`expenses_draw_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1520000000 DEFAULT CHARSET=latin1 COMMENT='id=152';


CREATE TABLE `t_expenses_draw_detail` (
  `expenses_draw_detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `expenses_draw_id` int(11) DEFAULT NULL,
  `desc1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `desc2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amount` decimal(17,2) DEFAULT NULL,
  `expenses_draw_type_id` int(11) DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_type_id` int(11) DEFAULT NULL,
  `sort1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`expenses_draw_detail_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1530000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=150 หน้าจอ เบิกเงิน';


CREATE TABLE `b_expenses` (
  `expenses_id` int(11) NOT NULL AUTO_INCREMENT,
  `expenses_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_app` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_tax` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expense_cat_id` int(11) DEFAULT NULL,
  `expense_type_id` int(11) DEFAULT NULL,
  `acc_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`expenses_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1120000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=112';


CREATE TABLE `b_expenses_cat` (
  `expenses_cat_id` int(11) NOT NULL AUTO_INCREMENT,
  `expenses_cat_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_cat_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_cat_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`expenses_cat_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1470000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=147';


CREATE TABLE `b_expenses_draw_type` (
  `expenses_draw_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `expenses_draw_type_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_draw_type_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_draw_type_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `use_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`expenses_draw_type_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1510000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=151 หน้าจอ ประเภทการเบิกเงิน';


CREATE TABLE `b_expenses_grp` (
  `expenses_grp_id` int(11) NOT NULL AUTO_INCREMENT,
  `expenses_grp_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_grp_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_grp_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`expenses_grp_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1490000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=149';


CREATE TABLE `b_expenses_type` (
  `expenses_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `expenses_type_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_type_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `expenses_type_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`expenses_type_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1480000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=148';


