<?php

// 1. feladat
$vegyes = [5, 9, "Hello", 11.2, "Béla", 33, "Márta", 48.98, 7];

// 2. feladat
// Hibaüzenet, ha a felhasználó nem jól adná meg a paramétert
if ($argc != 2)
{
    echo "A szkript pontosan egy paramétert vár!\n";
    exit(1);
}

// Paraméterek lementése
$parameter = $argv[1];

// 3. feladat
// Hibaüzenet, ha a felhasználó nem jó paramétert adna meg
if ($parameter != "szamok" && $parameter != "egesz" && $parameter != "valos" && $parameter != "szoveg")
{
    echo "A paraméter csak 'szamok', 'egesz', 'valos', vagy 'szoveg' lehet.\n";
    exit(2);
}

// 4. feladat
echo "4. feladat\n";

if ($parameter == "szamok")
{
    $szamok = [];
    $counter = 0;

    foreach ($vegyes as $ertek)
    {
        if (!is_string($ertek))
        {
            $szamok[] = $ertek;
            echo ++$counter . ". szám: " . $szamok[$counter-1] . "\n";
        }
    }
}
else if ($parameter == "egesz")
{
    $egeszSzamok = [];
    $counter = 0;

    foreach ($vegyes as $ertek)
    {
        if (is_int($ertek))
        {
            $egeszSzamok[] = $ertek;
            echo ++$counter . ". szám: " . $egeszSzamok[$counter-1] . "\n";
        }
    }
}
else if ($parameter == "valos")
{
    $valosSzamok = [];
    $counter = 0;

    foreach ($vegyes as $ertek)
    {
        if (is_float($ertek))
        {
            $valosSzamok[] = $ertek;
            echo ++$counter . ". szám: " . $valosSzamok[$counter-1] . "\n";
        }
    }
}
else
{
    $szovegek = [];
    $counter = 0;

    foreach ($vegyes as $ertek)
    {
        if (is_string($ertek))
        {
            $szovegek[] = $ertek;
            echo ++$counter . ". szám: " . $szovegek[$counter-1] . "\n";
        }
    }
}

?>