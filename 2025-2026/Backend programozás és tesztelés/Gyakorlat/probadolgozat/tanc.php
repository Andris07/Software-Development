<?php

require_once("adatok.php");

if ($argc > 2)
{
    echo "Túl sok paraméter!\n";
    exit(4);
}
else if ($argc == 1)
{
    for ($i = 0; $i < count($adatok); $i += 2)
    {
        echo $parok[$i] . " - " . $parok[$i+1] . "\n";
    }
}

switch ($argv[1])
{
    case "fiuk":
    {
        for ($i = 1; $i < count($parok); $i+= 2)
        {
            echo "." . explode(" ", $parok[$i])[0] . "\n";
        }
        break;
    }
    case "lanyok":
    {
        $keresztnevek = [];

        for ($i = 0; $i < count($parok); $i += 2)
        {
            $keresztnevek[] = $explode(" ", $parok[$i])[1];
        }

        echo implode(", ", $keresztnevek) . "\n";
        break;
    }
    case "utolso":
    {
        echo $parok[count($parok - 2)] . " - " . $parok[count($parok - 1)] . "\n";
        break;
    }
    case "letszam":
    {
        echo (count($parok) / 2) . "\n";
        break;
    }
    default:
    {
        echo "Ismeretlen paraméter!\n";
        exit(3);
    }
}

//docker build -f .Dockerfile -t lag/tanc .

?>