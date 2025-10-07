<?php

// Hibaüzenet, ha a felhasználó nem adna meg elég paramétert
if ($argc < 3)
{
    echo "Adja meg a két befogót\n";
    exit(1);
}

// Paraméterek lementése
$a = $argv[1];
$b = $argv[2];

// Hibaüzenet, ha a felhasználó nem jó paramétert adna meg
if (!is_numeric($a) || !is_numeric($b))
{
    echo "Két számot adjon meg!\n";
    exit(2);
}

// Átfogó kiszámítása a megadott paraméterek alapján
$c = sqrt($a ** 2 + $b ** 2);

// Kiírás konzolra
echo "a^2 + b^2 = c^2\n";
echo "{$a}^2 + {$b}^2 = {$c}^2\n";
echo "{$c}\n";

?>