namespace AdventOfCode

open Utils

module Day1=
    let private collect (list: int list) (item: int option)=
        match list with
        | head :: tail -> 
            match item with
            | None -> 0::list
            | Some num -> (head + num)::tail
        | [] -> 
            match item with
            | None -> list
            | Some num -> [num]

    let private get_value (item: int)=
        item

    let private get_calorie_list (input: string)=
        input
        |> Utils.split [|'\n'|]
        |> Array.map Utils.try_convert
        |> Array.fold collect List.empty
        |> List.sortByDescending get_value

    let solve_day_1_part_1 (input: string)=
        let list = get_calorie_list input
        list.Head

    let solve_day_1_part_2 (input: string)=
        (get_calorie_list input)
        |> List.take 3
        |>List.sum  
