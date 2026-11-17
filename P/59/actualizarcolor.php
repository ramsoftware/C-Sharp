<?php

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

$codigo = $_POST["codigo"];
$nombre = $_POST["nombre"];

$SQL = "UPDATE colores SET nombre = :nombre WHERE codigo = :codigo";
$Sentencia = $Conexion->prepare($SQL);
$Sentencia->bindParam(':nombre', $nombre, PDO::PARAM_STR);
$Sentencia->bindParam(':codigo', $codigo, PDO::PARAM_INT);
if($Sentencia->execute()){
    echo "Registro actualizado";
}
else{
    echo "Error al actualizar";
}