<?php

// Ellenőrizzük, hogy van-e legalább egy paraméter
if ($argc < 2)
{
    echo "Túl kevés paraméter!\n";
    exit(1);
}

$hero = $argv[1];
$tars = $argc > 2 ? $argv[2] : null;

echo "2. feladat:\n";
echo "Hős neve: " . strtoupper($hero) . "\n";

echo "3. feladat:\n";
echo "hős karaktereinek a száma: " . strlen($hero) . "\n";

echo "4. feladat:\n";
if ($tars)
{
    echo "A hősnek van társa: $tars\n";
}
else
{
    echo "A hősnek nincs társa.\n";
}

echo "5. feladat:\n";
if (stripos($hero, "man") !== false)
{
    echo "A hős nevében szerepel a 'man' szó.\n";
}
else
{
    echo "A hős nevében nem szerepel a 'man' szó.\n";
}

echo "6. feladat:\n";
$reversed = strrev(strtolower($hero));
if (strtolower($hero) === $reversed) {
    echo "A hős neve palindrom szó.\n";
} else {
    echo "A hős neve NEM palindrom szó.\n";
}

echo "7. feladat:\n";
if (strtoupper($hero[0]) === 'S') {
    echo "A hős neve 'S' betűvel kezdődik.\n";
} else {
    echo "A hős neve nem 'S' betűvel kezdődik.\n";
}

echo "8. feladat:\n";
if (strtolower(substr($hero, -1)) === 'n')
{
    echo "A hős neve 'n' betűvel végződik.\n";
}
else
{
    echo "A hős neve nem 'n' betűvel végződik.\n";
}
?>