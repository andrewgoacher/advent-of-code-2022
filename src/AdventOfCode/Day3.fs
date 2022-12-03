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

    let solve_part_2 (input: string)=
        0

