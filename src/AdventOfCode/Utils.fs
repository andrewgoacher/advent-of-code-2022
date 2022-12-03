namespace AdventOfCode

open System

module Utils=

    let split (chars: char[]) (input: string)=
        input.Split(chars, StringSplitOptions.None)

    let split_complete (chars: char[]) (input: string)=
        input.Split(chars, StringSplitOptions.RemoveEmptyEntries)

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
