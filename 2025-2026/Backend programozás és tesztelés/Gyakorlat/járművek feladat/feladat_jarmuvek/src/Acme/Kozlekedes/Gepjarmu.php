<?php

namespace Acme\Kozlekedes;

class Gepjarmu extends Jarmu
{
    protected string $motor;

    protected function __construct(string $gyarto, string $tipus, string $szin, string $motor)
    {
        parent::__construct($gyarto, $tipus, $szin);
        $this -> motor = $motor;
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