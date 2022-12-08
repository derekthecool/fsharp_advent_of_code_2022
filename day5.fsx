#load "helper.fsx"
open Helper

let allLines = getLinesFromFileByDayNumber 5
let boxLineCount = 8
let boxLines = allLines |> Seq.toList |> List.take boxLineCount
let actionLines = allLines |> Seq.toList |> List.skip (boxLineCount + 2) // Skip the number line and the blank line

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

transpose rowParsedBoxData
