<?php
header("Content-Type: application/json");

//Conectarse a la base de datos
$Servidor = "mysql:host=localhost";
$Sesion = "root";
$Contrasena = "";
$Instancia = "educar";

try {
//Usando PDO (PHP Data Objects) para conectarse.
	$Conexion = new PDO($Servidor.";dbname=".$Instancia, $Sesion, $Contrasena, array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8"));
	$Conexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $UnError){
	echo $UnError->getMessage();
	exit;
}

//Hace la consulta a la tabla
$SQL = "SELECT codigo, nombre FROM colores ORDER BY nombre";
$Sentencia = $Conexion->prepare($SQL);
$Sentencia->execute();  //Ejecuta la consulta
$colores = $Sentencia->fetchAll(PDO::FETCH_ASSOC);
echo json_encode($colores);