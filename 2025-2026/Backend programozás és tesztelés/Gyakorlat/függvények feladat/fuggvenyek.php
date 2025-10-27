<?php

function hetNapja($dayNum)
{
    $days =
    [
        1 => "hétfő",
        2 => "kedd",
        3 => "szerda",
        4 => "csütörtök",
        5 => "péntek",
        6 => "szombat",
        7 => "vasárnap"
    ];

    return $days[$dayNum] ?? "Nincs ilyen nap!";
}

function napSorszama($dayName)
{
    $days =
    [
        "hétfő" => 1,
        "kedd" => 2,
        "szerda" => 3,
        "csütörtök" => 4,
        "péntek" => 5,
        "szombat" => 6,
        "vasárnap" => 7
    ];

    return $days[$dayName] ?? 0;
}

function parosE(int $num)
{
    return $num % 2 == 0 ? true : false;
}

function paratlanE(int $num)
{
    return $num % 2 != 0 ? true : false;
}

function oszthatoE(int $num1, int $num2)
{
    return $num1 % $num2 == 0 ? true : false;
}

function negativE(int $num)
{
    return $num < 0 ? true : false;
}

function szignum(int $num)
{
    if ($num > 0)
    {
        return 1;
    }
    elseif ($num < 0)
    {
        return -1;
    }
    else
    {
        return 0;
    }
}

function datumIdo(string $type)
{
    switch ($type)
    {
        case 'óra':
            return date("H");
        case 'perc':
            return date('i');
        case 'masodperc':
            return date('s');
        case "év":
            return date('Y');
        case "hónap":
            return date('m');
        case "nap":
            return date('d');
        default:
            return "Ismeretlen típus!";
    }
}

//-------------------------------------------------------------------------------

function utolso($array)
{
    //return array_pop($array);
    return $array[count($array) - 1];
}

function osszeg($array)
{
    $sum = 0;
    foreach ($array as $value)
    {
        $sum += $value;
    }
    return $sum;
}

function szorzat($array)
{
    $product = 1;
    foreach ($array as $value)
    {
        $product *= $value;
    }
    return $product;
}

function parosDb($array)
{
    $count = 0;
    foreach ($array as $value)
    {
        if (parosE($value))
        {
            $count++;
        }
    }
    return $count;
}

function parosOsszeg($array)
{
    $sum = 0;
    foreach ($array as $value)
    {
        if (parosE($value))
        {
            $sum += $value;
        }
    }
    return $sum;
}

function elsoNOsszeg($array, int $n)
{
    $sum =0;
    for ($i = 0; $i < $n && $i < count($array); $i++)
    {
        $sum += $array[$i];
    }
    return $sum;
}

//-------------------------------------------------------------------------------

function f2c($f)
{
    return ($f - 32) * 5/9;
}

function c2f($c)
{
    return ($c * 9/5) + 32;
}

//-------------------------------------------------------------------------------

function atlagfogyaztas(int $km, float $liter)
{
    return round(($liter / $km) * 100, 2);
}


//-------------------------------------------------------------------------------

function felKerekites(float $x): int
{
    return (int) ceil($x);
}

function leKerekites(float $x): int
{
    return (int) floor($x);
}

function matematikaiKerekites(float $x): int
{
    return (int) round($x);
}

function ftKerekites(int $x): int
{
    $mod = $x % 10;
    if($mod == 1 || $mod == 2)
    {
        return $x - $mod;
    }
    elseif($mod == 8 || $mod == 9)
    {
        return $x + (10 - $mod);
    }
    else
    {
        return $x - $mod + 5;
    }
}

function bankarKerekites(float $x): int
{
    $rounded = round($x);
    if($rounded % 2 == 0)
    {
        return $rounded;
    }
    else
    {
        $lower = $rounded - 1;
        $upper = $rounded + 1;
        return (abs($x - $lower) <= abs($x - $upper)) ? $lower : $upper;
    }
}

?>