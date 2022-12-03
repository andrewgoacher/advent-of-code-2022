namespace AdventOfCode

open System

module Utils=
    let split (chars: char[]) (input: string)=
        input.Split(chars, StringSplitOptions.None)

    let try_convert (input: string)=
        let str = input.Replace("\r", "").Replace("\n", "") 
        if String.IsNullOrEmpty(str) then
            None
        else
            str
            |> Convert.ToInt32 |> Some


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

    let solve_day_1 (input: string)=
        let list = 
            input
            |> Utils.split [|'\n'|]
            |> Array.map Utils.try_convert
            |> Array.fold collect List.empty
            |> List.sortByDescending get_value

        list.Head
