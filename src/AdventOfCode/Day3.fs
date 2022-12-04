namespace AdventOfCode
module Day3=
    
    let private char_to_score (char: char)=
        if System.Char.IsUpper char then
            (int char) - 38
        else 
            (int char) - 96

    let private split (str:string)=
        (str.Substring(0, str.Length/2),str.Substring(str.Length/2))

    let private to_arrays (tuple: string*string)=
        let (arr1, arr2) = tuple
        (arr1.ToCharArray(), arr2.ToCharArray())

    let private get_score (char)=
        char
        |> Array.map char_to_score
        |> Array.sum

    let private calculate = to_arrays >> Utils.get_items_in_both_collections >> get_score

    let private collect_3s (inputs: string[])=
        seq {
            for i in 0 .. 3 .. inputs.Length-3 do
                inputs
                |> Array.skip i
                |> Array.take 3
        }

    let private to_char_array (str:string)=
        str.ToCharArray()

    let private convert_to_arrays (arrays: string[])=
        arrays
        |> Array.map to_char_array

    let private get_unique_3s (chars: char[][])=
        Utils.get_items_in_both_collections ((Utils.get_items_in_both_collections (chars.[0], chars.[1])), chars.[2])

    let private calculate_3s = 
        convert_to_arrays 
        >> get_unique_3s 
        >> get_score
        
    let solve_part_1 (input: string) =
        input
        |> Utils.split_complete [|'\r';'\n'|]
        |> Array.map split
        |> Array.map calculate
        |> Array.sum

    let solve_part_2 (input: string)=
        input
        |> Utils.split_complete [|'\r';'\n'|]
        |> collect_3s
        |> Seq.map calculate_3s
        |> Seq.sum

