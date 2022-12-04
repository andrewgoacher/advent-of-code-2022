namespace AdventOfCode

open System

module Day4=

    type Pairing = {start:int;end':int}

    let private get_pairings (input:string)=
        let pairings = 
            input    
            |> Utils.split_complete [|','|]

        (pairings.[0], pairings.[1])

    let private expand_pairing (pairing:string)=
        let pair = 
            pairing
            |> Utils.split_complete [|'-'|]

        (pair.[0], pair.[1])

    let private convert_pairings (input:string*string)=
        let (start,end') = input
        {start=Convert.ToInt32 start; end'= Convert.ToInt32 end'}

    let private create_pairing = expand_pairing >> convert_pairings
        
    let private collect_pairings (input:string) =
        let (first, second) = get_pairings input
        (create_pairing first, create_pairing second)

    let private chores_completely_overlap (input:Pairing*Pairing)=
        let (first, second) = input
        match (first, second) with
        | (f, s) when f.start <= s.start && f.end' >= s.end' -> true
        | (f, s) when f.start >= s.start && f.end' <= s.end' -> true
        | _ -> false

    let expand pairing=
        [|pairing.start .. pairing.end'|]            

    let private chores_overlap (input:Pairing*Pairing)=
        let (first, second) = input
        let first = expand first
        let second = expand second

        let input = (first, second)

        let number_of_items=
            Utils.get_items_in_both_collections input
            |> Array.length

        number_of_items > 0

    let solve_part_1 (input:string)=
        input
        |> Utils.split_complete [|'\r';'\n'|]
        |> Array.filter (collect_pairings >> chores_completely_overlap)
        |> Array.length

    let solve_part_2 (input: string)=
        input
        |> Utils.split_complete [|'\r';'\n'|]
        |> Array.filter (collect_pairings >> chores_overlap)
        |> Array.length

