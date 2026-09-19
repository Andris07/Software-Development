<?php

namespace App\Http\Controllers;

use DateTime;
use DateInterval;
use Illuminate\Http\Request;

class CalendarController extends Controller
{
    protected $weekdays =
    [
        1 => "hétfő",
        2 => "kedd",
        3 => "szerda",
        4 => "csütörtök",
        5 => "péntek",
        6 => "szombat",
        7 => "vasárnap",
    ];

    public function weekdayName(int $num)
    {
        return
        [
            "data" =>
            [
                "data" => $this -> weekdays[$num]
            ]
        ];
    }

    public function weekdayNumber(string $str)
    {
        if (!in_array($str, $this -> weekdays))
        {
            return ["error" => "Ismeretlen nap!"];
        }
        
        return
        [
            "data" => array_search($str, $this -> weekdays)
        ];
    }

    public function today()
    {
        $currentDate = new DateTime();

        return
        [
            "data" =>
            [
                "title" => "Ma",
                "date" => $currentDate -> format('Y-m-d')
            ]
        ];
    }

    public function yesterday()
    {
        $currentDate = new DateTime();
        $yesterday = $currentDate -> sub(new DateInterval("P1D"));

        return
        [
            "data" =>
            [
                "title" => "Tegnap",
                "date" => $yesterday -> format('Y-m-d')
            ]
        ];
    }

    public function tomorrow()
    {
        $currentDate = new DateTime();
        $tomorrow = $currentDate -> add(new DateInterval("P1D"));

        return
        [
            "data" =>
            [
                "title" => "Holnap",
                "date" => $tomorrow -> format('Y-m-d')
            ]
        ];
    }
}
