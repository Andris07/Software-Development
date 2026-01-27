<?php

declare(strict_types=1);

require_once 'adatok.php';

function atlagSebesseg(string $tarsasag, array $vonatok2): float
{
    $osszeg = 0;
    foreach ($vonatok2[$tarsasag] as $vonat)
    {
        $osszeg += $vonat['sebesseg'];
    }
    return $osszeg / count($vonatok2[$tarsasag]);
}

function osztalyAr(array $vonatok2, string $osztaly): int
{
    $osszeg = 0;

    foreach ($vonatok2 as $tarsasag => $vonatok)
    {
        foreach ($vonatok as $vonat)
        {
            if ($vonat['osztaly'] === $osztaly)
            {
                $osszeg += $vonat['ar'];
            }
        }
    }
    return $osszeg;
}

if ($argc >= 3 && strtolower($argv[1]) === "atlag")
{
    echo (int)atlagSebesseg($argv[2], $vonatok2) . "\n";
    exit(0);
}
#docker build -t lag/statisztika -f statisztika.Dockerfile .
#docker run lag/statisztika atlag ÖBB
?>