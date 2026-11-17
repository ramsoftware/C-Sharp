<?php

header("Content-Type: application/json; charset=UTF-8");

$datos = [
    "nombre" => "Sandra Milena",
    "edad" => 27,
    "ciudad" => "Cali"
];

echo json_encode($datos);
