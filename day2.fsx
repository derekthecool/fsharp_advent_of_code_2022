open System
open System.IO

let matcher input =
    match input with
    | 

File.ReadAllLines("./data/day2.txt")
|>Seq.map(fun line -> line.Split())
// |>Seq.iter(printfn "A")
|>printfn "%A"
