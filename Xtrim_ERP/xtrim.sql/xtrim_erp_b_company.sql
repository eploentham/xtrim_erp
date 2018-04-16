-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: xtrim_erp
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `b_company`
--

DROP TABLE IF EXISTS `b_company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_company` (
  `comp_id` int(11) NOT NULL AUTO_INCREMENT,
  `comp_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_address_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_address_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `addr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `addr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amphur_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `district_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `province_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `website` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `logo` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tax_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `vat` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `spec1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line5` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line6` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line5` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line6` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `po_line1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `po_due_period` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `taddr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`comp_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_company`
--

LOCK TABLES `b_company` WRITE;
/*!40000 ALTER TABLE `b_company` DISABLE KEYS */;
INSERT INTO `b_company` VALUES (1,'001','บริษัท เอ็กซ์ทริม โลจิสติกส์ จำกัด','XTRIM LOGISTICS CO.,LTD.','','','','','','','','10110','02-6123519','02-6123051','','xtrim-logistics.co.th','','0105549126051','','','2018-04-16 10:47:45','2018-04-16 11:04:59','','','','','','','','','','','','','','','','','','','1','','47 อาคาร เอ็มที เแอนด์ ที่ ชั้น 4','พระโขนง','วัฒนา','กทมฯ','','','','');
/*!40000 ALTER TABLE `b_company` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-16 18:57:29
