<?php

declare(strict_types = 1);

require_once __DIR__ . "/vendor/autoload.php";

use Acme\Frosty\IceCream;
use Faker\Factory;

$faker = Factory::create("hu_HU");

if ($argc < 2)
{
  echo "Legalább 1 paraméter megadása szükséges!\n";
  exit(7);
}

$iceCreamsToBeGenerated = $argv[1];
if (!is_numeric($iceCreamsToBeGenerated) || (int)$iceCreamsToBeGenerated < 1)
{
  echo "Nem megfelelő paraméter!\n";
  echo "Az első paraméternek 0-nál nagyobb számnak kell lennie!\n";
  exit(17);
}
$iceCreamsToBeGenerated = (int)$iceCreamsToBeGenerated;

$icecreams = [];

for ($i = 0; $i < $iceCreamsToBeGenerated; $i++)
{
  $scoops = $faker -> numberBetween(1, 5);
  $sweetCone = $faker -> boolean();

  $availableFlavours = IceCream::availableFlavours();
  $flavours = [];

  for ($j = 0; $j < $scoops; $j++)
  {
    $flavours[] = $faker -> randomElement($availableFlavours);
  }

  $icecream = new IceCream($scoops, $sweetCone);
  $icecream -> flavours = $flavours;

  $icecreams[] = $icecream;
}

foreach ($icecreams as $egyik)
{
  echo $egyik . PHP_EOL;
}

foreach ($icecreams as $egyik)
{
    $oldPrice = $egyik -> price;
    $newPrice = (int) round($oldPrice * 0.9);
    $egyik -> price = $newPrice;
}

$outDir = __DIR__ . "/out";

if (!is_dir($outDir))
{
  mkdir($outDir);
}

$csvFile = $outDir . "/sale.csv";
$f = fopen($csvFile, "w");

foreach ($icecreams as $egyik)
{
    $arr = $egyik->toArray();

    $sor = $arr[0] . ";" . $arr[3] . ";" . '"' . $arr[2] . '";"' . $arr[1] . '"';
    fwrite($f, $sor . PHP_EOL);
}

fclose($f);

echo "CSV generálva: out/sale.csv\n";

// docker build -t lag/frosty -f Frosty.Dockerfile .

?>