-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 24, 2018 at 09:49 PM
-- Server version: 10.1.31-MariaDB
-- PHP Version: 7.2.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jkm_baig`
--

-- --------------------------------------------------------

--
-- Table structure for table `ben_33`
--

CREATE TABLE `ben_33` (
  `kmokid` int(11) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Administravimo išlaidos` double NOT NULL,
  `Laiptinės langų valymas (67.69 x 0.1186)` double NOT NULL,
  `Atliekų išvežimas (65.69 x  0.0536)` double NOT NULL,
  `Patalpų valymas (65.69 x  0.0737)` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `ben_34`
--

CREATE TABLE `ben_34` (
  `kmokid` int(11) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Langų valymas` double NOT NULL,
  `Administravimo išlaidos` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `ben_35`
--

CREATE TABLE `ben_35` (
  `kmokid` int(11) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Administravimo išlaidos` double NOT NULL,
  `Bendro kiemo palaikymas` double NOT NULL,
  `Lifto elektra` double NOT NULL,
  `Parkingas` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `nuomininkai`
--

CREATE TABLE `nuomininkai` (
  `nid` int(11) NOT NULL,
  `vard` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL,
  `pav` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL,
  `tel_num` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL,
  `email` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL,
  `asm_kod` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL,
  `dek_gyv` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nuomininkai`
--

INSERT INTO `nuomininkai` (`nid`, `vard`, `pav`, `tel_num`, `email`, `asm_kod`, `dek_gyv`) VALUES
(40, 'Dionizas', 'Veiksa', '8 (686) 65231', ' asdf@gmail.com', '7735463323 ', ' Vaidoto g. 40, LT-76137, Šiaulių m. sav.'),
(41, 'Augustas', 'Bradauskas', '8 (686) 86662', ' asdf1@gmail.com', '1170512481 ', 'Ozo g. 25, LT-07150, Vilniaus m. sav. (PC Akropolis)'),
(42, 'Leopoldas', 'Dubauskas', '8 (5) 2464157', ' asdf123@gmail.com', '1250982760 ', 'Ozo g. 25, LT-01001, Vilniaus m. sav.'),
(43, 'Leonarda ', 'Remeikaite', '8 (5) 2630726', '1234@gmail.com', '3136293130 ', 'Erfurto g. 46-71, LT-04102, Vilniaus m. sav.'),
(44, 'Žiede', 'Leikauskaite', '8 (37) 330151', '1235555@gmail.com', '3402523829 ', 'Savanorių pr. 163, LT-50174, Kauno m. sav.'),
(45, 'Eleonora', 'Opcikaite', '8 (41) 525044', 'labas@gmail.com', '7743270428', 'Dvaro g. 79, LT-76299, Šiaulių m. sav.');

-- --------------------------------------------------------

--
-- Table structure for table `objektai`
--

CREATE TABLE `objektai` (
  `obid` int(11) NOT NULL,
  `ob_addr` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL,
  `ob_kvad` double NOT NULL,
  `Nuoma` double NOT NULL,
  `corr_nid` int(11) NOT NULL,
  `ce_oid` int(11) NOT NULL,
  `cd_oid` int(11) NOT NULL,
  `cv_oid` int(11) NOT NULL,
  `ci_oid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `objektai`
--

INSERT INTO `objektai` (`obid`, `ob_addr`, `ob_kvad`, `Nuoma`, `corr_nid`, `ce_oid`, `cd_oid`, `cv_oid`, `ci_oid`) VALUES
(33, ' H. Manto g. 22, LT-92131, Klaipėdos m. sav. (PC Akropolis)', 65.69, 465, 41, 44, 41, 39, 49),
(34, 'Konstitucijos pr. 16, LT-09308, Vilniaus m. sav. (2 aukštas)', 82.95, 560, 40, 45, 42, 39, 47),
(35, 'Kedrų g. 6, LT-03117, Vilniaus m. sav.', 23.25, 120, 43, 45, 42, 40, 48);

-- --------------------------------------------------------

--
-- Table structure for table `operatoriai`
--

CREATE TABLE `operatoriai` (
  `oid` int(11) NOT NULL,
  `op_pav` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL,
  `op_type` text CHARACTER SET utf16 COLLATE utf16_lithuanian_ci NOT NULL,
  `op_rate` double NOT NULL,
  `last_updated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `operatoriai`
--

INSERT INTO `operatoriai` (`oid`, `op_pav`, `op_type`, `op_rate`, `last_updated`) VALUES
(38, 'Klaipėdos vandenėlis', 'Vanduo', 9.32, '2018-04-22 16:01:36'),
(39, 'Kauno Vandenys', 'Vanduo', 0.74, '2018-04-24 18:39:12'),
(40, 'ESO (vanduo)', 'Vanduo', 16, '2018-04-22 16:02:05'),
(41, 'ESO (dujos)', 'Dujos', 0.39, '2018-04-24 18:39:46'),
(42, 'Gazprom', 'Dujos', 10.13, '2018-04-22 16:02:25'),
(43, 'Vilniaus dujotekis', 'Dujos', 14.5, '2018-04-22 16:02:51'),
(44, 'ESO (elektra)', 'Elektra', 0.113, '2018-04-24 18:39:32'),
(45, 'Vilniaus energija', 'Elektra', 6, '2018-04-22 16:03:55'),
(46, 'AB Achema', 'Elektra', 12, '2018-04-22 16:04:32'),
(47, 'Telia (bazinis šviesolaidis)', 'Internetas', 9.9, '2018-04-22 16:05:53'),
(48, 'Telia (optimalus plius)', 'Internetas', 18.9, '2018-04-22 16:06:12'),
(49, 'Init (maksi)', 'Internetas', 9.5, '2018-04-22 16:06:48');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ben_33`
--
ALTER TABLE `ben_33`
  ADD PRIMARY KEY (`kmokid`);

--
-- Indexes for table `ben_34`
--
ALTER TABLE `ben_34`
  ADD PRIMARY KEY (`kmokid`);

--
-- Indexes for table `ben_35`
--
ALTER TABLE `ben_35`
  ADD PRIMARY KEY (`kmokid`);

--
-- Indexes for table `nuomininkai`
--
ALTER TABLE `nuomininkai`
  ADD PRIMARY KEY (`nid`);

--
-- Indexes for table `objektai`
--
ALTER TABLE `objektai`
  ADD PRIMARY KEY (`obid`);

--
-- Indexes for table `operatoriai`
--
ALTER TABLE `operatoriai`
  ADD PRIMARY KEY (`oid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ben_33`
--
ALTER TABLE `ben_33`
  MODIFY `kmokid` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ben_34`
--
ALTER TABLE `ben_34`
  MODIFY `kmokid` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ben_35`
--
ALTER TABLE `ben_35`
  MODIFY `kmokid` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `nuomininkai`
--
ALTER TABLE `nuomininkai`
  MODIFY `nid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `objektai`
--
ALTER TABLE `objektai`
  MODIFY `obid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT for table `operatoriai`
--
ALTER TABLE `operatoriai`
  MODIFY `oid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
