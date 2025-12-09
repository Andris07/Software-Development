<?php

declare(strict_types=1);

include("./src/Culture/Movie/Quotation.php");

use Culture\Movie\Quotation as Quotation;

$quotation1 = new Quotation
(
    "Az Erő legyen veled.",
    "Obi-Wan Kenobi",
    "Csillagok háborúja",
);
$quotation2 = new Quotation
(
    "Az új magyar narancs. Kicsit sárgább, kicsit savanyúbb, de a mienk!",
    "Pelikán",
    "A tanú",
);
$quotation3 = new Quotation
(
    "Tigris van a fürdőszobában!",
    "Stu Price",
    "Másnaposok",
);

$quotations =
[
    1 => $quotation1,
    2 => $quotation2,
    3 => $quotation3,
];

for ($i = 1; $i <= count($quotations); $i++)
{
    $quotation = $quotations[$i] -> getText();
    $nameAndMovie = $quotations[$i] -> getPerson() . " - ". $quotations[$i] -> getTitle();
    echo "$quotation\n";
    echo "$nameAndMovie\n\n";
}

?>