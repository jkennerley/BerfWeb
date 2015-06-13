[<AutoOpen>]
module FDac.Util

    open System

    ///
    let nullable value = 
        new System.Nullable<_>(value)

    ///
    let defaultToEmpty x =
        match x with
        | None -> String.Empty
        | Some(x) -> x

    ///
    let defaultTo0 x =
        match x with
        | None -> 0
        | Some(x) -> x

    ///
    let toSeparatedString postSeperator (stringList:String list) =
        let rec loop acc =
            function
            | [] -> acc
            | x :: [] -> loop ((acc) + (string x)) []
            | x :: xs -> loop ((acc) + (string x) + postSeperator) xs
        loop String.Empty stringList

    ///
    let toSeparated pre post (stringList:String list) =
        let rec loop acc =
            function
            | [] -> acc
            | x :: [] -> loop ((acc) + pre + (string x)) []
            | x :: xs -> loop ((acc) + pre + (string x) + post) xs
        loop String.Empty stringList
