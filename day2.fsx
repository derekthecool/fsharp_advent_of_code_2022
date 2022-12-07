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

let rockPaperScissors2 A (B:string) =
    // Convert XYZ to ABC
    let BB = B.Replace("X","A").Replace("Y","B").Replace("Z","C")
    let check = match BB with
                | "A" -> 0
                | "B" -> 3
                | "C" -> 6
                | _ -> 0

    /// rock = A = 1 point
    /// paper = B = 2 points
    /// scissors = C = 3 points
    let newScore = 
        if BB = "A" then // need to lose
            if A = "A" then // enemy uses rock
                3 // need to use scissors to lose to rock
            elif A = "B" then // emmy uses paper
                1 // need to use rock to lose
            else // enemy uses scissors
                2 // need to use paper to lose
        elif BB = "B" then // need to tie
            if A = "A" then // enemy uses rock
                1 // rock to rock
            elif A = "B" then
                2 // paper to paper
            else
                3 // scissors to scissors
        else  // need to win
            if A = "A" then // enemy uses rock
                2 // use paper to win rock
            elif A = "B" then // enemy uses paper
                3 // use scissors to beat paper
            else //// enemy uses scissors
                1 // use rock to beat scissors
    check + newScore


lines
|>Seq.map(fun line -> line.Split())
|>Seq.map(fun x -> rockPaperScissors2 x[0] x[1])
// |>Seq.iter(printfn "%A")
|> Seq.sum
|>printfn "%A"

//First attempt I guessed 13326 : feedback was that the number was too high
