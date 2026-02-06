<?php

declare(strict_types=1);

namespace Neu\Eszkozok;

use Exception;

class Nyomtato
{
    protected string $gyarto;
    protected string $tipus;
    protected bool $szines;
    protected int $ar;

    private static $gyartok =
    [
        "HP",
        "Canon",
        "Xerox",
        "Epson",
    ];

    public function __construct(string $gyarto, string $tipus, bool $szines, int $ar)
    {
        $this -> gyarto = $gyarto;
        $this -> tipus = $tipus;
        $this -> szines = $szines;
        $this -> ar = $ar;
    }

    public static function getGyartok() : array
    {
        return self :: $gyartok;
    }

    public function __get(string $tulajdonsag) : mixed
    {
        if (in_array($tulajdonsag, array_keys(get_object_vars($this))))
        {
            return $this -> $tulajdonsag;
        }
        throw new Exception("Nem olvasható a tulajdonság\n");
    }
}

?>