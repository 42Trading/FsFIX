﻿module ReaderUtils




let ReadField (ss:string) (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag <> expectedTag then 
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss expectedTag tag
        failwith msg
    let pos3, fld = readFunc pos2 bs
    pos3, fld


let ReadOptionalField (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc : int * 'b option = 
    match FIXBufUtils.readTagOpt pos bs with
    | Some (pos2, tag)  ->     
        if tag = expectedTag then 
            let pos3, fld = readFunc pos2 bs
            pos3, Some fld
        else
            pos, None   // return the original pos, the next read op will re-read it
    | None -> pos, None   // return the original pos, the next read op will re-read it



let rec readGrpInner (acc: 'grp list) (pos:int) (recursionCount:uint32) (bs:byte[]) (readFunc: int -> byte [] -> int * 'grp) =
    match recursionCount with
    | 0u    ->  pos, acc
    | _     ->  let pos2, grpInstance = readFunc pos bs 
                readGrpInner (grpInstance::acc) pos2 (recursionCount-1u) bs readFunc


let ReadGroup (ss:string) (pos:int) (numTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag <> numTag then 
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss numTag tag
        failwith msg
    let pos3, numRepeatBs = FIXBufUtils.readValAfterTagValSep pos2 bs 
    let numRepeats = Conversions.bytesToUInt32 numRepeatBs
    let pos4, gs = readGrpInner [] pos3 numRepeats bs readFunc
    let gsRev = gs |> List.rev
    pos4, gsRev


let ReadOptionalGroup (pos:int) (numFieldTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag = numFieldTag then 
        let pos3, numRepeatBs = FIXBufUtils.readValAfterTagValSep pos2 bs 
        let numRepeats = Conversions.bytesToUInt32 numRepeatBs
        let pos4, gs = readGrpInner [] pos3 numRepeats bs readFunc
        let gsRev = gs |> List.rev
        pos4, Some gsRev
    else
        pos, None   // return the original pos, the next read op will re-read it


let ReadComponent (ss:string) (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag <> expectedTag then 
        let msg = sprintf "when reading %s: expected tag: %A, actual: %A" ss expectedTag tag
        failwith msg
    let pos3, fld = readFunc pos2 bs
    pos3, fld



let ReadOptionalComponent (pos:int) (expectedTag:byte[]) (bs:byte[]) readFunc = 
    let pos2, tag = FIXBufUtils.readTag pos bs
    if tag = expectedTag then 
        let pos3, fld = readFunc pos2 bs
        pos3, Some fld
    else
        pos, None   // return the original pos, the next read op will re-read it