<?php

// 1. feladat
$szamok = [1, 5, 8, 17, 25, 34];

// 2. feladat
echo "2. feladat\n";
echo count($szamok) . "\n\n";

// 3. feladat
echo "3. feladat\n";
echo "Első szám: {$szamok[0]}\n";
echo "Utolsó szám: {$szamok[count($szamok) - 1]}\n\n";

// 4. feladat
echo "4. feladat\n";

echo join(", ", $szamok) . "\n\n";

// 5. feladat
echo "5. feladat\n";

foreach ($szamok as $szam)
{
    if ($szam%2 == 0)
    {
        echo "{$szam}\n";
    }
}
echo "\n";

// 6. feladat
echo "6. feladat\n";

for ($i = count($szamok) - 1; $i >= 0; $i--)
{
    echo "{$szamok[$i]}\n";
}
echo "\n";

// 7. feladat
echo "7. feladat\n";

$sum = 0;
for ($i = count($szamok) - 1; $i >= 0; $i--)
{
    $sum += $szamok[$i];
}
echo "{$sum}\n\n";

// 8. feladat
echo "8. feladat\n";

$avg = $sum/count($szamok);

echo "{$avg}\n";

?>