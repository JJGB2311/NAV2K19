-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-11-2019 a las 00:23:40
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
-- Base de datos: `proyectogeneral`
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
-- Estructura de tabla para la tabla `ayuda`
--

CREATE TABLE `ayuda` (
  `Id_ayuda` int(11) NOT NULL,
  `Ruta` text COLLATE utf8_unicode_ci NOT NULL,
  `indice` text COLLATE utf8_unicode_ci NOT NULL,
  `estado` int(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `ayuda`
--

INSERT INTO `ayuda` (`Id_ayuda`, `Ruta`, `indice`, `estado`) VALUES
(1, 'Página web ayuda/ayuda.chm', 'menu.html', 1),
(2, 'Página web ayuda/ayuda.chm', 'Menúboletos.html', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tblproveedorbodega`
--

CREATE TABLE `tblproveedorbodega` (
  `KidProveedorBodega` int(16) NOT NULL,
  `KidProveedor` int(16) NOT NULL,
  `KidBodega` int(16) NOT NULL,
  `KidProducto` int(16) NOT NULL,
  `stock` int(3) DEFAULT NULL,
  `maxStock` int(3) DEFAULT NULL,
  `minStock` int(3) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_acreedor`
--

CREATE TABLE `tbl_acreedor` (
  `KidAcreedor` int(12) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(150) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_aplicacion`
--

CREATE TABLE `tbl_aplicacion` (
  `PK_id_aplicacion` int(11) NOT NULL,
  `PK_id_modulo` int(11) NOT NULL,
  `nombre_aplicacion` varchar(45) DEFAULT NULL,
  `descripcion_aplicacion` varchar(200) DEFAULT NULL,
  `estado_aplicacion` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_aplicacion`
--

INSERT INTO `tbl_aplicacion` (`PK_id_aplicacion`, `PK_id_modulo`, `nombre_aplicacion`, `descripcion_aplicacion`, `estado_aplicacion`) VALUES
(1, 1, 'Administracion', 'Admin del Hotel', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_areas`
--

CREATE TABLE `tbl_areas` (
  `KidArea` int(11) NOT NULL,
  `nombreArea` varchar(45) DEFAULT NULL,
  `estado` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_areas`
--

INSERT INTO `tbl_areas` (`KidArea`, `nombreArea`, `estado`) VALUES
(1, 'Resturante', 1),
(2, 'Lobby', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_asignacion_empleado`
--

CREATE TABLE `tbl_asignacion_empleado` (
  `KidPoliza` int(11) NOT NULL,
  `KidComisiones` int(11) NOT NULL,
  `KidEmpleados` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_balancegeneral_detalle`
--

CREATE TABLE `tbl_balancegeneral_detalle` (
  `KidBalanceGeneral` int(11) NOT NULL,
  `KidCuentaContable` int(11) NOT NULL,
  `valor` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_balancegeneral_encabezado`
--

CREATE TABLE `tbl_balancegeneral_encabezado` (
  `KidBalanceGeneral` int(11) NOT NULL,
  `capital` float DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_bancos`
--

CREATE TABLE `tbl_bancos` (
  `KidBanco` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(150) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_bancotalento`
--

CREATE TABLE `tbl_bancotalento` (
  `KidBancoTalento` int(11) NOT NULL,
  `nombre_candidato` varchar(45) DEFAULT NULL,
  `apellido_candidato` varchar(45) DEFAULT NULL,
  `numero` int(11) DEFAULT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `correoelectronico` varchar(45) DEFAULT NULL,
  `KidReporteVacante` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_bodega`
--

CREATE TABLE `tbl_bodega` (
  `KidBodega` int(16) NOT NULL,
  `KidSucursal` int(16) NOT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  `direccion` varchar(20) DEFAULT NULL,
  `maxStock` int(3) DEFAULT NULL,
  `minStock` int(3) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_carpeta_mdl`
--

CREATE TABLE `tbl_carpeta_mdl` (
  `ID_CONFIGURACION` int(12) NOT NULL,
  `ID_MODULO` int(12) NOT NULL,
  `ESTADO` int(2) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_carpeta_mdl`
--

INSERT INTO `tbl_carpeta_mdl` (`ID_CONFIGURACION`, `ID_MODULO`, `ESTADO`) VALUES
(2, 1, 1),
(3, 2, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_categorias_habitacion`
--

CREATE TABLE `tbl_categorias_habitacion` (
  `KidCategoria` varchar(45) NOT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_categorias_habitacion`
--

INSERT INTO `tbl_categorias_habitacion` (`KidCategoria`, `estado`) VALUES
('Especial', 1),
('Normal', 1);

--
-- Disparadores `tbl_categorias_habitacion`
--
DELIMITER $$
CREATE TRIGGER `EstadoHabitaciones2` AFTER UPDATE ON `tbl_categorias_habitacion` FOR EACH ROW BEGIN
UPDATE tbl_habitaciones set estado = new.estado WHERE tbl_habitaciones.KidCategoria=new.KidCategoria;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_check_in`
--

CREATE TABLE `tbl_check_in` (
  `KidCheckIn` int(11) NOT NULL,
  `KidCliente` int(11) NOT NULL,
  `KidEmpleado` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_check_out`
--

CREATE TABLE `tbl_check_out` (
  `KidCheckOut` int(11) NOT NULL,
  `KidCliente` int(11) NOT NULL,
  `KidEmpleado` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_chequera`
--

CREATE TABLE `tbl_chequera` (
  `KidChequera` int(4) NOT NULL,
  `KidCuentaBancaria` int(11) NOT NULL,
  `No_cheques` int(4) NOT NULL,
  `estado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_clientes`
--

CREATE TABLE `tbl_clientes` (
  `KidCliente` int(11) NOT NULL,
  `nombres_cliente` varchar(45) DEFAULT NULL,
  `apellidos_cliente` varchar(45) DEFAULT NULL,
  `telefono_cliente` varchar(10) DEFAULT NULL,
  `direccion_cliente` text,
  `dpi_cliente` int(11) DEFAULT NULL,
  `nit_cliente` varchar(10) DEFAULT NULL,
  `contacto_cliente` varchar(45) DEFAULT NULL,
  `telefono_contacto` varchar(10) DEFAULT NULL,
  `KidTipoCliente` int(11) NOT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_comandas`
--

CREATE TABLE `tbl_comandas` (
  `KidNumeroComanda` int(11) NOT NULL,
  `KidServicio` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_comandas`
--

INSERT INTO `tbl_comandas` (`KidNumeroComanda`, `KidServicio`, `estado`) VALUES
(1, 1, 1),
(2, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_comisiones`
--

CREATE TABLE `tbl_comisiones` (
  `KidComisiones` int(11) NOT NULL,
  `KidTipoProducto` int(11) NOT NULL,
  `fecha_comisiones` date DEFAULT NULL,
  `descripcion_comisiones` varchar(45) DEFAULT NULL,
  `monto_comisiones` double DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_conceptos`
--

CREATE TABLE `tbl_conceptos` (
  `KidConcepto` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `naturalezaconcepto` varchar(45) DEFAULT NULL,
  `valor` float DEFAULT NULL,
  `estado` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_conciliacion_bancaria`
--

CREATE TABLE `tbl_conciliacion_bancaria` (
  `KidBanco` int(11) NOT NULL,
  `Kperiodo` date NOT NULL,
  `diferencia` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_configuracion_rpt`
--

CREATE TABLE `tbl_configuracion_rpt` (
  `ID_CONFIGURACION` int(12) NOT NULL,
  `NOMBRE` varchar(50) NOT NULL,
  `USER` varchar(50) DEFAULT NULL,
  `PASSWORD` varchar(100) DEFAULT NULL,
  `PUERTO` varchar(3) DEFAULT NULL,
  `RUTA` varchar(100) NOT NULL,
  `ESTADO` int(2) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_configuracion_rpt`
--

INSERT INTO `tbl_configuracion_rpt` (`ID_CONFIGURACION`, `NOMBRE`, `USER`, `PASSWORD`, `PUERTO`, `RUTA`, `ESTADO`) VALUES
(1, 'plantillas', 'na', 'na', 'na', 'C:\\\\Reportes\\\\recursos\\\\', 1),
(2, 'MDI', 'na', 'na', 'na', 'C:\\\\Reportes\\\\MDI\\\\', 1),
(3, 'mdlSeguridad', 'na', 'na', 'na', 'C:\\\\Reportes\\\\Seguridad\\\\', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_consulta`
--

CREATE TABLE `tbl_consulta` (
  `KidConsulta` int(11) NOT NULL,
  `cadena_consulta` varchar(255) DEFAULT NULL,
  `nombreconsulta_consulta` varchar(45) DEFAULT NULL,
  `descripcion_consulta` varchar(255) DEFAULT NULL,
  `KidUsuario` varchar(45) NOT NULL,
  `disponible` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_contacto`
--

CREATE TABLE `tbl_contacto` (
  `KidContacto` int(16) NOT NULL,
  `KidProveedor` int(16) NOT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `telefono` varchar(15) DEFAULT NULL,
  `email` varchar(20) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_control_mesas`
--

CREATE TABLE `tbl_control_mesas` (
  `KidControl` int(11) NOT NULL,
  `KidNumeroMesa` int(11) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_cotizaciondetalle`
--

CREATE TABLE `tbl_cotizaciondetalle` (
  `KidCotizacionDetalle` int(11) NOT NULL,
  `KidProducto` int(11) DEFAULT NULL,
  `cantidad_cotizacionDetalle` int(11) DEFAULT NULL,
  `monto_cotizacionDetalle` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_cotizacionencabezado`
--

CREATE TABLE `tbl_cotizacionencabezado` (
  `KidCotizacionEncabezado` int(11) NOT NULL,
  `KidCliente` int(11) DEFAULT NULL,
  `fecha_cotizacionEncabezado` date DEFAULT NULL,
  `vencimiento_cotizacionEncabezado` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_creditopedido`
--

CREATE TABLE `tbl_creditopedido` (
  `KidCreditoPedido` int(12) NOT NULL,
  `KidPedido` int(12) NOT NULL,
  `KidBanco` int(12) NOT NULL,
  `total` double(12,2) NOT NULL,
  `cuotas` int(2) NOT NULL,
  `fechaIni` timestamp NULL DEFAULT NULL,
  `fechaFin` timestamp NULL DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_creditoservicio`
--

CREATE TABLE `tbl_creditoservicio` (
  `KidCreditoServicio` int(12) NOT NULL,
  `KidPagoServicio` int(12) NOT NULL,
  `KidBanco` int(12) NOT NULL,
  `total` double(12,2) NOT NULL,
  `cuotas` int(2) NOT NULL,
  `fechaIni` timestamp NULL DEFAULT NULL,
  `fechaFin` timestamp NULL DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_credpeddet`
--

CREATE TABLE `tbl_credpeddet` (
  `KidCodigoCresDet` int(12) NOT NULL,
  `KidCreditoPedido` int(12) NOT NULL,
  `valor` double(12,2) NOT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_credservdet`
--

CREATE TABLE `tbl_credservdet` (
  `KidCredServDet` int(12) NOT NULL,
  `KidCreditoServicio` int(12) NOT NULL,
  `valor` double(12,2) NOT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_cuentabancaria`
--

CREATE TABLE `tbl_cuentabancaria` (
  `KidCuentaBancaria` int(11) NOT NULL,
  `NumeroCuenta` varchar(20) NOT NULL,
  `Descripcion` varchar(45) DEFAULT NULL,
  `KidBanco` int(11) NOT NULL,
  `KidMoneda` varchar(11) NOT NULL,
  `Firmas_Individuales` varchar(45) DEFAULT NULL,
  `Firmas_Conjuntas` varchar(45) DEFAULT NULL,
  `Saldo` varchar(20) DEFAULT NULL,
  `Cuenta_Primaria` tinyint(4) NOT NULL,
  `estado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_cuentas`
--

CREATE TABLE `tbl_cuentas` (
  `KidCuenta` int(11) NOT NULL,
  `KidTipoCuenta` int(11) NOT NULL,
  `nombre` varchar(25) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_departamentos`
--

CREATE TABLE `tbl_departamentos` (
  `KidDepartamento` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `numdepartamento` varchar(45) DEFAULT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `KidArea` int(11) DEFAULT NULL,
  `estado` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_descuentos`
--

CREATE TABLE `tbl_descuentos` (
  `KidDescuentos` int(11) NOT NULL,
  `nombre_descuentos` varchar(45) DEFAULT NULL,
  `porcentaje_descuentos` double DEFAULT NULL,
  `fecha_inicio_descuentos` date DEFAULT NULL,
  `fecha_final_descuentos` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_descuentos`
--

INSERT INTO `tbl_descuentos` (`KidDescuentos`, `nombre_descuentos`, `porcentaje_descuentos`, `fecha_inicio_descuentos`, `fecha_final_descuentos`, `estado`) VALUES
(200, 'ninguno', 0, '2019-11-04', '2019-11-07', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detallecomprobante`
--

CREATE TABLE `tbl_detallecomprobante` (
  `KidDetalleComprobante` int(11) NOT NULL,
  `articulo_servicio` varchar(45) DEFAULT NULL,
  `Precio` double DEFAULT NULL,
  `Cantidad` int(11) DEFAULT NULL,
  `Descuento` double DEFAULT NULL,
  `Ivaincluido` tinyint(1) DEFAULT NULL,
  `Concepto` varchar(45) DEFAULT NULL,
  `Total` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detallepedido`
--

CREATE TABLE `tbl_detallepedido` (
  `KidDetallePedido` int(11) NOT NULL,
  `KidProducto` int(11) DEFAULT NULL,
  `cantidad_Detallepedido` int(11) DEFAULT NULL,
  `monto_Detallepedido` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detallereportevacante`
--

CREATE TABLE `tbl_detallereportevacante` (
  `KidReporteVacante` int(11) NOT NULL,
  `razon` varchar(200) DEFAULT NULL,
  `DescripcionCualidades` varchar(200) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detalle_control`
--

CREATE TABLE `tbl_detalle_control` (
  `KidNumeroDetalle` int(11) NOT NULL,
  `KidControl` int(11) NOT NULL,
  `KidPlatillo` int(11) NOT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detalle_evento`
--

CREATE TABLE `tbl_detalle_evento` (
  `KidNumeroDetalle` int(11) NOT NULL,
  `KidNumeroSalon` int(11) NOT NULL,
  `KidEvento` int(11) DEFAULT NULL,
  `llegada` date DEFAULT NULL,
  `salida` date DEFAULT NULL,
  `requisitos` varchar(45) DEFAULT NULL,
  `tipo` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detalle_folio`
--

CREATE TABLE `tbl_detalle_folio` (
  `KidFolio` int(11) NOT NULL,
  `KidNumeroDetalle` int(11) NOT NULL,
  `KidComanda` int(11) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `monto` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detalle_lista_precios`
--

CREATE TABLE `tbl_detalle_lista_precios` (
  `KidDetalleListaPrecios` int(11) NOT NULL,
  `KidProducto` int(11) DEFAULT NULL,
  `Kidtipo_lista_precios` int(11) DEFAULT NULL,
  `nombre_listaprecios` varchar(50) DEFAULT NULL,
  `precio_listaprecios` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detalle_producto`
--

CREATE TABLE `tbl_detalle_producto` (
  `Kiddetalleproducto` int(11) NOT NULL,
  `Kidproducto` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `presentacion` varchar(45) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detalle_reservacion`
--

CREATE TABLE `tbl_detalle_reservacion` (
  `KidNumeroDetalle` int(11) NOT NULL,
  `KidReservacion` int(11) DEFAULT NULL,
  `KidNumeroHabitacion` int(11) DEFAULT NULL,
  `llegada` date DEFAULT NULL,
  `salida` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_detalle_roles`
--

CREATE TABLE `tbl_detalle_roles` (
  `KidRolpago` int(11) NOT NULL,
  `KidEmpleado` int(11) NOT NULL,
  `remuneracion` float DEFAULT NULL,
  `horasExtras` int(11) DEFAULT NULL,
  `aporteigss` int(11) DEFAULT NULL,
  `gastos` float DEFAULT NULL,
  `vacaciones` int(11) DEFAULT NULL,
  `sueldototal` float DEFAULT NULL,
  `prestamos` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_devoluciones`
--

CREATE TABLE `tbl_devoluciones` (
  `kidDevoluciones` int(11) NOT NULL,
  `motivo_devoluciones` varchar(45) DEFAULT NULL,
  `fecha_devoluciones` date DEFAULT NULL,
  `KidFacturaEncabezado` int(11) NOT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_devoluciones_platillos`
--

CREATE TABLE `tbl_devoluciones_platillos` (
  `KidDevPlatillo` int(11) NOT NULL,
  `KidPlatillo` int(11) NOT NULL,
  `motivo` varchar(45) DEFAULT NULL,
  `resolucion` varchar(45) DEFAULT NULL,
  `costo` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_divisa`
--

CREATE TABLE `tbl_divisa` (
  `KidDivisa` varchar(11) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_empleado`
--

CREATE TABLE `tbl_empleado` (
  `KidEmpleado` int(11) NOT NULL,
  `nombres` varchar(45) DEFAULT NULL,
  `apellidos` varchar(45) DEFAULT NULL,
  `dpi` varchar(35) DEFAULT NULL,
  `nit` varchar(25) DEFAULT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `telefonoalternativo` varchar(45) DEFAULT NULL,
  `correo` varchar(45) DEFAULT NULL,
  `correoalternativo` varchar(45) DEFAULT NULL,
  `fechanacimiento` date DEFAULT NULL,
  `estadoCivil` varchar(45) DEFAULT NULL,
  `KidPuesto` int(11) DEFAULT NULL,
  `KidDepartamento` int(11) DEFAULT NULL,
  `estado` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_encabezadocomprobante`
--

CREATE TABLE `tbl_encabezadocomprobante` (
  `KidEncabezadoComprobante` int(11) NOT NULL,
  `KidFacturaEncabezado` int(11) DEFAULT NULL,
  `KidCliente` int(11) NOT NULL,
  `KidEmpleado` int(11) NOT NULL,
  `KidtiposComprobantes` int(11) NOT NULL,
  `Serie` varchar(45) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `Moneda` varchar(45) DEFAULT NULL,
  `Cotizacion` double DEFAULT NULL,
  `Centro` varchar(45) DEFAULT NULL,
  `fechaVencimiento` date DEFAULT NULL,
  `Periodo` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_encabezadopedido`
--

CREATE TABLE `tbl_encabezadopedido` (
  `KidEncabezadoPedido` int(11) NOT NULL,
  `KidFacturaEncabezado` int(11) DEFAULT NULL,
  `KidCliente` int(11) DEFAULT NULL,
  `fecha_encabezadopedido` date DEFAULT NULL,
  `vencimiento_encabezadopedido` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_encabezadoreportevacante`
--

CREATE TABLE `tbl_encabezadoreportevacante` (
  `KidReporteVacante` int(11) NOT NULL,
  `KidEmpleado` int(11) DEFAULT NULL,
  `KidPuesto` int(11) DEFAULT NULL,
  `fechaCreacion` date DEFAULT NULL,
  `tipoDeContratacion` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_encabezado_lista_precios`
--

CREATE TABLE `tbl_encabezado_lista_precios` (
  `KidEncabezadoListaPrecios` int(11) NOT NULL,
  `Fecha_inicio_listaprecios` date DEFAULT NULL,
  `fecha_modificacion_listaprecios` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_estado_perdidas_ganacias_detalle`
--

CREATE TABLE `tbl_estado_perdidas_ganacias_detalle` (
  `KidPerdidasGanancias` int(11) NOT NULL,
  `KidCuenta` int(11) NOT NULL,
  `debe` float DEFAULT NULL,
  `haber` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_estado_perdidas_ganancias_encabezado`
--

CREATE TABLE `tbl_estado_perdidas_ganancias_encabezado` (
  `KidPerdidasGanancias` int(11) NOT NULL,
  `gananciaEnOperacion` float DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_eventos`
--

CREATE TABLE `tbl_eventos` (
  `KidEvento` int(11) NOT NULL,
  `KidCliente` int(11) NOT NULL,
  `_KidEmpleado` int(11) NOT NULL,
  `fechaEvento` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_existencia`
--

CREATE TABLE `tbl_existencia` (
  `Kidexistencia` int(11) NOT NULL,
  `kidproducto` int(11) NOT NULL,
  `cantidad` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_existencias`
--

CREATE TABLE `tbl_existencias` (
  `KidExistencia` int(11) NOT NULL,
  `KidProducto` int(11) DEFAULT NULL,
  `KidBodega` int(11) DEFAULT NULL,
  `existencia` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_facturadetalle`
--

CREATE TABLE `tbl_facturadetalle` (
  `KidFacturaDetalle` int(11) NOT NULL,
  `cantidad_facturadetalle` int(11) DEFAULT NULL,
  `monto_facturadetalle` double DEFAULT NULL,
  `KidProducto` int(11) NOT NULL,
  `KidFacturaEncabezado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_facturaencabezado`
--

CREATE TABLE `tbl_facturaencabezado` (
  `KidFacturaEncabezado` int(11) NOT NULL,
  `KidEncabezadoListaPrecios` int(11) NOT NULL,
  `KidCotizacionEncabezado` int(11) DEFAULT NULL,
  `fecha_facturaencabezado` date DEFAULT NULL,
  `descripcion_facturaencabezado` varchar(45) DEFAULT NULL,
  `KidSerie` int(11) NOT NULL,
  `KidCliente` int(11) NOT NULL,
  `KidImpuesto` int(11) NOT NULL,
  `KidMoneda` int(11) NOT NULL,
  `KidDescuentos` int(11) NOT NULL,
  `impuesto_facturaencabezado` double DEFAULT NULL,
  `monto_facturaencabezado` double DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_flujoefectivo_detalle`
--

CREATE TABLE `tbl_flujoefectivo_detalle` (
  `KidFlujoEfectivo` int(11) NOT NULL,
  `KidCuenta` int(11) NOT NULL,
  `valor` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_flujoefectivo_encabezado`
--

CREATE TABLE `tbl_flujoefectivo_encabezado` (
  `KidFlujoEfectivo` int(11) NOT NULL,
  `total_efectivo` float DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_folios`
--

CREATE TABLE `tbl_folios` (
  `KidFolio` int(11) NOT NULL,
  `KidCliente` int(11) DEFAULT NULL,
  `fechaApertura` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_gestionmovimientocliente`
--

CREATE TABLE `tbl_gestionmovimientocliente` (
  `KidGestionMovimientoCliente` int(11) NOT NULL,
  `KidEncabezadoComprobante` int(11) NOT NULL,
  `SaldoCliente` double DEFAULT NULL,
  `Debe` double DEFAULT NULL,
  `Haber` double DEFAULT NULL,
  `SaldoComprobante` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_habitaciones`
--

CREATE TABLE `tbl_habitaciones` (
  `KidNumeroHabitacion` int(11) NOT NULL,
  `KidTipoHabitacion` varchar(45) DEFAULT NULL,
  `KidCategoria` varchar(45) DEFAULT NULL,
  `precio` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_habitaciones`
--

INSERT INTO `tbl_habitaciones` (`KidNumeroHabitacion`, `KidTipoHabitacion`, `KidCategoria`, `precio`, `estado`) VALUES
(101, 'Simple', 'Normal', 1500, 1),
(102, 'Simple', 'Especial', 3000, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_historia_inventario`
--

CREATE TABLE `tbl_historia_inventario` (
  `Kidproducto` int(11) NOT NULL,
  `Kidmovimientoinventario` int(11) NOT NULL,
  `Kidbodega` int(11) NOT NULL,
  `Kidsucursal` int(11) NOT NULL,
  `fecha` datetime DEFAULT NULL,
  `cantidad` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_impuesto`
--

CREATE TABLE `tbl_impuesto` (
  `KidImpuesto` int(11) NOT NULL,
  `nombre_impuesto` varchar(45) DEFAULT NULL,
  `descripcion_impuesto` varchar(150) DEFAULT NULL,
  `porcentaje_impuesto` double DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_ingredientes`
--

CREATE TABLE `tbl_ingredientes` (
  `KidIngredientes` int(11) NOT NULL,
  `KidProducto` int(11) NOT NULL,
  `KidRecetas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_inventario`
--

CREATE TABLE `tbl_inventario` (
  `KidInventario` int(11) NOT NULL,
  `KidProducto` int(11) NOT NULL,
  `Kidbodega` int(11) NOT NULL,
  `Kidstock` int(11) NOT NULL,
  `Kidexistencia` int(11) NOT NULL,
  `fecha_inventario` date DEFAULT NULL,
  `cantidad_inventario` int(11) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_librodiario_detalle`
--

CREATE TABLE `tbl_librodiario_detalle` (
  `KidLibroDiarioEncabezado` int(11) NOT NULL,
  `KidPoliza` int(11) NOT NULL,
  `debe` float DEFAULT NULL,
  `haber` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_librodiario_encabezado`
--

CREATE TABLE `tbl_librodiario_encabezado` (
  `KidLibroDiarioEncabezado` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `total_debe` float DEFAULT NULL,
  `total_haber` float DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_libromayor_detalle`
--

CREATE TABLE `tbl_libromayor_detalle` (
  `KidLibroMayor` int(11) NOT NULL,
  `debe` float DEFAULT NULL,
  `haber` float DEFAULT NULL,
  `saldo_parcial` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_libromayor_encabezado`
--

CREATE TABLE `tbl_libromayor_encabezado` (
  `KidLibroMayor` int(11) NOT NULL,
  `KidLibroDiarioEncabezado` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `saldo_final` float DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_libro_bancos`
--

CREATE TABLE `tbl_libro_bancos` (
  `KidMovimiento` int(11) NOT NULL,
  `KidBanco` int(11) NOT NULL,
  `fecha_movimiento` date DEFAULT NULL,
  `monto` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_lista_precios_productos`
--

CREATE TABLE `tbl_lista_precios_productos` (
  `KidLista_precios` int(11) NOT NULL,
  `KidProducto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_marca`
--

CREATE TABLE `tbl_marca` (
  `Kidmarca` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `paisOrigen` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_menus`
--

CREATE TABLE `tbl_menus` (
  `KidMenu` int(11) NOT NULL,
  `nombreMenu` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_menus`
--

INSERT INTO `tbl_menus` (`KidMenu`, `nombreMenu`, `estado`) VALUES
(1, 'Entradas', 1),
(2, 'bebidas', 1),
(3, 'Postres', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_mesas`
--

CREATE TABLE `tbl_mesas` (
  `KidNumeroMesa` int(11) NOT NULL,
  `KidArea` int(11) NOT NULL,
  `capacidad` int(11) DEFAULT NULL,
  `estadoMesa` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_mesas`
--

INSERT INTO `tbl_mesas` (`KidNumeroMesa`, `KidArea`, `capacidad`, `estadoMesa`, `estado`) VALUES
(1, 1, 5, 1, 1),
(2, 1, 4, 1, 1);

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
-- Estructura de tabla para la tabla `tbl_moneda`
--

CREATE TABLE `tbl_moneda` (
  `KidMoneda` int(11) NOT NULL,
  `nombre_moneda` varchar(45) DEFAULT NULL,
  `tasa_moneda` double DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_moviemiento_inventario`
--

CREATE TABLE `tbl_moviemiento_inventario` (
  `Kidmoviemientoinventario` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `naturaleza` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_nominasdetalle`
--

CREATE TABLE `tbl_nominasdetalle` (
  `KidLinea` int(11) NOT NULL,
  `KidNomina` int(11) NOT NULL,
  `KidConcepto` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_nominasencabezado`
--

CREATE TABLE `tbl_nominasencabezado` (
  `KidNomina` int(11) NOT NULL,
  `KidEmpleado` int(11) NOT NULL,
  `dias` int(11) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `sueldoliquido` float DEFAULT NULL,
  `perdidaoganancia` tinyint(1) DEFAULT NULL,
  `estado` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_objetos_perdidos`
--

CREATE TABLE `tbl_objetos_perdidos` (
  `KidObjeto` int(11) NOT NULL,
  `KidNumeroHabitacion` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_objetos_perdidos`
--

INSERT INTO `tbl_objetos_perdidos` (`KidObjeto`, `KidNumeroHabitacion`, `fecha`, `descripcion`, `estado`) VALUES
(1, 101, '2019-11-03', 'Sueter Azul', 1),
(2, 101, '2019-11-01', 'Zapato Deportivo Rojo', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_orden_compra_encabezado`
--

CREATE TABLE `tbl_orden_compra_encabezado` (
  `KidOrdenCompraEncabezado` int(16) NOT NULL,
  `KidProveedor` int(16) NOT NULL,
  `KidImpuesto` int(12) DEFAULT NULL,
  `fechaEmisionOrdenCompraEncabezado` date NOT NULL,
  `fechaRevisionOrdenCompraEncabezado` date NOT NULL,
  `nombreOrdenCompraEncabezado` varchar(30) DEFAULT NULL,
  `descripcionOrdenCompraEncabezado` varchar(100) DEFAULT NULL,
  `fechaEstimadaEntregaOrdenCompraEncabezado` datetime DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_orden_dompra_detalle`
--

CREATE TABLE `tbl_orden_dompra_detalle` (
  `KidOrdenCompraDetalle` int(16) NOT NULL,
  `KidOrdenCompraEncabezado` int(16) NOT NULL,
  `KidProducto` int(16) NOT NULL,
  `precioUnitario` float(4,2) DEFAULT NULL,
  `cantidadProducto` int(3) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_pagos`
--

CREATE TABLE `tbl_pagos` (
  `KidPagos` int(11) NOT NULL,
  `fecha_pagos` date DEFAULT NULL,
  `descripcion_pagos` varchar(45) DEFAULT NULL,
  `monto_pagos` double DEFAULT NULL,
  `KidTipoPago` int(11) NOT NULL,
  `KidFacturaEncabezado` int(11) NOT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_pagoservicio`
--

CREATE TABLE `tbl_pagoservicio` (
  `KidPagoServicio` int(12) NOT NULL,
  `KidAcreedor` int(12) NOT NULL,
  `KidServicio` int(12) NOT NULL,
  `fecha` datetime NOT NULL,
  `monto` decimal(10,2) NOT NULL,
  `impuesto` int(12) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_pedido`
--

CREATE TABLE `tbl_pedido` (
  `KidPedido` int(12) NOT NULL,
  `KidProveedor` int(12) NOT NULL,
  `KidOrdenCompra` int(12) NOT NULL,
  `total` double(12,2) NOT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_pedidodet`
--

CREATE TABLE `tbl_pedidodet` (
  `KidPedido` int(12) NOT NULL,
  `KidProducto` int(12) NOT NULL,
  `cantidad` int(3) NOT NULL,
  `valor` double(12,2) NOT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
-- Estructura de tabla para la tabla `tbl_planillasdetalle`
--

CREATE TABLE `tbl_planillasdetalle` (
  `KidPlanilla` int(11) NOT NULL,
  `Ktipo` int(11) NOT NULL,
  `documento` varchar(45) DEFAULT NULL,
  `KidEmpleado` int(11) DEFAULT NULL,
  `ingresos` float DEFAULT NULL,
  `descuentos` float DEFAULT NULL,
  `importeneto` float DEFAULT NULL,
  `estadoenvio` float DEFAULT NULL,
  `estadoregistro` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_planillasencabezado`
--

CREATE TABLE `tbl_planillasencabezado` (
  `KidPlanilla` int(11) NOT NULL,
  `tipo` varchar(25) DEFAULT NULL,
  `clase` varchar(25) DEFAULT NULL,
  `fechaemision` date DEFAULT NULL,
  `correlativo` int(11) DEFAULT NULL,
  `total` float DEFAULT NULL,
  `estado` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_platillos`
--

CREATE TABLE `tbl_platillos` (
  `KidPlatillo` int(11) NOT NULL,
  `KidMenu` int(11) NOT NULL,
  `nombrePlatillo` varchar(45) DEFAULT NULL,
  `precio` float DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_platillos`
--

INSERT INTO `tbl_platillos` (`KidPlatillo`, `KidMenu`, `nombrePlatillo`, `precio`, `estado`) VALUES
(1, 1, 'Camarones al Ajillo', 45, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_poliza`
--

CREATE TABLE `tbl_poliza` (
  `KidPoliza` int(11) NOT NULL,
  `KidFacturaDetalle` int(11) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `monto` double DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_poliza_detalle`
--

CREATE TABLE `tbl_poliza_detalle` (
  `KidPoliza` int(11) NOT NULL,
  `KidCuenta` int(11) NOT NULL,
  `debe` double DEFAULT NULL,
  `haber` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_poliza_encabezado`
--

CREATE TABLE `tbl_poliza_encabezado` (
  `KidPoliza` int(11) NOT NULL,
  `KidTipoDePoliza` varchar(5) NOT NULL,
  `KidDocumentoAsociado` int(11) NOT NULL,
  `descripcion` varchar(150) DEFAULT NULL,
  `fecha_poliza` date DEFAULT NULL,
  `total_poliza` double DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_precios`
--

CREATE TABLE `tbl_precios` (
  `KidPrecios` int(11) NOT NULL,
  `precio_precios` double DEFAULT NULL,
  `descripcion_precios` varchar(45) DEFAULT NULL,
  `KidProducto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_presupuesto`
--

CREATE TABLE `tbl_presupuesto` (
  `Kidpresupuesto` int(11) NOT NULL,
  `KidMoneda` int(11) DEFAULT NULL,
  `KidArea` int(11) NOT NULL,
  `KidCuenta` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `descripcion` varchar(300) DEFAULT NULL,
  `monto` double DEFAULT NULL,
  `anotacion` varchar(45) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_producto`
--

CREATE TABLE `tbl_producto` (
  `KidProducto` int(11) NOT NULL,
  `KidTipoProducto` int(11) NOT NULL,
  `KidDescuentos` int(11) NOT NULL,
  `nombre_producto` varchar(45) DEFAULT NULL,
  `descripcion_producto` varchar(45) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_producto`
--

INSERT INTO `tbl_producto` (`KidProducto`, `KidTipoProducto`, `KidDescuentos`, `nombre_producto`, `descripcion_producto`, `estado`) VALUES
(101, 100, 200, 'Filete ', 'Trozo de Carne', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_producto_marca`
--

CREATE TABLE `tbl_producto_marca` (
  `Kidproducto` int(11) NOT NULL,
  `Kidmarca` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_proveedor`
--

CREATE TABLE `tbl_proveedor` (
  `KidProveedor` int(16) NOT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `telefono` varchar(15) DEFAULT NULL,
  `direccion` varchar(20) DEFAULT NULL,
  `pagina` varchar(20) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_pruebas`
--

CREATE TABLE `tbl_pruebas` (
  `KidPruebas` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `TiempoDuracion` varchar(45) DEFAULT NULL,
  `PreRequisitos` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_puestos`
--

CREATE TABLE `tbl_puestos` (
  `KidPuesto` int(11) NOT NULL,
  `KidArea` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `sueldofijo` varchar(45) DEFAULT NULL,
  `estado` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_quejas`
--

CREATE TABLE `tbl_quejas` (
  `KidQueja` int(11) NOT NULL,
  `KidCliente` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `queja` text,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_recetas`
--

CREATE TABLE `tbl_recetas` (
  `KidRecetas` int(11) NOT NULL,
  `receta` varchar(500) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_recetas`
--

INSERT INTO `tbl_recetas` (`KidRecetas`, `receta`, `estado`) VALUES
(1, 'Cocinar comida', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_reporte`
--

CREATE TABLE `tbl_reporte` (
  `ID_REPORTE` int(12) NOT NULL,
  `ID_CONFIGURACION` int(12) NOT NULL,
  `NOMBRE` varchar(50) NOT NULL,
  `FILENAME` varchar(100) NOT NULL,
  `ESTADO` int(2) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_reservaciones`
--

CREATE TABLE `tbl_reservaciones` (
  `KidReservacion` int(11) NOT NULL,
  `KidCliente` int(11) NOT NULL,
  `KidEmpleado` int(11) NOT NULL,
  `fechaReservacion` date DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_resultados`
--

CREATE TABLE `tbl_resultados` (
  `KidResultados` int(11) NOT NULL,
  `KidBancoTalento` int(11) DEFAULT NULL,
  `KidPruebas` int(11) DEFAULT NULL,
  `Resultado` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_roles_de_pago`
--

CREATE TABLE `tbl_roles_de_pago` (
  `KidRolpago` int(11) NOT NULL,
  `anio` date DEFAULT NULL,
  `mes` date DEFAULT NULL,
  `quincena` date DEFAULT NULL,
  `fechaelaboracion` date DEFAULT NULL,
  `estado` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_rpt_almacen`
--

CREATE TABLE `tbl_rpt_almacen` (
  `ID_RPT_ALMACEN` int(12) NOT NULL,
  `ID_USUARIO` int(12) NOT NULL,
  `ID_MODULO` int(12) NOT NULL,
  `NOMBRE` varchar(50) NOT NULL,
  `FECHA` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `ESTADO` int(12) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_rpt_app`
--

CREATE TABLE `tbl_rpt_app` (
  `ID_REPORTE` int(12) NOT NULL,
  `ID_APLICACION` int(11) NOT NULL,
  `ID_MODULO` int(11) NOT NULL,
  `ESTADO` int(2) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_rpt_mdl`
--

CREATE TABLE `tbl_rpt_mdl` (
  `ID_REPORTE` int(12) NOT NULL,
  `ID_MODULO` int(11) NOT NULL,
  `ESTADO` int(2) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_salones`
--

CREATE TABLE `tbl_salones` (
  `KidNumeroSalon` int(11) NOT NULL,
  `capacidad` int(11) DEFAULT NULL,
  `precio` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_salones`
--

INSERT INTO `tbl_salones` (`KidNumeroSalon`, `capacidad`, `precio`, `estado`) VALUES
(1, 200, 20000, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_serie`
--

CREATE TABLE `tbl_serie` (
  `KidSerie` int(11) NOT NULL,
  `KidFolio` int(11) NOT NULL,
  `serie_serie` varchar(45) DEFAULT NULL,
  `certificado_serie` varchar(45) DEFAULT NULL,
  `regimen_fiscal_serie` varchar(45) DEFAULT NULL,
  `formato_serie` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_servicio`
--

CREATE TABLE `tbl_servicio` (
  `KidServicio` int(12) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(150) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_servicios`
--

CREATE TABLE `tbl_servicios` (
  `KidServicio` int(11) NOT NULL,
  `KidArea` int(11) NOT NULL,
  `nombreServicio` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_servicios`
--

INSERT INTO `tbl_servicios` (`KidServicio`, `KidArea`, `nombreServicio`, `estado`) VALUES
(1, 1, 'Camaraderia', 1),
(2, 1, 'Cocina', 1),
(3, 1, 'Caja', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_solicitudrembolso`
--

CREATE TABLE `tbl_solicitudrembolso` (
  `KidSolicitudRembolso` int(11) NOT NULL,
  `fecha_solicitudrembolso` date DEFAULT NULL,
  `motivo_solicitudrembolso` varchar(45) DEFAULT NULL,
  `KidFacturaEncabezado` int(11) NOT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_stock`
--

CREATE TABLE `tbl_stock` (
  `Kidstock` int(11) NOT NULL,
  `cantidadMaxima` int(11) DEFAULT NULL,
  `cantidadMinima` int(11) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_sucursal`
--

CREATE TABLE `tbl_sucursal` (
  `KidSucursal` int(16) NOT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tiendas`
--

CREATE TABLE `tbl_tiendas` (
  `KidTienda` int(11) NOT NULL,
  `KidArea` int(11) NOT NULL,
  `descripcion` text,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_tiendas`
--

INSERT INTO `tbl_tiendas` (`KidTienda`, `KidArea`, `descripcion`, `estado`) VALUES
(1, 1, 'Cafeteria', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tiendas_producto`
--

CREATE TABLE `tbl_tiendas_producto` (
  `KidProducto` int(11) NOT NULL,
  `KidTienda` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipocambio`
--

CREATE TABLE `tbl_tipocambio` (
  `KidMonedaBase` varchar(11) NOT NULL,
  `KidMonedaConversion` varchar(11) NOT NULL,
  `tipo_cambio` float DEFAULT NULL,
  `fecha_tipo_cambio` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipocliente`
--

CREATE TABLE `tbl_tipocliente` (
  `KidTipoCliente` int(11) NOT NULL,
  `tipo_tipocliente` varchar(45) DEFAULT NULL,
  `descripcion_tipocliente` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipocuenta`
--

CREATE TABLE `tbl_tipocuenta` (
  `KidTipoCuenta` int(11) NOT NULL,
  `nombre_tipoCuenta` varchar(25) DEFAULT NULL,
  `descripcion_tipoCuenta` varchar(45) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipofactura`
--

CREATE TABLE `tbl_tipofactura` (
  `KidTipoFactura` int(11) NOT NULL,
  `tipo_tipofactura` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipopago`
--

CREATE TABLE `tbl_tipopago` (
  `KidTipoPago` int(11) NOT NULL,
  `tipo_tipopago` varchar(45) DEFAULT NULL,
  `descripcion_tipopago` varchar(45) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipoproducto`
--

CREATE TABLE `tbl_tipoproducto` (
  `KidTipoProducto` int(11) NOT NULL,
  `tipo_tipoproducto` varchar(45) DEFAULT NULL,
  `descripcion_tipoproducto` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_tipoproducto`
--

INSERT INTO `tbl_tipoproducto` (`KidTipoProducto`, `tipo_tipoproducto`, `descripcion_tipoproducto`) VALUES
(100, 'Res', 'Carne de res');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tiposcomprobantes`
--

CREATE TABLE `tbl_tiposcomprobantes` (
  `KidtiposComprobantes` int(11) NOT NULL,
  `NombreComprobante` varchar(45) DEFAULT NULL,
  `detalle` varchar(255) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipo_habitacion`
--

CREATE TABLE `tbl_tipo_habitacion` (
  `KidTipoHabitacion` varchar(45) NOT NULL,
  `numeroCamas` int(11) DEFAULT NULL,
  `numeroAmbientes` int(11) DEFAULT NULL,
  `numeroPersonas` varchar(45) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_tipo_habitacion`
--

INSERT INTO `tbl_tipo_habitacion` (`KidTipoHabitacion`, `numeroCamas`, `numeroAmbientes`, `numeroPersonas`, `estado`) VALUES
('Simple', 1, 1, '2', 1);

--
-- Disparadores `tbl_tipo_habitacion`
--
DELIMITER $$
CREATE TRIGGER `EstadoHabitaciones` AFTER UPDATE ON `tbl_tipo_habitacion` FOR EACH ROW BEGIN
UPDATE tbl_habitaciones set estado = new.estado WHERE tbl_habitaciones.KidTipoHabitacion=new.KidTipoHabitacion;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipo_lista_precios`
--

CREATE TABLE `tbl_tipo_lista_precios` (
  `Kidtipo_lista_precios` int(11) NOT NULL,
  `nombre_lista_precios_detalle` varchar(45) DEFAULT NULL,
  `descuento_lista_precios` double DEFAULT NULL,
  `estado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_tipo_poliza`
--

CREATE TABLE `tbl_tipo_poliza` (
  `KidTipoDePoliza` varchar(5) NOT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_ubicacion`
--

CREATE TABLE `tbl_ubicacion` (
  `Kidubicacion` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `capacidad` int(10) DEFAULT NULL,
  `estado` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_ubicacionprodcuto`
--

CREATE TABLE `tbl_ubicacionprodcuto` (
  `Kidubicacion` int(11) NOT NULL,
  `Kidproducto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  `estado_usuario` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tbl_usuario`
--

INSERT INTO `tbl_usuario` (`PK_id_usuario`, `nombre_usuario`, `apellido_usuarios`, `password_usuario`, `cambio_contrasena`, `estado_usuario`) VALUES
('MiUsuario', 'Usuario', 'Prueba', 'e19d5cd5af0378da05f63f891c7467af', 0, 1);

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
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tblproveedorbodega`
--
ALTER TABLE `tblproveedorbodega`
  ADD PRIMARY KEY (`KidProveedorBodega`),
  ADD KEY `FK_proveedor_bodega` (`KidProveedor`),
  ADD KEY `FK_bodega_proveedor` (`KidBodega`),
  ADD KEY `Fk_proveedor_bodega_producto` (`KidProducto`);

--
-- Indices de la tabla `tbl_acreedor`
--
ALTER TABLE `tbl_acreedor`
  ADD PRIMARY KEY (`KidAcreedor`);

--
-- Indices de la tabla `tbl_aplicacion`
--
ALTER TABLE `tbl_aplicacion`
  ADD PRIMARY KEY (`PK_id_aplicacion`,`PK_id_modulo`),
  ADD KEY `fk_Aplicacion_Modulo` (`PK_id_modulo`);

--
-- Indices de la tabla `tbl_areas`
--
ALTER TABLE `tbl_areas`
  ADD PRIMARY KEY (`KidArea`);

--
-- Indices de la tabla `tbl_asignacion_empleado`
--
ALTER TABLE `tbl_asignacion_empleado`
  ADD PRIMARY KEY (`KidPoliza`,`KidComisiones`),
  ADD KEY `fk_Ventas_has_Comisiones_Comisiones1` (`KidComisiones`),
  ADD KEY `fk_Asignacion_Empleado_Empleados1` (`KidEmpleados`);

--
-- Indices de la tabla `tbl_balancegeneral_detalle`
--
ALTER TABLE `tbl_balancegeneral_detalle`
  ADD PRIMARY KEY (`KidBalanceGeneral`,`KidCuentaContable`),
  ADD KEY `fk_tbl_BalanceGeneral_Detalle_tbl_cuentas_contables1` (`KidCuentaContable`);

--
-- Indices de la tabla `tbl_balancegeneral_encabezado`
--
ALTER TABLE `tbl_balancegeneral_encabezado`
  ADD PRIMARY KEY (`KidBalanceGeneral`);

--
-- Indices de la tabla `tbl_bancos`
--
ALTER TABLE `tbl_bancos`
  ADD PRIMARY KEY (`KidBanco`);

--
-- Indices de la tabla `tbl_bancotalento`
--
ALTER TABLE `tbl_bancotalento`
  ADD PRIMARY KEY (`KidBancoTalento`),
  ADD KEY `FK_encabezadoReporteVacante_BancoTalento` (`KidReporteVacante`);

--
-- Indices de la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  ADD PRIMARY KEY (`PK_id_bitacora`,`PK_id_usuario`),
  ADD KEY `fk_Bitacora_Usuario1` (`PK_id_usuario`);

--
-- Indices de la tabla `tbl_bodega`
--
ALTER TABLE `tbl_bodega`
  ADD PRIMARY KEY (`KidBodega`);

--
-- Indices de la tabla `tbl_carpeta_mdl`
--
ALTER TABLE `tbl_carpeta_mdl`
  ADD PRIMARY KEY (`ID_CONFIGURACION`,`ID_MODULO`),
  ADD KEY `FK_CRPT_MDL_USUARIO` (`ID_MODULO`);

--
-- Indices de la tabla `tbl_categorias_habitacion`
--
ALTER TABLE `tbl_categorias_habitacion`
  ADD PRIMARY KEY (`KidCategoria`);

--
-- Indices de la tabla `tbl_check_in`
--
ALTER TABLE `tbl_check_in`
  ADD PRIMARY KEY (`KidCheckIn`),
  ADD KEY `fk_Tbl_Check_In_Tbl_Empleados1` (`KidEmpleado`),
  ADD KEY `fk_Tbl_Check_In_Tbl_Clientes1` (`KidCliente`);

--
-- Indices de la tabla `tbl_check_out`
--
ALTER TABLE `tbl_check_out`
  ADD PRIMARY KEY (`KidCheckOut`),
  ADD KEY `fk_Tbl_Check_Out_Tbl_Clientes1` (`KidCliente`),
  ADD KEY `fk_Tbl_Check_Out_Tbl_Empleados1` (`KidEmpleado`);

--
-- Indices de la tabla `tbl_chequera`
--
ALTER TABLE `tbl_chequera`
  ADD PRIMARY KEY (`KidChequera`),
  ADD KEY `FK_CuentaBancaria_Chequera` (`KidCuentaBancaria`);

--
-- Indices de la tabla `tbl_clientes`
--
ALTER TABLE `tbl_clientes`
  ADD PRIMARY KEY (`KidCliente`),
  ADD KEY `fk_Cliente_TipoCliente` (`KidTipoCliente`);

--
-- Indices de la tabla `tbl_comandas`
--
ALTER TABLE `tbl_comandas`
  ADD PRIMARY KEY (`KidNumeroComanda`),
  ADD KEY `service` (`KidServicio`);

--
-- Indices de la tabla `tbl_comisiones`
--
ALTER TABLE `tbl_comisiones`
  ADD PRIMARY KEY (`KidComisiones`),
  ADD KEY `fk_TipoProducto_Comisiones` (`KidTipoProducto`);

--
-- Indices de la tabla `tbl_conceptos`
--
ALTER TABLE `tbl_conceptos`
  ADD PRIMARY KEY (`KidConcepto`);

--
-- Indices de la tabla `tbl_conciliacion_bancaria`
--
ALTER TABLE `tbl_conciliacion_bancaria`
  ADD PRIMARY KEY (`KidBanco`,`Kperiodo`);

--
-- Indices de la tabla `tbl_configuracion_rpt`
--
ALTER TABLE `tbl_configuracion_rpt`
  ADD PRIMARY KEY (`ID_CONFIGURACION`);

--
-- Indices de la tabla `tbl_consulta`
--
ALTER TABLE `tbl_consulta`
  ADD PRIMARY KEY (`KidConsulta`,`KidUsuario`),
  ADD KEY `FK_usuario_consulta` (`KidUsuario`);

--
-- Indices de la tabla `tbl_contacto`
--
ALTER TABLE `tbl_contacto`
  ADD PRIMARY KEY (`KidContacto`),
  ADD KEY `fk_proveedor_contacto` (`KidProveedor`);

--
-- Indices de la tabla `tbl_control_mesas`
--
ALTER TABLE `tbl_control_mesas`
  ADD PRIMARY KEY (`KidControl`),
  ADD KEY `mesa` (`KidNumeroMesa`);

--
-- Indices de la tabla `tbl_cotizaciondetalle`
--
ALTER TABLE `tbl_cotizaciondetalle`
  ADD PRIMARY KEY (`KidCotizacionDetalle`),
  ADD KEY `FK_Productos_cotizacionDetalle` (`KidProducto`);

--
-- Indices de la tabla `tbl_cotizacionencabezado`
--
ALTER TABLE `tbl_cotizacionencabezado`
  ADD PRIMARY KEY (`KidCotizacionEncabezado`),
  ADD KEY `FK_clientes_cotizacionEncabezado` (`KidCliente`);

--
-- Indices de la tabla `tbl_creditopedido`
--
ALTER TABLE `tbl_creditopedido`
  ADD PRIMARY KEY (`KidCreditoPedido`),
  ADD KEY `FK_credito_pedido` (`KidPedido`),
  ADD KEY `fk_credito_banco` (`KidBanco`);

--
-- Indices de la tabla `tbl_creditoservicio`
--
ALTER TABLE `tbl_creditoservicio`
  ADD PRIMARY KEY (`KidCreditoServicio`),
  ADD KEY `FK_credigo_pagoServicio` (`KidPagoServicio`),
  ADD KEY `fk_creditoServicio_banco` (`KidBanco`);

--
-- Indices de la tabla `tbl_credpeddet`
--
ALTER TABLE `tbl_credpeddet`
  ADD PRIMARY KEY (`KidCodigoCresDet`,`KidCreditoPedido`),
  ADD KEY `FK_creditoPedDet_CreditoPedido` (`KidCreditoPedido`);

--
-- Indices de la tabla `tbl_credservdet`
--
ALTER TABLE `tbl_credservdet`
  ADD PRIMARY KEY (`KidCredServDet`,`KidCreditoServicio`),
  ADD KEY `fk_credServDet_CreditoServicio` (`KidCreditoServicio`);

--
-- Indices de la tabla `tbl_cuentabancaria`
--
ALTER TABLE `tbl_cuentabancaria`
  ADD PRIMARY KEY (`KidCuentaBancaria`),
  ADD KEY `FK_Bancos_CuentaBancaria` (`KidBanco`),
  ADD KEY `FK_Moneda_CuentaBancaria` (`KidMoneda`);

--
-- Indices de la tabla `tbl_cuentas`
--
ALTER TABLE `tbl_cuentas`
  ADD PRIMARY KEY (`KidCuenta`,`KidTipoCuenta`),
  ADD KEY `fk_tbl_cuentas_contables_tbl_tipoCuentaContable1` (`KidTipoCuenta`);

--
-- Indices de la tabla `tbl_departamentos`
--
ALTER TABLE `tbl_departamentos`
  ADD PRIMARY KEY (`KidDepartamento`),
  ADD KEY `fk_Tbl_departamentos_Tbl_areas1_idx` (`KidArea`);

--
-- Indices de la tabla `tbl_descuentos`
--
ALTER TABLE `tbl_descuentos`
  ADD PRIMARY KEY (`KidDescuentos`);

--
-- Indices de la tabla `tbl_detallecomprobante`
--
ALTER TABLE `tbl_detallecomprobante`
  ADD PRIMARY KEY (`KidDetalleComprobante`);

--
-- Indices de la tabla `tbl_detallepedido`
--
ALTER TABLE `tbl_detallepedido`
  ADD PRIMARY KEY (`KidDetallePedido`),
  ADD KEY `FK_Productos_DetallePedido1` (`KidProducto`);

--
-- Indices de la tabla `tbl_detallereportevacante`
--
ALTER TABLE `tbl_detallereportevacante`
  ADD PRIMARY KEY (`KidReporteVacante`);

--
-- Indices de la tabla `tbl_detalle_control`
--
ALTER TABLE `tbl_detalle_control`
  ADD PRIMARY KEY (`KidNumeroDetalle`),
  ADD KEY `fk_Tbl_Detalle_Control_Tbl_Control_Mesas1` (`KidControl`),
  ADD KEY `fk_Tbl_Detalle_Control_Tbl_Platillos1` (`KidPlatillo`);

--
-- Indices de la tabla `tbl_detalle_evento`
--
ALTER TABLE `tbl_detalle_evento`
  ADD PRIMARY KEY (`KidNumeroDetalle`),
  ADD KEY `reservacion0` (`KidEvento`),
  ADD KEY `fk_Tbl_Detalle_Evento_Tbl_Salones1` (`KidNumeroSalon`);

--
-- Indices de la tabla `tbl_detalle_folio`
--
ALTER TABLE `tbl_detalle_folio`
  ADD PRIMARY KEY (`KidFolio`,`KidNumeroDetalle`),
  ADD KEY `servicio` (`KidComanda`);

--
-- Indices de la tabla `tbl_detalle_lista_precios`
--
ALTER TABLE `tbl_detalle_lista_precios`
  ADD PRIMARY KEY (`KidDetalleListaPrecios`),
  ADD KEY `FK_Productos_DetallePedido` (`KidProducto`),
  ADD KEY `FK_TipoListaPrecios_DetalleListaPrecios` (`Kidtipo_lista_precios`);

--
-- Indices de la tabla `tbl_detalle_producto`
--
ALTER TABLE `tbl_detalle_producto`
  ADD PRIMARY KEY (`Kiddetalleproducto`),
  ADD KEY `fk_DetalleProducto_Producto` (`Kidproducto`);

--
-- Indices de la tabla `tbl_detalle_reservacion`
--
ALTER TABLE `tbl_detalle_reservacion`
  ADD PRIMARY KEY (`KidNumeroDetalle`),
  ADD KEY `reservacion` (`KidReservacion`),
  ADD KEY `habitacion` (`KidNumeroHabitacion`);

--
-- Indices de la tabla `tbl_detalle_roles`
--
ALTER TABLE `tbl_detalle_roles`
  ADD PRIMARY KEY (`KidRolpago`,`KidEmpleado`),
  ADD KEY `fk_Tbl_detalle_roles_Tbl_empleado1_idx` (`KidEmpleado`);

--
-- Indices de la tabla `tbl_devoluciones`
--
ALTER TABLE `tbl_devoluciones`
  ADD PRIMARY KEY (`kidDevoluciones`),
  ADD KEY `fk_Devoluciones_FacturaEncabezado1` (`KidFacturaEncabezado`);

--
-- Indices de la tabla `tbl_devoluciones_platillos`
--
ALTER TABLE `tbl_devoluciones_platillos`
  ADD PRIMARY KEY (`KidDevPlatillo`,`KidPlatillo`);

--
-- Indices de la tabla `tbl_divisa`
--
ALTER TABLE `tbl_divisa`
  ADD PRIMARY KEY (`KidDivisa`);

--
-- Indices de la tabla `tbl_empleado`
--
ALTER TABLE `tbl_empleado`
  ADD PRIMARY KEY (`KidEmpleado`),
  ADD KEY `fk_Tbl_empleado_Tbl_puestos1_idx` (`KidPuesto`),
  ADD KEY `fk_Tbl_empleado_Tbl_departamentos1_idx` (`KidDepartamento`);

--
-- Indices de la tabla `tbl_encabezadocomprobante`
--
ALTER TABLE `tbl_encabezadocomprobante`
  ADD PRIMARY KEY (`KidEncabezadoComprobante`),
  ADD KEY `FK_cliente_encabezadoComprobante` (`KidCliente`),
  ADD KEY `FK_empleado_encabezadoComprobante` (`KidEmpleado`),
  ADD KEY `FK_tipoComprobante_encabezadoComprobante` (`KidtiposComprobantes`),
  ADD KEY `FK_FacturaEncabezado_EncabezadoComprobante` (`KidFacturaEncabezado`);

--
-- Indices de la tabla `tbl_encabezadopedido`
--
ALTER TABLE `tbl_encabezadopedido`
  ADD PRIMARY KEY (`KidEncabezadoPedido`),
  ADD KEY `FK_FacturaEncabezado_EncabezadoPedido` (`KidFacturaEncabezado`),
  ADD KEY `FK_clientes_EncabezadoPedido` (`KidCliente`);

--
-- Indices de la tabla `tbl_encabezadoreportevacante`
--
ALTER TABLE `tbl_encabezadoreportevacante`
  ADD PRIMARY KEY (`KidReporteVacante`),
  ADD KEY `FK_Empleado_ReporteVacante` (`KidEmpleado`),
  ADD KEY `FK_Puesto_ReporteVacante` (`KidPuesto`);

--
-- Indices de la tabla `tbl_encabezado_lista_precios`
--
ALTER TABLE `tbl_encabezado_lista_precios`
  ADD PRIMARY KEY (`KidEncabezadoListaPrecios`);

--
-- Indices de la tabla `tbl_estado_perdidas_ganacias_detalle`
--
ALTER TABLE `tbl_estado_perdidas_ganacias_detalle`
  ADD PRIMARY KEY (`KidPerdidasGanancias`),
  ADD KEY `fk_tbl_estado_perdidas_ganacias_Detalle_tbl_cuentas_contables1` (`KidCuenta`);

--
-- Indices de la tabla `tbl_estado_perdidas_ganancias_encabezado`
--
ALTER TABLE `tbl_estado_perdidas_ganancias_encabezado`
  ADD PRIMARY KEY (`KidPerdidasGanancias`);

--
-- Indices de la tabla `tbl_eventos`
--
ALTER TABLE `tbl_eventos`
  ADD PRIMARY KEY (`KidEvento`),
  ADD KEY `fk_Tbl_Eventos_Tbl_Clientes1` (`KidCliente`),
  ADD KEY `fk_Tbl_Eventos_Tbl_Empleados1` (`_KidEmpleado`);

--
-- Indices de la tabla `tbl_existencia`
--
ALTER TABLE `tbl_existencia`
  ADD PRIMARY KEY (`Kidexistencia`,`kidproducto`),
  ADD KEY `fk_Producto_Existencia` (`kidproducto`);

--
-- Indices de la tabla `tbl_existencias`
--
ALTER TABLE `tbl_existencias`
  ADD PRIMARY KEY (`KidExistencia`),
  ADD KEY `prod` (`KidProducto`),
  ADD KEY `bode` (`KidBodega`);

--
-- Indices de la tabla `tbl_facturadetalle`
--
ALTER TABLE `tbl_facturadetalle`
  ADD PRIMARY KEY (`KidFacturaDetalle`),
  ADD KEY `fk_FacturaDetalle_Producto1` (`KidProducto`),
  ADD KEY `fk_FacturaDetalle_FacturaEncabezado1` (`KidFacturaEncabezado`);

--
-- Indices de la tabla `tbl_facturaencabezado`
--
ALTER TABLE `tbl_facturaencabezado`
  ADD PRIMARY KEY (`KidFacturaEncabezado`,`KidSerie`),
  ADD KEY `fk_FacturaEncabezado_Cliente1` (`KidCliente`),
  ADD KEY `fk_FacturaEncabezado_Serie1` (`KidSerie`),
  ADD KEY `fk_Tbl_FacturaEncabezado_Tbl_Impuesto1` (`KidImpuesto`),
  ADD KEY `fk_Tbl_FacturaEncabezado_Tbl_Moneda1` (`KidMoneda`),
  ADD KEY `fk_Descuentos_facturaEncabezado` (`KidDescuentos`),
  ADD KEY `FK_EncabezadoLista_Precios_FacturaEncabezado` (`KidEncabezadoListaPrecios`),
  ADD KEY `FK_cotizacionEncabezado_FacturaEncabezado` (`KidCotizacionEncabezado`);

--
-- Indices de la tabla `tbl_flujoefectivo_detalle`
--
ALTER TABLE `tbl_flujoefectivo_detalle`
  ADD PRIMARY KEY (`KidFlujoEfectivo`,`KidCuenta`),
  ADD KEY `fk_tbl_flujoEfectivo_Detalle_tbl_cuentas1` (`KidCuenta`);

--
-- Indices de la tabla `tbl_flujoefectivo_encabezado`
--
ALTER TABLE `tbl_flujoefectivo_encabezado`
  ADD PRIMARY KEY (`KidFlujoEfectivo`);

--
-- Indices de la tabla `tbl_folios`
--
ALTER TABLE `tbl_folios`
  ADD PRIMARY KEY (`KidFolio`),
  ADD KEY `folio` (`KidCliente`);

--
-- Indices de la tabla `tbl_gestionmovimientocliente`
--
ALTER TABLE `tbl_gestionmovimientocliente`
  ADD PRIMARY KEY (`KidGestionMovimientoCliente`),
  ADD KEY `FK_encabezadoComprobante_GestionMovimientoCliente` (`KidEncabezadoComprobante`);

--
-- Indices de la tabla `tbl_habitaciones`
--
ALTER TABLE `tbl_habitaciones`
  ADD PRIMARY KEY (`KidNumeroHabitacion`),
  ADD KEY `tipoHabitacion` (`KidTipoHabitacion`),
  ADD KEY `categoria` (`KidCategoria`);

--
-- Indices de la tabla `tbl_historia_inventario`
--
ALTER TABLE `tbl_historia_inventario`
  ADD PRIMARY KEY (`Kidproducto`,`Kidmovimientoinventario`),
  ADD KEY `fk_MovimientoInventario_HistoriaInventario` (`Kidmovimientoinventario`),
  ADD KEY `FK_Bodega_HistoriaInventario` (`Kidbodega`),
  ADD KEY `fk_Sucursal_HistoriaInventario` (`Kidsucursal`);

--
-- Indices de la tabla `tbl_impuesto`
--
ALTER TABLE `tbl_impuesto`
  ADD PRIMARY KEY (`KidImpuesto`);

--
-- Indices de la tabla `tbl_ingredientes`
--
ALTER TABLE `tbl_ingredientes`
  ADD PRIMARY KEY (`KidIngredientes`,`KidRecetas`,`KidProducto`),
  ADD KEY `fk_Tbl_Ingredientes_Tbl_Producto1` (`KidProducto`),
  ADD KEY `fk_Tbl_Ingredientes_Tbl_Recetas1` (`KidRecetas`);

--
-- Indices de la tabla `tbl_inventario`
--
ALTER TABLE `tbl_inventario`
  ADD PRIMARY KEY (`KidInventario`),
  ADD KEY `fk_Inventario_Producto1` (`KidProducto`),
  ADD KEY `fk_Inventario_Bodegas` (`Kidbodega`),
  ADD KEY `Fk_Inventario_Stock` (`Kidstock`),
  ADD KEY `fk_Inventario_Existencia` (`Kidexistencia`);

--
-- Indices de la tabla `tbl_librodiario_detalle`
--
ALTER TABLE `tbl_librodiario_detalle`
  ADD PRIMARY KEY (`KidLibroDiarioEncabezado`,`KidPoliza`),
  ADD KEY `fk_polizaEncabezado_libroDiarioDetalle` (`KidPoliza`);

--
-- Indices de la tabla `tbl_librodiario_encabezado`
--
ALTER TABLE `tbl_librodiario_encabezado`
  ADD PRIMARY KEY (`KidLibroDiarioEncabezado`);

--
-- Indices de la tabla `tbl_libromayor_detalle`
--
ALTER TABLE `tbl_libromayor_detalle`
  ADD PRIMARY KEY (`KidLibroMayor`);

--
-- Indices de la tabla `tbl_libromayor_encabezado`
--
ALTER TABLE `tbl_libromayor_encabezado`
  ADD PRIMARY KEY (`KidLibroMayor`,`KidLibroDiarioEncabezado`),
  ADD KEY `fk_tbl_libroMayor_tbl_libroDiario_Encabezado1` (`KidLibroDiarioEncabezado`);

--
-- Indices de la tabla `tbl_libro_bancos`
--
ALTER TABLE `tbl_libro_bancos`
  ADD PRIMARY KEY (`KidMovimiento`,`KidBanco`),
  ADD KEY `fk_tbl_libro_bancos_tbl_bancos1` (`KidBanco`);

--
-- Indices de la tabla `tbl_lista_precios_productos`
--
ALTER TABLE `tbl_lista_precios_productos`
  ADD PRIMARY KEY (`KidLista_precios`,`KidProducto`),
  ADD KEY `FK_productos_lista_precios` (`KidProducto`);

--
-- Indices de la tabla `tbl_marca`
--
ALTER TABLE `tbl_marca`
  ADD PRIMARY KEY (`Kidmarca`);

--
-- Indices de la tabla `tbl_menus`
--
ALTER TABLE `tbl_menus`
  ADD PRIMARY KEY (`KidMenu`);

--
-- Indices de la tabla `tbl_mesas`
--
ALTER TABLE `tbl_mesas`
  ADD PRIMARY KEY (`KidNumeroMesa`),
  ADD KEY `fk_Tbl_Mesas_Tbl_Areas1` (`KidArea`);

--
-- Indices de la tabla `tbl_modulo`
--
ALTER TABLE `tbl_modulo`
  ADD PRIMARY KEY (`PK_id_Modulo`);

--
-- Indices de la tabla `tbl_moneda`
--
ALTER TABLE `tbl_moneda`
  ADD PRIMARY KEY (`KidMoneda`);

--
-- Indices de la tabla `tbl_moviemiento_inventario`
--
ALTER TABLE `tbl_moviemiento_inventario`
  ADD PRIMARY KEY (`Kidmoviemientoinventario`);

--
-- Indices de la tabla `tbl_nominasdetalle`
--
ALTER TABLE `tbl_nominasdetalle`
  ADD PRIMARY KEY (`KidLinea`,`KidNomina`),
  ADD KEY `fk_Tbl_nominasDetalle_Tbl_nominasEncabezado1_idx` (`KidNomina`),
  ADD KEY `fk_Tbl_nominasDetalle_Tbl_conceptos1_idx` (`KidConcepto`);

--
-- Indices de la tabla `tbl_nominasencabezado`
--
ALTER TABLE `tbl_nominasencabezado`
  ADD PRIMARY KEY (`KidNomina`,`KidEmpleado`),
  ADD KEY `fk_Tbl_nominasEncabezado_Tbl_empleado1_idx` (`KidEmpleado`);

--
-- Indices de la tabla `tbl_objetos_perdidos`
--
ALTER TABLE `tbl_objetos_perdidos`
  ADD PRIMARY KEY (`KidObjeto`),
  ADD KEY `fk_Tbl_Objetos_Perdidos_Tbl_Habitaciones1` (`KidNumeroHabitacion`);

--
-- Indices de la tabla `tbl_orden_compra_encabezado`
--
ALTER TABLE `tbl_orden_compra_encabezado`
  ADD PRIMARY KEY (`KidOrdenCompraEncabezado`),
  ADD KEY `fk_OrdenEncabezado_proveedor` (`KidProveedor`),
  ADD KEY `Fk_ordenencabezado_impuesto` (`KidImpuesto`);

--
-- Indices de la tabla `tbl_orden_dompra_detalle`
--
ALTER TABLE `tbl_orden_dompra_detalle`
  ADD PRIMARY KEY (`KidOrdenCompraDetalle`,`KidOrdenCompraEncabezado`,`KidProducto`),
  ADD KEY `fk_OrdenEncabezado_detalle` (`KidOrdenCompraEncabezado`),
  ADD KEY `fk_ordendetalle_producto` (`KidProducto`);

--
-- Indices de la tabla `tbl_pagos`
--
ALTER TABLE `tbl_pagos`
  ADD PRIMARY KEY (`KidPagos`,`KidTipoPago`),
  ADD KEY `fk_Pagos_TipoPago1` (`KidTipoPago`),
  ADD KEY `fk_Pagos_FacturaEncabezado1` (`KidFacturaEncabezado`);

--
-- Indices de la tabla `tbl_pagoservicio`
--
ALTER TABLE `tbl_pagoservicio`
  ADD PRIMARY KEY (`KidPagoServicio`),
  ADD KEY `FK_pago_acreedor` (`KidAcreedor`),
  ADD KEY `FK_pago_servicio` (`KidServicio`);

--
-- Indices de la tabla `tbl_pedido`
--
ALTER TABLE `tbl_pedido`
  ADD PRIMARY KEY (`KidPedido`),
  ADD KEY `FK_proveedor_pedido` (`KidProveedor`),
  ADD KEY `fk_OrdenEncabezado_pedido` (`KidOrdenCompra`);

--
-- Indices de la tabla `tbl_pedidodet`
--
ALTER TABLE `tbl_pedidodet`
  ADD PRIMARY KEY (`KidPedido`,`KidProducto`),
  ADD KEY `fk_PedidoDet_producto` (`KidProducto`);

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
-- Indices de la tabla `tbl_planillasdetalle`
--
ALTER TABLE `tbl_planillasdetalle`
  ADD PRIMARY KEY (`KidPlanilla`,`Ktipo`),
  ADD KEY `fk_Tbl_PlanillasDetalle_Tbl_empleado1_idx` (`KidEmpleado`);

--
-- Indices de la tabla `tbl_planillasencabezado`
--
ALTER TABLE `tbl_planillasencabezado`
  ADD PRIMARY KEY (`KidPlanilla`);

--
-- Indices de la tabla `tbl_platillos`
--
ALTER TABLE `tbl_platillos`
  ADD PRIMARY KEY (`KidPlatillo`,`KidMenu`),
  ADD KEY `menu` (`KidMenu`);

--
-- Indices de la tabla `tbl_poliza`
--
ALTER TABLE `tbl_poliza`
  ADD PRIMARY KEY (`KidPoliza`),
  ADD KEY `FK_FacturaDetalle_Poliza` (`KidFacturaDetalle`);

--
-- Indices de la tabla `tbl_poliza_detalle`
--
ALTER TABLE `tbl_poliza_detalle`
  ADD PRIMARY KEY (`KidPoliza`,`KidCuenta`),
  ADD KEY `fk_Cuentas_PolizaDetalle` (`KidCuenta`);

--
-- Indices de la tabla `tbl_poliza_encabezado`
--
ALTER TABLE `tbl_poliza_encabezado`
  ADD PRIMARY KEY (`KidPoliza`,`KidTipoDePoliza`,`KidDocumentoAsociado`),
  ADD KEY `fk_tipoDePoliza_PolizaEncabezado` (`KidTipoDePoliza`);

--
-- Indices de la tabla `tbl_precios`
--
ALTER TABLE `tbl_precios`
  ADD PRIMARY KEY (`KidPrecios`),
  ADD KEY `fk_Precios_Producto1` (`KidProducto`);

--
-- Indices de la tabla `tbl_presupuesto`
--
ALTER TABLE `tbl_presupuesto`
  ADD PRIMARY KEY (`Kidpresupuesto`),
  ADD KEY `FK_Moneda_Presupuesto` (`KidMoneda`),
  ADD KEY `FK_area_presupuesto` (`KidArea`),
  ADD KEY `FK_cuentas_presupuesto` (`KidCuenta`);

--
-- Indices de la tabla `tbl_producto`
--
ALTER TABLE `tbl_producto`
  ADD PRIMARY KEY (`KidProducto`),
  ADD KEY `fk_Producto_TipoProducto1` (`KidTipoProducto`),
  ADD KEY `fk_Descuento_Producto` (`KidDescuentos`);

--
-- Indices de la tabla `tbl_producto_marca`
--
ALTER TABLE `tbl_producto_marca`
  ADD PRIMARY KEY (`Kidproducto`,`Kidmarca`),
  ADD KEY `fk_Marca_Producto` (`Kidmarca`);

--
-- Indices de la tabla `tbl_proveedor`
--
ALTER TABLE `tbl_proveedor`
  ADD PRIMARY KEY (`KidProveedor`);

--
-- Indices de la tabla `tbl_pruebas`
--
ALTER TABLE `tbl_pruebas`
  ADD PRIMARY KEY (`KidPruebas`);

--
-- Indices de la tabla `tbl_puestos`
--
ALTER TABLE `tbl_puestos`
  ADD PRIMARY KEY (`KidPuesto`),
  ADD KEY `fk_Area_Puestos` (`KidArea`);

--
-- Indices de la tabla `tbl_quejas`
--
ALTER TABLE `tbl_quejas`
  ADD PRIMARY KEY (`KidQueja`),
  ADD KEY `fk_Tbl_Quejas_Tbl_Clientes1` (`KidCliente`);

--
-- Indices de la tabla `tbl_recetas`
--
ALTER TABLE `tbl_recetas`
  ADD PRIMARY KEY (`KidRecetas`);

--
-- Indices de la tabla `tbl_reporte`
--
ALTER TABLE `tbl_reporte`
  ADD PRIMARY KEY (`ID_REPORTE`),
  ADD KEY `FK_RPT_CONFIGURACION` (`ID_CONFIGURACION`);

--
-- Indices de la tabla `tbl_reservaciones`
--
ALTER TABLE `tbl_reservaciones`
  ADD PRIMARY KEY (`KidReservacion`),
  ADD KEY `fk_Tbl_Reservaciones_Tbl_Clientes1` (`KidCliente`),
  ADD KEY `fk_Tbl_Reservaciones_Tbl_Empleados1` (`KidEmpleado`);

--
-- Indices de la tabla `tbl_resultados`
--
ALTER TABLE `tbl_resultados`
  ADD PRIMARY KEY (`KidResultados`),
  ADD KEY `FK_BancoTalento_Resultados` (`KidBancoTalento`),
  ADD KEY `FK_Pruebas_Resultados` (`KidPruebas`);

--
-- Indices de la tabla `tbl_roles_de_pago`
--
ALTER TABLE `tbl_roles_de_pago`
  ADD PRIMARY KEY (`KidRolpago`);

--
-- Indices de la tabla `tbl_rpt_almacen`
--
ALTER TABLE `tbl_rpt_almacen`
  ADD PRIMARY KEY (`ID_RPT_ALMACEN`),
  ADD KEY `FK_RPT_ALM_MODULO` (`ID_MODULO`);

--
-- Indices de la tabla `tbl_rpt_app`
--
ALTER TABLE `tbl_rpt_app`
  ADD PRIMARY KEY (`ID_REPORTE`,`ID_APLICACION`,`ID_MODULO`),
  ADD KEY `FK_RPT_APP_APLICACION` (`ID_APLICACION`),
  ADD KEY `FK_RPT_APP_MODULO` (`ID_MODULO`);

--
-- Indices de la tabla `tbl_rpt_mdl`
--
ALTER TABLE `tbl_rpt_mdl`
  ADD PRIMARY KEY (`ID_REPORTE`,`ID_MODULO`),
  ADD KEY `FK_RPT_MDL_MODULO` (`ID_MODULO`);

--
-- Indices de la tabla `tbl_salones`
--
ALTER TABLE `tbl_salones`
  ADD PRIMARY KEY (`KidNumeroSalon`);

--
-- Indices de la tabla `tbl_serie`
--
ALTER TABLE `tbl_serie`
  ADD PRIMARY KEY (`KidSerie`),
  ADD KEY `FK_Folio_Serie` (`KidFolio`);

--
-- Indices de la tabla `tbl_servicio`
--
ALTER TABLE `tbl_servicio`
  ADD PRIMARY KEY (`KidServicio`);

--
-- Indices de la tabla `tbl_servicios`
--
ALTER TABLE `tbl_servicios`
  ADD PRIMARY KEY (`KidServicio`),
  ADD KEY `fk_Tbl_Servicios_Tbl_Areas1` (`KidArea`);

--
-- Indices de la tabla `tbl_solicitudrembolso`
--
ALTER TABLE `tbl_solicitudrembolso`
  ADD PRIMARY KEY (`KidSolicitudRembolso`),
  ADD KEY `fk_SolicitudRembolso_FacturaEncabezado1` (`KidFacturaEncabezado`);

--
-- Indices de la tabla `tbl_stock`
--
ALTER TABLE `tbl_stock`
  ADD PRIMARY KEY (`Kidstock`);

--
-- Indices de la tabla `tbl_sucursal`
--
ALTER TABLE `tbl_sucursal`
  ADD PRIMARY KEY (`KidSucursal`);

--
-- Indices de la tabla `tbl_tiendas`
--
ALTER TABLE `tbl_tiendas`
  ADD PRIMARY KEY (`KidTienda`),
  ADD KEY `fk_Tbl_Tiendas_Tbl_Areas1` (`KidArea`);

--
-- Indices de la tabla `tbl_tiendas_producto`
--
ALTER TABLE `tbl_tiendas_producto`
  ADD PRIMARY KEY (`KidProducto`,`KidTienda`),
  ADD KEY `fk_Tbl_Producto_has_Tbl_Tiendas_Tbl_Tiendas1` (`KidTienda`);

--
-- Indices de la tabla `tbl_tipocambio`
--
ALTER TABLE `tbl_tipocambio`
  ADD PRIMARY KEY (`KidMonedaBase`,`KidMonedaConversion`),
  ADD KEY `fk_tbl_tipoCambio_tbl_Divisa_idx` (`KidMonedaConversion`);

--
-- Indices de la tabla `tbl_tipocliente`
--
ALTER TABLE `tbl_tipocliente`
  ADD PRIMARY KEY (`KidTipoCliente`);

--
-- Indices de la tabla `tbl_tipocuenta`
--
ALTER TABLE `tbl_tipocuenta`
  ADD PRIMARY KEY (`KidTipoCuenta`);

--
-- Indices de la tabla `tbl_tipofactura`
--
ALTER TABLE `tbl_tipofactura`
  ADD PRIMARY KEY (`KidTipoFactura`);

--
-- Indices de la tabla `tbl_tipopago`
--
ALTER TABLE `tbl_tipopago`
  ADD PRIMARY KEY (`KidTipoPago`);

--
-- Indices de la tabla `tbl_tipoproducto`
--
ALTER TABLE `tbl_tipoproducto`
  ADD PRIMARY KEY (`KidTipoProducto`);

--
-- Indices de la tabla `tbl_tiposcomprobantes`
--
ALTER TABLE `tbl_tiposcomprobantes`
  ADD PRIMARY KEY (`KidtiposComprobantes`);

--
-- Indices de la tabla `tbl_tipo_habitacion`
--
ALTER TABLE `tbl_tipo_habitacion`
  ADD PRIMARY KEY (`KidTipoHabitacion`);

--
-- Indices de la tabla `tbl_tipo_lista_precios`
--
ALTER TABLE `tbl_tipo_lista_precios`
  ADD PRIMARY KEY (`Kidtipo_lista_precios`);

--
-- Indices de la tabla `tbl_tipo_poliza`
--
ALTER TABLE `tbl_tipo_poliza`
  ADD PRIMARY KEY (`KidTipoDePoliza`);

--
-- Indices de la tabla `tbl_ubicacion`
--
ALTER TABLE `tbl_ubicacion`
  ADD PRIMARY KEY (`Kidubicacion`);

--
-- Indices de la tabla `tbl_ubicacionprodcuto`
--
ALTER TABLE `tbl_ubicacionprodcuto`
  ADD PRIMARY KEY (`Kidubicacion`,`Kidproducto`),
  ADD KEY `fk_Producto_Ubicacion` (`Kidproducto`);

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
-- AUTO_INCREMENT de la tabla `tbl_balancegeneral_encabezado`
--
ALTER TABLE `tbl_balancegeneral_encabezado`
  MODIFY `KidBalanceGeneral` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_bancos`
--
ALTER TABLE `tbl_bancos`
  MODIFY `KidBanco` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  MODIFY `PK_id_bitacora` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_chequera`
--
ALTER TABLE `tbl_chequera`
  MODIFY `KidChequera` int(4) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_cuentabancaria`
--
ALTER TABLE `tbl_cuentabancaria`
  MODIFY `KidCuentaBancaria` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_cuentas`
--
ALTER TABLE `tbl_cuentas`
  MODIFY `KidCuenta` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_estado_perdidas_ganancias_encabezado`
--
ALTER TABLE `tbl_estado_perdidas_ganancias_encabezado`
  MODIFY `KidPerdidasGanancias` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_flujoefectivo_encabezado`
--
ALTER TABLE `tbl_flujoefectivo_encabezado`
  MODIFY `KidFlujoEfectivo` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_librodiario_encabezado`
--
ALTER TABLE `tbl_librodiario_encabezado`
  MODIFY `KidLibroDiarioEncabezado` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_libromayor_encabezado`
--
ALTER TABLE `tbl_libromayor_encabezado`
  MODIFY `KidLibroMayor` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_libro_bancos`
--
ALTER TABLE `tbl_libro_bancos`
  MODIFY `KidMovimiento` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_poliza_encabezado`
--
ALTER TABLE `tbl_poliza_encabezado`
  MODIFY `KidPoliza` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_presupuesto`
--
ALTER TABLE `tbl_presupuesto`
  MODIFY `Kidpresupuesto` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tbl_tipocuenta`
--
ALTER TABLE `tbl_tipocuenta`
  MODIFY `KidTipoCuenta` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `tblproveedorbodega`
--
ALTER TABLE `tblproveedorbodega`
  ADD CONSTRAINT `FK_bodega_proveedor` FOREIGN KEY (`KidBodega`) REFERENCES `tbl_bodega` (`KidBodega`),
  ADD CONSTRAINT `FK_proveedor_bodega` FOREIGN KEY (`KidProveedor`) REFERENCES `tbl_proveedor` (`KidProveedor`),
  ADD CONSTRAINT `Fk_proveedor_bodega_producto` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_aplicacion`
--
ALTER TABLE `tbl_aplicacion`
  ADD CONSTRAINT `fk_Aplicacion_Modulo` FOREIGN KEY (`PK_id_modulo`) REFERENCES `tbl_modulo` (`PK_id_Modulo`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_asignacion_empleado`
--
ALTER TABLE `tbl_asignacion_empleado`
  ADD CONSTRAINT `fk_Asignacion_Empleado_Empleados1` FOREIGN KEY (`KidEmpleados`) REFERENCES `tbl_empleado` (`KidEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Ventas_has_Comisiones_Comisiones1` FOREIGN KEY (`KidComisiones`) REFERENCES `tbl_comisiones` (`KidComisiones`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Ventas_has_Comisiones_Ventas1` FOREIGN KEY (`KidPoliza`) REFERENCES `tbl_poliza` (`KidPoliza`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_balancegeneral_detalle`
--
ALTER TABLE `tbl_balancegeneral_detalle`
  ADD CONSTRAINT `fk_tbl_BalanceGeneral_Detalle_tbl_BalanceGeneral_Encabezado1` FOREIGN KEY (`KidBalanceGeneral`) REFERENCES `tbl_balancegeneral_encabezado` (`KidBalanceGeneral`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_BalanceGeneral_Detalle_tbl_cuentas_contables1` FOREIGN KEY (`KidCuentaContable`) REFERENCES `tbl_cuentas` (`KidCuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_bancotalento`
--
ALTER TABLE `tbl_bancotalento`
  ADD CONSTRAINT `FK_encabezadoReporteVacante_BancoTalento` FOREIGN KEY (`KidReporteVacante`) REFERENCES `tbl_encabezadoreportevacante` (`KidReporteVacante`);

--
-- Filtros para la tabla `tbl_bitacora`
--
ALTER TABLE `tbl_bitacora`
  ADD CONSTRAINT `fk_Bitacora_Usuario1` FOREIGN KEY (`PK_id_usuario`) REFERENCES `tbl_usuario` (`PK_id_usuario`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_carpeta_mdl`
--
ALTER TABLE `tbl_carpeta_mdl`
  ADD CONSTRAINT `FK_CRPT_MDL_USUARIO` FOREIGN KEY (`ID_MODULO`) REFERENCES `tbl_modulo` (`PK_ID_MODULO`);

--
-- Filtros para la tabla `tbl_check_in`
--
ALTER TABLE `tbl_check_in`
  ADD CONSTRAINT `fk_Tbl_Check_In_Tbl_Clientes1` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_Check_In_Tbl_Empleados1` FOREIGN KEY (`KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_check_out`
--
ALTER TABLE `tbl_check_out`
  ADD CONSTRAINT `fk_Tbl_Check_Out_Tbl_Clientes1` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_Check_Out_Tbl_Empleados1` FOREIGN KEY (`KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_chequera`
--
ALTER TABLE `tbl_chequera`
  ADD CONSTRAINT `FK_CuentaBancaria_Chequera` FOREIGN KEY (`KidCuentaBancaria`) REFERENCES `tbl_cuentabancaria` (`KidCuentaBancaria`);

--
-- Filtros para la tabla `tbl_clientes`
--
ALTER TABLE `tbl_clientes`
  ADD CONSTRAINT `fk_Cliente_TipoCliente` FOREIGN KEY (`KidTipoCliente`) REFERENCES `tbl_tipocliente` (`KidTipoCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_comandas`
--
ALTER TABLE `tbl_comandas`
  ADD CONSTRAINT `service` FOREIGN KEY (`KidServicio`) REFERENCES `tbl_servicios` (`KidServicio`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_comisiones`
--
ALTER TABLE `tbl_comisiones`
  ADD CONSTRAINT `fk_TipoProducto_Comisiones` FOREIGN KEY (`KidTipoProducto`) REFERENCES `tbl_tipoproducto` (`KidTipoProducto`);

--
-- Filtros para la tabla `tbl_conciliacion_bancaria`
--
ALTER TABLE `tbl_conciliacion_bancaria`
  ADD CONSTRAINT `fk_tbl_conciliacion_bancaria_tbl_bancos1` FOREIGN KEY (`KidBanco`) REFERENCES `tbl_bancos` (`KidBanco`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_consulta`
--
ALTER TABLE `tbl_consulta`
  ADD CONSTRAINT `FK_usuario_consulta` FOREIGN KEY (`KidUsuario`) REFERENCES `tbl_usuario` (`PK_id_usuario`);

--
-- Filtros para la tabla `tbl_contacto`
--
ALTER TABLE `tbl_contacto`
  ADD CONSTRAINT `fk_proveedor_contacto` FOREIGN KEY (`KidProveedor`) REFERENCES `tbl_proveedor` (`KidProveedor`);

--
-- Filtros para la tabla `tbl_control_mesas`
--
ALTER TABLE `tbl_control_mesas`
  ADD CONSTRAINT `mesa` FOREIGN KEY (`KidNumeroMesa`) REFERENCES `tbl_mesas` (`KidNumeroMesa`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_cotizaciondetalle`
--
ALTER TABLE `tbl_cotizaciondetalle`
  ADD CONSTRAINT `FK_Productos_cotizacionDetalle` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`),
  ADD CONSTRAINT `FK_cotizacionEncabezado_CotizacionDetalle` FOREIGN KEY (`KidCotizacionDetalle`) REFERENCES `tbl_cotizacionencabezado` (`KidCotizacionEncabezado`);

--
-- Filtros para la tabla `tbl_cotizacionencabezado`
--
ALTER TABLE `tbl_cotizacionencabezado`
  ADD CONSTRAINT `FK_clientes_cotizacionEncabezado` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`);

--
-- Filtros para la tabla `tbl_creditopedido`
--
ALTER TABLE `tbl_creditopedido`
  ADD CONSTRAINT `FK_credito_pedido` FOREIGN KEY (`KidPedido`) REFERENCES `tbl_pedido` (`KidPedido`),
  ADD CONSTRAINT `fk_credito_banco` FOREIGN KEY (`KidBanco`) REFERENCES `tbl_bancos` (`KidBanco`);

--
-- Filtros para la tabla `tbl_creditoservicio`
--
ALTER TABLE `tbl_creditoservicio`
  ADD CONSTRAINT `FK_credigo_pagoServicio` FOREIGN KEY (`KidPagoServicio`) REFERENCES `tbl_pagoservicio` (`KidPagoServicio`),
  ADD CONSTRAINT `fk_creditoServicio_banco` FOREIGN KEY (`KidBanco`) REFERENCES `tbl_bancos` (`KidBanco`);

--
-- Filtros para la tabla `tbl_credpeddet`
--
ALTER TABLE `tbl_credpeddet`
  ADD CONSTRAINT `FK_creditoPedDet_CreditoPedido` FOREIGN KEY (`KidCreditoPedido`) REFERENCES `tbl_creditopedido` (`KidCreditoPedido`);

--
-- Filtros para la tabla `tbl_credservdet`
--
ALTER TABLE `tbl_credservdet`
  ADD CONSTRAINT `fk_credServDet_CreditoServicio` FOREIGN KEY (`KidCreditoServicio`) REFERENCES `tbl_creditoservicio` (`KidCreditoServicio`);

--
-- Filtros para la tabla `tbl_cuentabancaria`
--
ALTER TABLE `tbl_cuentabancaria`
  ADD CONSTRAINT `FK_Bancos_CuentaBancaria` FOREIGN KEY (`KidBanco`) REFERENCES `tbl_bancos` (`KidBanco`),
  ADD CONSTRAINT `FK_Moneda_CuentaBancaria` FOREIGN KEY (`KidMoneda`) REFERENCES `tbl_divisa` (`KidDivisa`);

--
-- Filtros para la tabla `tbl_cuentas`
--
ALTER TABLE `tbl_cuentas`
  ADD CONSTRAINT `fk_tbl_cuentas_contables_tbl_tipoCuentaContable1` FOREIGN KEY (`KidTipoCuenta`) REFERENCES `tbl_tipocuenta` (`KidTipoCuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_departamentos`
--
ALTER TABLE `tbl_departamentos`
  ADD CONSTRAINT `fk_Tbl_departamentos_Tbl_areas1` FOREIGN KEY (`KidArea`) REFERENCES `tbl_areas` (`KidArea`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_detallecomprobante`
--
ALTER TABLE `tbl_detallecomprobante`
  ADD CONSTRAINT `FK_encabezado_detalleComprobante` FOREIGN KEY (`KidDetalleComprobante`) REFERENCES `tbl_encabezadocomprobante` (`KidEncabezadoComprobante`);

--
-- Filtros para la tabla `tbl_detallepedido`
--
ALTER TABLE `tbl_detallepedido`
  ADD CONSTRAINT `FK_EncabezadoPedido_DetallePedido1` FOREIGN KEY (`KidDetallePedido`) REFERENCES `tbl_encabezadopedido` (`KidEncabezadoPedido`),
  ADD CONSTRAINT `FK_Productos_DetallePedido1` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_detallereportevacante`
--
ALTER TABLE `tbl_detallereportevacante`
  ADD CONSTRAINT `FK_Encabezado_DetalleReporteVacante` FOREIGN KEY (`KidReporteVacante`) REFERENCES `tbl_encabezadoreportevacante` (`KidReporteVacante`);

--
-- Filtros para la tabla `tbl_detalle_control`
--
ALTER TABLE `tbl_detalle_control`
  ADD CONSTRAINT `fk_Tbl_Detalle_Control_Tbl_Control_Mesas1` FOREIGN KEY (`KidControl`) REFERENCES `tbl_control_mesas` (`KidControl`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_Detalle_Control_Tbl_Platillos1` FOREIGN KEY (`KidPlatillo`) REFERENCES `tbl_platillos` (`KidPlatillo`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_detalle_evento`
--
ALTER TABLE `tbl_detalle_evento`
  ADD CONSTRAINT `fk_Tbl_Detalle_Evento_Tbl_Salones1` FOREIGN KEY (`KidNumeroSalon`) REFERENCES `tbl_salones` (`KidNumeroSalon`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `reservacion0` FOREIGN KEY (`KidEvento`) REFERENCES `tbl_eventos` (`KidEvento`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_detalle_folio`
--
ALTER TABLE `tbl_detalle_folio`
  ADD CONSTRAINT `fk_Tbl_Detalle_Folio_Tbl_Folios1` FOREIGN KEY (`KidFolio`) REFERENCES `tbl_folios` (`KidFolio`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `servicio` FOREIGN KEY (`KidComanda`) REFERENCES `tbl_comandas` (`KidNumeroComanda`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_detalle_lista_precios`
--
ALTER TABLE `tbl_detalle_lista_precios`
  ADD CONSTRAINT `FK_EncabezadoLista_Precios_Detalle_Lista_Precios` FOREIGN KEY (`KidDetalleListaPrecios`) REFERENCES `tbl_encabezado_lista_precios` (`KidEncabezadoListaPrecios`),
  ADD CONSTRAINT `FK_Productos_DetallePedido` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`),
  ADD CONSTRAINT `FK_TipoListaPrecios_DetalleListaPrecios` FOREIGN KEY (`Kidtipo_lista_precios`) REFERENCES `tbl_tipo_lista_precios` (`Kidtipo_lista_precios`);

--
-- Filtros para la tabla `tbl_detalle_producto`
--
ALTER TABLE `tbl_detalle_producto`
  ADD CONSTRAINT `fk_DetalleProducto_Producto` FOREIGN KEY (`Kidproducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_detalle_reservacion`
--
ALTER TABLE `tbl_detalle_reservacion`
  ADD CONSTRAINT `habitacion` FOREIGN KEY (`KidNumeroHabitacion`) REFERENCES `tbl_habitaciones` (`KidNumeroHabitacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `reservacion` FOREIGN KEY (`KidReservacion`) REFERENCES `tbl_reservaciones` (`KidReservacion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_detalle_roles`
--
ALTER TABLE `tbl_detalle_roles`
  ADD CONSTRAINT `fk_Tbl_detalle_roles_Tbl_empleado1` FOREIGN KEY (`KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_detalle_roles_Tbl_roles_de_pago` FOREIGN KEY (`KidRolpago`) REFERENCES `tbl_roles_de_pago` (`KidRolpago`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_devoluciones`
--
ALTER TABLE `tbl_devoluciones`
  ADD CONSTRAINT `fk_Devoluciones_FacturaEncabezado1` FOREIGN KEY (`KidFacturaEncabezado`) REFERENCES `tbl_facturaencabezado` (`KidFacturaEncabezado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_devoluciones_platillos`
--
ALTER TABLE `tbl_devoluciones_platillos`
  ADD CONSTRAINT `fk_Devoluciones_platillos1` FOREIGN KEY (`KidDevPlatillo`) REFERENCES `tbl_platillos` (`KidPlatillo`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_empleado`
--
ALTER TABLE `tbl_empleado`
  ADD CONSTRAINT `fk_Tbl_empleado_Tbl_departamentos1` FOREIGN KEY (`KidDepartamento`) REFERENCES `tbl_departamentos` (`KidDepartamento`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_empleado_Tbl_puestos1` FOREIGN KEY (`KidPuesto`) REFERENCES `tbl_puestos` (`KidPuesto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_encabezadocomprobante`
--
ALTER TABLE `tbl_encabezadocomprobante`
  ADD CONSTRAINT `FK_FacturaEncabezado_EncabezadoComprobante` FOREIGN KEY (`KidFacturaEncabezado`) REFERENCES `tbl_facturaencabezado` (`KidFacturaEncabezado`),
  ADD CONSTRAINT `FK_cliente_encabezadoComprobante` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`),
  ADD CONSTRAINT `FK_empleado_encabezadoComprobante` FOREIGN KEY (`KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`),
  ADD CONSTRAINT `FK_tipoComprobante_encabezadoComprobante` FOREIGN KEY (`KidtiposComprobantes`) REFERENCES `tbl_tiposcomprobantes` (`KidtiposComprobantes`);

--
-- Filtros para la tabla `tbl_encabezadopedido`
--
ALTER TABLE `tbl_encabezadopedido`
  ADD CONSTRAINT `FK_FacturaEncabezado_EncabezadoPedido` FOREIGN KEY (`KidFacturaEncabezado`) REFERENCES `tbl_facturaencabezado` (`KidFacturaEncabezado`),
  ADD CONSTRAINT `FK_clientes_EncabezadoPedido` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`);

--
-- Filtros para la tabla `tbl_encabezadoreportevacante`
--
ALTER TABLE `tbl_encabezadoreportevacante`
  ADD CONSTRAINT `FK_Empleado_ReporteVacante` FOREIGN KEY (`KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`),
  ADD CONSTRAINT `FK_Puesto_ReporteVacante` FOREIGN KEY (`KidPuesto`) REFERENCES `tbl_puestos` (`KidPuesto`);

--
-- Filtros para la tabla `tbl_estado_perdidas_ganacias_detalle`
--
ALTER TABLE `tbl_estado_perdidas_ganacias_detalle`
  ADD CONSTRAINT `fk_tbl_estado_perdidas_ganacias_Detalle_tbl_cuentas_contables1` FOREIGN KEY (`KidCuenta`) REFERENCES `tbl_cuentas` (`KidCuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_estado_perdidas_ganacias_Detalle_tbl_estado_perdidas_g1` FOREIGN KEY (`KidPerdidasGanancias`) REFERENCES `tbl_estado_perdidas_ganancias_encabezado` (`KidPerdidasGanancias`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_eventos`
--
ALTER TABLE `tbl_eventos`
  ADD CONSTRAINT `fk_Tbl_Eventos_Tbl_Clientes1` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_Eventos_Tbl_Empleados1` FOREIGN KEY (`_KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_existencia`
--
ALTER TABLE `tbl_existencia`
  ADD CONSTRAINT `fk_Producto_Existencia` FOREIGN KEY (`kidproducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_existencias`
--
ALTER TABLE `tbl_existencias`
  ADD CONSTRAINT `bode` FOREIGN KEY (`KidBodega`) REFERENCES `tbl_bodega` (`KidBodega`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `prod` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_facturadetalle`
--
ALTER TABLE `tbl_facturadetalle`
  ADD CONSTRAINT `fk_FacturaDetalle_FacturaEncabezado1` FOREIGN KEY (`KidFacturaEncabezado`) REFERENCES `tbl_facturaencabezado` (`KidFacturaEncabezado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_FacturaDetalle_Producto1` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_facturaencabezado`
--
ALTER TABLE `tbl_facturaencabezado`
  ADD CONSTRAINT `FK_EncabezadoLista_Precios_FacturaEncabezado` FOREIGN KEY (`KidEncabezadoListaPrecios`) REFERENCES `tbl_encabezado_lista_precios` (`KidEncabezadoListaPrecios`),
  ADD CONSTRAINT `FK_cotizacionEncabezado_FacturaEncabezado` FOREIGN KEY (`KidCotizacionEncabezado`) REFERENCES `tbl_cotizacionencabezado` (`KidCotizacionEncabezado`),
  ADD CONSTRAINT `fk_Descuentos_facturaEncabezado` FOREIGN KEY (`KidDescuentos`) REFERENCES `tbl_descuentos` (`KidDescuentos`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_FacturaEncabezado_Cliente1` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_FacturaEncabezado_Serie1` FOREIGN KEY (`KidSerie`) REFERENCES `tbl_serie` (`KidSerie`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_FacturaEncabezado_Tbl_Impuesto1` FOREIGN KEY (`KidImpuesto`) REFERENCES `tbl_impuesto` (`KidImpuesto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_FacturaEncabezado_Tbl_Moneda1` FOREIGN KEY (`KidMoneda`) REFERENCES `tbl_moneda` (`KidMoneda`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_flujoefectivo_detalle`
--
ALTER TABLE `tbl_flujoefectivo_detalle`
  ADD CONSTRAINT `fk_tbl_flujoEfectivo_Detalle_tbl_cuentas1` FOREIGN KEY (`KidCuenta`) REFERENCES `tbl_cuentas` (`KidCuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_flujoEfectivo_Detalle_tbl_flujoEfectivo_Encabezado1` FOREIGN KEY (`KidFlujoEfectivo`) REFERENCES `tbl_flujoefectivo_encabezado` (`KidFlujoEfectivo`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_folios`
--
ALTER TABLE `tbl_folios`
  ADD CONSTRAINT `folio` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`);

--
-- Filtros para la tabla `tbl_gestionmovimientocliente`
--
ALTER TABLE `tbl_gestionmovimientocliente`
  ADD CONSTRAINT `FK_encabezadoComprobante_GestionMovimientoCliente` FOREIGN KEY (`KidEncabezadoComprobante`) REFERENCES `tbl_encabezadocomprobante` (`KidEncabezadoComprobante`);

--
-- Filtros para la tabla `tbl_habitaciones`
--
ALTER TABLE `tbl_habitaciones`
  ADD CONSTRAINT `categoria` FOREIGN KEY (`KidCategoria`) REFERENCES `tbl_categorias_habitacion` (`KidCategoria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `tipoHabitacion` FOREIGN KEY (`KidTipoHabitacion`) REFERENCES `tbl_tipo_habitacion` (`KidTipoHabitacion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_historia_inventario`
--
ALTER TABLE `tbl_historia_inventario`
  ADD CONSTRAINT `FK_Bodega_HistoriaInventario` FOREIGN KEY (`Kidbodega`) REFERENCES `tbl_bodega` (`KidBodega`),
  ADD CONSTRAINT `fk_MovimientoInventario_HistoriaInventario` FOREIGN KEY (`Kidmovimientoinventario`) REFERENCES `tbl_moviemiento_inventario` (`Kidmoviemientoinventario`),
  ADD CONSTRAINT `fk_Producto_HistoriaInventario` FOREIGN KEY (`Kidproducto`) REFERENCES `tbl_producto` (`KidProducto`),
  ADD CONSTRAINT `fk_Sucursal_HistoriaInventario` FOREIGN KEY (`Kidsucursal`) REFERENCES `tbl_sucursal` (`KidSucursal`);

--
-- Filtros para la tabla `tbl_ingredientes`
--
ALTER TABLE `tbl_ingredientes`
  ADD CONSTRAINT `fk_Tbl_Ingredientes_Tbl_Producto1` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_Ingredientes_Tbl_Recetas1` FOREIGN KEY (`KidRecetas`) REFERENCES `tbl_recetas` (`KidRecetas`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_inventario`
--
ALTER TABLE `tbl_inventario`
  ADD CONSTRAINT `Fk_Inventario_Stock` FOREIGN KEY (`Kidstock`) REFERENCES `tbl_stock` (`Kidstock`),
  ADD CONSTRAINT `fk_Inventario_Bodegas` FOREIGN KEY (`Kidbodega`) REFERENCES `tbl_bodega` (`KidBodega`),
  ADD CONSTRAINT `fk_Inventario_Existencia` FOREIGN KEY (`Kidexistencia`) REFERENCES `tbl_existencia` (`Kidexistencia`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Inventario_Producto1` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_librodiario_detalle`
--
ALTER TABLE `tbl_librodiario_detalle`
  ADD CONSTRAINT `fk_polizaEncabezado_libroDiarioDetalle` FOREIGN KEY (`KidPoliza`) REFERENCES `tbl_poliza_encabezado` (`KidPoliza`),
  ADD CONSTRAINT `fk_tbl_libroDiario_Detalle_tbl_libroDiario_Encabezado` FOREIGN KEY (`KidLibroDiarioEncabezado`) REFERENCES `tbl_librodiario_encabezado` (`KidLibroDiarioEncabezado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_libromayor_detalle`
--
ALTER TABLE `tbl_libromayor_detalle`
  ADD CONSTRAINT `fk_tbl_libroMayor_Detalle_tbl_libroMayor1` FOREIGN KEY (`KidLibroMayor`) REFERENCES `tbl_libromayor_encabezado` (`KidLibroMayor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_libromayor_encabezado`
--
ALTER TABLE `tbl_libromayor_encabezado`
  ADD CONSTRAINT `fk_tbl_libroMayor_tbl_libroDiario_Encabezado1` FOREIGN KEY (`KidLibroDiarioEncabezado`) REFERENCES `tbl_librodiario_encabezado` (`KidLibroDiarioEncabezado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_libro_bancos`
--
ALTER TABLE `tbl_libro_bancos`
  ADD CONSTRAINT `fk_tbl_libro_bancos_tbl_bancos1` FOREIGN KEY (`KidBanco`) REFERENCES `tbl_bancos` (`KidBanco`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_lista_precios_productos`
--
ALTER TABLE `tbl_lista_precios_productos`
  ADD CONSTRAINT `FK_productos_lista_precios` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_mesas`
--
ALTER TABLE `tbl_mesas`
  ADD CONSTRAINT `fk_Tbl_Mesas_Tbl_Areas1` FOREIGN KEY (`KidArea`) REFERENCES `tbl_areas` (`KidArea`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_nominasdetalle`
--
ALTER TABLE `tbl_nominasdetalle`
  ADD CONSTRAINT `fk_Tbl_nominasDetalle_Tbl_conceptos1` FOREIGN KEY (`KidConcepto`) REFERENCES `tbl_conceptos` (`KidConcepto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_nominasDetalle_Tbl_nominasEncabezado1` FOREIGN KEY (`KidNomina`) REFERENCES `tbl_nominasencabezado` (`KidNomina`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_nominasencabezado`
--
ALTER TABLE `tbl_nominasencabezado`
  ADD CONSTRAINT `fk_Tbl_nominasEncabezado_Tbl_empleado1` FOREIGN KEY (`KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_objetos_perdidos`
--
ALTER TABLE `tbl_objetos_perdidos`
  ADD CONSTRAINT `fk_Tbl_Objetos_Perdidos_Tbl_Habitaciones1` FOREIGN KEY (`KidNumeroHabitacion`) REFERENCES `tbl_habitaciones` (`KidNumeroHabitacion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_orden_compra_encabezado`
--
ALTER TABLE `tbl_orden_compra_encabezado`
  ADD CONSTRAINT `Fk_ordenencabezado_impuesto` FOREIGN KEY (`KidImpuesto`) REFERENCES `tbl_impuesto` (`KidImpuesto`),
  ADD CONSTRAINT `fk_OrdenEncabezado_proveedor` FOREIGN KEY (`KidProveedor`) REFERENCES `tbl_proveedor` (`KidProveedor`);

--
-- Filtros para la tabla `tbl_orden_dompra_detalle`
--
ALTER TABLE `tbl_orden_dompra_detalle`
  ADD CONSTRAINT `fk_OrdenEncabezado_detalle` FOREIGN KEY (`KidOrdenCompraEncabezado`) REFERENCES `tbl_orden_compra_encabezado` (`KidOrdenCompraEncabezado`),
  ADD CONSTRAINT `fk_ordendetalle_producto` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_pagos`
--
ALTER TABLE `tbl_pagos`
  ADD CONSTRAINT `fk_Pagos_FacturaEncabezado1` FOREIGN KEY (`KidFacturaEncabezado`) REFERENCES `tbl_facturaencabezado` (`KidFacturaEncabezado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Pagos_TipoPago1` FOREIGN KEY (`KidTipoPago`) REFERENCES `tbl_tipopago` (`KidTipoPago`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_pagoservicio`
--
ALTER TABLE `tbl_pagoservicio`
  ADD CONSTRAINT `FK_pago_acreedor` FOREIGN KEY (`KidAcreedor`) REFERENCES `tbl_acreedor` (`KidAcreedor`),
  ADD CONSTRAINT `FK_pago_servicio` FOREIGN KEY (`KidServicio`) REFERENCES `tbl_servicio` (`KidServicio`);

--
-- Filtros para la tabla `tbl_pedido`
--
ALTER TABLE `tbl_pedido`
  ADD CONSTRAINT `FK_proveedor_pedido` FOREIGN KEY (`KidProveedor`) REFERENCES `tbl_proveedor` (`KidProveedor`),
  ADD CONSTRAINT `fk_OrdenEncabezado_pedido` FOREIGN KEY (`KidOrdenCompra`) REFERENCES `tbl_orden_compra_encabezado` (`KidOrdenCompraEncabezado`);

--
-- Filtros para la tabla `tbl_pedidodet`
--
ALTER TABLE `tbl_pedidodet`
  ADD CONSTRAINT `fk_PedidoDet_producto` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_perfil_detalle`
--
ALTER TABLE `tbl_perfil_detalle`
  ADD CONSTRAINT `fk_Perfil_detalle_Aplicacion1` FOREIGN KEY (`PK_id_aplicacion`) REFERENCES `tbl_aplicacion` (`PK_id_aplicacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Perfil_detalle_Perfil1` FOREIGN KEY (`PK_id_perfil`) REFERENCES `tbl_perfil_encabezado` (`PK_id_perfil`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_planillasdetalle`
--
ALTER TABLE `tbl_planillasdetalle`
  ADD CONSTRAINT `fk_Tbl_PlanillasDetalle_Tbl_empleado1` FOREIGN KEY (`KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_PlanillasDetalle_Tbl_planillasEncabezado1` FOREIGN KEY (`KidPlanilla`) REFERENCES `tbl_planillasencabezado` (`KidPlanilla`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_platillos`
--
ALTER TABLE `tbl_platillos`
  ADD CONSTRAINT `menu` FOREIGN KEY (`KidMenu`) REFERENCES `tbl_menus` (`KidMenu`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_poliza`
--
ALTER TABLE `tbl_poliza`
  ADD CONSTRAINT `FK_FacturaDetalle_Poliza` FOREIGN KEY (`KidFacturaDetalle`) REFERENCES `tbl_facturadetalle` (`KidFacturaDetalle`);

--
-- Filtros para la tabla `tbl_poliza_detalle`
--
ALTER TABLE `tbl_poliza_detalle`
  ADD CONSTRAINT `fk_Cuentas_PolizaDetalle` FOREIGN KEY (`KidCuenta`) REFERENCES `tbl_cuentas` (`KidCuenta`),
  ADD CONSTRAINT `fk_PolizaEncabezado_PolizaDetalle` FOREIGN KEY (`KidPoliza`) REFERENCES `tbl_poliza_encabezado` (`KidPoliza`);

--
-- Filtros para la tabla `tbl_poliza_encabezado`
--
ALTER TABLE `tbl_poliza_encabezado`
  ADD CONSTRAINT `fk_tipoDePoliza_PolizaEncabezado` FOREIGN KEY (`KidTipoDePoliza`) REFERENCES `tbl_tipo_poliza` (`KidTipoDePoliza`);

--
-- Filtros para la tabla `tbl_precios`
--
ALTER TABLE `tbl_precios`
  ADD CONSTRAINT `fk_Precios_Producto1` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_presupuesto`
--
ALTER TABLE `tbl_presupuesto`
  ADD CONSTRAINT `FK_Moneda_Presupuesto` FOREIGN KEY (`KidMoneda`) REFERENCES `tbl_moneda` (`KidMoneda`),
  ADD CONSTRAINT `FK_area_presupuesto` FOREIGN KEY (`KidArea`) REFERENCES `tbl_areas` (`KidArea`),
  ADD CONSTRAINT `FK_cuentas_presupuesto` FOREIGN KEY (`KidCuenta`) REFERENCES `tbl_cuentas` (`KidCuenta`);

--
-- Filtros para la tabla `tbl_producto`
--
ALTER TABLE `tbl_producto`
  ADD CONSTRAINT `fk_Descuento_Producto` FOREIGN KEY (`KidDescuentos`) REFERENCES `tbl_descuentos` (`KidDescuentos`),
  ADD CONSTRAINT `fk_Producto_TipoProducto1` FOREIGN KEY (`KidTipoProducto`) REFERENCES `tbl_tipoproducto` (`KidTipoProducto`);

--
-- Filtros para la tabla `tbl_producto_marca`
--
ALTER TABLE `tbl_producto_marca`
  ADD CONSTRAINT `fk_Marca_Producto` FOREIGN KEY (`Kidmarca`) REFERENCES `tbl_marca` (`Kidmarca`),
  ADD CONSTRAINT `fk_Producto_Marca` FOREIGN KEY (`Kidproducto`) REFERENCES `tbl_producto` (`KidProducto`);

--
-- Filtros para la tabla `tbl_puestos`
--
ALTER TABLE `tbl_puestos`
  ADD CONSTRAINT `fk_Area_Puestos` FOREIGN KEY (`KidArea`) REFERENCES `tbl_tipocliente` (`KidTipoCliente`);

--
-- Filtros para la tabla `tbl_quejas`
--
ALTER TABLE `tbl_quejas`
  ADD CONSTRAINT `fk_Tbl_Quejas_Tbl_Clientes1` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_reporte`
--
ALTER TABLE `tbl_reporte`
  ADD CONSTRAINT `FK_RPT_CONFIGURACION` FOREIGN KEY (`ID_CONFIGURACION`) REFERENCES `tbl_configuracion_rpt` (`ID_CONFIGURACION`);

--
-- Filtros para la tabla `tbl_reservaciones`
--
ALTER TABLE `tbl_reservaciones`
  ADD CONSTRAINT `fk_Tbl_Reservaciones_Tbl_Clientes1` FOREIGN KEY (`KidCliente`) REFERENCES `tbl_clientes` (`KidCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_Reservaciones_Tbl_Empleados1` FOREIGN KEY (`KidEmpleado`) REFERENCES `tbl_empleado` (`KidEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_resultados`
--
ALTER TABLE `tbl_resultados`
  ADD CONSTRAINT `FK_BancoTalento_Resultados` FOREIGN KEY (`KidBancoTalento`) REFERENCES `tbl_bancotalento` (`KidBancoTalento`),
  ADD CONSTRAINT `FK_Pruebas_Resultados` FOREIGN KEY (`KidPruebas`) REFERENCES `tbl_pruebas` (`KidPruebas`);

--
-- Filtros para la tabla `tbl_rpt_almacen`
--
ALTER TABLE `tbl_rpt_almacen`
  ADD CONSTRAINT `FK_RPT_ALM_MODULO` FOREIGN KEY (`ID_MODULO`) REFERENCES `tbl_modulo` (`PK_ID_MODULO`),
  ADD CONSTRAINT `FK_RPT_ALM_USUARIO` FOREIGN KEY (`ID_MODULO`) REFERENCES `tbl_modulo` (`PK_ID_MODULO`);

--
-- Filtros para la tabla `tbl_rpt_app`
--
ALTER TABLE `tbl_rpt_app`
  ADD CONSTRAINT `FK_RPT_APP_APLICACION` FOREIGN KEY (`ID_APLICACION`) REFERENCES `tbl_aplicacion` (`PK_ID_APLICACION`),
  ADD CONSTRAINT `FK_RPT_APP_MODULO` FOREIGN KEY (`ID_MODULO`) REFERENCES `tbl_modulo` (`PK_ID_MODULO`),
  ADD CONSTRAINT `FK_RPT_APP_REPORTE` FOREIGN KEY (`ID_REPORTE`) REFERENCES `tbl_reporte` (`ID_REPORTE`);

--
-- Filtros para la tabla `tbl_rpt_mdl`
--
ALTER TABLE `tbl_rpt_mdl`
  ADD CONSTRAINT `FK_RPT_MDL_MODULO` FOREIGN KEY (`ID_MODULO`) REFERENCES `tbl_modulo` (`PK_ID_MODULO`),
  ADD CONSTRAINT `FK_RPT_MDL_REPORTE` FOREIGN KEY (`ID_REPORTE`) REFERENCES `tbl_reporte` (`ID_REPORTE`);

--
-- Filtros para la tabla `tbl_serie`
--
ALTER TABLE `tbl_serie`
  ADD CONSTRAINT `FK_Folio_Serie` FOREIGN KEY (`KidFolio`) REFERENCES `tbl_folios` (`KidFolio`);

--
-- Filtros para la tabla `tbl_servicios`
--
ALTER TABLE `tbl_servicios`
  ADD CONSTRAINT `fk_Tbl_Servicios_Tbl_Areas1` FOREIGN KEY (`KidArea`) REFERENCES `tbl_areas` (`KidArea`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_solicitudrembolso`
--
ALTER TABLE `tbl_solicitudrembolso`
  ADD CONSTRAINT `fk_SolicitudRembolso_FacturaEncabezado1` FOREIGN KEY (`KidFacturaEncabezado`) REFERENCES `tbl_facturaencabezado` (`KidFacturaEncabezado`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_tiendas`
--
ALTER TABLE `tbl_tiendas`
  ADD CONSTRAINT `fk_Tbl_Tiendas_Tbl_Areas1` FOREIGN KEY (`KidArea`) REFERENCES `tbl_areas` (`KidArea`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_tiendas_producto`
--
ALTER TABLE `tbl_tiendas_producto`
  ADD CONSTRAINT `fk_Tbl_Producto_has_Tbl_Tiendas_Tbl_Producto1` FOREIGN KEY (`KidProducto`) REFERENCES `tbl_producto` (`KidProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Tbl_Producto_has_Tbl_Tiendas_Tbl_Tiendas1` FOREIGN KEY (`KidTienda`) REFERENCES `tbl_tiendas` (`KidTienda`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_tipocambio`
--
ALTER TABLE `tbl_tipocambio`
  ADD CONSTRAINT `fk_tbl_tipoCambio_tbl_Divisa` FOREIGN KEY (`KidMonedaConversion`) REFERENCES `tbl_divisa` (`KidDivisa`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_tipoCambio_tbl_Divisa1` FOREIGN KEY (`KidMonedaBase`) REFERENCES `tbl_divisa` (`KidDivisa`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `tbl_ubicacionprodcuto`
--
ALTER TABLE `tbl_ubicacionprodcuto`
  ADD CONSTRAINT `fk_Producto_Ubicacion` FOREIGN KEY (`Kidproducto`) REFERENCES `tbl_producto` (`KidProducto`),
  ADD CONSTRAINT `fk_Ubicacion_Producto` FOREIGN KEY (`Kidubicacion`) REFERENCES `tbl_ubicacion` (`Kidubicacion`);

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
