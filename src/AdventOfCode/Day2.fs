namespace AdventOfCode

open Utils

module Day2=

    type RPS=
    | Rock 
    | Paper
    | Scissors

    type Success=
    | Win
    | Lose
    | Draw

    let private get_rps = function
    | "A" | "X" -> Some RPS.Rock
    | "B" | "Y" -> Some RPS.Paper
    | "C" | "Z" -> Some RPS.Scissors
    | _ -> None

    let private get_success_type = function
    | "X" -> Some Success.Lose
    | "Y" -> Some Success.Draw
    | "Z" -> Some Success.Win
    | _ -> None

    let private score_rps = function
    | RPS.Rock -> 1
    | RPS.Paper -> 2
    | RPS.Scissors -> 3

    let private score_success=function
    | Success.Win -> 6
    | Success.Draw -> 3
    | Success.Lose -> 0

    let private get_inputs (input: string list)=
        match input with
        | first :: second :: _ -> 
            match get_rps first with
            | None -> None
            | Some f -> 
                match get_rps second with
                | None -> None
                | Some s -> Some (f, s)
        | [] -> None
        | _ -> None

    let private get_win_move = function
    | None -> None
    | Some RPS.Rock -> Some (RPS.Rock, RPS.Paper)
    | Some RPS.Paper -> Some (RPS.Paper, RPS.Scissors)
    | Some RPS.Scissors -> Some (RPS.Scissors, RPS.Rock)

    let private get_draw_move = function
    | None -> None
    | Some x -> Some (x, x)

    let private get_lose_move = function
    | None -> None
    | Some RPS.Rock -> Some (RPS.Rock,  RPS.Scissors)
    | Some RPS.Paper -> Some (RPS.Paper, RPS.Rock)
    | Some RPS.Scissors -> Some (RPS.Scissors, RPS.Paper)

    let private calculate_rps=function
    | first :: second :: _-> 
        let first = get_rps first
        match get_success_type second with
        | None -> None
        | Some (Success.Win) -> get_win_move first
        | Some (Success.Draw) -> get_draw_move first
        | Some (Success.Lose) -> get_lose_move first
        
    | [] -> None
    | _ -> None


    let private get_success= function
    | None -> None
    | Some (a,b) when a = b -> Some (b, Success.Draw)
    | Some (RPS.Scissors, RPS.Paper) -> Some (RPS.Paper, Success.Lose)
    | Some (RPS.Paper, RPS.Rock) -> Some (RPS.Rock, Success.Lose)
    | Some (RPS.Rock, RPS.Scissors) -> Some (RPS.Scissors, Success.Lose)
    | Some (_, b) -> Some (b, Success.Win)

    let private get_score=function
    | None -> 0
    | Some(rps, succ) ->
        (score_rps rps) + (score_success succ)

    let private collect (input: string)=
        input
        |> split_complete [|' '|]
        |> Array.toList 

    let private play calculator= 
        collect 
        >> calculator 
        >> get_success 
        >> get_score

    let solve_day_2_part_1 (input: string)=
        input
        |> split_complete [|'\r'; '\n'|]
        |> Array.map (play get_inputs)
        |> Array.sum

    let solve_day_2_part_2 (input: string)=
        input
        |> split_complete [|'\r';'\n'|]
        |> Array.map (play calculate_rps)
        |> Array.sum

