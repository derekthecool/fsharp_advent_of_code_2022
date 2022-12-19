open System.Text.RegularExpressions
#load "helper.fsx"
open Helper

let lines = getLinesFromFileByDayNumber 6 |> Seq.head

print_advent_information 6 1

let WordMatcher =
    Regex(
        """
    (\w)                       # First char capture, no restrictions
    ((?!\1|\2|\3|\4)\w)        # second capture, must not equal any other capture group
                               # Checking for 4 letter uniqueness can be done
                               # with negative look ahead (?! ...) and inside
                               # that you can reference each capture group you
                               # don't want to match.
                               # Finally just capture the single letter after
                               # that check with the (\w)

    ((?!\1|\2|\3|\4)\w)        # Repeat exactly second capture

    ((?!\1|\2|\3|\4)\w)        # Again repeat second capture

    (?<FirstIndexAfterFour>\w) # Finally capture the first occurrance after four unique
    """,
        RegexOptions.IgnorePatternWhitespace
    )

let firstSequenceOfFourDifferentLettersIndex =
    WordMatcher.Matches(lines) |> Seq.head |> fun item ->
        item.Groups["FirstIndexAfterFour"].Index

printfn "firstSequenceOfFourDifferentLettersIndex: %A" firstSequenceOfFourDifferentLettersIndex
