<?php

// Hibaüzenet, ha a felhasználó túl sok paramétert adna meg
if ($argc > 3)
{
    echo "Túl sok paraméter!\n";
    exit(1);
}

$originalNum = $argv[1];
$roundingOption = $argv[2];

if (strtolower($roundingOption) == "fel")
{
    felKerekites($originalNum);
}
else if (strtolower($roundingOption) == "le")
{
    leKerekites($originalNum);
}
else if (strtolower($roundingOption) == "ft")
{
    ftKerekites($originalNum);
}
else if (strtolower($roundingOption) == "bankar")
{
    bankarKerekites($originalNum);
}
else if (!is_null($roundingOption))
{
    $roundingOption = matematikaiKerekites();
}
else
{
    echo "Ismeretlen kerekítési mód!\n";
    exit(2);
}

function felKerekites(float $num)
{
    return ceil($num);
}
function leKerekites(float $num)
{
    return floor($num);
}
function matematikaiKerekites(float $num)
{
    return round($num);
}
function ftKerekites($num)
{
    if (str($num)[count($num)-1] === "1" || str($num)[count($num)-1] === "2")
    {
        return $num - $num%5;
    }
    else if (str($num)[count($num)-1] === "8" || str($num)[count($num)-1] === "9")
    {
        return $num + $num%5;
    }
    else
    {
        return $num - $num%5 + 5;
    }
}

?>