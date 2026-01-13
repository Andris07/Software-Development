<?php

namespace Acme\Frosty;

class IceCream implements \Stringable
{
  private int $scoop;
  private int $price;
  private bool $sweetCone;
  private array $flavours = [];

  public static array $availableFlavours =
  [
    "vanilla",
    "strawberry",
    "chocolate",
    "coconut",
  ];

  public function __construct(int $scoop, bool $sweetCone)
  {
    $this -> scoop = $scoop;
    $this -> sweetCone = $sweetCone;
    $this -> price = ($scoop * 400) + ($sweetCone ? 80 : 0);
  }

  public function __get(string $name) : mixed
  {
    if (property_exists($this, $name))
    {
      return $this -> $name;
    }
    return null;
  }

  public function __set(string $name, mixed $value) : void
  {
    if (!property_exists($this, $name))
    {
      return;
    }

    switch ($name)
    {
      case "scoop":
      {
        $this -> scoop = (int)$value;
        break;
      }
      case "flavours":
      {
        $this -> flavours = is_array($value) ? $value : [$value];
        break;
      }
      case "sweetCone":
      {
        $this -> sweetCone = (bool)$value;
        break;
      }
    }

    $this -> price = ($this -> scoop * 400) + ($this -> sweetCone ? 80 : 0);
  }

  public static function availableFlavours() : array
  {
    return self::$availableFlavours;
  }

  public function __toString() : string
  {
    $flavourText = "";
    if (!empty($this -> flavours))
    {
      $flavoursStrUpper = array_map("strtoupper", $this -> flavours);
      $flavourTypes = "[" . implode(", ", $flavoursStrUpper) . "]";
    }

    $coneType = $this -> sweetCone ? "édes tölcsérben" : "normál tölcsérben";
    return $this -> scoop . " gombócos fagylalt " . $this -> flavours . " ízekkel " . $this -> coneType . " ( " . $this -> price . " Ft)";
  }

  public function toArray(): array
  {
    $flavourText = "[" . implode(", ", array_map("strtoupper", $this->flavours)) . "]";
    $coneType = $this -> sweetCone ? "édes" : "normál";
    return [$this -> scoop, $flavourText, $coneType, $this -> price];
  }
}

?>