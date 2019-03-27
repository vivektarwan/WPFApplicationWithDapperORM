-- --------------------------------------------------------
-- Host:                         192.168.10.17
-- Server version:               10.3.9-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for test
CREATE DATABASE IF NOT EXISTS `test` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `test`;

-- Dumping structure for table test.space
CREATE TABLE IF NOT EXISTS `space` (
  `Name` varchar(50) DEFAULT NULL,
  `Type` int(11) DEFAULT 0,
  `No_of_floors` int(11) DEFAULT 0,
  `No_of_seats` int(11) DEFAULT 0,
  `No_of_rooms` int(11) DEFAULT 0,
  `No_of_kitchens` int(11) DEFAULT 0,
  `No_of_toilets` int(11) DEFAULT 0,
  `No_of_cabins` int(11) DEFAULT 0,
  `SquareFeet` int(11) DEFAULT 1,
  `Space_ID` int(11) NOT NULL AUTO_INCREMENT,
  KEY `Index 1` (`Space_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
