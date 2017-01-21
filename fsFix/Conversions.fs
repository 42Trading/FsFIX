﻿module Conversions

open System


let bytesToStrIdx bs pos len = System.Text.Encoding.UTF8.GetString (bs, pos, len)

let bytesToCharIdx (bs:byte[]) pos len = 
    //let cs = System.Text.Encoding.UTF8.GetChars(bs, pos, len)
    if len = 1 then
        let b = bs.[pos]
        char (b)
    else
        let msg = sprintf "should be single char at pos: %d, len: %d" pos len
        failwith msg


// todo: replace with an impl the reads the int directly from the byte array without a tmp string
let bytesToInt32Idx bs pos len =
    let ss = bytesToStrIdx bs pos len
    System.Convert.ToInt32 ss


// todo: replace with an impl the reads the uint directly from the byte array without a tmp string
let bytesToUInt32Idx bs pos len =
    let ss = bytesToStrIdx bs pos len
    System.Convert.ToUInt32 ss

let bytesToBoolIdx (bs:byte[]) (pos:int) =
    match bs.[pos] with
    | 89uy ->  true  // Y
    | 78uy ->  false  // N
    | _ ->  failwith (sprintf "invalid value for bool field: %d, should be 89 (Y) or 78 (N)" bs.[pos]) 

// todo: replace with impl that reads the decimal directly with the tmp string
let bytesToDecimalIdx (bs:byte[]) pos len = 
    let ss = bytesToStrIdx bs pos len
    match Decimal.TryParse(ss) with
    | false, _  -> failwith (sprintf "invalid value for decimal field: %s" ss) 
    | true, dd  -> dd




let private sToB (ss:string) = System.Text.Encoding.UTF8.GetBytes ss


//todo: consider how to avoid allocation by writing into a pre-allocated array at a give postion
[<AbstractClass;Sealed>]
type ToBytes private () =
    static member Convert (str:string) = sToB str
    static member Convert (ii:int32)   = sprintf "%d" ii |> sToB     
    static member Convert (ui:uint32)  = sprintf "%d" ui |> sToB     
    static member Convert (dd:decimal) = sprintf "%.15f" dd |> sToB  // see http://www.onixs.biz/fix-dictionary/4.4/
    static member Convert (bb:bool)    = if bb then "Y"B else "N"B
    static member Convert (bs:byte []) = bs
    

