open System
open System.IO

let print_advent_information day part =
    printfn "\n\nAdvent of code day %d, part %d results" day part

let lines = File.ReadLines("./data/day2.txt")


let rockPaperScissors A (B:string) =
    let BB = B.Replace("X","A").Replace("Y","B").Replace("Z","C")
    let check = if A = BB then 3
                elif (A = "A" && BB = "B") || (A = "B" && BB = "C") || (A = "C" && BB = "A") then 6
                else 0
    let extraPoints = match BB with
                      | "A" -> 1
                      | "B" -> 2
                      | "C" -> 3
                      | _ -> 0
    check + extraPoints

print_advent_information 2 1

lines
|>Seq.map(fun line -> line.Split())
|>Seq.map(fun x -> rockPaperScissors x[0] x[1])
// |>Seq.iter(printfn "%A")
|> Seq.sum
|>printfn "%A"

let maximumLength = 9 * (lines |> Seq.length)
let minimumLength = 1 * (lines |> Seq.length)
printfn "Sanity check: maximum possible value: %d, minimum possible value: %d" maximumLength minimumLength


print_advent_information 2 1
