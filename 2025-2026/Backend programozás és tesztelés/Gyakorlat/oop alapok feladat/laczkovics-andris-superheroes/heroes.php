<?php

declare(strict_types=1);

include("./src/Universe/Entities/Superhero.php");

use \Universe\Entities\Superhero as Superhero;

$superhero1 = new Superhero
(
    "Flash",
    28,
    ["Speed", "Time Travel"],
);
$superhero2 = new Superhero
(
    "Iron Man",
    45,
    ["Genius Intellect", "Powered Armor Suit", "Wealth"],
);
$superhero3 = new Superhero
(
    "Spider-Man",
    18,
    ["Wall-Crawling", "Spider-Sense", "Super Agility"],
);
$superhero4 = new Superhero
(
    "Superman",
    35,
    ["Strength", "Flight", "X-ray Vision"],
);

$superheroes =
[
    1 => $superhero1,
    2 => $superhero2,
    3 => $superhero3,
    4 => $superhero4,
];

for ($i = 1; $i <= count($Superheroes); $i++)
{
    $name = $sperheroes[$i] -> getName();
    $age = $superheroes[$i] -> getAge();
    $powers = $superheroes[$i] -> getSuperpowers();

    echo "Név: $name\n";
    echo "Kor: $age\n";
    echo "Szupererők: " . Join(", ", $powers). "\n\n";
}

?>