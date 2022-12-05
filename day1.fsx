open System
open System.IO

let print_advent_information day part =
    printfn "\n\nAdvent of code day %d, part %d results" day part

let lines = File.ReadAllLines("./data/day1.txt")

print_advent_information 1 1

String.Join(" ", lines).Split("  ")
|> Seq.map (fun text -> text.Split() |> Seq.map int |> Seq.sum)
|> Seq.max
|> printfn "The total calories of the elf with the most food is: %d"

print_advent_information 1 2

String.Join(" ", lines).Split("  ")
|> Seq.map (fun text -> text.Split() |> Seq.map int |> Seq.sum)
|> Seq.sortDescending
|> Seq.take 3
|> Seq.sum
|> printfn "The total sum of the calories of the top 3 elves is: %d"
