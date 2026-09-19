<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class QuoteController extends Controller
{
    public function index()
    {
        return "Quotes";
    }

    public function house()
    {
        return
        [
            "data" =>
            [
                "title" => "House",
                "quote" => "Nemcsak az emberek megalázásával lehet a gőzt kiereszteni;...",
                "name" => "Dr. House"
            ]
        ];
    }

    public function modernFamily()
    {
        return
        [
            "data" =>
            [
                "title" => "Modern Család",
                "quote" => "A siker mindig 1 százalék ihlet, plusz 98 százalék...",
                "name" => "Phil Dunphy"
            ]
        ];
    }

    public function uvegtigrisCsoki()
    {
        return
        [
            "data" =>
            [
                "title" => "Üvegtigris",
                "quote" => "Mennyire vagy túsz? Sörhöz odaférsz?",
                "name" => "Csoki"
            ]
        ];
    }

    public function uvegtigrisLali()
    {
        return
        [
            "data" =>
            [
                "title" => "Üvegtigris",
                "quote" => "Az egybubis az egy kicsit drágább, mert hát...",
                "name" => "Lali"
            ]
        ];
    }

    public function harryPotter(string $slug)
    {
        if (!in_array($slug, ["fred-es-george", "hermione"]))
        {
            abort(404);
        }
        else
        {
            if ($slug === "fred-es-george")
            {
                return
                [
                    "data" =>
                    [
                        "title" => "Harry Potter",
                        "quote" => "- Mindig is tudtuk hol a határ- bólintott Fred- És csak...",
                        "name" => "Fred és George"
                    ]
                ];
            }
            else
            {
                return
                [
                    "data" =>
                    [
                        "title" => "Harry Potter",
                        "quote" => "Még egy ilyen remek ötlet, és mindhárman meghalunk, vagy...",
                        "name" => "Hermione"
                    ]
                ];
            }
        }
    }
}
