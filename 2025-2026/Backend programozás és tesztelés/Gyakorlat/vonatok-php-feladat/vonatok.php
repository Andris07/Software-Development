<?php

declare(strict_types = 1);

require_once 'adatok.php';

if ($argc > 3)
{
    echo "Túl sok paraméter!\n";
    exit(9);
}

else if ($argc === 1)
{
    for($i = 0; $i < count($vonatok1); $i += 2)
    {
        echo "* " . $vonatok1[$i] . " " . $vonatok1[$i+1] . "\n";
    }
}

else if ($argc === 2 || $argc === 3)
{
    if ($argv[1] !== "jet" && $argv[1] !== "tarsasagok" && $argv[1] !== "darab" && $argv[1] !== "uj")
    {
        echo "Ismeretlen paraméter!\n";
        exit(3);
    }
    else
    {
        switch($argv[1])
        {
            case "jet":
                for($i = 0; $i <count($vonatok1); $i++)
                {
                    if (str_ends_with($vonatok1[$i],"jet"))
                    {
                        echo "- " . $vonatok1[$i] . "\n";
                    }
                }
                break;
            
            case "tarsasagok":
                $tarsasagok = [];

                for($i = 0; $i <count($vonatok1); $i++)
                {
                    if ($i%2 !==0 && !in_array($vonatok1[$i], $tarsasagok))
                    {
                        $tarsasagok[] = $vonatok1[$i];
                    }
                }
                echo implode("*",$tarsasagok) . "\n";
                break;
            
            case "darab":
                echo count($vonatok1) / 2 . "\n";
                break;
            
            case "uj":
                $bemenet = explode("+", $argv[2]);
                array_push($vonatok1, $bemenet[0], $bemenet[1]);
                for ($i = 0; $i < count($vonatok1); $i += 2)
                {
                    echo " " . $vonatok1[$i] . " " . $vonatok1[$i+1] . "\n";
                }
                break;
        }
    }
}
#docker build -f Dockerfile -t lag/vonatok .
#docker run lag/vonatok darab
?>