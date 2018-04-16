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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-16 18:57:29
