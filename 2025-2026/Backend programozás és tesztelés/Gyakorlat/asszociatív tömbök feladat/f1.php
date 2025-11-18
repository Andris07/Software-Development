<?php

require_once("versenyzok.php");

if ($argc>2)
{
    echo "Túl sok paraméter!\n";
    exit(8);
}
else if ($argc == 1)
{
    echo "rajtsz.\tNév\tOrszág\tSzületési dátum\n";

    for($i = 0; $i < count($versenyzok); $i++)
    {
        echo "{$versenyzok[$i]["rajtszam"]}\t{$versenyzok[$i]["nev"]}\t";
        echo "{$versenyzok[$i]["orszag"]}\t{$versenyzok[$i]["szulido"]}\n";
    }
}
else
{
    for($i = 0; $i < count($versenyzok); $i++)
    {
        if($versenyzok[$i]["orszag"] == $argv[1])
        {
            echo "- {$versenyzok[$i]["rajtszam"]} :";
            echo " {$versenyzok[$i]["nev"]}\n";
        }
    }
}

//docker build -f f1.Dockerfile -t lag/f1 .

?>