<?php

// Hibaüzenet, ha a felhasználó nem adna meg elég paramétert
if ($argc < 3)
{
    echo "Adja meg a vezeték-és keresztnevét!\n";
    exit(1);
}

// Paraméterek lementése
$firstName = $argv[2];
$lastName = $argv[1];

// Kiírás konzolra
echo "Angol: ({$firstName} {$lastName})\n";
echo "Magyar: [{$lastName} {$firstName}]\n";

?>