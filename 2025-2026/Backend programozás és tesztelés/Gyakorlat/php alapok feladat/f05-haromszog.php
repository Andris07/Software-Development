<?php

// Hibaüzenet, ha a felhasználó nem adna meg elég paramétert
if ($argc < 4)
{
    echo "Túl kevés paraméter\n";
    exit(1);
}

// Hibaüzenet, ha a felhasználó túl sok paramétert adna meg
if ($argc > 4)
{
    echo "Túl sok paraméter\n";
    exit(2);
}

// Paraméterek lementése
$a = $argv[1];
$b = $argv[2];
$c = $argv[3];

// Hibaüzenet, ha a felhasználó nem jó paramétert adna meg
if (!is_numeric($a) || !is_numeric($b) || !is_numeric($c))
{
    echo "Három számot adjon meg!\n";
    exit(3);
}
if ($a + $b < $c || $a + $c < $b || $b + $c < $a)
{
    echo "Nem szerkeszhető meg\n";
    exit(4);
}

// Kiírás konzolra
$t = $a * $b * $c;
$k = $a + $b + $c;

echo "T={$t}\n";
echo "K={$k}\n";

?>