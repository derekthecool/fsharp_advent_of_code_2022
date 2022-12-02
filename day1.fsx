open System
open System.IO

let lines = File.ReadAllLines("./data/day1_data.txt")

String.Join(" ", lines).Split("  ")
|>Seq.map(fun text -> text.Split() |> Seq.map int |> Seq.sum)
|>Seq.max
|>printfn "The total calories of the elf with the most food is: %d"
