(*
#load "helper.fsx"
open Helper

let allLines = getLinesFromFileByDayNumber 5
let boxLineCount = 8
let boxLines = allLines |> Seq.toList |> List.take boxLineCount
// let actionLines = allLines |> Seq.toList |> List.skip (boxLineCount + 2) // Skip the number line and the blank line

/// All the regex or other splitting options I tried were far too long and ugly
/// this is an easy method that is nicer to read. And readable code is good!
let parseCrateLine (line: string) =
    line
    |> Seq.toList
    |> List.chunkBySize 4
    |> List.map (fun items -> items |> List.item 1)

/// I found a helpful transpose function from stack overflow
/// Trying to create my own failed pretty bad. I am still trying to wrap my head
/// around these recursive list building functions.
/// https://stackoverflow.com/a/43287398/9842112
let rec transpose matrix =
    match matrix with
    | [] :: _ -> []
    | _ -> List.map List.head matrix :: transpose (List.map List.tail matrix)

let rowParsedBoxData = boxLines |> List.map parseCrateLine

let test = [ [ 1..3 ]; [ 3..6 ]; [ 6..9 ] ]

transpose test |> List.iter (printfn "%A")

let columnParsedBoxData =
    transpose rowParsedBoxData
    |> List.map (fun X -> X |> List.filter (fun items -> items <> ' '))
*)

(*
I tried lots of things but this problem was too tough for me so I looked to
GitHub for help.
https://github.com/shinpou/aoc2022/blob/75c22476fe15e757b6cb5cf8d4f80d5aa3e43d56/day05.fsx
*)


open System.IO
open System.Linq
open System.Text.RegularExpressions
open System
open System.Collections.Generic

let input = File.ReadAllLines("./data/day5.txt");

let startingBuckets = input |> Array.take 9

let instructions =
    input
    |> Array.skip 10 |> Array.map (fun s ->
        s.Split([| "move "; " from "; " to " |], StringSplitOptions.RemoveEmptyEntries)
        |> Array.map (int >> fun s -> s - 1))

let buckets =
    [| 1..4 .. 4 * 9 |]
    |> Array.map (
        (fun column -> [| 0 .. 8 |] |> Array.map (fun i -> startingBuckets[i][column])) >> Array.where Char.IsUpper
    )

let runCrateMover900 =
    instructions
    |> Array.fold (fun (acc: char[][]) ([| amount; from; target |]) ->
        let targetNewLine = Array.concat [| acc[from][0..amount] |> Array.rev; acc[target] |] // Remove rev for answer 2
        let sourceNewLine = acc[from][amount + 1 .. acc[from].Length]
        let midState = Array.updateAt from sourceNewLine acc
        Array.updateAt target targetNewLine midState) buckets
    |>  Array.map (Array.head) |> String |> printfn "Answer 1: %s"
