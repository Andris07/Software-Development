<?php

use App\Http\Controllers\StudentController;
use App\Http\Controllers\TabletController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get("tablets", [TabletController::class, "index"]) -> name("tablets.index");

Route::get("tablets/wifi", [TabletController::class, "wifi"]) -> name("tablets.wifi");

Route::get("tablets/cheap", [TabletController::class, "cheap"]) -> name("tablets.cheap");

Route::get("tablets/manufacturer/{manufacturer}", [TabletController::class, "manufacturer"]) -> whereAlpha("manufacturer") -> name("tablets.manufacturer");

Route::get("tablets/top5/{manufacturer}", [TabletController::class, "top5"]) -> whereAlpha("manufacturer") -> name("tablets.top5");

Route::get("tablets/apple/pro", [TabletController::class, "pro"]) -> name("tablets.pro");

Route::get("tablets/price/{min}/{max}", [TabletController::class, "price"]) -> whereNumber("min") -> whereNumber("max") -> name("tablets.price");

Route::get("tablets/better/{storage}/{memory}/{display}", [TabletController::class, "better"]) -> whereNumber("min") -> whereNumber("storage") -> whereNumber("memory") -> where("display", "[0-9]+(\.[0-9]+)?") -> name("tablets.better");

Route::get("students", [StudentController::class, "index"]) -> name("student.index");

// csak a swagger miatt nincs validálva a név, -> whereAlpha("username") lenne amúgy
Route::get("students/student/{username}", [StudentController::class, "student"]) -> name("student.student");

Route::get("students/class/{class}", [StudentController::class, "class"]) -> name("student.class");

Route::get("students/taller/{height}", [StudentController::class, "taller"]) -> whereNumber("height") -> name("student.taller");

Route::get("students/tallest", [StudentController::class, "tallest"])-> name("student.tallest");

Route::get("students/classes", [StudentController::class, "classes"]) -> name("student.classes");

Route::get("students/stat/{class}", [StudentController::class, "stat"]) -> whereAlphaNumeric("class") -> name("student.stat");

