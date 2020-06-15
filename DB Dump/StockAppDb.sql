-- MySQL dump 10.13  Distrib 5.7.30, for Linux (x86_64)
--
-- Host: localhost    Database: StockApp_Bettan
-- ------------------------------------------------------
-- Server version	5.7.30-0ubuntu0.18.04.1

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
-- Table structure for table `Companies`
--

DROP TABLE IF EXISTS `Companies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Companies` (
  `CompanyId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `IndustryId` int(11) NOT NULL,
  PRIMARY KEY (`CompanyId`),
  KEY `IndustryId` (`IndustryId`),
  CONSTRAINT `Companies_ibfk_1` FOREIGN KEY (`IndustryId`) REFERENCES `Industry` (`IndustryId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Companies`
--

LOCK TABLES `Companies` WRITE;
/*!40000 ALTER TABLE `Companies` DISABLE KEYS */;
INSERT INTO `Companies` VALUES (1,'Jonson & Jonson Construction LLC',1),(2,'Pharma IT Ltd.',2),(3,'LogCutters Inc.',3);
/*!40000 ALTER TABLE `Companies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CompanyStock`
--

DROP TABLE IF EXISTS `CompanyStock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CompanyStock` (
  `Shares` int(11) NOT NULL,
  `SharePrice` decimal(15,2) DEFAULT NULL,
  `CompanyId` int(11) NOT NULL,
  `ShareId` int(11) NOT NULL,
  PRIMARY KEY (`ShareId`),
  KEY `CompanyId` (`CompanyId`),
  CONSTRAINT `CompanyStock_ibfk_1` FOREIGN KEY (`CompanyId`) REFERENCES `Companies` (`CompanyId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CompanyStock`
--

LOCK TABLES `CompanyStock` WRITE;
/*!40000 ALTER TABLE `CompanyStock` DISABLE KEYS */;
/*!40000 ALTER TABLE `CompanyStock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Industry`
--

DROP TABLE IF EXISTS `Industry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Industry` (
  `IndustryId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`IndustryId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Industry`
--

LOCK TABLES `Industry` WRITE;
/*!40000 ALTER TABLE `Industry` DISABLE KEYS */;
INSERT INTO `Industry` VALUES (1,'Construction'),(2,'MedTech'),(3,'Forestry');
/*!40000 ALTER TABLE `Industry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Organizations`
--

DROP TABLE IF EXISTS `Organizations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Organizations` (
  `OrgNr` varchar(20) NOT NULL,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`OrgNr`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Organizations`
--

LOCK TABLES `Organizations` WRITE;
/*!40000 ALTER TABLE `Organizations` DISABLE KEYS */;
/*!40000 ALTER TABLE `Organizations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserAddress`
--

DROP TABLE IF EXISTS `UserAddress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `UserAddress` (
  `UserId` int(11) NOT NULL,
  `AddressRow1` varchar(100) DEFAULT NULL,
  `AddressRow2` varchar(100) DEFAULT NULL,
  `AddressRow3` varchar(100) DEFAULT NULL,
  `ZipCode` varchar(10) DEFAULT NULL,
  `City` varchar(100) DEFAULT NULL,
  KEY `UserId` (`UserId`),
  CONSTRAINT `UserAddress_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserAddress`
--

LOCK TABLES `UserAddress` WRITE;
/*!40000 ALTER TABLE `UserAddress` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserAddress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserShares`
--

DROP TABLE IF EXISTS `UserShares`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `UserShares` (
  `UserId` int(11) NOT NULL,
  `ShareId` int(11) NOT NULL,
  `Count` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserId`,`ShareId`),
  KEY `ShareId` (`ShareId`),
  CONSTRAINT `UserShares_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`),
  CONSTRAINT `UserShares_ibfk_2` FOREIGN KEY (`ShareId`) REFERENCES `CompanyStock` (`ShareId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserShares`
--

LOCK TABLES `UserShares` WRITE;
/*!40000 ALTER TABLE `UserShares` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserShares` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Users` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `PersonNr` varchar(12) DEFAULT NULL,
  `OrgNr` varchar(20) DEFAULT NULL,
  `Password` varchar(4000) NOT NULL,
  `PasswordSalt` varchar(4000) NOT NULL,
  `ImgUrl` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-15 19:23:48
