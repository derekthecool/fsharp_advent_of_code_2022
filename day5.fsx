open System
open System.Text.RegularExpressions

#load "helper.fsx"
open Helper

let allLines = getLinesFromFileByDayNumber 5
let boxLineCount = 8
let boxLines = allLines |> Seq.take boxLineCount
let actionLines = allLines |> Seq.skip (boxLineCount + 2) // Skip the number line and the blank line

let parseCrateLine line =
    line |> Seq.chunkBySize 4 |> Seq.map (fun items -> items |> Seq.item 1)

let rowParsedBoxData = boxLines |> Seq.map parseCrateLine
// Visualize all crate data
rowParsedBoxData |> Seq.iter (fun X -> printfn "%s" (String.Join(" ", X)))
