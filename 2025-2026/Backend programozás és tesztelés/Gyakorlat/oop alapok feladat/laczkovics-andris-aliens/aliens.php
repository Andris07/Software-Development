<?php

declare(strict_types=1);

include("./src/Space/Exploration/Alien.php");

use Space\Exploration\Alien as Alien;

$alien1 = new Alien
(
    "Zog",
    "Zogonia",
    true,
);
$alien2 = new Alien
(
    "Blip",
    "Blipton",
    false,
);
$alien3 = new Alien
(
    "Xar",
    "Xarax",
    true,
);
$alien4 = new Alien
(
    "Gloop",
    "Gloopia",
    false,
);

$aliens =
[
    1 => $alien1,
    2 => $alien2,
    3 => $alien3,
    4 => $alien4,
];

for ($i = 1; $i <= count($Aliens); $i++)
{
    $species = $Aliens[$i] -> getSpecies();
    $planet = $Aliens[$i] -> getPlanet();
    $isFriendly = $Aliens[$i] -> isFriendly();

    $output = "";

    if($isFriendly)
    {
        $output = $output . " ";
    }
    else
    {
        $output = $output . "!";
    }

    $output = $output . $species . " (" . $planet . ")\n\n";
    echo $output;
}

?>