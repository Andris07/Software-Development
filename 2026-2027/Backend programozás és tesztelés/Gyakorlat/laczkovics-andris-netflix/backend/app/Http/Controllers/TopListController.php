<?php

namespace App\Http\Controllers;

use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Psy\Util\Json;

class TopListController extends Controller
{
    public function index(): JsonResponse
    {
        $queryBuilder = DB::table("toplist");

        return response() -> json([
            "data" => $queryBuilder -> get(),
        ]);
    }

    public function categories(): JsonResponse
    {
        $queryBuilder = DB::table("toplist")
                        -> distinct();

        return response() -> json([
            "data" => $queryBuilder -> pluck("category"),
        ]);
    }

    public function films(): JsonResponse
    {
        $queryBuilder = DB::table("toplist")
                        -> where("category", "like", "Films%");

        return response() -> json([
            "data" => $queryBuilder -> get(),
        ]);
    }

    public function tvs(): JsonResponse
    {
        $queryBuilder = DB::table("toplist")
                        -> where("category", "like", "TV%");

        return response() -> json([
            "data" => $queryBuilder -> get(),
        ]);
    }

    public function popular(): JsonResponse
    {
        $queryBuilder = DB::table("toplist")
                        -> where("cumulative_weeks_in_top_ten", ">=", "23")
                        -> orwhere("weekly_hours_viewed", ">=", "158680000")
                        -> orderBy("weekly_hours_viewed", "desc");

        return response() -> json([
            "data" => $queryBuilder -> get(),
        ]);
    }

    public function week(Request $request, string $week): JsonResponse
    {
        $queryBuilder = DB::table("toplist")
                        -> where("week", "=", $week)
                        -> limit(10);
        
        $orderBy = $request -> query("order_by");

        if ($orderBy === "category")
        {
            $queryBuilder -> orderBy("category", "asc");
        }
        elseif ($orderBy === "weekly_rank")
        {
            $queryBuilder -> orderBy("weekly_rank", "asc");
        }
        elseif ($orderBy === "weekly_hours_viewed")
        {
            $queryBuilder -> orderBy("weekly_hours_viewed", "desc");
        }

        return response() -> json([
            "data" =>
            [
                "week" => $week,
                "items" => $queryBuilder -> get(),
            ],
        ]);
    }

    public function top1(Request $request, string $week): JsonResponse
    {
        $queryBuilder = DB::table("toplist")
                        -> where("category", "=", "TV (English)")
                        -> where("week", "=", $week)
                        -> where("weekly_rank", "=", "1");

        return response() -> json([
            "data" =>
            [
                "week" => $week,
                "items" => $queryBuilder -> value("show_title"),
            ],
        ]);
    }
}
