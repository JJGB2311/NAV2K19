-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 22-09-2019 a las 21:25:17
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdnavegador`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ayuda`
--

CREATE TABLE `ayuda` (
  `Id_ayuda` int(11) NOT NULL,
  `Ruta` text COLLATE utf8_unicode_ci NOT NULL,
  `indice` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `ayuda`
--

INSERT INTO `ayuda` (`Id_ayuda`, `Ruta`, `indice`) VALUES
(1, 'Página web ayuda/ayuda.chm', 'menu.html'),
(2, 'Página web ayuda/ayuda.chm', 'Menúboletos.html');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_bodega`
--

CREATE TABLE `tbl_bodega` (
  `kbodega` int(4) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `telefono` varchar(255) NOT NULL,
  `direccion` text NOT NULL,
  `encargado` varchar(255) NOT NULL,
  `estado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `tbl_bodega`
--

INSERT INTO `tbl_bodega` (`kbodega`, `nombre`, `telefono`, `direccion`, `encargado`, `estado`) VALUES
(1, 'Norte', '23564785', 'Petén', 'Randy Choc', 0),
(2, 'Sur', '265987854', 'Escuintla', 'Juan Gamez', 0),
(3, 'Central', '244778899', 'Ciudad', 'Gustavo Perez', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_producto`
--

CREATE TABLE `tbl_producto` (
  `kproducto` int(4) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `proveedor` varchar(255) NOT NULL,
  `presentacion` varchar(255) NOT NULL,
  `fecha_compra` date NOT NULL,
  `Minimo` int(11) NOT NULL,
  `bodega` varchar(255) NOT NULL,
  `estado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `tbl_producto`
--

INSERT INTO `tbl_producto` (`kproducto`, `nombre`, `proveedor`, `presentacion`, `fecha_compra`, `Minimo`, `bodega`, `estado`) VALUES
(1, 'Sprite', 'Coca Cola', 'Pqequeña', '2019-09-20', 50, 'Norte', 0),
(2, 'Pasta Dental', 'Colgate', 'Pequeña', '2019-09-11', 50, 'Sur', 0),
(3, 'Nachos', 'Boca2', 'Grande', '2019-09-14', 50, 'Norte', 0),
(4, 'Fideos', 'INA', 'Pequeña', '2019-09-12', 50, 'Sur', 0),
(5, 'Salchichas', 'Perry', 'Mediana', '2019-09-20', 50, 'Norte', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_proveedor`
--

CREATE TABLE `tbl_proveedor` (
  `kproveedor` int(4) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `telefono` varchar(255) NOT NULL,
  `estado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `tbl_proveedor`
--

INSERT INTO `tbl_proveedor` (`kproveedor`, `nombre`, `telefono`, `estado`) VALUES
(1, 'Coca Cola', '236564587', 0),
(2, 'Colgate', '255478874', 0),
(3, 'INA', '266987445', 0),
(4, 'Boca2', '26658795', 0),
(5, 'Perry', '23652357', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tbl_bodega`
--
ALTER TABLE `tbl_bodega`
  ADD PRIMARY KEY (`kbodega`);

--
-- Indices de la tabla `tbl_producto`
--
ALTER TABLE `tbl_producto`
  ADD PRIMARY KEY (`kproducto`),
  ADD KEY `proveedor` (`proveedor`),
  ADD KEY `bodega` (`bodega`),
  ADD KEY `presentacion` (`presentacion`);

--
-- Indices de la tabla `tbl_proveedor`
--
ALTER TABLE `tbl_proveedor`
  ADD PRIMARY KEY (`kproveedor`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `tbl_bodega`
--
ALTER TABLE `tbl_bodega`
  MODIFY `kbodega` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `tbl_producto`
--
ALTER TABLE `tbl_producto`
  MODIFY `kproducto` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `tbl_proveedor`
--
ALTER TABLE `tbl_proveedor`
  MODIFY `kproveedor` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
