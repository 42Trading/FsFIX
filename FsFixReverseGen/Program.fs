﻿open System

open System.Text.RegularExpressions

open ParseData
open Messages    
open GroupsAndComponents







// passing an accumulator param for tco
let rec ChunkByInner acc chunkPred xs =
    match xs with
    | []        ->  acc |> List.rev
    | hd::tl    ->  let chunked = tl |> List.takeWhile chunkPred
                    let remaining = xs |> List.skip (chunked.Length + 1) // +1 because hd is included in the chunked items
                    let acc2 = (hd::chunked) :: acc
                    (ChunkByInner acc2 chunkPred remaining)
let ChunkBy = ChunkByInner []



let printMsg (msgNameTagMap:Map<string,string>) (grpMap:Map<string,Member list>) (msg:Message) : unit = 
    let tag = msgNameTagMap.[msg.MName]
    printfn "         <message name=\"%s\" msgtype=\"%s\" msgcat=\"%s\">" msg.MName tag msg.Cat
    msg.Members |> List.iter (printMember "    " grpMap)
    printfn "        </message>"



let extractMsgNameAndTag (xs:string array) =
    match xs with
    | [|rawTag; rawMsgName|] ->
        let tag = rawTag.Replace("// tag: ", "")
        let mtch = Regex.Match(rawMsgName, "xx:[A-z]+", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        if mtch.Success then
            let msgName = mtch.Value.Replace("xx:","")
            msgName, tag
        else
            failwithf "could not extract msg name from: %s" rawMsgName
    | _ -> failwithf "extractMsgNameAndTag input list should be of length 2"






[<EntryPoint>]
let main argv = 
    // todo, get F# source base path as an arg, possibly accept a default if not present
    let fsCmpItmsPath = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.CompoundItems.fs"""
    let compoundItemData = ParseFsTypes fsCmpItmsPath |> List.filter isInteresting  |> ChunkBy isSameGrpCmp
    let groups, components = compoundItemData |> List.partition componentGroupPartitionPred
    let groupMap = groups |> List.map convCmpGrpChunk |> List.map (fun grp -> grp.CGName, grp.Members) |> Map.ofList

    printfn "<fix major=\"4\" minor=\"4\">"

    let fsMsgWritersPath = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.MsgWriters.fs""" // used to get msg tags
    let fsTags = IO.File.ReadLines fsMsgWritersPath |> Seq.filter (fun ss -> ss.Contains("tag:") || ss.Contains("xx:")) |> Seq.chunkBySize 2 |> Seq.map extractMsgNameAndTag
    let msgNameTagMap = fsTags |> Map.ofSeq

    let fsMsgPath = """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\Fix44.Messages.fs"""
    let msgData = ParseFsTypes fsMsgPath
    let msgs = msgData |> List.filter isInteresting |> ChunkBy isSameMsg |> List.map convMsgChunk
    printfn "    <messages>"
    msgs |> List.iter (printMsg msgNameTagMap groupMap)
    printfn "    </messages>"

    let componentsSorted = components |> List.map convCmpGrpChunk |> List.sortBy (fun cmp -> componentOrderMap.[cmp.CGName])
    printfn "    <components>"
    componentsSorted |> List.iter (printComponent groupMap)
    printfn "    </components>"

    printfn "</fix>"

    0 // return an integer exit code




