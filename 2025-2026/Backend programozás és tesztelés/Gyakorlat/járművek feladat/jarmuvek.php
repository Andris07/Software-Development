<?php

declare(strict_types=1);

require_once __DIR__ . "/vendor/autoload.php";

use Acme\Kozlekedes\Auto;
use Acme\Kozlekedes\Busz;
use Acme\Kozlekedes\Roller;

if ($argc > 3)
{
    echo "Túl sok paramétert adott meg!\n";
    exit(1);
}

$jarmuTipus = $argc >= 2 ? strtolower($argv[1]) : null;
$fajlNev = $argc === 3 ? $argv[2] : null;

$ervenyesJarmuTipusok = ["auto", "busz", "roller"];

if ($jarmuTipus !== null && !in_array($jarmuTipus, $ervenyesJarmuTipusok))
{
    echo "Helytelen járműtípus!\n";
    exit(2);
}

if ($fajlNev !== null && pathinfo($fajlNev, PATHINFO_EXTENSION) !== "csv")
{
    echo "Csak CSV fájl támogatott!\n";
    exit(3);
}

$jarmuvek =
[
    new Busz("Ikarus", "280", "kék", "diesel", 36),
    new Auto("Tesla", "Model S", "fehér", "elektromos", 5),
    new Roller("Oxelo", "C900", "fekete", 2),
    new Roller("Blackwheels", "Blink gyerek roller", "színes", 3),
];

if ($argc === 1)
{
    foreach ($jarmuvek as $jarmu)
    {
        echo $jarmu . "\n";
    }
    exit(4);
}

$szurt = array_filter($jarmuvek, function ($jarmu) use ($jarmuTipus)
{
    return match ($jarmuTipus)
    {
        "auto"   => $jarmu instanceof Auto,
        "busz"   => $jarmu instanceof Busz,
        "roller" => $jarmu instanceof Roller,
    };
});

if ($argc === 2)
{
    foreach ($szurt as $jarmu)
    {
        echo $jarmu . "\n";
    }
    exit(5);
}

if (!is_dir("out"))
{
    mkdir("out");
}

$fajl = fopen("out/" . $fajlNev, "w");

foreach ($szurt as $jarmu)
{
    fwrite($fajl, $jarmu . PHP_EOL);
}

fclose($fajl);

echo "Exportálás kész.\n";

?>