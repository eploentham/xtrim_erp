-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: xtrim_erp
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.25-MariaDB

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
-- Table structure for table `b_bank`
--

DROP TABLE IF EXISTS `b_bank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_bank` (
  `bank_id` int(11) NOT NULL AUTO_INCREMENT,
  `bank_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `bank_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `bank_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bank_id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_bank`
--

LOCK TABLES `b_bank` WRITE;
/*!40000 ALTER TABLE `b_bank` DISABLE KEYS */;
INSERT INTO `b_bank` VALUES (1,'scb','ธนาคารไทยพาณิชย์','Siam Commercial Bank','1','-','2018-04-15 10:35:43','2018-04-15 10:44:35',NULL,NULL,NULL,NULL),(2,'tmb','ธนาคารทหารไทย','qwerqwerq','1','','2018-04-15 10:50:16','2018-04-15 14:56:00',NULL,NULL,NULL,NULL),(3,'tmb','ธนาคารทหารไทย','','3','','2018-04-15 10:50:19',NULL,'2018-04-15 13:29:16',NULL,NULL,NULL),(4,'tmb','ธนาคารทหารไทย','','3','','2018-04-15 10:50:20',NULL,'2018-04-15 13:29:12',NULL,NULL,NULL),(5,'sss','','','3','','2018-04-15 10:52:13',NULL,'2018-04-15 13:29:02',NULL,NULL,NULL),(6,'kbank','ธนาคารกสิกรไทย','sdfsadf','1','','2018-04-15 13:49:33','2018-04-15 14:53:27',NULL,NULL,NULL,NULL),(7,'kbank','ธนาคารกสิกรไทย','qwerqwe','3','','2018-04-15 13:49:41','2018-04-15 14:53:26','2018-04-15 14:55:49',NULL,NULL,NULL);
/*!40000 ALTER TABLE `b_bank` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_company`
--

LOCK TABLES `b_company` WRITE;
/*!40000 ALTER TABLE `b_company` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_company_bank`
--

DROP TABLE IF EXISTS `b_company_bank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_company_bank` (
  `comp_bank_id` int(11) NOT NULL AUTO_INCREMENT,
  `comp_id` varchar(255) CHARACTER SET utf8mb4 DEFAULT NULL,
  `comp_bank_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_bank_branch` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_bank_active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `acc_number` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`comp_bank_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_company_bank`
--

LOCK TABLES `b_company_bank` WRITE;
/*!40000 ALTER TABLE `b_company_bank` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_company_bank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_contact`
--

DROP TABLE IF EXISTS `b_contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_contact` (
  `contact_id` int(11) NOT NULL AUTO_INCREMENT,
  `comp_id` int(11) DEFAULT NULL,
  `contact_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `username` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `password1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_id` int(11) DEFAULT NULL,
  `contact_fname_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_fname_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_lname_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_lname_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `priority` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `mobile` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `posi_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `posi_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`contact_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_contact`
--

LOCK TABLES `b_contact` WRITE;
/*!40000 ALTER TABLE `b_contact` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_contact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_customer`
--

DROP TABLE IF EXISTS `b_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_customer` (
  `cust_id` int(11) NOT NULL AUTO_INCREMENT,
  `cust_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `cust_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `cust_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `address_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `address_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `addr` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amphur_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `district_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `province_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sale_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sale_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tax_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_name1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_name2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_name1_tel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_name2_tel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_company` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_vendor` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `po_due_period` int(11) DEFAULT NULL,
  `taddr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`cust_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_customer`
--

LOCK TABLES `b_customer` WRITE;
/*!40000 ALTER TABLE `b_customer` DISABLE KEYS */;
INSERT INTO `b_customer` VALUES (1,'001','ฟฟฟฟฟ','ddddd','1','','','','','','','','','','','','','','','','','','','','','','2018-04-16 21:18:34','','','','','',0,'1','2','3','4','','','','');
/*!40000 ALTER TABLE `b_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_department`
--

DROP TABLE IF EXISTS `b_department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_department` (
  `depart_id` int(11) NOT NULL AUTO_INCREMENT,
  `depart_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `depart_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `depart_parent` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`depart_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_department`
--

LOCK TABLES `b_department` WRITE;
/*!40000 ALTER TABLE `b_department` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_employee`
--

DROP TABLE IF EXISTS `b_employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_employee` (
  `emp_id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_username` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_ssn` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `Emp_position` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `depart_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_work_type` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_type` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_nickname` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_password` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_privilege` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `pid` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_holiday` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_realday` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `emp_timerule` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`emp_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_employee`
--

LOCK TABLES `b_employee` WRITE;
/*!40000 ALTER TABLE `b_employee` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_importer`
--

DROP TABLE IF EXISTS `b_importer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_importer` (
  `imp_id` int(11) NOT NULL AUTO_INCREMENT,
  `cust_id` int(11) DEFAULT NULL,
  `imp_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `imp_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `imp_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `address_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `address_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `addr` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amphur_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `district_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `province_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sale_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sale_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tax_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_name1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_name2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_name1_tel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `contact_name2_tel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_company` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_vendor` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `po_due_period` int(11) DEFAULT NULL,
  `taddr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`imp_id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_importer`
--

LOCK TABLES `b_importer` WRITE;
/*!40000 ALTER TABLE `b_importer` DISABLE KEYS */;
INSERT INTO `b_importer` VALUES (2,0,'001','222','444','1','','','','','','','','','','','','','','','','','','','','','','','','','','','',0,'','','','','','','',''),(3,0,'001','222','444','1','','','','','','','','','','','','','','','','','','','','','','','','','','','',0,'','','','','','','',''),(4,0,'001','222','444','1','','','','','','','','','','','','','','','','','','','','','','','','','','','',0,'','','','','','','',''),(5,0,'001','222','444','1','','','','','','','','','','','','','','','','','','','','','','','','','','','',0,'','','','','','','','');
/*!40000 ALTER TABLE `b_importer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_prefix`
--

DROP TABLE IF EXISTS `b_prefix`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_prefix` (
  `prefix_id` int(11) NOT NULL AUTO_INCREMENT,
  `prefix_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`prefix_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_prefix`
--

LOCK TABLES `b_prefix` WRITE;
/*!40000 ALTER TABLE `b_prefix` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_prefix` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_staff`
--

DROP TABLE IF EXISTS `b_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `b_staff` (
  `staff_id` int(11) NOT NULL AUTO_INCREMENT,
  `staff_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `username` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `password1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_id` int(11) DEFAULT NULL,
  `staff_fname_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `staff_fname_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `staff_lname_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `staff_lname_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `priority` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `mobile` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `posi_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `posi_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`staff_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_staff`
--

LOCK TABLES `b_staff` WRITE;
/*!40000 ALTER TABLE `b_staff` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_amphures`
--

DROP TABLE IF EXISTS `f_amphures`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `f_amphures` (
  `amph_id` int(11) NOT NULL AUTO_INCREMENT,
  `amph_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amph_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `geo_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prov_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amph_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`amph_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_amphures`
--

LOCK TABLES `f_amphures` WRITE;
/*!40000 ALTER TABLE `f_amphures` DISABLE KEYS */;
/*!40000 ALTER TABLE `f_amphures` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_districts`
--

DROP TABLE IF EXISTS `f_districts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `f_districts` (
  `dist_id` int(11) NOT NULL AUTO_INCREMENT,
  `dist_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `dist_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `dist_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amph_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prov_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `geo_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`dist_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_districts`
--

LOCK TABLES `f_districts` WRITE;
/*!40000 ALTER TABLE `f_districts` DISABLE KEYS */;
/*!40000 ALTER TABLE `f_districts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_provinces`
--

DROP TABLE IF EXISTS `f_provinces`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `f_provinces` (
  `prov_id` int(11) NOT NULL AUTO_INCREMENT,
  `prov_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prov_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prov_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `geo_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`prov_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_provinces`
--

LOCK TABLES `f_provinces` WRITE;
/*!40000 ALTER TABLE `f_provinces` DISABLE KEYS */;
/*!40000 ALTER TABLE `f_provinces` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_zipcodes`
--

DROP TABLE IF EXISTS `f_zipcodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `f_zipcodes` (
  `id` int(11) NOT NULL,
  `dist_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8_bin DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_zipcodes`
--

LOCK TABLES `f_zipcodes` WRITE;
/*!40000 ALTER TABLE `f_zipcodes` DISABLE KEYS */;
/*!40000 ALTER TABLE `f_zipcodes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-17  9:38:34
