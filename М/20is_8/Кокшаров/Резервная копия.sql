-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: 172.17.4.11    Database: 20is_8
-- ------------------------------------------------------
-- Server version	8.0.26

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
  `orderstatus` varchar(50) NOT NULL,
  `paymentstatus` varchar(50) NOT NULL,
  `paymentmethod` varchar(50) NOT NULL,
  `datecreation` date NOT NULL,
  `addres` varchar(50) NOT NULL,
  PRIMARY KEY (`orderid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,'готовится','принят','наличные','2023-06-06','Россия, г. Тамбов, Социалистическая ул., д. 6'),(2,'готов','оплачен','наличные','2023-06-07','Россия, г. Ангарск, Комсомольская ул., д. 13'),(3,'готовится','принят','ипотека','2023-06-08','Россия, г. Щёлково, Центральная ул., д. 5'),(4,'готов','оплачен','ипотека','2023-06-09','Россия, г. Петропавловск-Камчатский, Вокзальная ул'),(5,'готов','принят','наличные','2023-06-10','Россия, г. Самара, Цветочная ул., д. 21');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderpersonlist`
--

DROP TABLE IF EXISTS `orderpersonlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderpersonlist` (
  `orderuserlistid` int NOT NULL AUTO_INCREMENT,
  `personrid` int NOT NULL,
  `orderid` int NOT NULL,
  PRIMARY KEY (`orderuserlistid`),
  KEY `orderpersonlist___fk` (`personrid`),
  KEY `orderpersonlist___fk_2` (`orderid`),
  CONSTRAINT `orderpersonlist___fk` FOREIGN KEY (`personrid`) REFERENCES `person` (`personid`),
  CONSTRAINT `orderpersonlist___fk_2` FOREIGN KEY (`orderid`) REFERENCES `order` (`orderid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderpersonlist`
--

LOCK TABLES `orderpersonlist` WRITE;
/*!40000 ALTER TABLE `orderpersonlist` DISABLE KEYS */;
INSERT INTO `orderpersonlist` VALUES (1,1,1),(2,2,2),(3,3,3);
/*!40000 ALTER TABLE `orderpersonlist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `person` (
  `personid` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `middlename` varchar(50) DEFAULT NULL,
  `personrole` varchar(50) NOT NULL,
  PRIMARY KEY (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'Николай','Селиванов','Даниилович','Пользователь'),(2,'Никита','Афанасьев','Львович','Пользователь'),(3,'Мария','Кириллова','Львовна','Пользователь'),(4,'Анна','Савина','Серафимовна','Пользователь'),(5,'Алиса','Зайцева','Адамовна','Пользователь'),(6,'Степан','Фадеев','Романович','Пользователь'),(7,'Ева','Яковлева','Максимовна','Пользователь'),(8,'Станислав','Зиновьев','Демидович','Пользователь'),(9,'Андрей','Корнев','Ильич','Пользователь'),(10,'Иван','Кондрашов','Даниилович','Пользователь'),(11,'Александр','Ульянов','Даниилович','Клиент'),(12,'Милана','Карпова','Вячеславовна','Клиент'),(13,'Иван','Коротков','Иванович','Клиент'),(14,'София','Черная','Марковна','Клиент'),(15,'Сафия','Дементьева','Матвеевна','Клиент');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
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
  `userroleid` int NOT NULL,
  `personid` int NOT NULL,
  PRIMARY KEY (`userid`),
  KEY `user___fk` (`userroleid`),
  KEY `user___fk_2` (`personid`),
  CONSTRAINT `user___fk` FOREIGN KEY (`userroleid`) REFERENCES `userrole` (`userroleid`),
  CONSTRAINT `user___fk_2` FOREIGN KEY (`personid`) REFERENCES `person` (`personid`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'rubies','cmjcFvB3cI','Уволен',2,1),(2,'windle','2PAUAd0gMZ','Работает',1,2),(3,'improv','bcFFGU16f6','Уволен',1,3),(4,'moving','A8HPZz9HTG','Работает',2,4),(5,'bellum','ZjXm3JW7RJ','Работает',3,5),(6,'siller','dVMfx1VMFF','Работает',3,6),(7,'ragman','25Y9oOkwHn','Работает',2,7),(8,'fautor','RJ41C0qynP','Работает',3,8),(9,'coated','8g2FubQVZH','Уволен',3,9),(10,'fiches','LO1qRB42GP','Уволен',1,10);
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
INSERT INTO `userrole` VALUES (1,'Администратор'),(2,'Риелтор'),(3,'Юрист');
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

-- Dump completed on 2024-06-22  8:25:59
