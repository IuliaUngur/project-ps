-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 09, 2016 at 11:29 AM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `desk_bank`
--

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE IF NOT EXISTS `clients` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `cnp` int(11) NOT NULL,
  `address` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cnp` (`cnp`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`, `cnp`, `address`) VALUES
(1, 'testtest fqwf d', 1234567890, 'snoop doggster d'),
(3, 'dogy pow', 1234567899, 'snoop dogy house'),
(4, 'eee', 1234567889, 'snoop doggster'),
(5, 'testtest fqwf d', 1234567882, 'snoop doggster d'),
(6, 'testtest fqwf d', 1234567886, 'snoop doggster d'),
(7, 'testtest fqwf d', 1234567888, 'snoop doggster d'),
(8, 'patty doggy dog', 987654321, 'doggy dogs house'),
(9, 'rapunzel', 347639, 'Disney Land, Paris, France'),
(11, 'didney', 123765, 'didney land pauis fance'),
(14, 'test', 3476392, 'tet');

-- --------------------------------------------------------

--
-- Table structure for table `client_accounts`
--

CREATE TABLE IF NOT EXISTS `client_accounts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` int(11) NOT NULL,
  `money_amount` int(11) NOT NULL,
  `created_on` datetime NOT NULL,
  `owner_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `owner_id` (`owner_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=34 ;

--
-- Dumping data for table `client_accounts`
--

INSERT INTO `client_accounts` (`id`, `type`, `money_amount`, `created_on`, `owner_id`) VALUES
(32, 1, 12565, '2016-04-23 12:08:56', 1234567899),
(33, 0, 0, '2016-04-09 12:18:55', 1234567899);

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE IF NOT EXISTS `employees` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `type` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user_name` (`user_name`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`id`, `user_name`, `password`, `type`) VALUES
(1, 'iuli', 'pwd', 1),
(3, 'test', 'test', 1);

-- --------------------------------------------------------

--
-- Table structure for table `employee_activities`
--

CREATE TABLE IF NOT EXISTS `employee_activities` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` int(11) NOT NULL,
  `date` date NOT NULL,
  `employee_id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `client_accounts`
--
ALTER TABLE `client_accounts`
  ADD CONSTRAINT `client_accounts_ibfk_1` FOREIGN KEY (`owner_id`) REFERENCES `clients` (`cnp`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
