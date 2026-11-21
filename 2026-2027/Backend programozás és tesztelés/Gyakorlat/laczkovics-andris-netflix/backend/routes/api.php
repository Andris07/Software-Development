<?php

use App\Http\Controllers\TopListController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get("/toplist", [TopListController::class, "index"]) -> name("toplist.index");
Route::get("/toplist/categories", [TopListController::class, "categories"]) -> name("toplist.categories");
Route::get("/toplist/films", [TopListController::class, "films"]) -> name("toplist.films");
Route::get("/toplist/tvs", [TopListController::class, "tvs"]) -> name("toplist.tvs");
Route::get("/toplist/popular", [TopListController::class, "popular"]) -> name("toplist.popular");
Route::get("/toplist/week/{week}", [TopListController::class, "week"]) -> where("week", "(?:19\d{2}|[2-9]\d{3})-(?:0[1-9]|1[0-2])-(?:0[1-9]|[12]\d|3[01])") -> name("toplist.week");
Route::get("/toplist/top1/{week}", [TopListController::class, "top1"]) -> where("week", "(?:19\d{2}|[2-9]\d{3})-(?:0[1-9]|1[0-2])-(?:0[1-9]|[12]\d|3[01])") -> name("toplist.top1");