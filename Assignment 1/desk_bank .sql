-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 09, 2016 at 08:44 PM
-- Server version: 10.1.10-MariaDB
-- PHP Version: 5.5.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `desk_bank`
--

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `cnp` int(11) NOT NULL,
  `address` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

CREATE TABLE `client_accounts` (
  `id` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `money_amount` int(11) NOT NULL,
  `created_on` datetime NOT NULL,
  `owner_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

CREATE TABLE `employees` (
  `id` int(11) NOT NULL,
  `user_name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`id`, `user_name`, `password`, `type`) VALUES
(3, 'admin', 'admin', 0),
(6, 'iuli', 'pwd2', 1);

-- --------------------------------------------------------

--
-- Table structure for table `employee_activities`
--

CREATE TABLE `employee_activities` (
  `id` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `employee_id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee_activities`
--

INSERT INTO `employee_activities` (`id`, `type`, `date`, `employee_id`, `description`) VALUES
(1, 0, '2016-04-13 00:00:00', 6, 'Some employee description'),
(2, 14, '2016-04-09 19:24:26', 3, 'Added employee with user name: testt ( password: testt, type: 1)'),
(3, 13, '2016-04-09 19:24:39', 3, 'Deleted employee with user name: testt'),
(4, 12, '2016-04-09 19:24:48', 3, 'Updated employee user name: iuli ( password: pwd2, type: 1)');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `cnp` (`cnp`);

--
-- Indexes for table `client_accounts`
--
ALTER TABLE `client_accounts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `owner_id` (`owner_id`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `user_name` (`user_name`);

--
-- Indexes for table `employee_activities`
--
ALTER TABLE `employee_activities`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT for table `client_accounts`
--
ALTER TABLE `client_accounts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `employee_activities`
--
ALTER TABLE `employee_activities`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
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
