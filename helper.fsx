open System.IO
open System.Text.RegularExpressions

let print_advent_information day part =
    printfn "\n\nAdvent of code day %d, part %d results" day part

/// Simple function to read a text file from the advent of code input. Simply
/// just call the function with the number day you want.
let getLinesFromFileByDayNumber (dayNumber: int) =
    File.ReadLines($"./data/day{dayNumber}.txt")
