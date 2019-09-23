-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 22-09-2019 a las 08:20:18
-- Versión del servidor: 10.1.26-MariaDB
-- Versión de PHP: 7.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `seguridad`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `procedimientoLogin` (IN `usuario` VARCHAR(25), IN `clave` VARCHAR(25))  NO SQL
Select tbl_usuario.PK_id_Usuario FROM tbl_usuario where tbl_usuario.PK_id_Usuario = usuario and tbl_usuario.password_usuario = MD5(clave) AND tbl_usuario.estado_usuario=1$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_aplicacion`
--

CREATE TABLE `tbl_aplicacion` (
  `PK_id_aplicacion` int(11) NOT NULL,
  `PK_id_modulo` int(11) NOT NULL,
  `nombre_aplicacion` varchar(45) DEFAULT NULL,
  `descripcion_aplicacion` varchar(200) DEFAULT NULL,
  `no_reporteAsociado` int(11) DEFAULT NULL,
  `estado_aplicacion` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_aplicacion`
--

INSERT INTO `tbl_aplicacion` (`PK_id_aplicacion`, `PK_id_modulo`, `nombre_aplicacion`, `descripcion_aplicacion`, `no_reporteAsociado`, `estado_aplicacion`) VALUES
(1, 1, 'recepcion', 'recepcion', NULL, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_bitacora`
--

CREATE TABLE `tbl_bitacora` (
  `PK_id_bitacora` int(11) NOT NULL,
  `PK_id_usuario` varchar(25) NOT NULL,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
  `host` varchar(45) DEFAULT NULL,
  `ip` varchar(25) DEFAULT NULL,
  `accion` varchar(50) DEFAULT NULL,
  `tabla` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_bitacora`
--

INSERT INTO `tbl_bitacora` (`PK_id_bitacora`, `PK_id_usuario`, `fecha`, `hora`, `host`, `ip`, `accion`, `tabla`) VALUES
(1, 'rchocm', '2019-09-19', '10:46:20', 'AMAZING', '192.168.43.248', 'Se logeo al sistema', 'Login'),
(2, 'rchocm', '2019-09-19', '10:47:04', 'AMAZING', '192.168.43.248', 'Inserto un nuevo modulo: 1 - hoteleria', 'tbl_modulo'),
(3, 'rchocm', '2019-09-19', '10:47:16', 'AMAZING', '192.168.43.248', 'Inserto un nuevo perfil: 1 - admin', 'tbl_perfil'),
(4, 'rchocm', '2019-09-19', '10:47:24', 'AMAZING', '192.168.43.248', 'Inserto un nuevo perfil: 2 - usuario', 'tbl_perfil'),
(5, 'rchocm', '2019-09-19', '10:47:28', 'AMAZING', '192.168.43.248', 'Realizo una consulta a modulos', 'tbl_modulos'),
(6, 'rchocm', '2019-09-19', '10:47:55', 'AMAZING', '192.168.43.248', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(7, 'rchocm', '2019-09-19', '10:47:55', 'AMAZING', '192.168.43.248', 'Realizo una consulta a modulos', 'tbl_modulos'),
(8, 'rchocm', '2019-09-19', '10:48:00', 'AMAZING', '192.168.43.248', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(9, 'rchocm', '2019-09-19', '10:48:09', 'AMAZING', '192.168.43.248', 'Asigno permiso: recepcion a perfil: admin', 'tbl_usuario_aplicacion'),
(10, 'rchocm', '2019-09-19', '10:48:14', 'AMAZING', '192.168.43.248', 'Realizo una consulta a aplicaciones', 'tbl_aplicacion'),
(11, 'rchocm', '2019-09-19', '10:48:21', 'AMAZING', '192.168.43.248', 'Asigno permiso: recepcion a perfil: usuario', 'tbl_usuario_aplicacion'),
(12, 'rchocm', '2019-09-19', '10:48:24', 'AMAZING', '192.168.43.248', 'Realizo una consulta a usuarios', 'tbl_usuario'),
(13, 'rchocm', '2019-09-19', '10:48:24', 'AMAZING', '192.168.43.248', 'Realizo una consulta a perfiles', 'tbl_perfil'),
(14, 'rchocm', '2019-09-19', '10:48:39', 'AMAZING', '192.168.43.248', 'Asigno perfil: admin a usuario: rchocm', 'tbl_usuario_perfil'),
(15, 'rchocm', '2019-09-19', '10:48:39', 'AMAZING', '192.168.43.248', 'Asigno perfil: usuario a usuario: choc', 'tbl_usuario_perfil'),
(16, 'rchocm', '2019-09-19', '10:49:56', 'AMAZING', '192.168.43.248', 'Se logeo al sistema', 'Login'),
(17, 'rchocm', '2019-09-19', '10:50:12', 'AMAZING', '192.168.43.248', 'Se creó un nuevo registro', 'Funciones'),
(18, 'rchocm', '2019-09-19', '10:55:21', 'AMAZING', '192.168.43.248', 'Se logeo al sistema', 'Login'),
(19, 'rchocm', '2019-09-19', '10:55:26', 'AMAZING', '192.168.43.248', 'Se creó un nuevo registro', 'Funciones'),
(20, 'choc', '2019-09-19', '10:56:32', 'AMAZING', '192.168.43.248', 'Se logeo al sistema', 'Login'),
(21, 'choc', '2019-09-19', '10:56:37', 'AMAZING', '192.168.43.248', 'Se creó un nuevo registro', 'Funciones'),
(22, 'rchocm', '2019-09-19', '10:57:14', 'AMAZING', '192.168.43.248', 'Se logeo al sistema', 'Login'),
(23, 'rchocm', '2019-09-19', '11:06:58', 'AMAZING', '192.168.43.248', 'Se logeo al sistema', 'Login'),
(24, 'rchocm', '2019-09-19', '11:26:32', 'AMAZING', '192.168.1.12', 'Se logeo al sistema', 'Login'),
(25, 'choc', '2019-09-19', '11:30:33', 'AMAZING', '192.168.1.12', 'Se logeo al sistema', 'Login'),
(26, 'choc', '2019-09-19', '11:53:14', 'AMAZING', '192.168.1.12', 'Se logeo al sistema', 'Login'),
(27, 'choc', '2019-09-19', '11:53:20', 'AMAZING', '192.168.1.12', 'Se creó un nuevo registro', 'Funciones'),
(28, 'choc', '2019-09-19', '11:54:18', 'AMAZING', '192.168.1.12', 'Se creó un nuevo registro', 'Funciones'),
(29, 'rchocm', '2019-09-20', '08:46:05', 'AMAZING', '192.168.56.1', 'Se logeo al sistema', 'Login'),
(30, 'choc', '2019-09-20', '08:46:33', 'AMAZING', '192.168.56.1', 'Se logeo al sistema', 'Login'),
(31, 'choc', '2019-09-20', '08:46:58', 'AMAZING', '192.168.56.1', 'Se creó un nuevo registro', 'Funciones'),
(32, 'choc', '2019-09-20', '08:49:02', 'AMAZING', '192.168.56.1', 'Se logeo al sistema', 'Login'),
(33, 'choc', '2019-09-20', '08:49:17', 'AMAZING', '192.168.56.1', 'Se creó un nuevo registro', 'Funciones'),
(34, 'choc', '2019-09-20', '08:50:16', 'AMAZING', '192.168.56.1', 'Se logeo al sistema', 'Login'),
(35, 'choc', '2019-09-20', '08:50:21', 'AMAZING', '192.168.56.1', 'Se creó un nuevo registro', 'Funciones'),
(36, 'rchocm', '2019-09-20', '10:51:31', 'AMAZING', '192.168.95.18', 'Se logeo al sistema', 'Login'),
(37, 'choc', '2019-09-20', '11:02:19', 'AMAZING', '192.168.95.18', 'Se logeo al sistema', 'Login'),
(38, 'rchocm', '2019-09-20', '11:07:20', 'AMAZING', '192.168.95.18', 'Se logeo al sistema', 'Login'),
(39, 'rchocm', '2019-09-20', '11:09:29', 'AMAZING', '192.168.95.18', 'Se logeo al sistema', 'Login'),
(40, 'rchocm', '2019-09-20', '11:12:53', 'AMAZING', '192.168.95.18', 'Se logeo al sistema', 'Login'),
(41, 'choc', '2019-09-20', '11:15:53', 'AMAZING', '192.168.95.18', 'Se logeo al sistema', 'Login'),
(42, 'choc', '2019-09-20', '11:17:50', 'AMAZING', '192.168.95.18', 'Se logeo al sistema', 'Login'),
(43, 'choc', '2019-09-21', '01:00:17', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(44, 'rchocm', '2019-09-21', '01:00:45', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(45, 'choc', '2019-09-21', '01:02:33', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(46, 'rchocm', '2019-09-21', '01:02:42', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(47, 'choc', '2019-09-21', '01:03:31', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(48, 'choc', '2019-09-21', '01:09:11', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(49, 'choc', '2019-09-21', '01:11:41', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(50, 'rchocm', '2019-09-21', '01:11:49', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(51, 'rchocm', '2019-09-21', '01:16:16', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(52, 'choc', '2019-09-21', '01:17:01', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(53, 'MiUsuario', '2019-09-21', '01:17:16', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(54, 'choc', '2019-09-21', '01:19:40', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(55, 'rchocm', '2019-09-21', '01:19:53', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(56, 'MiUsuario', '2019-09-21', '01:20:21', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(57, 'choc', '2019-09-21', '01:23:38', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(58, 'rchocm', '2019-09-21', '01:23:53', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(59, 'MiUsuario', '2019-09-21', '01:24:15', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(60, 'rchocm', '2019-09-21', '01:39:33', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(61, 'choc', '2019-09-21', '01:39:49', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(62, 'MiUsuario', '2019-09-21', '01:40:05', 'AMAZING', '192.168.1.20', 'Se logeo al sistema', 'Login'),
(63, 'choc', '2019-09-21', '10:11:17', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(64, 'choc', '2019-09-21', '10:16:04', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(65, 'choc', '2019-09-21', '10:19:56', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(66, 'choc', '2019-09-21', '10:23:56', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(67, 'choc', '2019-09-21', '10:24:16', 'AMAZING', '192.168.1.14', 'Se creó un nuevo registro', 'Funciones'),
(68, 'choc', '2019-09-21', '10:27:13', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(69, 'choc', '2019-09-21', '10:27:29', 'AMAZING', '192.168.1.14', 'Se creó un nuevo registro', 'Funciones'),
(70, 'choc', '2019-09-21', '10:28:41', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(71, 'choc', '2019-09-21', '10:28:55', 'AMAZING', '192.168.1.14', 'Se creó un nuevo registro', 'Funciones'),
(72, 'choc', '2019-09-21', '10:30:58', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(73, 'choc', '2019-09-21', '10:31:13', 'AMAZING', '192.168.1.14', 'Se creó un nuevo registro', 'Funciones'),
(74, 'choc', '2019-09-21', '10:43:20', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(75, 'choc', '2019-09-21', '10:46:15', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(76, 'choc', '2019-09-21', '10:50:53', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(77, 'rchocm', '2019-09-21', '10:51:18', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(78, 'choc', '2019-09-21', '11:08:13', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(79, 'choc', '2019-09-21', '11:09:06', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(80, 'choc', '2019-09-21', '11:17:30', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(81, 'choc', '2019-09-21', '11:19:42', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(82, 'choc', '2019-09-21', '11:21:15', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(83, 'choc', '2019-09-21', '11:22:16', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(84, 'choc', '2019-09-21', '11:22:42', 'AMAZING', '192.168.1.14', 'Se creó un nuevo registro', 'Funciones'),
(85, 'choc', '2019-09-21', '11:23:38', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(86, 'choc', '2019-09-21', '11:29:22', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(87, 'choc', '2019-09-21', '11:34:35', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(88, 'choc', '2019-09-21', '11:35:28', 'AMAZING', '192.168.1.14', 'Se creó un nuevo registro', 'Funciones'),
(89, 'rchocm', '2019-09-21', '11:36:55', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(90, 'rchocm', '2019-09-21', '11:37:18', 'AMAZING', '192.168.1.14', 'Se actualizó un registro', 'Funciones'),
(91, 'rchocm', '2019-09-21', '11:47:42', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(92, 'rchocm', '2019-09-21', '11:48:33', 'AMAZING', '192.168.1.14', 'Se actualizó un registro', 'Funciones'),
(93, 'rchocm', '2019-09-21', '11:52:54', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(94, 'rchocm', '2019-09-21', '11:54:35', 'AMAZING', '192.168.1.14', 'Se actualizó un registro', 'Funciones'),
(95, 'choc', '2019-09-21', '11:56:58', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(96, 'choc', '2019-09-21', '11:57:15', 'AMAZING', '192.168.1.14', 'Se creó un nuevo registro', 'Funciones'),
(97, 'rchocm', '2019-09-21', '11:57:38', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login'),
(98, 'rchocm', '2019-09-21', '11:58:08', 'AMAZING', '192.168.1.14', 'Se actualizó un registro', 'Funciones'),
(99, 'choc', '2019-09-21', '11:58:24', 'AMAZING', '192.168.1.14', 'Se logeo al sistema', 'Login');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_modulo`
--

CREATE TABLE `tbl_modulo` (
  `PK_id_Modulo` int(11) NOT NULL,
  `nombre_modulo` varchar(45) DEFAULT NULL,
  `descripcion_modulo` varchar(200) DEFAULT NULL,
  `estado_modulo` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_modulo`
--

INSERT INTO `tbl_modulo` (`PK_id_Modulo`, `nombre_modulo`, `descripcion_modulo`, `estado_modulo`) VALUES
(1, 'hoteleria', 'hoteleria', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_perfil_detalle`
--

CREATE TABLE `tbl_perfil_detalle` (
  `PK_id_perfil` int(11) NOT NULL,
  `PK_id_aplicacion` int(11) NOT NULL,
  `ingresar` tinyint(4) DEFAULT NULL,
  `consultar` tinyint(4) DEFAULT NULL,
  `modificar` tinyint(4) DEFAULT NULL,
  `eliminar` tinyint(4) DEFAULT NULL,
  `imprimir` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_perfil_detalle`
--

INSERT INTO `tbl_perfil_detalle` (`PK_id_perfil`, `PK_id_aplicacion`, `ingresar`, `consultar`, `modificar`, `eliminar`, `imprimir`) VALUES
(1, 1, 1, 1, 1, 1, 1),
(2, 1, 1, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_perfil_encabezado`
--

CREATE TABLE `tbl_perfil_encabezado` (
  `PK_id_perfil` int(11) NOT NULL,
  `nombre_perfil` varchar(45) DEFAULT NULL,
  `descripcion_perfil` varchar(200) DEFAULT NULL,
  `estado_perfil` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_perfil_encabezado`
--

INSERT INTO `tbl_perfil_encabezado` (`PK_id_perfil`, `nombre_perfil`, `descripcion_perfil`, `estado_perfil`) VALUES
(1, 'admin', 'admin', 1),
(2, 'usuario', 'usuario', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_usuario`
--

CREATE TABLE `tbl_usuario` (
  `PK_id_usuario` varchar(25) NOT NULL,
  `nombre_usuario` varchar(45) DEFAULT NULL,
  `apellido_usuarios` varchar(45) DEFAULT NULL,
  `password_usuario` varchar(45) DEFAULT NULL,
  `cambio_contrasena` tinyint(4) DEFAULT NULL,
  `ultima_conexion` datetime DEFAULT NULL,
  `estado_usuario` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_usuario`
--

INSERT INTO `tbl_usuario` (`PK_id_usuario`, `nombre_usuario`, `apellido_usuarios`, `password_usuario`, `cambio_contrasena`, `ultima_conexion`, `estado_usuario`) VALUES
('usuario', 'choc', 'choc', '509424c905af58c81c60603b8acd70b6', NULL, NULL, 1),
('MiUsuario', 'Usuario', 'Prueba', 'e19d5cd5af0378da05f63f891c7467af', 0, NULL, 1),
('rchocm', 'randy', 'choc', '17d0234375b389906d21b70ba5db8cae', NULL, NULL, 1);

--
-- Disparadores `tbl_usuario`
--
DELIMITER $$
CREATE TRIGGER `actualizarClave` BEFORE UPDATE ON `tbl_usuario` FOR EACH ROW IF NEW.password_usuario <> OLD.password_usuario THEN
SET NEW.password_usuario = MD5(NEW.password_usuario);
END IF
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `encriptarClave` BEFORE INSERT ON `tbl_usuario` FOR EACH ROW BEGIN
SET NEW.password_usuario = MD5(NEW.password_usuario);
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_usuario_aplicacion`
--

CREATE TABLE `tbl_usuario_aplicacion` (
  `PK_id_usuario` varchar(25) NOT NULL,
  `PK_id_aplicacion` int(11) NOT NULL,
  `ingresar` tinyint(4) DEFAULT NULL,
  `consultar` tinyint(4) DEFAULT NULL,
  `modificar` tinyint(4) DEFAULT NULL,
  `eliminar` tinyint(4) DEFAULT NULL,
  `imprimir` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_usuario_perfil`
--

CREATE TABLE `tbl_usuario_perfil` (
  `PK_id_usuario` varchar(25) NOT NULL,
  `PK_id_perfil` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_usuario_perfil`
--

INSERT INTO `tbl_usuario_perfil` (`PK_id_usuario`, `PK_id_perfil`) VALUES
('choc', 2),
('rchocm', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tbl_aplicacion`
--
ALTER TABLE `tbl_aplicacion`
  ADD PRIMARY KEY (`PK_id_aplicacion`,`PK_id_modulo`),
  ADD KEY `fk_Aplicacion_Modulo` (`PK_id_modulo`);

--
-- Indices de la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  ADD PRIMARY KEY (`PK_id_bitacora`,`PK_id_usuario`),
  ADD KEY `fk_Bitacora_Usuario1` (`PK_id_usuario`);

--
-- Indices de la tabla `tbl_modulo`
--
ALTER TABLE `tbl_modulo`
  ADD PRIMARY KEY (`PK_id_Modulo`);

--
-- Indices de la tabla `tbl_perfil_detalle`
--
ALTER TABLE `tbl_perfil_detalle`
  ADD PRIMARY KEY (`PK_id_perfil`,`PK_id_aplicacion`),
  ADD KEY `fk_Perfil_detalle_Aplicacion1` (`PK_id_aplicacion`);

--
-- Indices de la tabla `tbl_perfil_encabezado`
--
ALTER TABLE `tbl_perfil_encabezado`
  ADD PRIMARY KEY (`PK_id_perfil`);

--
-- Indices de la tabla `tbl_usuario`
--
ALTER TABLE `tbl_usuario`
  ADD PRIMARY KEY (`PK_id_usuario`);

--
-- Indices de la tabla `tbl_usuario_aplicacion`
--
ALTER TABLE `tbl_usuario_aplicacion`
  ADD PRIMARY KEY (`PK_id_usuario`,`PK_id_aplicacion`),
  ADD KEY `fk_tbl_usuario_aplicacion_tbl_aplicacion1` (`PK_id_aplicacion`);

--
-- Indices de la tabla `tbl_usuario_perfil`
--
ALTER TABLE `tbl_usuario_perfil`
  ADD PRIMARY KEY (`PK_id_usuario`,`PK_id_perfil`),
  ADD KEY `fk_Usuario_perfil_Perfil1` (`PK_id_perfil`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  MODIFY `PK_id_bitacora` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `tbl_aplicacion`
--
ALTER TABLE `tbl_aplicacion`
  ADD CONSTRAINT `fk_Aplicacion_Modulo` FOREIGN KEY (`PK_id_modulo`) REFERENCES `tbl_modulo` (`PK_id_Modulo`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  ADD CONSTRAINT `fk_Bitacora_Usuario1` FOREIGN KEY (`PK_id_usuario`) REFERENCES `tbl_usuario` (`PK_id_usuario`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_perfil_detalle`
--
ALTER TABLE `tbl_perfil_detalle`
  ADD CONSTRAINT `fk_Perfil_detalle_Aplicacion1` FOREIGN KEY (`PK_id_aplicacion`) REFERENCES `tbl_aplicacion` (`PK_id_aplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Perfil_detalle_Perfil1` FOREIGN KEY (`PK_id_perfil`) REFERENCES `tbl_perfil_encabezado` (`PK_id_perfil`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_usuario_aplicacion`
--
ALTER TABLE `tbl_usuario_aplicacion`
  ADD CONSTRAINT `fk_Usuario_aplicacion_Usuario1` FOREIGN KEY (`PK_id_usuario`) REFERENCES `tbl_usuario` (`PK_id_usuario`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_usuario_aplicacion_tbl_aplicacion1` FOREIGN KEY (`PK_id_aplicacion`) REFERENCES `tbl_aplicacion` (`PK_id_aplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_usuario_perfil`
--
ALTER TABLE `tbl_usuario_perfil`
  ADD CONSTRAINT `fk_Usuario_perfil_Perfil1` FOREIGN KEY (`PK_id_perfil`) REFERENCES `tbl_perfil_encabezado` (`PK_id_perfil`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Usuario_perfil_Usuario1` FOREIGN KEY (`PK_id_usuario`) REFERENCES `tbl_usuario` (`PK_id_usuario`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
