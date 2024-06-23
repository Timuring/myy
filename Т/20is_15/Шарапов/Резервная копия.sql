-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: service
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `orderid` int NOT NULL AUTO_INCREMENT,
  `datecreation` date NOT NULL,
  `orderstatus` varchar(50) NOT NULL,
  `paymentstatus` varchar(50) NOT NULL,
  `carelement` varchar(50) NOT NULL,
  `details` varchar(50) NOT NULL,
  `amountdamage` int NOT NULL,
  `liquids` varchar(50) NOT NULL,
  PRIMARY KEY (`orderid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,'2023-06-06','готовится','принят','блок воздуходувки','мотор вентилятора',1,'отсутствуют'),(2,'2023-06-07','готов','оплачен','топливный инжектор','уплотнительные кольца',8,'отсутствуют'),(3,'2023-06-09','готов','оплачен','электрооборудование','генератор',1,'отсутствуют'),(4,'2023-06-10','готов','принят','передняя часть двигателя','рем комлект ГРМ',1,'моторное масло'),(5,'2023-06-08','готовится','принят','система охлаждения двигателя','насос водяной',1,'антифриз');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderuserlist`
--

DROP TABLE IF EXISTS `orderuserlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderuserlist` (
  `orderuserlistid` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `orderid` int NOT NULL,
  PRIMARY KEY (`orderuserlistid`),
  KEY `orderuserlist___fk` (`userid`),
  KEY `orderuserlist___fk2` (`orderid`),
  CONSTRAINT `orderuserlist___fk` FOREIGN KEY (`userid`) REFERENCES `user` (`userid`),
  CONSTRAINT `orderuserlist___fk2` FOREIGN KEY (`orderid`) REFERENCES `order` (`orderid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderuserlist`
--

LOCK TABLES `orderuserlist` WRITE;
/*!40000 ALTER TABLE `orderuserlist` DISABLE KEYS */;
INSERT INTO `orderuserlist` VALUES (1,5,1),(2,6,2),(3,8,3),(4,5,4),(5,6,5);
/*!40000 ALTER TABLE `orderuserlist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shift`
--

DROP TABLE IF EXISTS `shift`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shift` (
  `shiftid` int NOT NULL AUTO_INCREMENT,
  `datestart` date NOT NULL,
  `dateend` date NOT NULL,
  PRIMARY KEY (`shiftid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shift`
--

LOCK TABLES `shift` WRITE;
/*!40000 ALTER TABLE `shift` DISABLE KEYS */;
INSERT INTO `shift` VALUES (1,'2024-05-05','2024-05-08'),(2,'2024-05-06','2024-05-07'),(3,'2024-05-01','2024-05-11');
/*!40000 ALTER TABLE `shift` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `userid` int NOT NULL AUTO_INCREMENT,
  `login` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  `lastname` varchar(50) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) DEFAULT NULL,
  `userroleid` int DEFAULT NULL,
  PRIMARY KEY (`userid`),
  KEY `user___fk` (`userroleid`),
  CONSTRAINT `user___fk` FOREIGN KEY (`userroleid`) REFERENCES `userrole` (`userroleid`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'rubies','cmjcFvB3cI','Уволен','Селиванов','Николай','Даниилович',1),(2,'windle','2PAUAd0gMZ','Работает','Афанасьев','Никита','Львович',2),(3,'improv','bcFFGU16f6','Уволен','Кириллова','Мария','Львовна',2),(4,'moving','A8HPZz9HTG','Работает','Савина','Анна','Серафимовна',1),(5,'bellum','ZjXm3JW7RJ','Работает','Зайцева','Алиса','Адамовна',3),(6,'siller','dVMfx1VMFF','Работает','Фадеев','Степан','Романович',3),(7,'ragman','25Y9oOkwHn','Работает','Яковлева','Ева','Максимовна',1),(8,'fautor','RJ41C0qynP','Работает','Зиновьев','Станислав','Демидович',3),(9,'coated','8g2FubQVZH','Уволен','Корнев','Андрей','Ильич',1),(10,'fiches','LO1qRB42GP','Уволен','Кондрашов','Иван','Даниилович',2),(13,'login','pass','Работает','Шарапов','Тимур','Ильдарович',2);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userlist`
--

DROP TABLE IF EXISTS `userlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userlist` (
  `userlistid` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `shiftid` int NOT NULL,
  PRIMARY KEY (`userlistid`),
  KEY `userlist___fk` (`userid`),
  KEY `userlist___fk2` (`shiftid`),
  CONSTRAINT `userlist___fk` FOREIGN KEY (`userid`) REFERENCES `user` (`userid`),
  CONSTRAINT `userlist___fk2` FOREIGN KEY (`shiftid`) REFERENCES `shift` (`shiftid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userlist`
--

LOCK TABLES `userlist` WRITE;
/*!40000 ALTER TABLE `userlist` DISABLE KEYS */;
INSERT INTO `userlist` VALUES (1,1,3),(2,2,2),(3,3,1);
/*!40000 ALTER TABLE `userlist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userrole`
--

DROP TABLE IF EXISTS `userrole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userrole` (
  `userroleid` int NOT NULL AUTO_INCREMENT,
  `namerole` varchar(50) NOT NULL,
  PRIMARY KEY (`userroleid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userrole`
--

LOCK TABLES `userrole` WRITE;
/*!40000 ALTER TABLE `userrole` DISABLE KEYS */;
INSERT INTO `userrole` VALUES (1,'Автомеханик'),(2,'Мастер приемщик'),(3,'Автодиагност');
/*!40000 ALTER TABLE `userrole` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-24  4:10:23
