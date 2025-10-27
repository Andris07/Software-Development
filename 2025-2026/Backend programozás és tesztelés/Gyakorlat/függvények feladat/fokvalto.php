<?php

require_once ('fuggvenyek.php');

if($argc != 3)
{
    echo "Túl kevés/sok paraméter!\n";
    exit(1);
}

if(!is_numeric($argv[1]))
{
    echo "Számot adjon meg!\n";
    exit(2);
}

if($argv[2] == "Celsius" || $argv[2] == "CELSIUS" || $argv[2] == "celsius" || $argv[2] == "C" || $argv[2] == "c")
{
    $result = c2f($argv[1]);
    echo round($argv[1], 2) . " Celsius = " . round($result, 2) . " Fahrenheit\n";
}

else
{
    $result = f2c($argv[1]);
    echo round($argv[1], 2) . " Fahrenheit = " . round($result, 2) . " Celsius\n";
}

?>