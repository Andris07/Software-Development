<?php

use App\Http\Controllers\ItemController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');
*/

Route::get("items", [ItemController::class, "index"]) -> name("items.index");

Route::get("items/{id}", [ItemController::class, "show"]) -> whereNumber("id") -> name("items.show");

Route::get("items/expensive", [ItemController::class, "expensive"]) -> name("items.expensive");

Route::get("items/sum", [ItemController::class, "sum"]) -> name("items.sum");

Route::get("items/recommended", [ItemController::class, "recommended"]) -> name("items.recommended");

Route::get("items/event/{event}", [ItemController::class, "event"]) -> whereAlpha("event") -> name("items.event");
