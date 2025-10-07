<?php

// Hibaüzenet, ha a felhasználó nem adna meg elég paramétert
if ($argc < 2)
{
    echo "Adja meg a kör sugarát!\n";
    exit(1);
}

// Paraméter lementése
$r = $argv[1];

// Hibaüzenet, ha a felhasználó nem jó paramétert adna meg
if (!is_numeric($r))
{
    echo "Számot adjon meg!\n";
    exit(2);
}

// Terület, Kerület kiszámítása a megadott paraméter alapján
$t = $r ** 2 * pi();
$k = $r * 2 * pi();

// Kiírás konzolra
echo "T={$t}\n";
echo "K={$k}\n";

?>