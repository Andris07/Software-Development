<?php

namespace Acme\Kozlekedes;

class Jarmu
{
    protected string $gyarto;
    protected string $tipus;
    protected string $szin;

    protected function __construct(string $gyarto, string $tipus, string $szin)
    {
        $this -> gyarto = $gyarto;
        $this -> tipus = $tipus;
        $this -> szin = $szin;
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