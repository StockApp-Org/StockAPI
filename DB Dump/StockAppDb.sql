-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 192.168.0.101    Database: StockAppDb
-- ------------------------------------------------------
-- Server version	5.7.30-0ubuntu0.18.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Companies` (
  `CompanyId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `IndustryId` int(11) NOT NULL,
  PRIMARY KEY (`CompanyId`),
  KEY `IndustryId` (`IndustryId`),
  CONSTRAINT `Companies_ibfk_1` FOREIGN KEY (`IndustryId`) REFERENCES `Industry` (`IndustryId`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `CompanyShareView`
--

DROP TABLE IF EXISTS `CompanyShareView`;
/*!50001 DROP VIEW IF EXISTS `CompanyShareView`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `CompanyShareView` AS SELECT 
 1 AS `ShareId`,
 1 AS `CompanyId`,
 1 AS `IndustryId`,
 1 AS `CompanyName`,
 1 AS `IndustryName`,
 1 AS `AvailableShares`,
 1 AS `SharePrice`,
 1 AS `NetWorth`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `CompanyStock`
--

DROP TABLE IF EXISTS `CompanyStock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `CompanyStock` (
  `Shares` int(11) NOT NULL,
  `SharePrice` decimal(15,2) DEFAULT NULL,
  `CompanyId` int(11) NOT NULL,
  `ShareId` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ShareId`),
  KEY `CompanyId` (`CompanyId`),
  CONSTRAINT `CompanyStock_ibfk_1` FOREIGN KEY (`CompanyId`) REFERENCES `Companies` (`CompanyId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Industry`
--

DROP TABLE IF EXISTS `Industry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Industry` (
  `IndustryId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`IndustryId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Organizations`
--

DROP TABLE IF EXISTS `Organizations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Organizations` (
  `OrgNr` varchar(20) NOT NULL,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`OrgNr`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `UserAddress`
--

DROP TABLE IF EXISTS `UserAddress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserAddress` (
  `UserId` int(11) NOT NULL,
  `AddressRow1` varchar(100) DEFAULT NULL,
  `AddressRow2` varchar(100) DEFAULT NULL,
  `AddressRow3` varchar(100) DEFAULT NULL,
  `ZipCode` varchar(10) DEFAULT NULL,
  `City` varchar(100) DEFAULT NULL,
  `AddressId` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`AddressId`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `UserAddress_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `UserShareView`
--

DROP TABLE IF EXISTS `UserShareView`;
/*!50001 DROP VIEW IF EXISTS `UserShareView`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `UserShareView` AS SELECT 
 1 AS `ShareId`,
 1 AS `UserId`,
 1 AS `FullName`,
 1 AS `CompanyName`,
 1 AS `IndustryName`,
 1 AS `ShareCount`,
 1 AS `NetWorth`,
 1 AS `SharePercent`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `UserShares`
--

DROP TABLE IF EXISTS `UserShares`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserShares` (
  `UserId` int(11) NOT NULL,
  `ShareId` int(11) NOT NULL,
  `Count` int(11) NOT NULL,
  PRIMARY KEY (`UserId`,`ShareId`),
  KEY `ShareId` (`ShareId`),
  CONSTRAINT `UserShares_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE CASCADE,
  CONSTRAINT `UserShares_ibfk_2` FOREIGN KEY (`ShareId`) REFERENCES `CompanyStock` (`ShareId`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER TR_AddUserShare
AFTER INSERT ON UserShares
FOR EACH ROW
UPDATE CompanyStock SET Shares = (Shares - NEW.Count)
WHERE ShareId = NEW.ShareId */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER TR_UpdateUserShare
AFTER UPDATE ON UserShares
FOR EACH ROW
UPDATE CompanyStock
SET Shares = (
SELECT CASE
WHEN (NEW.Count - OLD.Count > 0) THEN (Shares - (NEW.Count - OLD.Count))
WHEN (NEW.Count - OLD.Count < 0) THEN (Shares + (OLD.Count - NEW.Count))
END)
WHERE ShareId = NEW.ShareId */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER TR_DeleteUserShare
AFTER DELETE ON UserShares
FOR EACH ROW
UPDATE CompanyStock
SET Shares = (Shares + OLD.Count)
WHERE ShareId = OLD.ShareId */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
  `PhoneNumber` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'StockAppDb'
--

--
-- Dumping routines for database 'StockAppDb'
--

--
-- Final view structure for view `CompanyShareView`
--

/*!50001 DROP VIEW IF EXISTS `CompanyShareView`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `CompanyShareView` AS (select `cs`.`ShareId` AS `ShareId`,`c`.`CompanyId` AS `CompanyId`,`i`.`IndustryId` AS `IndustryId`,`c`.`Name` AS `CompanyName`,`i`.`Name` AS `IndustryName`,`cs`.`Shares` AS `AvailableShares`,`cs`.`SharePrice` AS `SharePrice`,(`cs`.`SharePrice` * `cs`.`Shares`) AS `NetWorth` from ((`Companies` `c` join `Industry` `i` on((`c`.`IndustryId` = `i`.`IndustryId`))) join `CompanyStock` `cs` on((`c`.`CompanyId` = `cs`.`CompanyId`)))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `UserShareView`
--

/*!50001 DROP VIEW IF EXISTS `UserShareView`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `UserShareView` AS (select `us`.`ShareId` AS `ShareId`,`u`.`UserId` AS `UserId`,concat(`u`.`FirstName`,' ',`u`.`LastName`) AS `FullName`,`c`.`Name` AS `CompanyName`,`i`.`Name` AS `IndustryName`,`us`.`Count` AS `ShareCount`,cast((`cs`.`SharePrice` * `us`.`Count`) as decimal(15,2)) AS `NetWorth`,((`us`.`Count` / `cs`.`Shares`) * 100) AS `SharePercent` from ((((`Users` `u` join `UserShares` `us` on((`u`.`UserId` = `us`.`UserId`))) join `CompanyStock` `cs` on((`us`.`ShareId` = `cs`.`ShareId`))) join `Companies` `c` on((`cs`.`CompanyId` = `c`.`CompanyId`))) join `Industry` `i` on((`c`.`IndustryId` = `i`.`IndustryId`)))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-28 16:05:53
