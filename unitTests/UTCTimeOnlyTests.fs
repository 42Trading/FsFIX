﻿module UTCTimeOnlyTests

open Xunit
open Swensen.Unquote



[<Fact>]
let ``write valid hhmmss to bytes`` () =
    let timeIn = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 59)
    let bs = Array.zeroCreate<byte> 8
    let posOut = UTCDateTime.writeUTCTimeOnly timeIn bs 0
    let expected = "23:59:59"B
    posOut =! 8
    expected =! bs


[<Fact>]
let ``write valid hhmmssNNN to bytes`` () =
    let timeIn = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 59, 123)
    let bs = Array.zeroCreate<byte> 12
    let posOut = UTCDateTime.writeUTCTimeOnly timeIn bs 0
    let expected = "23:59:59.123"B
    posOut =! 12
    expected =! bs


[<Fact>]
let ``read valid hhmmss from bytes`` () =
    let uto = UTCDateTime.readUTCTimeOnly "23:59:59"B 0 8
    let expected = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 59)
    expected =! uto



[<Fact>]
let ``read valid hhmmss midnight from bytes`` () =
    let uto = UTCDateTime.readUTCTimeOnly "00:00:00"B 0 8
    let expected = UTCDateTime.MakeUTCTimeOnly.Make (00, 00, 00)
    expected =! uto


[<Fact>]
let ``read valid leapsecond hhmmss from bytes`` () =
    let uto = UTCDateTime.readUTCTimeOnly "23:59:60"B 0 8
    let expected = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 60)
    expected =! uto


[<Fact>]
let ``read valid leapsecond hhmmssMMM from bytes`` () =
    let bs = "23:59:60.999"B
    let uto = UTCDateTime.readUTCTimeOnly bs  0 bs.Length
    let expected = UTCDateTime.MakeUTCTimeOnly.Make (23, 59, 60, 999)
    expected =! uto



[<Fact>]
let ``read invalid leapsecond hhmmssMMM from bytes`` () =
    try
        let bs = "23:58:60.999"B // leapseconds only occur in the last minute of the day
        UTCDateTime.readUTCTimeOnly bs  0 bs.Length |> ignore
        false // UTCDateTimex.fromBytes should throw
    with
    |   ex -> true




