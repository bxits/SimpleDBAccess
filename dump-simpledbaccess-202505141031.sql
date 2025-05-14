CREATE DATABASE  IF NOT EXISTS `simpledbaccess` /*!40100 DEFAULT CHARACTER SET utf8 */;
-- MariaDB dump 10.17  Distrib 10.4.14-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: simpledbaccess
-- ------------------------------------------------------
-- Server version	10.4.14-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbldata`
--

DROP TABLE IF EXISTS `tbldata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbldata` (
  `iddata` int(11) NOT NULL AUTO_INCREMENT,
  `message` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`iddata`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbldata`
--

LOCK TABLES `tbldata` WRITE;
/*!40000 ALTER TABLE `tbldata` DISABLE KEYS */;
INSERT INTO `tbldata` VALUES (1,'eine Msg'),(2,'Testdata'),(3,'asdfasdf'),(4,'tttttt'),(5,'eeeeee'),(6,'qqqq'),(7,'tttt'),(8,'Das ist ein Eintrag vom 14.05.2025 10:14:07'),(9,'Das ist ein Eintrag vom 14.05.2025 10:14:34'),(10,'Das ist ein Eintrag vom 14.05.2025 10:14:36'),(11,'Das ist ein Eintrag vom 14.05.2025 10:28:46'),(12,'Das ist ein Eintrag vom 14.05.2025 10:28:47'),(13,'Das ist ein Eintrag vom 14.05.2025 10:28:48'),(14,'Das ist ein Eintrag vom 14.05.2025 10:28:48'),(15,'Das ist ein Eintrag vom 14.05.2025 10:29:57');
/*!40000 ALTER TABLE `tbldata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'simpledbaccess'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-14 10:31:38
