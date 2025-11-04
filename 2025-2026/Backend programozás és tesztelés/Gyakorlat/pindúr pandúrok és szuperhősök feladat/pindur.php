<?php

echo "Pindúr Pandúrok (The Powerpuff Girls)\n";

// Ellenőrizzük, hogy van-e legalább egy paraméter
if ($argc < 2)
{
    echo "Túl kevés paraméter!\n";
    exit(1);
}

$pp =
[
    "pindurka" => "Blossom",
    "pinduri"  => "Bubbles",
    "pindusz"  => "Buttercup",
    "professzor" => "Professor Utonium",
    "mojo jojo" => "Mojo Jojo",
];

$input = $argv[1];
$magyarNevek = explode(";", $input);
$angolnevek = [];

foreach ($magyarNevek as $nev)
{
    $kulcs = strtolower(trim($nev));
    if (isset($pp[$kulcs]))
    {
        $angolnevek[] = $pp[$kulcs];
    }
    else
    {
        $angolnevek[] = "(ismeretlen: $nev)";
    }
}

echo implode("\n", $angolnevek) . "\n";
?>