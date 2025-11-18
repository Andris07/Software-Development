<?php

declare(strict_types=1);

$vonatok1 =
[
    "IC",
    "MÁV",
    "Railjet",
    "ÖBB",
    "ICE",
    "DB",
    "Nightjet",
    "ÖBB",
];

$vonatok2 =
[
    "MÁV" =>
    [
        [
            "id" => 1,
            "tipus" => "IC",
            "sebesseg" => 160,
            "ferohely" => 300,
            "osztaly" => "2. osztály",
            "ar" => 5000
        ],
        [
            "id" => 2,
            "tipus" => "ICPlusz",
            "sebesseg" => 160,
            "ferohely" => 200,
            "osztaly" => "1. osztály",
            "ar" => 8000
        ],
    ],
    "ÖBB" =>
    [
        [
            "id" => 3,
            "tipus" => "Railjet",
            "sebesseg" => 230,
            "ferohely" => 400,
            "osztaly" => "2. osztály",
            "ar" => 10000
        ],
        [
            "id" => 4,
            "tipus" => "Nightjet",
            "sebesseg" => 200,
            "ferohely" => 300,
            "osztaly" => "1. osztály",
            "ar" => 12000
        ],
    ],
];

?>