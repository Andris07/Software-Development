<?php

namespace App\Http\Controllers;

use Illuminate\Http\JsonResponse;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class StudentController extends Controller
{
    public function index() : JsonResponse
    {
        $builder = DB::table("students");
        $students = $builder -> get();

        return response() -> json([
            "data" => $students
        ]);
    }

    public function student(string $username) : JsonResponse
    {
        $builder = DB::table("students");
        $student = $builder -> get()
                            -> firstOrFail("username", $username);

        return response() -> json([
            "data" => $student
        ]);
    }

    public function class(string $class) : JsonResponse
    {
        $builder = DB::table("students");
        $students = $builder    -> get()
                                -> where("class", $class);

        return response() -> json([
            "data" => $students
        ]);
    }

    public function taller(int $height) : JsonResponse
    {
        $builder = DB::table("students");
        $students = $builder    -> get()
                                -> where("height", ">=", $height);

        return response() -> json([
            "data" => $students
        ]);
    }

    public function tallest() : JsonResponse
    {
        $builder = DB::table("students");
        $student = $builder
                            -> orderBy("height", "desc")
                            -> firstOrFail();

        return response() -> json([
            "data" => $student
        ]);
    }

    public function classes() : JsonResponse
    {
        $builder = DB::table("students");
        $classes = $builder
                            -> groupBy("class")
                            -> pluck("class");

        return response() -> json([
            "data" => $classes
        ]);
    }

    public function stat(string $class) : JsonResponse
    {
        $builder = DB::table("students");
        $class = $builder
                            -> where("class", $class)
                            -> get();

        return response() -> json([
            "data" =>
            [
                "average" => round($class -> avg("average"), 2),
                "size" => $class -> count()
            ]
        ]);
    }
}
