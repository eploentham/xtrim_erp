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
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_customer`
--

LOCK TABLES `b_customer` WRITE;
/*!40000 ALTER TABLE `b_customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_customer` ENABLE KEYS */;
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
