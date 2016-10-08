﻿open System


open System.Xml.Linq
open System.Xml.XPath
open System.IO

open FIXGenTypes
open FieldGenerator






let fixSpecXmlFile = """C:\Users\Ian\Documents\GitHub\quickfixn\spec\fix\FIX44.xml"""


let MkOutpath flName = 
    sprintf """C:\Users\Ian\Documents\GitHub\fsFixGen\fsFix\%s""" flName





[<EntryPoint>]
let main _ = 

    let fixXml = IO.File.ReadAllText(fixSpecXmlFile)
    let doc = XDocument.Parse fixXml

    let xpthFields = doc.XPathSelectElement "fix/fields"
    use swFixFields = new StreamWriter (MkOutpath "Fix44.Fields.fs")
    use swFieldReadWriteFuncs = new StreamWriter (MkOutpath "Fix44.FieldReadWriteFuncs.fs")
    
    printfn "reading and generating FIX field source"
    let fieldData = FieldGenerator.ParseFieldData2 xpthFields 
    let lenFieldNames, mergedFields = FieldGenerator.MergeLenFields fieldData
    FieldGenerator.Gen mergedFields swFixFields swFieldReadWriteFuncs

    printfn "reading components"
    let xpthMsgs = doc.XPathSelectElement "fix/components"
    let components = ComponentGenerator.Read xpthMsgs

    // make a map of component name to component
    // used for marrying up component refs with components
    let cmpNameMap = components 
                        |> List.map (fun cmp -> cmp.CName, cmp)
                        |> Map.ofList

    printfn "reading messages"
    let xpthMsgs = doc.XPathSelectElement "fix/messages"
    let msgs = MessageGenerator.Read xpthMsgs


    printfn "merging group definitions"
    let cmpGrps = GroupUtils.extractLevel1GroupsFromComponents components
    let msgGrps = GroupUtils.extractLevel1GroupsFromMsgs msgs
    let allGrps = cmpGrps @ msgGrps

    // a map of the groups longname (a compound name based on its parentage) to a merge candidate
    let groupMerges = GroupUtils.makeMergeMap allGrps
    groupMerges 
        |> List.sortBy (fun (_,grp) -> grp.GName)
        |> List.iter (fun (ln,grp) -> printfn "group merge: %A -> %A" ln grp.GName)

    printf ""

    //#### repoint groups to merged def in components and messages using groupMap
    //#### generate combined component+group definitions



//
//
//
//    let msgItems = 
//        [ for msg in msgs do
//          yield! msg.Items ]
//
//    // extract the components and groups refered to in messages
//    // these will in-turn contain nested components and groups
//    // group definitions are nested, component definitions are not (components are defined in their own xml element, groups are defined in messages and components)
//    let msgCompoundItems  = msgItems |> (CompoundItemFuncs.extractCompoundItems cmpNameMap)
//    let msgCompoundItems2 = msgCompoundItems |> List.distinct
//    let flattenedMsgCompoundItems   = msgCompoundItems2 |> CompoundItemFuncs.flattenCompoundItems cmpNameMap
//    let flattenedMsgCompoundItems2 = flattenedMsgCompoundItems |> List.distinct

//    let depOrder = flattenedMsgCompoundItems2 |> (DependencyConstraintSolver.ConstrainGroupDependencyOrder cmpNameMap)


    // get the compound items from the messages
    // flatten the compound items
    // get compound items in dependency order
    // must write compound items in same source file, as some components will depend on groups and visa versa







//    let depOrderGroups = GroupGenerator.GetGroupsInDependencyOrder allGrps

//    printfn "generating group source"
//    use swGroups = new StreamWriter (MkOutpath "Fix44.Groups.fs")
//    use swGroupWriteFuncs = new StreamWriter (MkOutpath "Fix44.GroupWriteFuncs.fs")
//    use swGroupFactoryFuncs = new StreamWriter (MkOutpath "Fix44.GroupFactoryFuncs.fs")
//    GroupGenerator.Gen depOrderGroups swGroups swGroupWriteFuncs

//    GroupGenerator.GenFactoryFuncs depOrderGroups swGroupFactoryFuncs


    0 // return an integer exit code