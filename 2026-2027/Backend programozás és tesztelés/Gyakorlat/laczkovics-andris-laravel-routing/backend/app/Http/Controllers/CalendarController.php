<?php

namespace App\Http\Controllers;

use DateInterval;
use DateTime;
use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;

class CalendarController extends Controller
{
    protected $weekdays = ["hétfő", "kedd", "szerda", "csütörtök", "péntek", "szombat", "vasárnap"];

    public function today() : JsonResponse
    {
        $today = new DateTime();

        return response() -> json([
            "data" =>
            [
                "title" => "Ma",
                "date" => $today -> format("Y-m-d"),
            ]
        ]);
    }

    public function yesterday() : JsonResponse
    {
        $yesterday = new DateTime() -> sub(new DateInterval("P1D"));

        return response() -> json([
            "data" =>
            [
                "title" => "Tegnap",
                "date" => $yesterday -> format("Y-m-d"),
            ]
        ]);
    }

    public function tomorrow() : JsonResponse
    {
        $tomorrow = new DateTime() -> add(new DateInterval("P1D"));

        return response() -> json([
            "data" =>
            [
                "title" => "Holnap",
                "date" => $tomorrow -> format("Y-m-d"),
            ]
        ]);
    }

    public function weekdayName(int $number) : JsonResponse
    {
        if ($number < 1 || $number > 7)
        {
            return response() -> json([
                "error" => "A hét napjához adja meg a sorszámát (1 és 7 közötti szám)"
            ]);
        }
        return response() -> json([
            "data" => $this -> weekdays[$number-1]
        ]);
    }

    public function weekdayNumber(string $name) : JsonResponse
    {
        $index = array_search($name, $this -> weekdays);

        if ($index === false)
        {
            return response() -> json([
                "error" => "Ismeretlen nap!"
            ]);
        }

        return response() -> json([
            "data" => $index + 1
        ]);
    }
}
