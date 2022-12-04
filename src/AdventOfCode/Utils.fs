namespace AdventOfCode

open System

module Utils=

    let split (chars: char[]) (input: string)=
        input.Trim().Split(chars, StringSplitOptions.None)

    let split_complete (chars: char[]) (input: string)=
        input.Trim().Split(chars, StringSplitOptions.RemoveEmptyEntries)

    let try_convert (input: string)=
        let str = input.Replace("\r", "").Replace("\n", "") 
        if String.IsNullOrEmpty(str) then
            None
        else
            str
            |> Convert.ToInt32 |> Some

    let get_input_string day =
        (sprintf "content/day%i.txt" day)
        |> System.IO.File.ReadAllText

    let private contains_item (array) (value)=
        array
        |> Array.contains value

    let get_items_in_both_collections (arrays)=
        let (arr1, arr2) = arrays
        let contains_item_1 = contains_item arr1
        arr2
        |> Array.filter contains_item_1
        |> Array.distinct
