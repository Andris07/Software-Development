<?php

declare(strict_types=1);

namespace Neu\Eszkozok;
use Faker\Factory;
use Neu\Eszkozok\Nyomtato;
use Neu\Eszkozok\TintasugarasNyomtato;
use Neu\Eszkozok\LezerNyomtato;

error_reporting(E_ALL);
ini_set("display_errors", 1);

require_once "vendor/autoload.php";
$faker = Factory::create();

if ($argc < 2)
{
    echo "Túl kevés paraméter!\n";
    exit(7);    
}

if ($argc > 3)
{
    echo "Túl sok paraméter!\n";
    exit(3);    
}

$nyomtato_tipus = $argv[1];

if ($nyomtato_tipus !== "lezer" && $nyomtato_tipus !== "tintasugaras")
{
    echo "Rossz nyomtató típus!\n";
    exit(29);
}

$nyomtatok = [];

for ($i = 0; $i < 5; $i++)
{
    $gyarto = $faker -> randomElement(Nyomtato :: getGyartok());
    $tipus = mb_strtoupper($faker -> randomLetter() . $faker -> randomNumber(3, true));
    $szines = random_int(1, 3);
    $szines = $szines === 1 ? true : false;
    $tonerekSzama = $szines ? 4 : 1;

    if ($nyomtato_tipus === "lezer")
    {
        $ar = $faker -> numberBetween(40000, 300000);
        $nyomtato = new LezerNyomtato($gyarto, $tipus, $szines, $ar, $tonerekSzama);
    }
    else
    {
        $ar = $faker -> numberBetween(20000, 250000);
        $nyomtato = new TintasugarasNyomtato($gyarto, $tipus, $szines, $ar, $tonerekSzama);
    }
    array_push($nyomtatok, $nyomtato);
}
echo implode("\n", $nyomtatok) . "\n";

$masodik_parameter = isset($argv[2]) ? $argv[2] : null;

if ($masodik_parameter === "fajlba")
{
    $fajl = fopen("./out/" . $nyomtato_tipus . ".csv", "w");
    $szeparator = ";";
    foreach ($nyomtatok as $nyomtato)
    {
        fputcsv($fajl, $nyomtato -> __toArray(), $szeparator, '"', "\\");
    }
    fclose($fajl);
}
else if (is_numeric($masodik_parameter))
{
    echo $nyomtatok[$masodik_parameter] . "\n";
}

?>