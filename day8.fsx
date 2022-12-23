open System

#load "helper.fsx"
open Helper

let lines = getLinesFromFileByDayNumber 8

let gridMaker input =
    input
    |> Seq.map (fun X -> X |> Seq.map string |> Seq.map int |> Seq.toArray)
    |> Seq.toArray

let (practice: Collections.Generic.IEnumerable<string>) =
    [ "30373"; "25512"; "65332"; "33549"; "35390" ]

let smallPracticeGrid = gridMaker practice


let treeGrid = gridMaker lines

let treesInForest = float (treeGrid[0].Length) ** 2
let lengthOfForest = treeGrid[0].Length
let perimeterCount = lengthOfForest * 4 - 4
let bottomRightCorner = treeGrid[lengthOfForest - 1][lengthOfForest - 1]

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

let scanHorizontalByCoordinate (row: int array) =
    let doTheWork (inputArray: array<int>) =
        let mutable currentMaximum = 0

        for i = 0 to (inputArray.Length - 1) do
            if inputArray[i] > currentMaximum then
                currentMaximum <- inputArray[i]
                ()
            else
                inputArray[i] <- 0
                ()

        inputArray

    let A = Array.copy row
    let B = Array.copy row |> Array.rev
    let leftToRight = doTheWork A
    let rightToLeft = doTheWork B |> Array.rev

    leftToRight
    |> Array.zip rightToLeft
    |> Array.map (fun (x, y) -> if x <> 0 || y <> 0 then 1 else 0)

let scanVerticalColumns (input:array<array<int>>) =
    // let doTheWorkare
    let mutable currentMaximum = 0
    for column = 0 to (input.Length - 1) do
        for row = 0 to (input.Length - 1) do


scanHorizontalByCoordinate (treeGrid[0])
|> Array.sum
|> printfn "Sum of one row %A"
// scanHorizontalByCoordinate (smallPracticeGrid[0])

treeGrid
|> Array.map scanHorizontalByCoordinate
|> Array.map Array.sum
|> Array.sum

printfn "Check to see if treeGrid is destroyed by impure function: %A" treeGrid[0]
