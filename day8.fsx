open System

#load "helper.fsx"
open Helper

let lines = getLinesFromFileByDayNumber 8

let grid =
    lines
    |> Seq.map (fun X -> X |> Seq.map string |> Seq.map int |> Seq.toArray)
    |> Seq.toArray

let treesInForest = float (grid[0].Length) ** 2
let lengthOfForest = grid[0].Length
let perimeterCount = lengthOfForest * 4 - 4
let bottomRightCorner = grid[lengthOfForest - 1][lengthOfForest - 1]

printfn
    """Sanity check for question
    length of forest: %d
    trees in forest: %g
    perimeterCount: %d
    bottom bottomRightCorner tree: %d"""
    lengthOfForest
    treesInForest
    perimeterCount
    bottomRightCorner

let scanHorizontalByCoordinate (row: int array) (X: int) (Y: int) =
    // for i in row do


// scanHorizontalByCoordinate (grid[0]) 0 0
