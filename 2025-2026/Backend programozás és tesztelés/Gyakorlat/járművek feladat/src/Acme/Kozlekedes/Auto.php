<?php

namespace Acme\Kozlekedes;

use Stringable;

class Auto extends Gepjarmu implements Stringable
{
    protected int $ajtok;

    public function __construct(string $gyarto, string $tipus, string $szin, string $motor, int $ajtok)
    {
        parent::__construct($gyarto, $tipus, $szin, $motor);
        $this -> ajtok = $ajtok;
    }

    public function __get(string $tulajdonsag) : mixed
    {
        if (in_array($tulajdonsag, array_keys(get_object_vars($this))))
        {
            return $this -> $tulajdonsag;
        }
        throw new Exception("Nem olvasható a tulajdonság\n");
    }

    public function __toString() : string
    {
        return '"' . $this -> gyarto . '", "' . $this -> tipus . '", "' . $this -> szin . '", "' . $this -> motor . '", "' . $this -> ajtok . '"';
    }
}

?>