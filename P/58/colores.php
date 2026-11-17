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

// Página solicitada
$pagina = isset($_GET["pagina"]) ? intval($_GET["pagina"]) : 1;
if($pagina < 1){
    $pagina = 1;
}
$registrosPorPagina = 10;
$inicio = ($pagina - 1) * $registrosPorPagina;

$SQL = "SELECT codigo, nombre
        FROM colores
        ORDER BY nombre
        LIMIT :inicio, :cantidad";

$Sentencia = $Conexion->prepare($SQL);
$Sentencia->bindValue(':inicio', $inicio, PDO::PARAM_INT);
$Sentencia->bindValue(':cantidad', $registrosPorPagina, PDO::PARAM_INT);
$Sentencia->execute();
$colores = $Sentencia->fetchAll(PDO::FETCH_ASSOC);
echo json_encode($colores);