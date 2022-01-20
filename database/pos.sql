-- phpMyAdmin SQL Dump
-- version 3.5.0
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Oct 02, 2012 at 08:03 PM
-- Server version: 5.0.88-community-nt
-- PHP Version: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `pos`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE IF NOT EXISTS `barang` (
  `Id_barang` varchar(10) character set latin1 NOT NULL default '',
  `nm_barang` varchar(60) character set latin1 default NULL,
  `jns_barang` varchar(50) character set latin1 default NULL,
  `ukrn_barang` varchar(10) character set latin1 default NULL,
  `kmsn_barang` varchar(20) character set latin1 default NULL,
  `stok_barang` int(11) default NULL,
  `hrg_barang` double default NULL,
  `ket_barang` varchar(255) character set latin1 default NULL,
  PRIMARY KEY  (`Id_barang`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`Id_barang`, `nm_barang`, `jns_barang`, `ukrn_barang`, `kmsn_barang`, `stok_barang`, `hrg_barang`, `ket_barang`) VALUES
('ADC-000001', 'Sparkling Acne Day Cream 10gr', 'Acne Day Cream', '10gr', 'Box', 999, 90000, 'Sparkling Acne Day Cream 10gr'),
('AFW-000001', 'Sparkling Acne Facial Wash 100ml', 'Acne Facial Wash', '100ml', 'Box', 999, 75000, 'Sparkling Acne Facial Wash 100ml'),
('ANC-000001', 'Sparkling Acne Night Cream 10gr', 'Acne Night Cream', '10gr', 'Box', 999, 105000, 'Sparkling Acne Night Cream 10gr'),
('ASC-000001', 'Sparkling Acne Spot Cream 5gr', 'Acne Spot Cream', '5gr', 'Box', 999, 60000, 'Sparkling Acne Spot Cream 5gr'),
('BLP-000001', 'Sparkling Brightening Lip Cream', 'Brightening Lip Cream', '-', 'Box', 999, 45000, 'Sparkling Brightening Lip Cream'),
('DBR-000001', 'Sparkling Daily Bright Serum', 'Daily Bright Serum', '-', 'Botol', 999, 125000, 'Sparkling Daily Bright Serum'),
('DCR-000001', 'Sparkling Day Cream 10gr', 'Day Cream', '10gr', 'Box', 999, 90000, 'Sparkling Day Cream 10gr'),
('DLT-000001', 'Sparkling Day Lotion 100ml', 'Day Lotion', '100ml', 'Botol', 999, 100, 'Sparkling Day Lotion 100ml'),
('NCR-000001', 'Sparkling Night Cream 10gr', 'Night Cream', '10gr', 'Box', 999, 105000, 'Sparkling Night Cream 10gr'),
('NLT-000001', 'Sparkling Night Lotion 100 ml', 'Night Lotion', '100 ml', 'Box', 999, 150000, 'Sparkling Night Lotion 100 ml'),
('PKT-ACNE', 'Paket Acne ', 'Paket Acne ', '-', 'Box', 999, 270000, 'Acne Night Cream + Acne Day Cream + Acne Facial Wash + Acne Spot Cream'),
('PKT-BASIC', 'Paket Basic', 'Paket Basic', '-', 'Box', 999, 230000, 'Night Cream + Day Cream + Facial Wash'),
('PKT-LOTION', 'Paket Lotion', 'Paket Lotion', '-', 'Box', 999, 250000, 'Day Lotion 100ml + Night Lotion 100ml'),
('PKT-SERUM', 'Paket Serum', 'Paket Serum', '-', 'Box', 999, 415000, 'Night Cream + Day Cream + Facial Wash + Toner + Daily Bright Serum'),
('PKT-TONER', 'Paket Toner', 'Paket Toner', '-', 'Box', 999, 300000, 'Night Cream + Day Cream + Facial Wash + Toner'),
('SCR-000001', 'Sparkling Sensitive Care', 'Sensitive Care', '-', 'Box', 999, 90000, 'Sparkling Sensitive Care'),
('SEG-000001', 'Sparkling Eye Gel + Vit C 10gr', 'Sparkling Eye Gel', '10gr', 'Box', 999, 65000, 'Sparkling Eye Gel + Vit C 10gr'),
('SFW-000001', 'Sparkling Facial Wash 100ml', 'Facial Wash', '100ml', 'Box', 999, 75000, 'Sparkling Facial Wash 100ml'),
('STN-000001', 'Sparkling Toner', 'Toner', '-', 'Box', 999, 85000, 'Sparkling Toner');

-- --------------------------------------------------------

--
-- Table structure for table `diskon`
--

CREATE TABLE IF NOT EXISTS `diskon` (
  `Id` int(11) NOT NULL auto_increment,
  `nama` varchar(50) default NULL,
  `jenis` varchar(10) default NULL,
  `jml` double default NULL,
  PRIMARY KEY  (`Id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=16 ;

--
-- Dumping data for table `diskon`
--

INSERT INTO `diskon` (`Id`, `nama`, `jenis`, `jml`) VALUES
(1, 'Diskon 5%', 'persentase', 0.05),
(2, 'Diskon 10%', 'persentase', 0.1),
(3, 'Diskon 15%', 'persentase', 0.15),
(4, 'Voucher Rp. 50.000', 'voucher', 50000),
(5, 'Voucher Rp.100.000', 'voucher', 100000),
(6, 'Diskon 20%', 'persentase', 0.2),
(7, 'Diskon 25%', 'persentase', 0.25),
(8, 'Diskon 30%', 'persentase', 0.3),
(9, 'Diskon 35%', 'persentase', 0.35),
(10, 'Diskon 40%', 'persentase', 0.4),
(11, 'Diskon 45%', 'persentase', 0.45),
(12, 'Diskon 50%', 'persentase', 0.5),
(13, 'Voucher Rp. 150.000', 'voucher', 150000),
(14, 'Voucher Rp. 200.000', 'voucher', 200000),
(15, 'Voucher Rp. 300.000', 'voucher', 300000);

-- --------------------------------------------------------

--
-- Table structure for table `faktur`
--

CREATE TABLE IF NOT EXISTS `faktur` (
  `no_faktur` varchar(16) character set latin1 NOT NULL default '',
  `tgl_faktur` date default NULL,
  `atas_nama` varchar(30) character set latin1 default NULL,
  `dgn_telp` varchar(14) character set latin1 default NULL,
  `nama_user` varchar(20) character set latin1 default NULL,
  PRIMARY KEY  (`no_faktur`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `faktur`
--

INSERT INTO `faktur` (`no_faktur`, `tgl_faktur`, `atas_nama`, `dgn_telp`, `nama_user`) VALUES
('2012091700001', '2012-09-17', 'test', '1', ''),
('K012012091200001', '2012-09-12', 'test', '12321', NULL),
('K012012091200002', '2012-09-12', 'dffu', '07686', NULL),
('K012012091200003', '2012-09-12', 'kkm', '0909', 'admin'),
('K012012091700001', '2012-09-17', 'aaa', '1', 'admin'),
('K012012092300001', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300002', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300003', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300004', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300005', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300006', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300007', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300008', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300009', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300010', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300011', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300012', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300013', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300014', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300015', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300016', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300017', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300018', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300019', '2012-09-23', 'Hilmi', '081310156503', 'Yusuf'),
('K012012092300020', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300021', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300022', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300023', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300024', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300025', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300026', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300027', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300028', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300029', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300030', '2012-09-23', 'Yusuf awaludin', '7315533', 'Yusuf'),
('K012012092300031', '2012-09-23', 'Guest', '', 'Yusuf'),
('K012012092300032', '2012-09-23', 'Yusuf awaludin', '7315533', 'Yusuf'),
('K012012092400001', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400002', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400003', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400004', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400005', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400006', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400007', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400008', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400009', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400010', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400011', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400012', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400013', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400014', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400015', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400016', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400017', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400018', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400019', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400020', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400021', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400022', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400023', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400024', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400025', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400026', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400027', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400028', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400029', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400030', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400031', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400032', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400033', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400034', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400035', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400036', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400037', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400038', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400039', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400040', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400041', '2012-09-24', 'Hilmi', '0816545667788', 'Yusuf'),
('K012012092400042', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400043', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400044', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400045', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400046', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400047', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400048', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400049', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400050', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400051', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400052', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400053', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400054', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400055', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400056', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400057', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400058', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092400059', '2012-09-24', 'Guest', '', 'Yusuf'),
('K012012092500001', '2012-09-25', 'Guest', '', 'Yusuf'),
('K012012092500002', '2012-09-25', 'Guest', '', 'Yusuf'),
('K012012092500003', '2012-09-25', 'Guest', '', 'Yusuf'),
('K012012092700001', '2012-09-27', 'Guest', '', 'Yusuf'),
('K012012092700002', '2012-09-27', 'Guest', '', 'Yusuf'),
('K012012100200001', '2012-10-02', 'Guest', '', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `faktur_detail`
--

CREATE TABLE IF NOT EXISTS `faktur_detail` (
  `Id_fak_treatment` int(11) NOT NULL auto_increment,
  `no_faktur` varchar(16) collate latin1_bin default NULL,
  `id_produk` varchar(10) collate latin1_bin default NULL,
  `harga` int(11) default NULL,
  `jml_beli` int(255) default NULL,
  `total` int(11) default NULL,
  `diskon` int(11) default NULL,
  `tot_stlh_diskon` int(11) default NULL,
  `free` int(11) default '0',
  PRIMARY KEY  (`Id_fak_treatment`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=387 ;

--
-- Dumping data for table `faktur_detail`
--

INSERT INTO `faktur_detail` (`Id_fak_treatment`, `no_faktur`, `id_produk`, `harga`, `jml_beli`, `total`, `diskon`, `tot_stlh_diskon`, `free`) VALUES
(185, 'K012012091200001', 'FPT-000003', 245000, 6, 1470000, 0, 1470000, 1),
(187, 'K012012091200002', 'IAT-000003', 300000, 1, 300000, 0, 300000, 0),
(188, 'K012012091200003', 'SRP-000004', 400000, 1, 400000, 0, 400000, 0),
(190, 'K012012091200003', 'IAT-000003', 300000, 1, 300000, 0, 300000, 0),
(191, 'K012012091200003', 'MST-000001', 600000, 1, 600000, 0, 600000, 0),
(192, '2012091700001', 'SLP-000005', 2000000, 1, 2000000, 0, 2000000, 0),
(193, 'K012012091700001', 'SRP-000001', 150000, 1, 150000, 0, 150000, 0),
(197, 'K012012092300011', 'ASC-000001', 60000, 1, 60000, 0, 60000, 0),
(195, 'K012012092300009', 'ADC-000001', 90000, 1, 90000, 0, 90000, 0),
(196, 'K012012092300010', 'AFW-000001', 75000, 1, 75000, 0, 75000, 0),
(198, 'K012012092300013', 'ADC-000001', 90000, 1, 90000, 0, 90000, 0),
(199, 'K012012092300014', 'ADC-000001', 90000, 1, 90000, 0, 90000, 0),
(200, 'K012012092300014', 'SRP-000005', 750000, 1, 750000, 0, 750000, 0),
(201, 'K012012092300014', 'STN-000001', 85000, 1, 85000, 0, 85000, 0),
(202, 'K012012092300018', 'BTX-000001', 3500000, 1, 3500000, 0, 3500000, 0),
(203, 'K012012092300018', 'BTX-000002', 4000000, 1, 4000000, 0, 4000000, 0),
(204, 'K012012092300019', 'ADC-000001', 90000, 1, 90000, 0, 90000, 0),
(205, 'K012012092300021', 'ADC-000001', 90000, 2, 180000, 0, 180000, 0),
(206, 'K012012092300021', 'ADC-000001', 90000, 2, 180000, 0, 180000, 0),
(207, 'K012012092300022', 'ADC-000001', 90000, 3, 270000, 0, 270000, 0),
(208, 'K012012092300022', 'NCR-000001', 105000, 2, 210000, 0, 210000, 0),
(209, 'K012012092300023', 'ADC-000001', 90000, 3, 270000, 0, 270000, 0),
(210, 'K012012092300024', 'BLP-000001', 45000, 3, 135000, 0, 135000, 0),
(211, 'K012012092300026', 'ADC-000001', 90000, 4, 360000, 0, 360000, 0),
(212, 'K012012092300026', 'FPT-000006', 200000, 4, 800000, 0, 800000, 0),
(213, 'K012012092300027', 'BLP-000001', 45000, 3, 135000, 0, 135000, 0),
(214, 'K012012092300027', 'PKT-SERUM', 415000, 3, 1245000, 0, 1245000, 0),
(215, 'K012012092300027', 'IAT-000002', 200000, 4, 800000, 0, 800000, 0),
(216, 'K012012092300028', 'AFW-000001', 75000, 1, 75000, 0, 75000, 0),
(217, 'K012012092300028', 'AFW-000001', 75000, 1, 75000, 0, 75000, 0),
(218, 'K012012092300028', 'AFW-000001', 75000, 1, 75000, 0, 75000, 0),
(219, 'K012012092300029', 'DBR-000001', 125000, 1, 125000, 0, 125000, 0),
(220, 'K012012092300029', 'BLP-000001', 45000, 1, 45000, 0, 45000, 0),
(221, 'K012012092300029', 'FPT-000003', 245000, 1, 245000, 0, 245000, 0),
(222, 'K012012092300029', 'SRP-000005', 750000, 1, 750000, 0, 750000, 0),
(223, 'K012012092300030', 'BLP-000001', 45000, 1, 45000, 0, 45000, 0),
(224, 'K012012092300030', 'MST-000001', 600000, 1, 600000, 0, 600000, 0),
(225, 'K012012092300031', 'ADC-000001', 90000, 2, 180000, 0, 180000, 0),
(226, 'K012012092300031', 'NLT-000001', 150000, 3, 450000, 0, 450000, 0),
(227, 'K012012092300031', 'SFW-000001', 75000, 5, 375000, 0, 375000, 0),
(228, 'K012012092300032', 'DCR-000001', 90000, 5, 450000, 0, 450000, 0),
(229, 'K012012092300032', 'PKT-SERUM', 415000, 4, 1660000, 0, 1660000, 0),
(230, 'K012012092300032', 'PKT-ACNE', 270000, 4, 1080000, 0, 1080000, 0),
(231, 'K012012092300032', 'IAT-000002', 200000, 4, 800000, 0, 800000, 0),
(232, 'K012012092300032', 'SRP-000005', 750000, 4, 3000000, 0, 3000000, 0),
(233, 'K012012092300032', 'SCAR-00001', 500000, 5, 2500000, 0, 2500000, 0),
(234, 'K012012092300032', 'IAT-000003', 300000, 5, 1500000, 0, 1500000, 0),
(235, 'K012012092300032', 'FPT-000006', 200000, 5, 1000000, 0, 1000000, 0),
(236, 'K012012092300032', 'FPT-000003', 245000, 5, 1225000, 0, 1225000, 0),
(237, 'K012012092300032', 'FPT-000004', 350000, 2, 700000, 0, 700000, 0),
(238, 'K012012092300032', 'FPT-000004', 350000, 3, 1050000, 0, 1050000, 0),
(239, 'K012012092400001', 'DBR-000001', 125000, 3, 375000, 0, 375000, 0),
(240, 'K012012092400001', 'STN-000001', 85000, 4, 340000, 0, 340000, 0),
(241, 'K012012092400001', 'PKT-LOTION', 250000, 3, 750000, 0, 750000, 0),
(242, 'K012012092400001', 'PKT-ACNE', 270000, 2, 540000, 0, 540000, 0),
(243, 'K012012092400002', 'NCR-000001', 105000, 3, 315000, 0, 315000, 0),
(244, 'K012012092400003', 'DBR-000001', 125000, 3, 375000, 0, 375000, 0),
(245, 'K012012092400003', 'DCR-000001', 90000, 5, 450000, 0, 450000, 0),
(246, 'K012012092400004', 'DBR-000001', 125000, 3, 375000, 0, 375000, 0),
(247, 'K012012092400004', 'DCR-000001', 90000, 5, 450000, 0, 450000, 0),
(248, 'K012012092400005', 'DCR-000001', 90000, 4, 360000, 0, 360000, 0),
(249, 'K012012092400005', 'STN-000001', 85000, 5, 425000, 0, 425000, 0),
(250, 'K012012092400006', 'BLP-000001', 45000, 3, 135000, 0, 135000, 0),
(251, 'K012012092400006', 'DLT-000001', 100, 2, 200, 0, 200, 0),
(252, 'K012012092400006', 'SLP-000003', 495000, 4, 1980000, 0, 1980000, 0),
(253, 'K012012092400007', 'NLT-000001', 150000, 3, 450000, 0, 450000, 0),
(254, 'K012012092400008', 'NLT-000001', 150000, 4, 600000, 0, 600000, 0),
(255, 'K012012092400009', 'SFW-000001', 75000, 2, 150000, 0, 150000, 0),
(256, 'K012012092400010', 'NCR-000001', 105000, 4, 420000, 0, 420000, 0),
(257, 'K012012092400010', 'DBR-000001', 125000, 2, 250000, 0, 250000, 0),
(258, 'K012012092400010', 'SFW-000001', 75000, 4, 300000, 0, 300000, 0),
(259, 'K012012092400010', 'PKT-ACNE', 270000, 5, 1350000, 0, 1350000, 0),
(260, 'K012012092400011', 'SCAR-00003', 3500000, 4, 14000000, 0, 14000000, 0),
(261, 'K012012092400012', 'NLT-000001', 150000, 3, 450000, 0, 450000, 0),
(262, 'K012012092400012', 'SCAR-00003', 3500000, 5, 17500000, 0, 17500000, 0),
(263, 'K012012092400012', 'SRP-000001', 150000, 4, 600000, 0, 600000, 0),
(264, 'K012012092400013', 'SCAR-00003', 3500000, 3, 10500000, 0, 10500000, 0),
(265, 'K012012092400014', 'SCAR-00003', 3500000, 4, 14000000, 0, 14000000, 0),
(266, 'K012012092400014', 'SCAR-00003', 3500000, 3, 10500000, 0, 10500000, 0),
(267, 'K012012092400014', 'SRP-000003', 295000, 2, 590000, 0, 590000, 0),
(268, 'K012012092400014', 'SRP-000004', 400000, 2, 800000, 0, 800000, 0),
(269, 'K012012092400014', 'SRP-000005', 750000, 3, 2250000, 0, 2250000, 0),
(270, 'K012012092400014', 'SRP-000005', 750000, 3, 2250000, 0, 2250000, 0),
(271, 'K012012092400020', 'PKT-LOTION', 250000, 44, 11000000, 0, 11000000, 0),
(272, 'K012012092400020', 'SFW-000001', 75000, 3, 225000, 0, 225000, 0),
(273, 'K012012092400020', 'DBR-000001', 125000, 6, 750000, 0, 750000, 0),
(274, 'K012012092400020', 'SEG-000001', 65000, 4, 260000, 0, 260000, 0),
(275, 'K012012092400021', 'SCAR-00002', 800000, 3, 2400000, 0, 2400000, 0),
(276, 'K012012092400021', 'IAT-000002', 200000, 3, 600000, 0, 600000, 0),
(277, 'K012012092400022', 'BLP-000001', 45000, 2, 90000, 0, 90000, 0),
(278, 'K012012092400023', 'BLP-000001', 45000, 1, 45000, 0, 45000, 0),
(279, 'K012012092400024', 'BLP-000001', 45000, 4, 180000, 0, 180000, 0),
(280, 'K012012092400024', 'BLP-000001', 45000, 1, 45000, 0, 45000, 0),
(281, 'K012012092400025', 'NCR-000001', 105000, 4, 420000, 0, 420000, 0),
(282, 'K012012092400026', 'BLP-000001', 45000, 3, 135000, 0, 135000, 0),
(283, 'K012012092400026', 'PKT-LOTION', 250000, 5, 1250000, 0, 1250000, 0),
(284, 'K012012092400027', 'ADC-000001', 90000, 5, 450000, 0, 450000, 0),
(285, 'K012012092400027', 'PKT-ACNE', 270000, 4, 1080000, 0, 1080000, 0),
(286, 'K012012092400027', 'DLT-000001', 100, 7, 700, 0, 700, 0),
(287, 'K012012092400028', 'NCR-000001', 105000, 5, 525000, 0, 525000, 0),
(288, 'K012012092400029', 'PKT-SERUM', 415000, 5, 2075000, 0, 2075000, 0),
(289, 'K012012092400029', 'SFW-000001', 75000, 1, 75000, 0, 75000, 0),
(290, 'K012012092400030', 'BLP-000001', 45000, 2, 90000, 0, 90000, 0),
(291, 'K012012092400030', 'NLT-000001', 150000, 1, 150000, 0, 150000, 0),
(292, 'K012012092400030', 'NLT-000001', 150000, 3, 450000, 0, 450000, 0),
(293, 'K012012092400030', 'DBR-000001', 125000, 5, 625000, 0, 625000, 0),
(294, 'K012012092400031', 'PKT-LOTION', 250000, 6, 1500000, 0, 1500000, 0),
(295, 'K012012092400031', 'DBR-000001', 125000, 2, 250000, 0, 250000, 0),
(296, 'K012012092400031', 'DCR-000001', 90000, 4, 360000, 0, 360000, 0),
(297, 'K012012092400031', 'DCR-000001', 90000, 3, 270000, 0, 270000, 0),
(298, 'K012012092400031', 'AFW-000001', 75000, 6, 450000, 0, 450000, 0),
(299, 'K012012092400032', 'NCR-000001', 105000, 3, 315000, 0, 315000, 0),
(300, 'K012012092400032', 'PKT-SERUM', 415000, 4, 1660000, 0, 1660000, 0),
(301, 'K012012092400032', 'DBR-000001', 125000, 5, 625000, 0, 625000, 0),
(302, 'K012012092400032', 'DCR-000001', 90000, 6, 540000, 0, 540000, 0),
(303, 'K012012092400033', 'NLT-000001', 150000, 5, 750000, 0, 750000, 0),
(304, 'K012012092400033', 'NLT-000001', 150000, 2, 300000, 0, 300000, 0),
(305, 'K012012092400033', 'DBR-000001', 125000, 1, 125000, 0, 125000, 0),
(306, 'K012012092400034', 'NCR-000001', 105000, 3, 315000, 0, 315000, 0),
(307, 'K012012092400034', 'DBR-000001', 125000, 2, 250000, 0, 250000, 0),
(308, 'K012012092400034', 'PKT-TONER', 300000, 5, 1500000, 0, 1500000, 0),
(309, 'K012012092400034', 'DBR-000001', 125000, 19, 2375000, 0, 2375000, 0),
(310, 'K012012092400035', 'PKT-LOTION', 250000, 3, 750000, 0, 750000, 0),
(311, 'K012012092400035', 'DBR-000001', 125000, 5, 625000, 0, 625000, 0),
(312, 'K012012092400035', 'BLP-000001', 45000, 2, 90000, 0, 90000, 0),
(313, 'K012012092400035', 'NLT-000001', 150000, 5, 750000, 0, 750000, 0),
(314, 'K012012092400036', 'PKT-SERUM', 415000, 6, 2490000, 0, 2490000, 0),
(315, 'K012012092400036', 'NCR-000001', 105000, 4, 420000, 0, 420000, 0),
(316, 'K012012092400036', 'SFW-000001', 75000, 3, 225000, 0, 225000, 0),
(317, 'K012012092400037', 'NCR-000001', 105000, 3, 315000, 0, 315000, 0),
(318, 'K012012092400037', 'NCR-000001', 105000, 4, 420000, 0, 420000, 0),
(319, 'K012012092400037', 'SEG-000001', 65000, 5, 325000, 0, 325000, 0),
(320, 'K012012092400038', 'PKT-LOTION', 250000, 3, 750000, 0, 750000, 0),
(321, 'K012012092400038', 'SFW-000001', 75000, 4, 300000, 0, 300000, 0),
(322, 'K012012092400038', 'NLT-000001', 150000, 5, 750000, 0, 750000, 0),
(323, 'K012012092400039', 'BLP-000001', 45000, 3, 135000, 0, 135000, 0),
(324, 'K012012092400039', 'BLP-000001', 45000, 2, 90000, 0, 90000, 0),
(325, 'K012012092400039', 'AFW-000001', 75000, 2, 150000, 0, 150000, 0),
(326, 'K012012092400040', 'NCR-000001', 105000, 4, 420000, 0, 420000, 0),
(327, 'K012012092400040', 'NLT-000001', 150000, 4, 600000, 0, 600000, 0),
(328, 'K012012092400040', 'DCR-000001', 90000, 2, 180000, 0, 180000, 0),
(329, 'K012012092400040', 'DLT-000001', 100, 3, 300, 0, 300, 0),
(330, 'K012012092400041', 'PKT-SERUM', 415000, 4, 1660000, 0, 1660000, 0),
(331, 'K012012092400041', 'PKT-LOTION', 250000, 2, 500000, 0, 500000, 0),
(332, 'K012012092400041', 'ANC-000001', 105000, 3, 315000, 0, 315000, 0),
(333, 'K012012092400041', 'ADC-000001', 90000, 2, 180000, 0, 180000, 0),
(334, 'K012012092400042', 'ADC-000001', 90000, 4, 360000, 0, 360000, 0),
(335, 'K012012092400042', 'DBR-000001', 125000, 4, 500000, 0, 500000, 0),
(336, 'K012012092400042', 'ANC-000001', 105000, 4, 420000, 0, 420000, 0),
(337, 'K012012092400042', 'ADC-000001', 90000, 2, 180000, 0, 180000, 0),
(338, 'K012012092400043', 'BTX-000001', 3500000, 5, 17500000, 0, 17500000, 0),
(339, 'K012012092400043', 'SCAR-00001', 500000, 5, 2500000, 0, 2500000, 0),
(340, 'K012012092400043', 'SRP-000002', 200000, 3, 600000, 0, 600000, 0),
(341, 'K012012092400043', 'SRP-000004', 400000, 3, 1200000, 0, 1200000, 0),
(342, 'K012012092400044', 'BLP-000001', 45000, 3, 135000, 0, 135000, 0),
(343, 'K012012092400044', 'NLT-000001', 150000, 5, 750000, 0, 750000, 0),
(344, 'K012012092400044', 'DCR-000001', 90000, 6, 540000, 0, 540000, 0),
(345, 'K012012092400044', 'ASC-000001', 60000, 8, 480000, 0, 480000, 0),
(346, 'K012012092400045', 'DBR-000001', 125000, 3, 375000, 0, 375000, 0),
(347, 'K012012092400045', 'AFW-000001', 75000, 5, 375000, 0, 375000, 0),
(348, 'K012012092400045', 'ANC-000001', 105000, 6, 630000, 0, 630000, 0),
(349, 'K012012092400045', 'ASC-000001', 60000, 6, 360000, 0, 360000, 0),
(350, 'K012012092400045', 'PKT-TONER', 300000, 5, 1500000, 0, 1500000, 0),
(351, 'K012012092400045', 'SFW-000001', 75000, 5, 375000, 0, 375000, 0),
(352, 'K012012092400045', 'PKT-SERUM', 415000, 3, 1245000, 0, 1245000, 0),
(353, 'K012012092400045', 'BLP-000001', 45000, 6, 270000, 0, 270000, 0),
(354, 'K012012092400045', 'ANC-000001', 105000, 7, 735000, 0, 735000, 0),
(355, 'K012012092400045', 'SFW-000001', 75000, 6, 450000, 0, 450000, 0),
(356, 'K012012092400046', 'SEG-000001', 65000, 4, 260000, 0, 260000, 0),
(357, 'K012012092400046', 'SFW-000001', 75000, 5, 375000, 0, 375000, 0),
(358, 'K012012092400046', 'DCR-000001', 90000, 6, 540000, 0, 540000, 0),
(359, 'K012012092400046', 'DBR-000001', 125000, 3, 375000, 0, 375000, 0),
(360, 'K012012092400046', 'ASC-000001', 60000, 4, 240000, 0, 240000, 0),
(361, 'K012012092400046', 'FPT-000007', 150000, 4, 600000, 0, 600000, 0),
(362, 'K012012092400046', 'SCAR-00002', 800000, 5, 4000000, 0, 4000000, 0),
(363, 'K012012092400046', 'IAT-000001', 100000, 6, 600000, 0, 600000, 0),
(364, 'K012012092400046', 'FPT-000005', 595000, 7, 4165000, 0, 4165000, 0),
(365, 'K012012092400047', 'ADC-000001', 90000, 10, 900000, 0, 900000, 0),
(366, 'K012012092400048', 'NCR-000001', 105000, 3, 315000, 0, 315000, 0),
(367, 'K012012092400048', 'STN-000001', 85000, 10, 850000, 0, 850000, 0),
(368, 'K012012092400058', 'ADC-000001', 90000, 1, 90000, 4500, 85500, 0),
(369, 'K012012092400059', 'BTX-000001', 3500000, 1, 3500000, 300000, 3200000, 0),
(370, 'K012012092400059', 'ADC-000001', 90000, 2, 180000, 150000, 30000, 0),
(371, 'K012012092400059', 'AFW-000001', 75000, 1, 75000, 7500, 67500, 0),
(372, 'K012012092500001', 'ADC-000001', 90000, 1, 90000, 0, 90000, 0),
(373, 'K012012092500001', 'BLP-000001', 45000, 1, 45000, 0, 45000, 0),
(374, 'K012012092500001', 'FPT-000007', 150000, 1, 150000, 0, 150000, 0),
(375, 'K012012092500002', 'IAT-000003', 300000, 1, 300000, 0, 300000, 0),
(377, 'K012012092500002', 'DBR-000001', 125000, 1, 125000, 0, 125000, 0),
(378, 'K012012092500003', 'NCR-000001', 105000, 1, 105000, 0, 105000, 0),
(380, 'K012012092500003', 'PKT-SERUM', 415000, 1, 415000, 0, 415000, 0),
(381, 'K012012092500003', 'ANC-000001', 105000, 1, 105000, 0, 105000, 0),
(382, 'K012012092500003', 'NCR-000001', 105000, 1, 105000, 0, 105000, 0),
(383, 'K012012092700001', 'ADC-000001', 90000, 1, 90000, 0, 90000, 0),
(384, 'K012012092700001', 'DCR-000001', 90000, 1, 90000, 50000, 40000, 0),
(385, 'K012012092700002', 'PKT-SERUM', 415000, 1, 415000, 50000, 365000, 0),
(386, 'K012012092700002', 'PKT-SERUM', 415000, 1, 415000, 0, 415000, 0);

-- --------------------------------------------------------

--
-- Table structure for table `faktur_diskon_detil`
--

CREATE TABLE IF NOT EXISTS `faktur_diskon_detil` (
  `Id` int(11) NOT NULL auto_increment,
  `no_faktur` varchar(16) collate latin1_bin NOT NULL default '',
  `id_diskon` int(11) NOT NULL default '0',
  `nama_diskon` varchar(50) collate latin1_bin default NULL,
  `jenis_diskon` varchar(10) collate latin1_bin default NULL,
  `jml_diskon` double NOT NULL default '0',
  PRIMARY KEY  (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_bin COMMENT='Data Kumpulan Diskon per Faktur Transaksi' AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `paket_detail`
--

CREATE TABLE IF NOT EXISTS `paket_detail` (
  `id` int(11) NOT NULL auto_increment,
  `id_produk_paket` varchar(10) collate latin1_bin NOT NULL,
  `id_produk` varchar(10) collate latin1_bin default NULL,
  `jumlah` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=7 ;

--
-- Dumping data for table `paket_detail`
--

INSERT INTO `paket_detail` (`id`, `id_produk_paket`, `id_produk`, `jumlah`) VALUES
(1, 'PKT-ACNE', 'ANC-000001', 1),
(2, 'PKT-ACNE', 'ADC-000001', 1),
(3, 'PKT-ACNE', 'AFW-000001', 100),
(4, 'PKT-BASIC', 'NCR-000001', 1),
(5, 'PKT-BASIC', 'DCR-000001', 1),
(6, 'PKT-BASIC', 'SFW-000001', 1);

-- --------------------------------------------------------

--
-- Table structure for table `pelanggan`
--

CREATE TABLE IF NOT EXISTS `pelanggan` (
  `Id` int(11) NOT NULL auto_increment,
  `nama` varchar(50) default NULL,
  `telepon` varchar(14) default NULL,
  `alamat` varchar(200) default NULL,
  PRIMARY KEY  (`Id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `pelanggan`
--

INSERT INTO `pelanggan` (`Id`, `nama`, `telepon`, `alamat`) VALUES
(1, 'Yusuf awaludin', '7315533', 'Kreo'),
(2, 'Hilmi', '0816545667788', 'Cipadu');

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

CREATE TABLE IF NOT EXISTS `pengguna` (
  `nama_user` varchar(10) character set latin1 NOT NULL default '',
  `pass_user` varchar(10) character set latin1 default NULL,
  `sts_user` varchar(10) character set latin1 default NULL,
  `creation_date` datetime default NULL COMMENT 'User Creation Time',
  `last_login` datetime default NULL COMMENT 'Last User Login Time',
  `last_form_used` varchar(255) collate latin1_bin default NULL COMMENT 'Last Application Form used by User',
  PRIMARY KEY  (`nama_user`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`nama_user`, `pass_user`, `sts_user`, `creation_date`, `last_login`, `last_form_used`) VALUES
('admin', '12345', 'admin', NULL, '2012-10-02 18:58:49', 'back_office'),
('imi', 'imi', 'supervisor', NULL, '2012-10-02 17:52:02', NULL),
('yusuf', 'yusuf', 'kasir', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `produk`
--

CREATE TABLE IF NOT EXISTS `produk` (
  `Id` varchar(10) collate latin1_bin NOT NULL default '',
  `nama` varchar(50) collate latin1_bin NOT NULL,
  `biaya` double NOT NULL,
  `ket` varchar(255) collate latin1_bin default NULL,
  `diskon_jml_max` int(11) default '0',
  `diskon_jml` int(11) default '0',
  `stok` double NOT NULL default '0',
  `pengurang_stok` tinyint(1) default '0',
  PRIMARY KEY  (`Id`),
  KEY `nama` (`nama`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_bin;

--
-- Dumping data for table `produk`
--

INSERT INTO `produk` (`Id`, `nama`, `biaya`, `ket`, `diskon_jml_max`, `diskon_jml`, `stok`, `pengurang_stok`) VALUES
('BTX-000001', 'Jaw Shaping (Pembentukan rahang)', 3500000, 'Botox & Anti Aging: Jaw Shaping (Pembentukan rahang)', 5, 1, 0, 0),
('BTX-000002', 'Botox Full Face', 4000000, 'Botox & Anti Aging: Botox Full Face', 5, 1, 0, 0),
('BTX-000003', 'Botox Per Area', 300000, 'Boxot & Anti Aging: Botox Per Area (2,5 unit)', 5, 1, 0, 0),
('FPT-000001', 'Sparkling Basic Maintenance Facial', 150000, 'Sparkling Basic Maintenance Facial', 5, 1, 0, 0),
('FPT-000002', 'Sparkling Flawless Facial', 250000, 'Sparkling Flawless Facial', 5, 1, 0, 0),
('FPT-000003', 'Sparkling Anti Acne Facial', 245000, 'Sparkling Anti Acne Facial', 5, 1, 0, 0),
('FPT-000004', 'Sparkling Gold Radiance Fasial', 350000, 'Sparkling Gold Radiance Fasial', 0, 0, 0, 0),
('FPT-000005', 'Sparkling Diamond Caviar Facial', 595000, 'Sparkling Diamond Caviar Facial', 0, 0, 0, 0),
('FPT-000006', 'Diamond Microdermabrasi', 200000, 'Diamond Microdermabrasi', 0, 0, 0, 0),
('FPT-000007', 'Sparkling Enzymatic Peeling', 150000, 'Sparkling Enzymatic Peeling', 0, 0, 0, 0),
('FPT-000008', 'Sparkling Chemical Peeling', 250000, 'Sparkling Chemical Peeling', 0, 0, 0, 0),
('IAT-000001', 'Acne Spot Injection 1', 100000, 'Intensive Acne Treatment: Acne Spot Injection 1', 0, 0, 0, 0),
('IAT-000002', 'Acne Spot Injection 2', 200000, 'Intensive Acne Treatment: Acne Spot Injection 2', 0, 0, 0, 0),
('IAT-000003', 'Anti Acne Serum Injection', 300000, 'Intensive Acne Treatment: Anti Acne Serum Injection', 0, 0, 0, 0),
('MST-000001', 'Meso Glow', 600000, 'Meso Glow', 0, 0, 0, 0),
('MST-000002', 'Meso Chubby cheek/ Double chin', 1100000, 'Meso Chubby cheek/ Double chin', 0, 0, 0, 0),
('MST-000003', 'Meso Lifting', 700000, 'Meso Lifting', 0, 0, 0, 0),
('SCAR-00001', 'Intensive Scall Collagen Induction', 500000, 'Scar & Stretmark microneedling program: Intensive Scall Collagen Induction', 0, 0, 0, 0),
('SCAR-00002', 'Advanced Scar Collagen Induction', 800000, 'Scar & Stretmark microneedling program: Advanced Scar Collagen Induction', 0, 0, 0, 0),
('SCAR-00003', 'Paket 5x Collagen Repair For Stretchmark', 3500000, 'Scar & Stretmark microneedling program: Paket 5x Collagen Repair For Stretchmark', 0, 0, 0, 0),
('SLP-000001', 'Slimming Injection', 150000, 'Slimming Injection', 0, 0, 0, 0),
('SLP-000002', 'Mesotherapy All Body Slimming', 450000, 'Mesotherapy All Body Slimming', 0, 0, 0, 0),
('SLP-000003', 'Mesotherapy Slimming Tanpa Jarum', 495000, 'Mesotherapy Slimming Tanpa Jarum', 0, 0, 0, 0),
('SLP-000004', 'Slimming Stimulator', 350000, 'Slimming Stimulator', 0, 0, 0, 0),
('SLP-000005', 'Premium Slimming Program', 2000000, '2x Mesotherapy All Body Slimming\r\n2x Mesotherapy Slimming Tanpa Jarum\r\n2x Slimming Stimulator\r\n2 Strip Slimming Tablet\r\nKonsultasi dan Panduan Nutrisi', 0, 0, 0, 0),
('SRP-000001', 'Vitamin C 2000 Injection', 150000, 'Vitamin C 2000 Injection', 0, 0, 0, 0),
('SRP-000002', 'Vitamin C 3000 Youthful Injection', 200000, 'Vitamin C 3000 Youthful Injection', 0, 0, 0, 0),
('SRP-000003', 'Vitamin C Whitening Injection', 295000, 'Vitamin C Whitening Injection', 0, 0, 0, 0),
('SRP-000004', 'Vitamin C Whitening Forte Injection', 400000, 'Vitamin C Whitening Forte Injection', 0, 0, 0, 0),
('SRP-000005', 'Cellular Ultimate Oxy-whitening Infusion', 750000, 'Cellular Ultimate Oxy-whitening Infusion', 0, 0, 0, 0),
('ADC-000001', 'Sparkling Acne Day Cream 10gr', 90000, 'Sparkling Acne Day Cream 10gr', 0, 0, 74, 1),
('AFW-000001', 'Sparkling Acne Facial Wash 100ml', 75000, 'Sparkling Acne Facial Wash 100ml', 0, 0, 10, 1),
('ANC-000001', 'Sparkling Acne Night Cream 10gr', 105000, 'Sparkling Acne Night Cream 10gr', 0, 0, 10, 1),
('ASC-000001', 'Sparkling Acne Spot Cream 5gr', 60000, 'Sparkling Acne Spot Cream 5gr', 0, 0, 50, 1),
('BLP-000001', 'Sparkling Brightening Lip Cream', 45000, 'Sparkling Brightening Lip Cream', 0, 0, 50, 1),
('DBR-000001', 'Sparkling Daily Bright Serum', 125000, 'Sparkling Daily Bright Serum', 0, 0, 20, 1),
('DCR-000001', 'Sparkling Day Cream 10gr', 90000, 'Sparkling Day Cream 10gr', 0, 0, 10, 1),
('DLT-000001', 'Sparkling Day Lotion 100ml', 100, 'Sparkling Day Lotion 100ml', 0, 0, 10, 1),
('NCR-000001', 'Sparkling Night Cream 10gr', 105000, 'Sparkling Night Cream 10gr', 0, 0, 10, 1),
('NLT-000001', 'Sparkling Night Lotion 100 ml', 150000, 'Sparkling Night Lotion 100 ml', 0, 0, 150, 1),
('PKT-ACNE', 'Paket Acne ', 270000, 'Acne Night Cream + Acne Day Cream + Acne Facial Wash + Acne Spot Cream', 0, 0, 100, 1),
('PKT-BASIC', 'Paket Basic', 230000, 'Night Cream + Day Cream + Facial Wash', 0, 0, 50, 1),
('PKT-LOTION', 'Paket Lotion', 250000, 'Day Lotion 100ml + Night Lotion 100ml', 0, 0, 50, 1),
('PKT-SERUM', 'Paket Serum', 415000, 'Night Cream + Day Cream + Facial Wash + Toner + Daily Bright Serum', 0, 0, 20, 1),
('PKT-TONER', 'Paket Toner', 300000, 'Night Cream + Day Cream + Facial Wash + Toner', 0, 0, 10, 1),
('SCR-000001', 'Sparkling Sensitive Care', 90000, 'Sparkling Sensitive Care', 0, 0, 1, 1),
('SEG-000001', 'Sparkling Eye Gel + Vit C 10gr', 65000, 'Sparkling Eye Gel + Vit C 10gr', 0, 0, 90, 1),
('SFW-000001', 'Sparkling Facial Wash 100ml', 75000, 'Sparkling Facial Wash 100ml', 0, 0, 80, 1),
('STN-000001', 'Sparkling Toner', 85000, '\r\n\r\n', 0, 0, 50, 1);

-- --------------------------------------------------------

--
-- Table structure for table `transaksi_temp`
--

CREATE TABLE IF NOT EXISTS `transaksi_temp` (
  `Id` int(11) NOT NULL auto_increment,
  `id_produk` varchar(10) collate latin1_bin default NULL,
  `harga` int(11) default NULL,
  `jml_beli` int(255) default NULL,
  `total` int(11) default NULL,
  `diskon` int(11) default NULL,
  `tot_stlh_diskon` int(11) default NULL,
  `free` int(11) default '0',
  PRIMARY KEY  (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
