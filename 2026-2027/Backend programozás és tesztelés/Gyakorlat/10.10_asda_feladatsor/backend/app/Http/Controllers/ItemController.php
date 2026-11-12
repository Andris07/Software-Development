<?php

namespace App\Http\Controllers;

use Illuminate\Http\JsonResponse;
use Illuminate\Support\Facades\DB;
use Illuminate\Http\Request;

class ItemController extends Controller
{
    public function index() : JsonResponse
    {
        $builder = DB::table("items");
        $items = $builder -> get();

        return response() -> json([
            "data" => $items
        ]);
    }

    public function show(int $id) : JsonResponse
    {
        $builder = DB::table(("items"));
        $item = $builder    -> get()
                            -> where("id","=",$id)
                            -> firstOrFail();

        return response() -> json([
            "data" => $item
        ]);
    }

    public function expensive() : JsonResponse
    {
        $builder = DB::table("items");
        $expensive = $builder
                                -> orderByDesc("price")
                                -> firstOrFail();

        return response() -> json([
            "data" => $expensive
        ]);
    }

    public function sum() : JsonResponse
    {
        $builder = DB::table("items");
        $sum = $builder
                        -> sum("price");

        return response() -> json([
            "data" => $sum
        ]);
    }

    public function recommended() : JsonResponse
    {
        $builder = DB::table("items");
        $recommended = $builder
                                -> whereNotNull("discount_price")
                                -> where("price",">","6")
                                -> pluck("name","id");

        return response() -> json([
            "data" => $recommended
        ]);
    }

    public function event(Request $request, string $event) : JsonResponse
    {
        $builder = DB::table("items");
        $event = $builder
                            -> where("event",$event);

        if ($request -> has("discounted") && $request -> query("discounted") === "yes")
        {
            $event -> whereNotNull("discount_price");
        }

        return response() -> json([
            "data" => $event -> get()
        ]);
    }
}
