open System.Text.RegularExpressions
open System.IO

// Again like day 6, I did not know where to start solving this with fsharp so I
// looked to GitHub
// thank you https://github.com/kimvais/AoC2022/blob/f1414de175b87af4b7deaa2b10ce1e14cd10ec1a/Day7.fs

let readLines filePath = File.ReadLines(filePath)

let getInputFilename s = "./data/day7.txt"

let readInput (s: string) = getInputFilename s |> readLines

let (|Regex|_|) pattern s =
    let m = Regex.Match(s, pattern)

    match m.Success with
    | false -> None
    | true -> Some(List.tail [ for g in m.Groups -> g.Value ])

let changeFunc num value =
    match value with
    | None -> Some(int64 num)
    | Some x -> Some(num + int64 x)

let parse (paths, dirs: Map<string list, int64>) line =
    match line with
    | Regex @"\$ cd \.\." [] -> List.tail paths, dirs
    | Regex @"\$ cd (.*)" [ dirName ] -> [ dirName ] @ paths, dirs
    | Regex @"([0-9]+) .*" [ fileSize ] ->
        let rec traverse (tail: string list) directories =
            match tail with
            | [] -> directories
            | _ :: t ->
                let newDirs = Map.change tail (changeFunc (int64 fileSize)) directories

                traverse t newDirs

        paths, traverse paths dirs
    | _ -> paths, dirs

let getDirectorySizes fn =
    readInput fn
    |> Seq.fold parse ([], Map.empty<string list, int64>)
    |> snd
    |> Map.values

let part1 fn () =
    getDirectorySizes fn |> Seq.filter ((>) 100000) |> Seq.sum

let part2 fn () =
    let dirSizes = getDirectorySizes fn
    let total = 70_000_000L
    let needed = 30_000_000L
    let toBeFreed = needed - (total - (Seq.max dirSizes))
    dirSizes |> Seq.filter ((<) toBeFreed) |> Seq.min

part1 "7" () |> printfn "github.com/kimvais/AoC2022 solution part 1: %A"
part2 "7" () |> printfn "github.com/kimvais/AoC2022 solution part 2: %A"
