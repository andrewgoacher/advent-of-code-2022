namespace AdventOfCode
module Day3=
    
    let private char_to_score (char: char)=
        if System.Char.IsUpper char then
            (int char) - 38
        else 
            (int char) - 96

    let private split (str:string)=
        (str.Substring(0, str.Length/2),str.Substring(str.Length/2))

    let private contains_item (char) (value)=
        char
        |> Array.contains value

    let private get_unique (chars)=
        let (char1, char2) = chars
        let contains_char_1 = contains_item char1
        char2
        |> Array.filter contains_char_1
        |> Array.distinct

    let private to_arrays (tuple: string*string)=
        let (arr1, arr2) = tuple
        (arr1.ToCharArray(), arr2.ToCharArray())

    let private get_score (char)=
        char
        |> Array.map char_to_score
        |> Array.sum

    let private calculate = to_arrays >> get_unique >> get_score
        
    let solve_part_1 (input: string) =
        input
        |> Utils.split_complete [|'\r';'\n'|]
        |> Array.map split
        |> Array.map calculate
        |> Array.sum

    let private collect_3s (inputs: string[])=
        seq {
            for i in 0 .. 3 .. inputs.Length-3 do
                inputs
                |> Array.skip i
                |> Array.take 3
        }

    let private convert_to_arrays (arrays: string[])=
        arrays
        |> Array.map (fun str -> str.ToCharArray())

    let private get_unique_3s (chars: char[][])=
        get_unique ((get_unique (chars.[0], chars.[1])), chars.[2])

    let private calculate_3s = convert_to_arrays >> get_unique_3s >> get_score

    let solve_part_2 (input: string)=
        input
        |> Utils.split_complete [|'\r';'\n'|]
        |> collect_3s
        |> Seq.map calculate_3s
        |> Seq.sum

