<?php

require_once ("adatok.php");

if ($argc > 2)
{
    echo "Túl sok paraméter!\n";
    exit(1);
}
else if ($argc == 1)
{
    for ($i = 0; $i < count($versenyzok); $i++)
    {
        echo strtoupper(explode(" ", $versenyzok[$i][2])[1]) . " (" . $versenyzok[$i][1] . ")" . " [" . $versenyzok[$i][0] . "]" . "\n";
    }
}
else if ($argv[1] == "vb")
{
    echo vb() . "\n";
}
else if
(is_numeric($argv[1]))
{
    echo dobogo($argv[1]) . "\n";
}
else
{
    echo "Ismeretlen paraméter!\n";
    exit(3);
} 

function dobogo($rajtszam)
{
    global $versenyzok;

    foreach ($versenyzok as $versenyzo)
    {
        if ($versenyzo[1] == $rajtszam)
        {
            return $versenyzo[4];
        }
    }
    return null;
}

function vb()
{
    global $versenyzok;

    $osszvb = 0;

    foreach ($versenyzok as $versenyzo)
    {
        $osszvb += $versenyzo[5];
    }
    return $osszvb;
}

#docker build -f f1.Dockerfile -t lag/f1 .

?>