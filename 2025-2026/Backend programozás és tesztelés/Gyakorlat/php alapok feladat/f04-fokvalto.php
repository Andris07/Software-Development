<?php

// Hibaüzenet, ha a felhasználó nem adna meg elég paramétert
if ($argc < 3)
{
    echo "Túl kevés paraméter\n";
    exit(1);
}

// Hibaüzenet, ha a felhasználó túl sok paramétert adna meg
if ($argc > 3)
{
    echo "Túl sok paraméter\n";
    exit(2);
}

// Paraméterek lementése
$temperature = $argv[1];
$metric = strtolower($argv[2]);

// Hibaüzenet, ha a felhasználó nem jó paramétert adna meg
if (!is_numeric($temperature))
{
    echo "Számot adjon meg!\n";
    exit(3);
}

// Kiírás konzolra
if ($metric == "celsius" || $metric == "c")
{
    $fahreinhet = $temperature * 1.8 + 32;
    echo "{$temperature} celsius az {$fahreinhet} fahrenheit.\n";
}
else if ($metric == "fahrenheit" || $metric == "f")
{
    $celsius = ($temperature - 32) / 1.8;
    echo "{$temperature} fahrenheit az {$celsius} celsius.\n";
}
else
{
    echo "Hibás mértékegység\n";
}

?>