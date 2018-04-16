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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-16 18:57:29
