-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: yamamadb
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20201014230545_addIdentity','2.2.6-servicing-10079'),('20201016175549_extendUser','2.2.6-servicing-10079');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actual_intencive`
--

DROP TABLE IF EXISTS `actual_intencive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actual_intencive` (
  `idactual_intencive` int NOT NULL AUTO_INCREMENT,
  `actual_intencive` int DEFAULT NULL,
  `date` date DEFAULT NULL,
  `id_user` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idactual_intencive`),
  KEY `id_user_idx` (`id_user`),
  CONSTRAINT `id_user` FOREIGN KEY (`id_user`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actual_intencive`
--

LOCK TABLES `actual_intencive` WRITE;
/*!40000 ALTER TABLE `actual_intencive` DISABLE KEYS */;
/*!40000 ALTER TABLE `actual_intencive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `actual_needs`
--

DROP TABLE IF EXISTS `actual_needs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actual_needs` (
  `idactual_needs` int NOT NULL AUTO_INCREMENT,
  `actual_needs1` int DEFAULT NULL,
  `date` date DEFAULT NULL,
  `id_product` int DEFAULT NULL,
  PRIMARY KEY (`idactual_needs`),
  KEY `product_id_idx` (`id_product`),
  CONSTRAINT `id_product` FOREIGN KEY (`id_product`) REFERENCES `product` (`idproduct`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `actual_needs`
--

LOCK TABLES `actual_needs` WRITE;
/*!40000 ALTER TABLE `actual_needs` DISABLE KEYS */;
/*!40000 ALTER TABLE `actual_needs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alert`
--

DROP TABLE IF EXISTS `alert`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alert` (
  `idalert` int NOT NULL AUTO_INCREMENT,
  `sender_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `reciever_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `notes` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `file_id` int DEFAULT NULL,
  `task_id` int DEFAULT NULL,
  PRIMARY KEY (`idalert`),
  KEY `file_id` (`file_id`) /*!80000 INVISIBLE */,
  KEY `task_id` (`task_id`) /*!80000 INVISIBLE */,
  KEY `sender_id` (`sender_id`) /*!80000 INVISIBLE */,
  KEY `reciever_id` (`reciever_id`),
  CONSTRAINT `alert_file_fk` FOREIGN KEY (`file_id`) REFERENCES `file` (`idfile`),
  CONSTRAINT `alert_receiver_fk` FOREIGN KEY (`reciever_id`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `alert_sender_fk` FOREIGN KEY (`sender_id`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `alert_task_fk` FOREIGN KEY (`task_id`) REFERENCES `task` (`idtask`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alert`
--

LOCK TABLES `alert` WRITE;
/*!40000 ALTER TABLE `alert` DISABLE KEYS */;
/*!40000 ALTER TABLE `alert` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `answers`
--

DROP TABLE IF EXISTS `answers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answers` (
  `idanswers` int NOT NULL AUTO_INCREMENT,
  `answer_text` text CHARACTER SET utf8 COLLATE utf8_bin,
  `answer_weight` int DEFAULT NULL,
  `question_id` int DEFAULT NULL,
  PRIMARY KEY (`idanswers`),
  KEY `question_id_idx` (`question_id`),
  CONSTRAINT `question_id` FOREIGN KEY (`question_id`) REFERENCES `questions` (`idQuestions`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `answers`
--

LOCK TABLES `answers` WRITE;
/*!40000 ALTER TABLE `answers` DISABLE KEYS */;
INSERT INTO `answers` VALUES (1,'yes',25,1),(2,'no',0,1),(3,'not every thing',15,1),(4,'yes',25,2),(5,'no',0,2),(6,'quite acceptable',15,2),(7,'yes',25,3),(8,'no',0,3),(9,'quite acceptable',15,3),(10,'yes',25,4),(11,'no',0,4),(12,'quite acceptable',15,4);
/*!40000 ALTER TABLE `answers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `ClaimValue` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_Role` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `NormalizedName` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('ee51427d-67d8-42e6-b0c7-13352f44b390','admin','ADMIN','fc040b8e-35d3-4ebc-b2db-e0faac86807b');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `ClaimValue` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetuserClaims_user` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('66699efb-e392-48f0-ac3c-9789d42cbf3d','ee51427d-67d8-42e6-b0c7-13352f44b390'),('758c505f-cd13-4797-85d7-5952974c336d','ee51427d-67d8-42e6-b0c7-13352f44b390'),('a36389ca-fa2c-48c6-958b-a07e08bef684','ee51427d-67d8-42e6-b0c7-13352f44b390'),('be82b6ca-baac-497a-a6b3-2042425d1a39','ee51427d-67d8-42e6-b0c7-13352f44b390'),('fe93e3b3-81e8-43bf-9260-ea9106642f39','ee51427d-67d8-42e6-b0c7-13352f44b390');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `UserName` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `NormalizedUserName` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `NormalizedEmail` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `SecurityStamp` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `ConcurrencyStamp` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `PhoneNumber` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  `FullName` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('66699efb-e392-48f0-ac3c-9789d42cbf3d','gm@yamama.prokoders.work','GM@YAMAMA.PROKODERS.WORK','gm@yamama.prokoders.work','GM@YAMAMA.PROKODERS.WORK',_binary '\0','AQAAAAEAACcQAAAAEKDZ01/x1i7hrq6CDiDr23ZZWS+bq6ZX7ADBVwHYEPeExB2tlgubDxkJAlBDaNQjgQ==','36Q3YPEPOJYYGSL4YGYUWDLYP27HDVWL','b148cde2-33a7-47f6-9e75-b95ad2019760','0935479586',_binary '\0',_binary '\0',NULL,_binary '',0,'ana'),('758c505f-cd13-4797-85d7-5952974c336d','UpdateUser@gmail.com','UPDATEUSER@GMAIL.COM','UpdateUser@gmail.com','UPDATEUSER@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAECjM/bDsGyy/sZH/vq6vTsLN68Ya/Z9aqS8/qx2eJCPI2r9A93Ez7ENcU7zN8bEzMQ==','QTJ6KTQ2JWVZUYZGOZMDJUHGYVDP2IW7','f8b3883e-8c5b-4e30-b06e-109f7ae133a1','0998683689',_binary '\0',_binary '\0',NULL,_binary '',0,'admin admin'),('a36389ca-fa2c-48c6-958b-a07e08bef684','a_shakkouf@prokoders.com','A_SHAKKOUF@PROKODERS.COM','a_shakkouf@prokoders.com','A_SHAKKOUF@PROKODERS.COM',_binary '\0','AQAAAAEAACcQAAAAEC6G94CwOC9vvxwiWBFPApefMDClu+uvktOJmT7RMw+ySb3XWpIMya72BS2O/pV8eA==','UENU4AGHDHSDCFEPRZI4G44XUDV77UCY','91d53492-d240-4a51-a186-830f9c0c7076','0935479586',_binary '\0',_binary '\0',NULL,_binary '',0,'3li'),('be82b6ca-baac-497a-a6b3-2042425d1a39','test@gmail.com','TEST@GMAIL.COM','test@gmail.com','TEST@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEOh/Ql80nIr+sbgp5Eb+s7qK+K5IPTyBNFZtFQB/EdxTLaElfiNir5pQxZCP6QEtEg==','FDZQZU3JTYLV2FSIIB67QZHOANBUUFFJ','b56b4695-cc31-4b8f-9144-246850375661','0935479586',_binary '\0',_binary '\0',NULL,_binary '',0,'as'),('fe93e3b3-81e8-43bf-9260-ea9106642f39','alishakkouf404@gmail.com','ALISHAKKOUF404@GMAIL.COM','alishakkouf404@gmail.com','ALISHAKKOUF404@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEHNP3LMYIa36lMM+H72B8/1HMn1UB4EQHeWXrwc9GN13hPggivD+A6+eUT4N5yANxw==','GWPS5HBSZ7X64O2452BO25C2SRVCXG6P','9b48b30e-c914-4939-8dfc-cecc10bd88cb','0935479586',_binary '\0',_binary '\0',NULL,_binary '',0,'ali shakkouf');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `Value` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetuserToken_User` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `balance`
--

DROP TABLE IF EXISTS `balance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `balance` (
  `idbalance` int NOT NULL AUTO_INCREMENT,
  `product_id1` int DEFAULT NULL,
  `first_period` int DEFAULT NULL,
  `date_of_first` date DEFAULT NULL,
  `last_period` int DEFAULT NULL,
  `date_of_last` date DEFAULT NULL,
  PRIMARY KEY (`idbalance`),
  KEY `product_id_idx` (`product_id1`),
  CONSTRAINT `product_id1` FOREIGN KEY (`product_id1`) REFERENCES `product` (`idproduct`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `balance`
--

LOCK TABLES `balance` WRITE;
/*!40000 ALTER TABLE `balance` DISABLE KEYS */;
INSERT INTO `balance` VALUES (1,1,30,'2020-12-01',30,'2020-11-13'),(2,2,40,'2020-12-01',40,'2020-11-13'),(3,3,20,'2020-12-01',20,'2020-11-13'),(4,4,50,'2020-12-01',50,'2020-11-13'),(5,4,80,'2020-12-01',80,'2020-11-13'),(6,3,65,'2020-12-01',65,'2020-11-14'),(7,2,165,'2020-12-01',165,'2020-11-14');
/*!40000 ALTER TABLE `balance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cart`
--

DROP TABLE IF EXISTS `cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart` (
  `idCart` int NOT NULL AUTO_INCREMENT,
  `ProductId` int DEFAULT NULL,
  `price` double DEFAULT NULL,
  `QTY` int DEFAULT NULL,
  `SubCost` double DEFAULT NULL,
  `InvoiceId` int DEFAULT NULL,
  `transported_id` int DEFAULT NULL,
  PRIMARY KEY (`idCart`),
  KEY `ProductId_idx` (`ProductId`),
  KEY `InvoiceId_idx` (`InvoiceId`),
  KEY `transported_id_idx` (`transported_id`),
  CONSTRAINT `InvoiceId` FOREIGN KEY (`InvoiceId`) REFERENCES `invoice` (`idinvoice`),
  CONSTRAINT `ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`idproduct`),
  CONSTRAINT `transported_id` FOREIGN KEY (`transported_id`) REFERENCES `transporter` (`idtransporter`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart`
--

LOCK TABLES `cart` WRITE;
/*!40000 ALTER TABLE `cart` DISABLE KEYS */;
INSERT INTO `cart` VALUES (1,1,100,25,2500,5,1),(2,1,100,25,2500,5,1),(3,1,100,25,2500,6,1),(4,1,100,25,2500,6,NULL),(5,1,10,30,300,15,1),(6,1,10,30,300,15,NULL),(38,1,100,50,5000,37,NULL),(39,1,100,50,5000,38,NULL),(51,2,100,40,4000,44,1),(52,1,100,500,5000,45,1);
/*!40000 ALTER TABLE `cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer_satisfaction_reports`
--

DROP TABLE IF EXISTS `customer_satisfaction_reports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_satisfaction_reports` (
  `idcustomer_satisfaction_reports` int NOT NULL AUTO_INCREMENT,
  `project_id` int DEFAULT NULL,
  `notes` text CHARACTER SET utf8 COLLATE utf8_bin,
  `satisfaction_evaluation` double DEFAULT NULL,
  `factory_id` int DEFAULT NULL,
  PRIMARY KEY (`idcustomer_satisfaction_reports`),
  KEY `factory_id_idx` (`factory_id`),
  KEY `project_id_idx` (`project_id`),
  CONSTRAINT `factory_id` FOREIGN KEY (`factory_id`) REFERENCES `factory` (`idfactory`),
  CONSTRAINT `project_id` FOREIGN KEY (`project_id`) REFERENCES `project` (`idproject`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_satisfaction_reports`
--

LOCK TABLES `customer_satisfaction_reports` WRITE;
/*!40000 ALTER TABLE `customer_satisfaction_reports` DISABLE KEYS */;
INSERT INTO `customer_satisfaction_reports` VALUES (7,NULL,'The employees were very rude TAL 3EMRAK',16,1),(8,NULL,'The employees were very rude TAL 3EMRAK',16,1),(9,NULL,'every thing was fine',16.25,1);
/*!40000 ALTER TABLE `customer_satisfaction_reports` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expected_intencive`
--

DROP TABLE IF EXISTS `expected_intencive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `expected_intencive` (
  `idexpected_intencive` int NOT NULL AUTO_INCREMENT,
  `expected_money` double DEFAULT NULL,
  `date` date DEFAULT NULL,
  `userID` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idexpected_intencive`),
  KEY `user_id_idx` (`userID`),
  CONSTRAINT `user_id` FOREIGN KEY (`userID`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expected_intencive`
--

LOCK TABLES `expected_intencive` WRITE;
/*!40000 ALTER TABLE `expected_intencive` DISABLE KEYS */;
/*!40000 ALTER TABLE `expected_intencive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expected_needs`
--

DROP TABLE IF EXISTS `expected_needs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `expected_needs` (
  `idexpected_needs` int NOT NULL AUTO_INCREMENT,
  `expected_quantity` int DEFAULT NULL,
  `date` date DEFAULT NULL,
  `product_id` int DEFAULT NULL,
  PRIMARY KEY (`idexpected_needs`),
  KEY `product_id_idx` (`product_id`),
  CONSTRAINT `product_id` FOREIGN KEY (`product_id`) REFERENCES `product` (`idproduct`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expected_needs`
--

LOCK TABLES `expected_needs` WRITE;
/*!40000 ALTER TABLE `expected_needs` DISABLE KEYS */;
/*!40000 ALTER TABLE `expected_needs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factory`
--

DROP TABLE IF EXISTS `factory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factory` (
  `idfactory` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `location` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `activity_nature` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `product_id` int DEFAULT NULL,
  `cement_price` double DEFAULT NULL,
  `transporter_id` int DEFAULT NULL,
  `notes` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `information_source` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idfactory`),
  KEY `product_id` (`product_id`) /*!80000 INVISIBLE */,
  KEY `transporter` (`transporter_id`),
  CONSTRAINT `product_factory_id_fk` FOREIGN KEY (`product_id`) REFERENCES `product` (`idproduct`),
  CONSTRAINT `transporter_factory_id_fk` FOREIGN KEY (`transporter_id`) REFERENCES `transporter` (`idtransporter`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factory`
--

LOCK TABLES `factory` WRITE;
/*!40000 ALTER TABLE `factory` DISABLE KEYS */;
INSERT INTO `factory` VALUES (1,'Shakkouf','Safita','fake',1,1500,1,'fake','fake');
/*!40000 ALTER TABLE `factory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `file`
--

DROP TABLE IF EXISTS `file`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `file` (
  `idfile` int NOT NULL AUTO_INCREMENT,
  `parent_type` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `parent_id` int DEFAULT NULL,
  `path` varchar(1000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idfile`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `file`
--

LOCK TABLES `file` WRITE;
/*!40000 ALTER TABLE `file` DISABLE KEYS */;
/*!40000 ALTER TABLE `file` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice` (
  `idinvoice` int NOT NULL AUTO_INCREMENT,
  `FactoryId` int DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `FullCost` double DEFAULT '0',
  `ProjectId` int DEFAULT NULL,
  `paid` double DEFAULT '0',
  `remainForYamama` double DEFAULT '0',
  `remainForCustomer` double DEFAULT '0',
  `type` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `supplier` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idinvoice`),
  KEY `ProjectId_idx` (`ProjectId`),
  KEY `FactoryId_idx` (`FactoryId`),
  KEY `user_id_idx` (`user_id`),
  CONSTRAINT `FactoryId` FOREIGN KEY (`FactoryId`) REFERENCES `factory` (`idfactory`),
  CONSTRAINT `ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `project` (`idproject`),
  CONSTRAINT `user_invoice_id_fk` FOREIGN KEY (`user_id`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice`
--

LOCK TABLES `invoice` WRITE;
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
INSERT INTO `invoice` VALUES (5,1,'2020-10-19',5000,NULL,7000,0,2000,NULL,NULL,NULL),(6,1,'2020-11-22',5000,NULL,100,4900,0,'purchases',NULL,NULL),(15,1,'2020-12-27',1000,NULL,500,500,0,'purchases',NULL,NULL),(17,1,'2020-12-10',400,NULL,200,200,0,'Purchses',NULL,NULL),(18,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(19,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(20,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(21,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(22,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(23,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(24,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(25,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(26,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(27,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(28,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(29,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(30,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(31,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(32,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(33,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(34,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(35,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(36,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(37,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(38,1,'2020-12-10',5000,NULL,2500,2500,0,'Purchses',NULL,NULL),(39,NULL,'2020-11-13',5000,NULL,1000,4000,0,'Import',NULL,NULL),(40,NULL,'2020-11-13',5000,NULL,1000,4000,0,'Import',NULL,NULL),(41,NULL,'2020-11-13',5000,NULL,1000,4000,0,'Import',NULL,NULL),(42,NULL,'2020-11-13',5000,NULL,1000,4000,0,'Import',NULL,NULL),(43,NULL,'2020-11-13',5000,NULL,1000,4000,0,'Import',NULL,NULL),(44,NULL,'2020-11-13',4000,NULL,1000,3000,0,'Import',NULL,NULL),(45,NULL,'2020-11-14',5000,NULL,1000,4000,0,'Import',NULL,NULL);
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `link_r_q_a`
--

DROP TABLE IF EXISTS `link_r_q_a`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `link_r_q_a` (
  `idlink_r_q_a` int NOT NULL AUTO_INCREMENT,
  `report_id` int DEFAULT NULL,
  `q_Id` int DEFAULT NULL,
  `answer_id` int DEFAULT NULL,
  PRIMARY KEY (`idlink_r_q_a`),
  KEY `report_id_idx` (`report_id`),
  KEY `question_id_idx` (`q_Id`),
  KEY `q_Id_idx` (`q_Id`),
  KEY `answer_id_idx` (`answer_id`),
  CONSTRAINT `answer_id` FOREIGN KEY (`answer_id`) REFERENCES `answers` (`idanswers`),
  CONSTRAINT `q_Id` FOREIGN KEY (`q_Id`) REFERENCES `questions` (`idQuestions`),
  CONSTRAINT `report_id` FOREIGN KEY (`report_id`) REFERENCES `customer_satisfaction_reports` (`idcustomer_satisfaction_reports`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `link_r_q_a`
--

LOCK TABLES `link_r_q_a` WRITE;
/*!40000 ALTER TABLE `link_r_q_a` DISABLE KEYS */;
INSERT INTO `link_r_q_a` VALUES (1,7,1,2),(2,7,2,1),(3,7,3,1),(4,7,4,3),(5,8,1,2),(6,8,2,1),(7,8,3,1),(8,8,4,3),(9,9,1,1),(10,9,2,2),(11,9,3,3),(12,9,4,4);
/*!40000 ALTER TABLE `link_r_q_a` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `money_delivered`
--

DROP TABLE IF EXISTS `money_delivered`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `money_delivered` (
  `idmoney_delivered` int NOT NULL AUTO_INCREMENT,
  `amount` double DEFAULT NULL,
  `first_date` datetime DEFAULT NULL,
  `invoice_id` int DEFAULT NULL,
  `f_id` int DEFAULT NULL,
  `p_id` int DEFAULT NULL,
  `state` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idmoney_delivered`),
  KEY `invoice_id_idx` (`invoice_id`),
  KEY `factory_id_idx` (`f_id`),
  KEY `p_id_idx` (`p_id`),
  CONSTRAINT `f_id` FOREIGN KEY (`f_id`) REFERENCES `factory` (`idfactory`),
  CONSTRAINT `invoice_id` FOREIGN KEY (`invoice_id`) REFERENCES `invoice` (`idinvoice`),
  CONSTRAINT `p_id` FOREIGN KEY (`p_id`) REFERENCES `project` (`idproject`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `money_delivered`
--

LOCK TABLES `money_delivered` WRITE;
/*!40000 ALTER TABLE `money_delivered` DISABLE KEYS */;
INSERT INTO `money_delivered` VALUES (5,2500,'2020-12-10 00:00:00',28,1,NULL,'delivered'),(6,NULL,NULL,NULL,NULL,NULL,NULL),(7,2500,'2020-12-10 00:00:00',37,1,NULL,'delivered'),(8,2500,'2020-12-15 00:00:00',37,1,NULL,'pending'),(9,2500,'2020-12-10 00:00:00',38,1,NULL,'delivered'),(10,2500,'2020-12-15 00:00:00',38,1,NULL,'pending');
/*!40000 ALTER TABLE `money_delivered` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification`
--

DROP TABLE IF EXISTS `notification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification` (
  `idnotification` int NOT NULL AUTO_INCREMENT,
  `sender-id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `receiver-id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `message` varchar(1000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idnotification`),
  KEY `sender-id_idx` (`sender-id`),
  KEY `receiver-id_idx` (`receiver-id`),
  CONSTRAINT `reciever_not_id` FOREIGN KEY (`receiver-id`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `sender_not_id` FOREIGN KEY (`sender-id`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification`
--

LOCK TABLES `notification` WRITE;
/*!40000 ALTER TABLE `notification` DISABLE KEYS */;
/*!40000 ALTER TABLE `notification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `photo`
--

DROP TABLE IF EXISTS `photo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `photo` (
  `idphoto` int NOT NULL AUTO_INCREMENT,
  `path` varchar(1000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `project_id` int DEFAULT NULL,
  PRIMARY KEY (`idphoto`),
  KEY `project_id` (`project_id`),
  CONSTRAINT `photo_project_id_fk` FOREIGN KEY (`project_id`) REFERENCES `project` (`idproject`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `photo`
--

LOCK TABLES `photo` WRITE;
/*!40000 ALTER TABLE `photo` DISABLE KEYS */;
/*!40000 ALTER TABLE `photo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `idproduct` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `price` double DEFAULT NULL,
  PRIMARY KEY (`idproduct`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'OPC BULK',10),(2,'PMC BAG',100),(3,'OPC BAG',200),(4,'SRC BULK',300);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production`
--

DROP TABLE IF EXISTS `production`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production` (
  `idproduction` int NOT NULL AUTO_INCREMENT,
  `IdProduct` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`idproduction`),
  KEY `product_id_idx` (`IdProduct`),
  CONSTRAINT `IdProduct` FOREIGN KEY (`IdProduct`) REFERENCES `product` (`idproduct`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production`
--

LOCK TABLES `production` WRITE;
/*!40000 ALTER TABLE `production` DISABLE KEYS */;
INSERT INTO `production` VALUES (1,1,45,'2020-10-20'),(2,1,45,'2020-10-20'),(3,1,45,'2020-10-20'),(4,NULL,45,'2020-10-20'),(5,1,45,'2020-10-20'),(6,1,45,'2020-10-20'),(7,1,45,'2020-10-20'),(8,1,45,'2020-10-20'),(9,2,45,'2020-11-20'),(10,3,45,'2020-12-20'),(11,4,45,'2020-09-20'),(12,2,40,'2020-11-14');
/*!40000 ALTER TABLE `production` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `idproject` int NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `owner` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `location` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `space` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cost` double DEFAULT NULL,
  `contractor` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `consultant` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `details` text CHARACTER SET utf8 COLLATE utf8_bin,
  `notes` text CHARACTER SET utf8 COLLATE utf8_bin,
  `information_source` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idproject`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `idQuestions` int NOT NULL AUTO_INCREMENT,
  `question_text` text CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`idQuestions`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'Did you find your requierments in Yamama company ?'),(2,'Did you find the prices appropriate ?'),(3,'Does the cement type meet expections ?'),(4,'Are you satisfied with the company\'s performance ? ');
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_information`
--

DROP TABLE IF EXISTS `request_information`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `request_information` (
  `idrequest_information` int NOT NULL AUTO_INCREMENT,
  `notes` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `file_id` int DEFAULT NULL,
  `task_id` int DEFAULT NULL,
  `sender_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `reciever_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idrequest_information`),
  KEY `file_id` (`file_id`),
  KEY `task_id` (`task_id`),
  KEY `reciever_id` (`reciever_id`) /*!80000 INVISIBLE */,
  KEY `sender_id` (`sender_id`),
  CONSTRAINT `file_id_info_fk` FOREIGN KEY (`file_id`) REFERENCES `file` (`idfile`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reciever_info_fk` FOREIGN KEY (`reciever_id`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `sender_info_fk` FOREIGN KEY (`sender_id`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `task_id_info_fk` FOREIGN KEY (`task_id`) REFERENCES `task` (`idtask`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_information`
--

LOCK TABLES `request_information` WRITE;
/*!40000 ALTER TABLE `request_information` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_information` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `store`
--

DROP TABLE IF EXISTS `store`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `store` (
  `idstore` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `pro_id` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  PRIMARY KEY (`idstore`),
  KEY `product_id` (`pro_id`),
  CONSTRAINT `FK_Product_store` FOREIGN KEY (`pro_id`) REFERENCES `product` (`idproduct`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `store`
--

LOCK TABLES `store` WRITE;
/*!40000 ALTER TABLE `store` DISABLE KEYS */;
INSERT INTO `store` VALUES (1,'store1',1,575),(2,'store1',2,165),(3,'store1',3,65),(4,'store1',4,125);
/*!40000 ALTER TABLE `store` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `target`
--

DROP TABLE IF EXISTS `target`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `target` (
  `idtarget` int NOT NULL AUTO_INCREMENT,
  `salesmanId` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `visits` int DEFAULT NULL,
  `sales` int DEFAULT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`idtarget`),
  KEY `salesmanId_idx` (`salesmanId`),
  CONSTRAINT `salesmanId_fk` FOREIGN KEY (`salesmanId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `target`
--

LOCK TABLES `target` WRITE;
/*!40000 ALTER TABLE `target` DISABLE KEYS */;
/*!40000 ALTER TABLE `target` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task` (
  `idtask` int NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `type_id` int DEFAULT NULL,
  `status_id` int DEFAULT NULL,
  `responsible_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `creator_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `content` varchar(1000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `file_id` int DEFAULT NULL,
  `photo_id` int DEFAULT NULL,
  PRIMARY KEY (`idtask`),
  KEY `type_id` (`type_id`),
  KEY `status_id` (`status_id`),
  KEY `file_id_idx` (`file_id`),
  KEY `photo_id_idx` (`photo_id`),
  KEY `creator_id` (`creator_id`),
  KEY `responsible_id` (`responsible_id`),
  CONSTRAINT `file_id` FOREIGN KEY (`file_id`) REFERENCES `file` (`idfile`),
  CONSTRAINT `photo_id` FOREIGN KEY (`photo_id`) REFERENCES `photo` (`idphoto`),
  CONSTRAINT `status_id_fk` FOREIGN KEY (`status_id`) REFERENCES `task_status` (`idtask_status`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `task_creator_fk` FOREIGN KEY (`creator_id`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `task_responsible_fk` FOREIGN KEY (`responsible_id`) REFERENCES `aspnetusers` (`Id`),
  CONSTRAINT `type_id_fk` FOREIGN KEY (`type_id`) REFERENCES `task_type` (`idtask_type`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task`
--

LOCK TABLES `task` WRITE;
/*!40000 ALTER TABLE `task` DISABLE KEYS */;
/*!40000 ALTER TABLE `task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task_status`
--

DROP TABLE IF EXISTS `task_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task_status` (
  `idtask_status` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idtask_status`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task_status`
--

LOCK TABLES `task_status` WRITE;
/*!40000 ALTER TABLE `task_status` DISABLE KEYS */;
/*!40000 ALTER TABLE `task_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task_type`
--

DROP TABLE IF EXISTS `task_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task_type` (
  `idtask_type` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idtask_type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task_type`
--

LOCK TABLES `task_type` WRITE;
/*!40000 ALTER TABLE `task_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `task_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transporter`
--

DROP TABLE IF EXISTS `transporter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transporter` (
  `idtransporter` int NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `transporter_num` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idtransporter`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transporter`
--

LOCK TABLES `transporter` WRITE;
/*!40000 ALTER TABLE `transporter` DISABLE KEYS */;
INSERT INTO `transporter` VALUES (1,NULL,NULL);
/*!40000 ALTER TABLE `transporter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visit`
--

DROP TABLE IF EXISTS `visit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visit` (
  `idvisit` int NOT NULL AUTO_INCREMENT,
  `factory_id` int DEFAULT NULL,
  `project_id` int DEFAULT NULL,
  `task_id` int DEFAULT NULL,
  `gifts` int DEFAULT NULL,
  `notes` varchar(1000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `User_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`idvisit`),
  KEY `factory_id` (`factory_id`) /*!80000 INVISIBLE */,
  KEY `project_id` (`project_id`),
  KEY `task_id` (`task_id`),
  KEY `user_id` (`User_id`),
  CONSTRAINT `factory_id_fk` FOREIGN KEY (`factory_id`) REFERENCES `factory` (`idfactory`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `project_id_fk` FOREIGN KEY (`project_id`) REFERENCES `project` (`idproject`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `task_id_fk` FOREIGN KEY (`task_id`) REFERENCES `task` (`idtask`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `user_visit_fk` FOREIGN KEY (`User_id`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visit`
--

LOCK TABLES `visit` WRITE;
/*!40000 ALTER TABLE `visit` DISABLE KEYS */;
/*!40000 ALTER TABLE `visit` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-15 10:27:22
