<?php

require_once("jaratok.php");

if ($argc > 3)
{
    echo "Túl sok paraméter!\n";
    exit(4);
}
else if ($argc == 1)
{
    foreach ($jaratok as $jaratszam => $adatok)
    {
        echo "$jaratszam\t{$adatok["honnan"]}-{$adatok["hova"]}\t";
        echo "\t{$adatok["indul"]}-{$adatok["erkezik"]}\t{$adatok["legitarsasag"]}\n";
    }
}
else if ($argc == 2)
{
    $isfalse = true;

    foreach($jaratok as $jaratszam => $adatok)
    {
        if ($jaratszam == $argv[1])
        {
            $adatok = $jaratok[$jaratszam];
            echo "$jaratszam\t{$adatok["honnan"]}-{$adatok["hova"]}\t";
            echo "\t{$adatok["indul"]}-{$adatok["erkezik"]}\t{$adatok["legitarsasag"]}\n";
            $isfalse = false;
            break;
        }
    }
    if ($isfalse)
    {
        echo "A keresett járat {$argv[1]} nem található!\n";
        exit(7);
    }
}
else if ($argc == 3)
{
    $param = $argv[1];

    if("legitarsasag"==$param)
    {
        $keresettlegitarsasag = $argv[2];
        $sum = 0;

        foreach ($jaratok as $jaratszam => $adatok)
        {
            if ($keresettlegitarsasag == $adatok["legitarsasag"])
            {
                $sum++;
            }
        }
        echo "A(z) $keresettlegitarsasag légitársaságnak $sum járata van az adatok között.\n";
    }
    else if ("repter" == $param)
    {
        $keresettrepter = $argv[2];
        $sum = 0;

        foreach($jaratok as $jaratszam => $adatok)
        {
            if($keresettrepter == $adatok["honnan"] || $keresettrepter == $adatok["hova"])
            {
                $sum++;
            }
        }
        echo "A(z) $keresettrepter azonosítójú reptér {$sum}x szerepel az adatok között.\n";
    }
    else
    {
        echo "Ismeretlen paraméter '{$argv[1]}'\n";
    }
}

?>