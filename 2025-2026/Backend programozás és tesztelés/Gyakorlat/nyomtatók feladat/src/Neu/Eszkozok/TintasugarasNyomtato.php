<?php

declare(strict_types=1);

namespace Neu\Eszkozok;

use Exception;
use Stringable;

class TintasugarasNyomtato extends Nyomtato implements Stringable
{
    protected int $patronokSzama;

    public function __construct(string $gyarto, string $tipus, bool $szines, int $ar, int $patronokSzama)
    {
        parent::__construct($gyarto, $tipus, $szines, $ar);
        $this -> patronokSzama = $patronokSzama;
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
        return $this -> gyarto . " " . $this -> tipus . " " . ($this -> szines ? "színes" : "fekete-fehér") . " " . "tintasugaras nyomtató " . " (" . $this -> patronokSzama . " patron) " . " " . $this -> ar . " Ft";
    }

    public function __toArray() : array
    {
        return [$this -> gyarto, $this -> tipus, ($this -> szines ? "színes" : "fekete-fehér"), $this -> patronokSzama, $this -> ar];
    }
}

?>