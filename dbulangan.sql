-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 13 Jun 2024 pada 02.45
-- Versi server: 10.4.28-MariaDB
-- Versi PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbulangan`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tdetsoal`
--

CREATE TABLE `tdetsoal` (
  `kd_soal` varchar(255) NOT NULL,
  `soal` text NOT NULL,
  `opsi_a` text NOT NULL,
  `opsi_b` text NOT NULL,
  `opsi_c` text NOT NULL,
  `opsi_d` text NOT NULL,
  `kunci` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tdetsoal`
--

INSERT INTO `tdetsoal` (`kd_soal`, `soal`, `opsi_a`, `opsi_b`, `opsi_c`, `opsi_d`, `kunci`) VALUES
('soal-001', '1+1=', '2', '4', '3', '5', '2'),
('soal-002', '2+2', '2', '4', '3', '5', '4'),
('MTK-001', '1+1=', '2', '4', '3', '5', '2'),
('MTK-002', '3*3=', '9', '11', '10', '12', '9'),
('MTK-003', '4+4=', '8', '11', '10', '12', '8');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tguru`
--

CREATE TABLE `tguru` (
  `nip` varchar(25) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `jk` enum('laki-laki','perempuan') NOT NULL,
  `kd_mapel` varchar(10) NOT NULL,
  `alamat` text NOT NULL,
  `no_tlp` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tguru`
--

INSERT INTO `tguru` (`nip`, `nama`, `jk`, `kd_mapel`, `alamat`, `no_tlp`) VALUES
('739387', 'Budi', 'perempuan', 'MPL-001', 'Cibogo', '+62736376272');

-- --------------------------------------------------------

--
-- Struktur dari tabel `thasil`
--

CREATE TABLE `thasil` (
  `nisn` varchar(25) NOT NULL,
  `kd_kelas` varchar(15) NOT NULL,
  `kd_ulangan` varchar(255) NOT NULL,
  `hasil` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `thasil`
--

INSERT INTO `thasil` (`nisn`, `kd_kelas`, `kd_ulangan`, `hasil`) VALUES
('3277020610060008', 'KLS-001', 'MTK-001', 50),
('87343424324', 'KLS-001', 'MTK-001', 100),
('78362868474', 'KLS-001', 'MTK-002', 50),
('78362868474', 'KLS-001', 'MTK-001', 100),
('3277020610060004', 'KLS-001', 'MTK-001', 100),
('3277020610060004', 'KLS-001', 'MTK-002', 33),
('00', 'KLS-001', 'MTK-001', 100),
('00', 'KLS-001', 'MTK-002', 67);

-- --------------------------------------------------------

--
-- Struktur dari tabel `theadsoal`
--

CREATE TABLE `theadsoal` (
  `kd_ulangan` varchar(255) NOT NULL,
  `kd_soal` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `theadsoal`
--

INSERT INTO `theadsoal` (`kd_ulangan`, `kd_soal`) VALUES
('MTK-001', 'soal-001'),
('MTK-001', 'soal-002'),
('MTK-002', 'MTK-001'),
('MTK-002', 'MTK-002'),
('MTK-002', 'MTK-003');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tjawaban`
--

CREATE TABLE `tjawaban` (
  `id` varchar(25) NOT NULL,
  `kd_soal` varchar(255) NOT NULL,
  `jawab` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tjawaban`
--

INSERT INTO `tjawaban` (`id`, `kd_soal`, `jawab`) VALUES
('siswa-01', 'soal-001', '2'),
('siswa-01', 'soal-002', '3'),
('siswa-02', 'soal-001', '2'),
('siswa-02', 'soal-002', '4'),
('SISWA-04', 'MTK-001', '2'),
('SISWA-04', 'MTK-002', '11'),
('SISWA-04', 'soal-001', '2'),
('SISWA-04', 'soal-002', '4'),
('siswa-05', 'soal-001', '2'),
('siswa-05', 'soal-002', '4'),
('siswa-05', 'MTK-001', '4'),
('siswa-05', 'MTK-002', '9'),
('siswa-05', 'MTK-003', '11'),
('siswa-test', 'soal-001', '2'),
('siswa-test', 'soal-002', '4'),
('siswa-test', 'MTK-001', '2'),
('siswa-test', 'MTK-002', '9'),
('siswa-test', 'MTK-003', '11');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tkelas`
--

CREATE TABLE `tkelas` (
  `kd_kelas` varchar(15) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `wakel` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tkelas`
--

INSERT INTO `tkelas` (`kd_kelas`, `nama`, `wakel`) VALUES
('KLS-001', 'Kelas 11 RPL A', '739387');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tmapel`
--

CREATE TABLE `tmapel` (
  `kd_mapel` varchar(10) NOT NULL,
  `nama` varchar(25) NOT NULL,
  `kkm` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tmapel`
--

INSERT INTO `tmapel` (`kd_mapel`, `nama`, `kkm`) VALUES
('MPL-001', 'Matematika', 80);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tsiswa`
--

CREATE TABLE `tsiswa` (
  `nisn` varchar(25) NOT NULL,
  `id` varchar(11) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `kelas` varchar(10) NOT NULL,
  `jk` enum('laki-laki','perempuan') NOT NULL,
  `alamat` text NOT NULL,
  `tlp_wali` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tsiswa`
--

INSERT INTO `tsiswa` (`nisn`, `id`, `nama`, `kelas`, `jk`, `alamat`, `tlp_wali`) VALUES
('00', 'siswa-test', 'Siswa-Test', 'KLS-001', 'laki-laki', 'Siswa-test', '+62847362746'),
('3277020610060003', 'SISWA-03', 'KC Ambarukmo', 'KLS-001', 'laki-laki', 'Tokyo', '+62763762627'),
('3277020610060004', 'SISWA-05', 'Icikiwir', 'KLS-001', 'laki-laki', 'Cimahi', '+62763344323'),
('3277020610060008', 'SISWA-01', 'Muhammad Defriansyah', 'KLS-001', 'laki-laki', 'Cimahi', '+62763762627'),
('78362868474', 'SISWA-04', 'Dadang', 'KLS-001', 'laki-laki', 'Pojok', '+62837873363'),
('87343424324', 'SISWA-02', 'Bambang', 'KLS-001', 'laki-laki', 'cimahi', '2343243');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tulangan`
--

CREATE TABLE `tulangan` (
  `kd_ulangan` varchar(255) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `jenis` enum('harian','sumatif') NOT NULL,
  `kd_mapel` varchar(10) NOT NULL,
  `waktu` varchar(10) NOT NULL,
  `tanggal` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tulangan`
--

INSERT INTO `tulangan` (`kd_ulangan`, `nama`, `jenis`, `kd_mapel`, `waktu`, `tanggal`) VALUES
('MTK-001', 'Ujian Matematika kelas 2', 'harian', 'MPL-001', '30', '2024-05-14'),
('MTK-002', 'Ujian Matematika kelas 1', 'harian', 'MPL-001', '30', '2024-05-23');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tuser`
--

CREATE TABLE `tuser` (
  `id` varchar(25) NOT NULL,
  `pw` varchar(25) NOT NULL,
  `lvl` enum('admin','siswa') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `tuser`
--

INSERT INTO `tuser` (`id`, `pw`, `lvl`) VALUES
('admin', 'admin', 'admin'),
('SISWA-01', 'siswa', 'siswa'),
('SISWA-02', 'siswa', 'siswa'),
('SISWA-03', 'siswa', 'siswa'),
('SISWA-04', 'siswa', 'siswa'),
('SISWA-05', 'siswa', 'siswa'),
('siswa-test', 'siswa-test', 'siswa');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tdetsoal`
--
ALTER TABLE `tdetsoal`
  ADD KEY `kd_soal` (`kd_soal`);

--
-- Indeks untuk tabel `tguru`
--
ALTER TABLE `tguru`
  ADD PRIMARY KEY (`nip`),
  ADD KEY `kd_mapel` (`kd_mapel`);

--
-- Indeks untuk tabel `thasil`
--
ALTER TABLE `thasil`
  ADD KEY `kd_ulangan` (`kd_ulangan`),
  ADD KEY `nisn` (`nisn`),
  ADD KEY `kd_kelas` (`kd_kelas`);

--
-- Indeks untuk tabel `theadsoal`
--
ALTER TABLE `theadsoal`
  ADD PRIMARY KEY (`kd_soal`),
  ADD KEY `theadsoal_ibfk_1` (`kd_ulangan`);

--
-- Indeks untuk tabel `tjawaban`
--
ALTER TABLE `tjawaban`
  ADD KEY `nisn` (`id`),
  ADD KEY `kd_soal` (`kd_soal`);

--
-- Indeks untuk tabel `tkelas`
--
ALTER TABLE `tkelas`
  ADD PRIMARY KEY (`kd_kelas`),
  ADD KEY `wakel` (`wakel`);

--
-- Indeks untuk tabel `tmapel`
--
ALTER TABLE `tmapel`
  ADD PRIMARY KEY (`kd_mapel`);

--
-- Indeks untuk tabel `tsiswa`
--
ALTER TABLE `tsiswa`
  ADD PRIMARY KEY (`nisn`),
  ADD KEY `kelas` (`kelas`),
  ADD KEY `id akun` (`id`);

--
-- Indeks untuk tabel `tulangan`
--
ALTER TABLE `tulangan`
  ADD PRIMARY KEY (`kd_ulangan`),
  ADD KEY `kd_mapel` (`kd_mapel`);

--
-- Indeks untuk tabel `tuser`
--
ALTER TABLE `tuser`
  ADD PRIMARY KEY (`id`);

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `tguru`
--
ALTER TABLE `tguru`
  ADD CONSTRAINT `tguru_ibfk_1` FOREIGN KEY (`kd_mapel`) REFERENCES `tmapel` (`kd_mapel`);

--
-- Ketidakleluasaan untuk tabel `thasil`
--
ALTER TABLE `thasil`
  ADD CONSTRAINT `thasil_ibfk_1` FOREIGN KEY (`nisn`) REFERENCES `tsiswa` (`nisn`),
  ADD CONSTRAINT `thasil_ibfk_2` FOREIGN KEY (`kd_ulangan`) REFERENCES `tulangan` (`kd_ulangan`),
  ADD CONSTRAINT `thasil_ibfk_3` FOREIGN KEY (`kd_kelas`) REFERENCES `tkelas` (`kd_kelas`);

--
-- Ketidakleluasaan untuk tabel `theadsoal`
--
ALTER TABLE `theadsoal`
  ADD CONSTRAINT `theadsoal_ibfk_1` FOREIGN KEY (`kd_ulangan`) REFERENCES `tulangan` (`kd_ulangan`) ON DELETE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `tjawaban`
--
ALTER TABLE `tjawaban`
  ADD CONSTRAINT `tjawaban_ibfk_1` FOREIGN KEY (`id`) REFERENCES `tuser` (`id`),
  ADD CONSTRAINT `tjawaban_ibfk_2` FOREIGN KEY (`kd_soal`) REFERENCES `theadsoal` (`kd_soal`);

--
-- Ketidakleluasaan untuk tabel `tkelas`
--
ALTER TABLE `tkelas`
  ADD CONSTRAINT `tkelas_ibfk_1` FOREIGN KEY (`wakel`) REFERENCES `tguru` (`nip`);

--
-- Ketidakleluasaan untuk tabel `tsiswa`
--
ALTER TABLE `tsiswa`
  ADD CONSTRAINT `tsiswa_ibfk_1` FOREIGN KEY (`kelas`) REFERENCES `tkelas` (`kd_kelas`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `tsiswa_ibfk_2` FOREIGN KEY (`id`) REFERENCES `tuser` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Ketidakleluasaan untuk tabel `tulangan`
--
ALTER TABLE `tulangan`
  ADD CONSTRAINT `tulangan_ibfk_1` FOREIGN KEY (`kd_mapel`) REFERENCES `tmapel` (`kd_mapel`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
