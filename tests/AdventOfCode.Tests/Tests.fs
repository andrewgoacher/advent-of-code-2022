module Tests

open System
open Xunit
open FsUnit
open AdventOfCode

module Inputs=
    let day1 = """
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

    let day2 = """
    A Y
B X
C Z
    """

    let day3="""
vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw
    """

    let day4 = """
    2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8
    """

[<Fact>]
let ``Day 1 Part 1: Elf with most calories`` () =

    let result = Day1.solve_day_1_part_1 Inputs.day1
    result |> should equal 24000

[<Fact>]
let ``Day 1 Part 2: Sum of top 3 calories`` ()=
    let result = Day1.solve_day_1_part_2 Inputs.day1
    result |> should equal 45000

[<Fact>]
let ``Day 2 Part 1: Calculated Score`` ()=
    (Day2.solve_day_2_part_1 Inputs.day2)
    |> should equal 15

[<Fact>]
let ``Day 2 Part 2: Calculated score``()=
    (Day2.solve_day_2_part_2 Inputs.day2)
    |> should equal 12

[<Fact>]
let ``Day 3 Part 1: Calculate priority``()=
    (Day3.solve_part_1 Inputs.day3)
    |> should equal 157

[<Fact>]
let ``Day 3 Part 2: Calculate priority``()=
    (Day3.solve_part_2 Inputs.day3)
    |> should equal 70

[<Fact>]
let ``Day 4 Part 1: Calculate number of duplicated jobs``()=
    (Day4.solve_part_1 Inputs.day4)
    |> should equal 2