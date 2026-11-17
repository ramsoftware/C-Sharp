<?php
header("Content-Type: text/plain");

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

$Nombre = $_POST["nombre"];
$SQL = "INSERT INTO colores(nombre) VALUES(:nombre)";
$Sentencia = $Conexion->prepare($SQL);
$Sentencia->bindParam(':nombre', $Nombre, PDO::PARAM_STR);
if($Sentencia->execute()){
    echo "Registro guardado";
}
else{
    echo "Error al guardar";
}