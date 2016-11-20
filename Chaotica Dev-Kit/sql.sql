-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.7.14


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema chaoticakit
--

CREATE DATABASE IF NOT EXISTS chaoticakit;
USE chaoticakit;

--
-- Definition of table `bugs`
--

DROP TABLE IF EXISTS `bugs`;
CREATE TABLE `bugs` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `PID` int(10) unsigned NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Description` text NOT NULL,
  `priority` int(10) unsigned NOT NULL,
  `resolved` tinyint(1) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bugs`
--

/*!40000 ALTER TABLE `bugs` DISABLE KEYS */;
INSERT INTO `bugs` (`ID`,`PID`,`Title`,`Description`,`priority`,`resolved`,`timestamp`) VALUES 
 (1,1,'Test','This is a bug report',0,0,'2016-11-20 08:26:35');
/*!40000 ALTER TABLE `bugs` ENABLE KEYS */;


--
-- Definition of table `projects`
--

DROP TABLE IF EXISTS `projects`;
CREATE TABLE `projects` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `projects`
--

/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` (`ID`,`Title`) VALUES 
 (1,'Example Project'),
 (2,'Chaotica Dev-Kit'),
 (26,'Montray Davis'),
 (27,'Example Project 3');
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
