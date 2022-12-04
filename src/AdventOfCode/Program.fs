namespace AdventOfCode
module Program=
    [<EntryPoint>]
    let main argv =
        Utils.get_input_string 1
        |> Day1.solve_day_1_part_1
        |> printfn "day1 part 1: %d"
    
        Utils.get_input_string 1
        |> Day1.solve_day_1_part_2
        |> printfn "day1 part 2: %d"
    
        Utils.get_input_string 2
        |> Day2.solve_day_2_part_1
        |> printfn "day 2 part 1: %d"

        Utils.get_input_string 2
        |> Day2.solve_day_2_part_2
        |> printfn "day 2 part 2: %d"

        Utils.get_input_string 3
        |> Day3.solve_part_1
        |> printfn "day 3 part 1: %d"

        Utils.get_input_string 3
        |> Day3.solve_part_2
        |> printfn "day 3 part 2: %d"

        Utils.get_input_string 4
        |> Day4.solve_part_1
        |> printfn "day 4 part 1: %d"
    
        System.Console.Read |> ignore
        0