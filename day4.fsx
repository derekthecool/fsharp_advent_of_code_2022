open System.Text.RegularExpressions
#load "helper.fsx"
open Helper

let lines = getLinesFromFileByDayNumber 4

let getSequencePairs input =
    let matches = Regex.Match(input, @"(\d+)-(\d+),(\d+)-(\d+)")

    [ set [ (int matches.Groups[1].Value) .. (int matches.Groups[2].Value) ]
      set [ (int matches.Groups[3].Value) .. (int matches.Groups[4].Value) ] ]

let isAnyASubsetOfAny (input: list<Set<int>>) =
    let first = input[0]
    let second = input[1]
    let firstCheck = Set.isSubset first second
    let secondCheck = Set.isSubset second first
    firstCheck || secondCheck

let A = set [ 1..5 ]
let B = set [ 4..5 ]
printfn "Testing function isAnyASubsetOfAny with test datasets A and B. Result is :%b" (isAnyASubsetOfAny [ A; B ])

print_advent_information 4 1

lines
|> Seq.map getSequencePairs
|> Seq.map isAnyASubsetOfAny
|> Seq.sumBy (fun boolSum -> if boolSum = true then 1 else 0)
|> printfn "Amount of ranges that our full subsets of the other: %d"

printfn "\nSanity check on input data. Maximum value : %d, Minimum value : 0\n" (lines |> Seq.length)

let doAnyOverlap (input: list<Set<int>>) =
    let first = input[0]
    let second = input[1]
    Set.intersect first second

print_advent_information 4 2

lines
|> Seq.map getSequencePairs
|> Seq.map doAnyOverlap
|> Seq.sumBy (fun X -> if Set.isEmpty X then 0 else 1)
|> printfn "Amount of ranges that have any over lap: %d"
