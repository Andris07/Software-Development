<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class CalculatorController extends Controller
{
    public function result(int $a, string $operator, int $b)
    {
        if ($operator === "/" && $b === 0)
        {
            abort(400);
        }

        else
        {
            $result = null;
            $title = null;

            switch ($operator)
            {
                case "+":
                    $title = "Összeadás";
                    $result = $a + $b;
                    break;
                case "-":
                    $title = "Kivonás";
                    $result = $a - $b;
                    break;
                case "*":
                    $title = "Szorzás";
                    $result = $a * $b;
                    break;
                case "/":
                    $title = "Osztás";
                    $result = $a / $b;
                    break;
            }

            return
            [
                "data" =>
                [
                    "title" => $title,
                    "a" => $a,
                    "b" => $b,
                    "result" => $result
                ]
            ];
        }
    }
}
