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
        if ($operator === "+")
        {
            $result = $a + $b;

            return response() -> json([
                "data" =>
                [
                    "title" => "Összeadás",
                    "a" => $a,
                    "b" => $b,
                    "result" => $result,
                ]
            ]);
        }
        elseif ($operator === "-")
        {
            $result = $a - $b;
            
            return response() -> json([
                "data" =>
                [
                    "title" => "Kivonás",
                    "a" => $a,
                    "b" => $b,
                    "result" => $result,
                ]
            ]);
        }
        elseif ($operator === "*")
        {
            $result = $a * $b;
            
            return response() -> json([
                "data" =>
                [
                    "title" => "Szorzás",
                    "a" => $a,
                    "b" => $b,
                    "result" => $result,
                ]
            ]);
        }
        else
        {
            $result = $a / $b;
            
            return response() -> json([
                "data" =>
                [
                    "title" => "Osztás",
                    "a" => $a,
                    "b" => $b,
                    "result" => $result,
                ]
            ]);
        }
    }
}
