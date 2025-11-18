<?php

require_once("en.php");

$en["jelszo"] = "alma1234";
$en["titok"] = "Az alma finom.";

if ($argc != 2)
{
    echo "A szkript pontosan 1 paramétert vár!\n";
    exit(1);
}
else if ($argv[1] == "nev" || $argv[1] == "szuletesi_datum" || $argv[1] == "kor" || $argv[1] == "kedvenc_szin")
{
    echo "{$en[$argv[1]]}\n";
}
else if ($argv[1] == $en["jelszo"])
{
    echo "{$en["titok"]}\n";
}
else
{
    echo "Ismeretlen paraméter!\n";
    exit(2);
}

//docker build -f en.Dockerfile -t lag/bemutato
?>