<?php

namespace App\Http\Controllers;

use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class TabletController extends Controller
{
    public function index() : JsonResponse
    {
        $builder = DB::table("tablets");
        $tablets = $builder -> get();

        return response() -> json([
            "data" => $tablets
        ]);
    }

    public function wifi() : JsonResponse
    {
        $builder = DB::table("tablets");
        $tablets = $builder -> get()
                            -> where("mobile_network", "Wi-Fi");

        return response() -> json([
            "data" => $tablets
        ]);
    }

    public function cheap() : JsonResponse
    {
        $builder = DB::table("tablets");
        $tablets = $builder
                            -> where("price", "<=", "150000")
                            -> get();

        return response() -> json([
            "data" => $tablets
        ]);
    }

    public function manufacturer(string $manufacturer) : JsonResponse
    {
        $builder = DB::table("tablets");
        $tablets = $builder
                            -> where("manufacturer", $manufacturer)
                            -> get();

        return response() -> json([
            "data" => $tablets
        ]);
    }

    public function top5(string $manufacturer) : JsonResponse
    {
        $builder = DB::table("tablets");
        $tablets = $builder
                            -> where("manufacturer", $manufacturer)
                            -> orderBy("price", "desc")
                            -> limit(5)
                            -> get();

        return response() -> json([
            "data" => $tablets
        ]);
    }

    public function pro() : JsonResponse
    {
        $builder = DB::table("tablets");
        $tablets = $builder
                            -> where("manufacturer", "Apple")
                            -> where("model", "like", "%air%")
                            -> orderBy("display_size", "desc")
                            -> orderBy("price", "asc")
                            -> get();

        return response() -> json([
            "data" => $tablets
        ]);
    }

    public function price(int $min, int $max) : JsonResponse
    {
        $builder = DB::table("tablets");
        $tablets = $builder
                            -> whereBetween("price", [$min, $max])
                            -> orderBy("price", "asc")
                            -> get();

        return response() -> json([
            "data" => $tablets
        ]);
    }

    public function better(int $storage, int $memory, string $display) : JsonResponse
    {
        $display = floatval($display);
        $builder = DB::table("tablets");
        $tablets = $builder
                            -> where("storage", ">=", $storage)
                            -> where("memory", ">=", $memory)
                            -> where("display_size", ">=", $display)
                            -> orderBy("price", "asc")
                            -> get();

        return response() -> json([
            "data" => $tablets
        ]);
    }
}
