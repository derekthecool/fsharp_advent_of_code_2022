open System
open System.IO

let lines = File.ReadAllLines("./data/day1_data.txt")

String.Join(" ", lines).Split("  ")
|>Seq.map(fun text -> text.Split() |> Seq.map int |> Seq.sum)
|>Seq.sortDescending
|>Seq.take 3
|>Seq.sum
|>printfn "The total sum of the calories of the top 3 elves is: %d"
