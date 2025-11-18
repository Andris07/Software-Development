<?php

require_once "fuggvenyek.php";

if ($argc != 4)
{
    echo "Túl kevés/sok paraméter!\n";
    exit(1);
}

$megtett = floatval($argv[2] - $argv[1]);

echo "Előző óraállás: " . number_format($argv[1], 0, ",", " ") . " km\n";
echo "Mostani óraállás: " . number_format($argv[2], 0, ",", " ") . " km\n";
echo "Megtett út: " . number_format($megtett, 0, ",", " ") . " km\n";
echo "Tankolt mennyiség: " . number_format($argv[3], 0, ",", " ") . " liter\n";
echo "Átlagfogyasztás: " . atlagfogyaztas($megtett, floatval($argv[3])) . " liter/100km\n";

?>