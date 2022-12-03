module Tests

open System
open Xunit
open FsUnit
open AdventOfCode

[<Fact>]
let ``Day 1 Part 1: Elf with most calories`` () =
    let input = """
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
"""
    let result = Day1.solve_day_1 input
    result |> should equal 24000
