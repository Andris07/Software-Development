<?php

require_once("fuggvenyek.php");

if($argc > 3)
{
    echo "Túl sok paraméter!\n";
    exit(1);
}
if($argc < 2)
{
    "Túl kevés paraméter!\n";
    exit(2);
}

$szam = $argv[1];
$mod = $argv[2] ?? "";

if(!is_numeric($szam))
{
    echo "Számot adjon meg!\n";
    exit(3);
}

$mod = $mod;

switch($mod) 
{
    case "fel":
        $eredmeny = felKerekites((float)$szam);
        break;
    case "le":
        $eredmeny = leKerekites((float)$szam);
        break;
    case "ft":
        $eredmeny = ftKerekites((int)$szam);
        break;
    case "bankar":
        $eredmeny = bankarKerekites((float)$szam);
        break;
    case "":
        $eredmeny = matematikaiKerekites((float)$szam);
        break;
    default:
        exit("Ismeretlen kerekítési mód!\n");
}

echo $eredmeny. "\n";

?>