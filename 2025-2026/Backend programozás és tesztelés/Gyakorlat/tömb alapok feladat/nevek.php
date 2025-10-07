<?php

// 1. feladat
$nevek =
[
    "Robert Downey Jr.",
    "Chris Hemsworth",
    "Scarlett Johansson",
    "Karen Gillan",
    "Benedict Cumberbatch",
];

// 2. feladat
echo "2. feladat\n";
echo "Első: {$nevek[0]}\n\n";

// 3. feladat
echo "3. feladat\n";
echo "Utolsó: {$nevek[count($nevek) - 1]}\n\n";

// 4. feladat
echo "4. feladat\n";
foreach ($nevek as $nev)
{
    echo "- {$nev}\n";
}

?>