open System
open System.IO
open System.Linq

let print_advent_information day part =
    printfn "\n\nAdvent of code day %d, part %d results" day part

let lines = File.ReadLines("./data/day3.txt")

let letterIndexer letter =
    // Lowercase has priority from 1 to 26
    if Char.IsLower(letter) then
        (int letter) - (int 'a') + 1
    // Uppercase has priority from 27 to 52
    else
        (int letter) - (int 'A') + 27


print_advent_information 3 1

lines
|> Seq.map (Seq.splitInto 2)
|> Seq.map (fun items -> Set.intersect (set (items.First())) (set (items.Last())))
|> Seq.map (fun X -> X.First())
|> Seq.map letterIndexer
|> Seq.sum
|> printfn "%d"


print_advent_information 3 2

lines
|> Seq.chunkBySize 3
|> Seq.map (fun items -> items |> Seq.map Set |> Set.intersectMany |> Set.minElement)
|> Seq.map letterIndexer
|> Seq.sum
|> printfn "%d"
