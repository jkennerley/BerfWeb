module FDac.UnitTest 

open FDac
open Xunit
open Swensen.Unquote

let getFileDropDirectory = 
    // hard code the place where the auto files will be written to
    // let autoDropDirectory = ConfigurationManager.AppSettings.["autoDropDirectory"]
    let autoDropDirectory= @"C:\Users\John\SkyDrive\Mi\FDac\"

    autoDropDirectory

[<Fact>]
let ``Enm should do expected``() =
    // IdeaType enm
    test <@ 1 = DataAccessEnm.IdeaType.New @>
    test <@ 2 = DataAccessEnm.IdeaType.Draft @>
    test <@ 3 = DataAccessEnm.IdeaType.Publish @>
    test <@ 4 = DataAccessEnm.IdeaType.Archived @>

    ()

[<Fact>]
let ``DataAccessConnectionString.CnString should do expected``() =
    let actual = DataAccessConfig.CnString
    test <@ actual = "name=MiDb" @>
    ()

/// T_SQL FOR ALL
[<Fact>]
[<Trait("category", "AutoGenSql")>]
let ``AutoGen T-SQL should do expected``() =
    // the file drop
    let fileName = "AutoDataAccess.sql"
    let dir = getFileDropDirectory
    let filePathName  = System.IO.Path.Combine (dir, fileName)

    // code type
    let codeFilter = T_SQL 

    let codeElelements = getTableMetaCodeElements

    let code =
        codeElelements 
        |> Seq.filter ( fun z -> z.Lang = codeFilter )
        |> Seq.map( fun x -> x.Code)
        |> Seq.fold (fun acc x -> sprintf """%s%s""" acc x ) ""  

    System.IO.File.WriteAllText (filePathName, code)
    ()

/// F# 
[<Fact>]
[<Trait("category", "DataAccessTypesFs")>]
let ``AutoGen F# AccessTypes should do expected``() =
    // the file drop
    let fileName = "AutoDataAccessTypes.fs"
    let dir = getFileDropDirectory
    let filePathName  = System.IO.Path.Combine (dir, fileName)

    // code type
    let codeFilter = FSHARP
   
    let codeElelements = getTableMetaCodeElements

    let fileContentHeader = """
module FDac.DataAccess

open FSharp.Data

    """

    let code =
        codeElelements 
        |> Seq.filter ( fun z -> z.Lang = codeFilter )
        |> Seq.map( fun x -> x.Code)
        |> Seq.fold (fun acc x -> sprintf """%s%s""" acc x ) fileContentHeader   

    System.IO.File.WriteAllText (filePathName, code)
    ()

///// F# DataAccessCrud
//[<Fact>]
//[<Trait("category", "DataAccessCrudFs")>]
//let ``AutoGen F# FsCrud should do expected``() =
//    // the file drop
//    let fileName = "AutoGenFDac_DataAccessCrud.fs"
//    let dir = getFileDropDirectory
//    let filePathName  = System.IO.Path.Combine (dir, fileName)
//
//    // code type
//    let codeFilter = FSHARP_CRUD
//   
//    let codeElelements = getTableMetaCodeElements
//
//    let code =
//        codeElelements 
//        |> Seq.filter ( fun z -> z.Lang = codeFilter )
//        |> Seq.map( fun x -> x.Code)
//        |> Seq.fold (fun acc x -> sprintf """%s%s""" acc x ) ""  
//
//    System.IO.File.WriteAllText (filePathName, code)
//    ()



/// F# DataAccessCrud
[<Fact>]
[<Trait("category", "DataAccessCrudFs")>]
let ``AutoGen F# FsCrud should do expected``() =
    // the file drop
    let fileName = "AutoDataAccessCrud.fs"
    let dir = getFileDropDirectory
    let filePathName  = System.IO.Path.Combine (dir, fileName)

    // code type
    let codeFilter = FSHARP_CRUD
   
    let codeElelements = getTableMetaCodeElements

    let fileContentHeader = """
[<AutoOpen>]
module FDac.DataAccessCrud

open FSharp.Data

(*
let insertBerfClient (be : BerfClient) =
    let cmd = new DataAccess.InsertBerfClient()
    cmd.Execute
        (be.id, be.sessionId, be.renderId, be.ord, be.url, be.entryType, be.source, be.created, be.unloadEventStart,
         be.unloadEventEnd, be.linkNegotiationStart, be.linkNegotiationEnd, be.redirectStart, be.redirectEnd,
         be.fetchStart, be.domainLookupStart, be.domainLookupEnd, be.connectStart, be.connectEnd,
         be.secureConnectionStart, be.requestStart, be.responseStart, be.responseEnd, be.domLoading, be.domInteractive,
         be.domContentLoadedEventStart, be.domContentLoadedEventEnd, be.domComplete, be.loadEventStart, be.loadEventEnd,
         be.prerenderSwitch, be.redirectCount, be.initiatorType, be.name, be.startTime, be.duration, be.navigationStart,
         be.userName, be.clientIP, be.userAgent, be.browser, be.browserVersion, be.hostMachineName)

*)


    """

    let code =
        codeElelements 
        |> Seq.filter ( fun z -> z.Lang = codeFilter )
        |> Seq.map( fun x -> x.Code)
        |> Seq.fold (fun acc x -> sprintf """%s%s""" acc x ) fileContentHeader   

    System.IO.File.WriteAllText (filePathName, code)
    ()

