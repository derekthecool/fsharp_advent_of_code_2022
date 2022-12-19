open System.Text.RegularExpressions
#load "helper.fsx"
open Helper

let line = getLinesFromFileByDayNumber 6 |> Seq.head

print_advent_information 6 1

let StartOfPacketMarkerRegex =
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
    StartOfPacketMarkerRegex.Matches(line)
    |> Seq.head
    |> fun item -> item.Groups["FirstIndexAfterFour"].Index

printfn "Part 1 answer: firstSequenceOfFourDifferentLettersIndex: %A" firstSequenceOfFourDifferentLettersIndex

/// This regex uses many capture groups
/// Capture groups higher than 9 can be referenced in two ways with dotnet
/// regex engine
/// First: \10
/// Second: \k<10>
///
/// My example using this second method
/// ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\k<10>|\k<11>|\k<12>|\k<13>|\k<14>)\w)
///
/// credit to this website https://www.rexegg.com/regex-capture.html
/// I love the quote on their
///
/// "In practice, you rarely need to create
/// back-references to groups with numbers above 3 or 4, because when you need to
/// juggle many groups you tend to create named capture groups. However, if you
/// spend time in the smoky corridors of regex, at one time or another you're sure
/// to wonder what is the correct syntax to create back-references to Groups 10
/// and higher."
let StartOfMessageMarkerRegex =
    Regex(
        """
    # First letter, no restrictions
    (\w)

    # Next 13 letters check for totally unique group of 14 letters
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)
    ((?!\1|\2|\3|\4|\5|\6|\7|\8|\9|\10|\11|\12|\13|\14)\w)

    # Finally capture the first occurrance after 4 unique
    (?<FirstIndexAfter14>\w)
    """,
        RegexOptions.IgnorePatternWhitespace
    )

    // First guess of 2062 failed because I forgot the '|' on some groups
let firstSequenceOf14DifferentLettersIndex = 
    StartOfMessageMarkerRegex.Matches(line)
    |> Seq.head
    |> fun item -> item.Groups["FirstIndexAfter14"].Index
