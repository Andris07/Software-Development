<?php

namespace Acme\Kozlekedes;

use Stringable;

class Roller extends Jarmu implements Stringable
{
    protected int $kerekekSzama;

    public function __construct(string $gyarto, string $tipus, string $szin, int $kerekekSzama)
    {
        parent::__construct($gyarto, $tipus, $szin);
        $this -> kerekekSzama = $kerekekSzama;
    }

    public function __get(string $tulajdonsag) : mixed
    {
        if (in_array($tulajdonsag, array_keys(get_object_vars($this))))
        {
            return $this -> $tulajdonsag;
        }
        throw new Exception("Nem olvasható a tulajdonság\n");
    }

    public function __toString()
    {
        return '"' . $this -> gyarto . '","' . $this -> tipus . '","' . $this -> szin . '",' . $this -> kerekekSzama;
    }
}

?>