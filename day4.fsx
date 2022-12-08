open System
open System.IO
open System.Text.RegularExpressions

let print_advent_information day part =
    printfn "\n\nAdvent of code day %d, part %d results" day part

let lines = File.ReadLines("./data/day4.txt")

let getSequencePairs input =
    let matches = Regex.Match(input, @"(\d+)-(\d+),(\d+)-(\d+)")

    [ set [ (int matches.Groups[1].Value) .. (int matches.Groups[2].Value) ]
      set [ (int matches.Groups[3].Value) .. (int matches.Groups[4].Value) ] ]

print_advent_information 4 1

lines |> Seq.map getSequencePairs |> Seq.iter (printfn "%A")
// |> Seq.iter (fun line -> printfn "%s" line.Groups[1].Value)

let A = set [ 1..5 ]
let B = set [ 4..5 ]

Set.isSubset B A |> printfn "The value is a subset: %b"


Set.isSubset A B |> printfn "The value is a subset: %b"
