<?php

declare(strict_types=1);

namespace Universe\Entities;

class Superhero
{
    private string $name;
    private int $age;
    private array $superpowers;

    public function __construct(string $name, int $age, array $superpowers)
    {
        $this -> name = $name;
        $this -> age = $age;
        $this -> superpowers = $superpowers;
    }

    public function getName() : string
    {
        return $this -> name;
    }

    public function setName($name) : void
    {
        $this -> name = $name;
    }

    public function getAge() : int
    {
        return $this -> age;
    }

    public function setAge($age) : void
    {
        $this -> name = $name;
    }

    public function getSuperpowers() : array
    {
        return $this -> superpowers;
    }
    
    public function setSuperpowers($superpowers) : void
    {
        $this -> superpowers = $superpowers;
    }
}

?>