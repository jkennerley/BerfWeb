module BerfDac.UnitTest 

open System.Configuration
open FDac
open Xunit
open Swensen.Unquote

(*
=======================
Config
*)
let getAppConfig () = 
    { BerfDac.IntegrationTest.DomainTypes.FileDropDirectory = ConfigurationManager.AppSettings.["FileDropDirectory"] }

// refactor : to config
let getProjectNameSpace = "BerfDac"

// refactor : to config
let getTablesWhiteList =
    // the tables we need crud for
    [ yield "BerfClient"]
    // [ yield "BerfClient"; yield "BerfMvc"]

(*
=======================
Tests Helpers
*)

let getFileDropDirectory = 
    let appConfig = getAppConfig()
    let autoDropDirectory = appConfig.FileDropDirectory 
    autoDropDirectory

let getCodeElements = 
    let whiteList = getTablesWhiteList 
    let codeElelements = getTableMetaCodeElementsForWhiteList whiteList 
    codeElelements

(*
=======================
Tests that kickout Crud and SQL files
*)


[<Fact>]
let ``DataAccessConnectionString.CnString should do expected``() =
    let actual = DataAccessConfig.CnString
    test <@ actual.Length <> 0 @>
    // test <@ actual = "name=Berf" @>
    ()

/// T_SQL FOR ALL
[<Fact>]
[<Trait("category", "AutoGenSql")>]
let ``AutoGen T-SQL should do expected``() =
    // the file drop
    let fileName = sprintf "%s.DataAccessAuto.sql" getProjectNameSpace 
    let dir = getFileDropDirectory
    let filePathName  = System.IO.Path.Combine (dir, fileName)

    // T-SQL  code elements
    let codeFilter = T_SQL 

    let codeElelements = getCodeElements 
    
    let code =
        codeElelements 
        |> Seq.filter ( fun z -> z.Lang = codeFilter )
        |> Seq.map( fun x -> x.Code)
        |> Seq.fold (fun acc x -> sprintf """%s%s""" acc x ) ""  

    System.IO.File.WriteAllText (filePathName, code)
    ()

/// F# Data Access Types
[<Fact>]
[<Trait("category", "DataAccessTypesFs")>]
let ``AutoGen F# AccessTypes should do expected``() =
    // the file drop
    let fileName = sprintf "%s.DataAccessTypesAuto.fs" getProjectNameSpace 
    let dir = getFileDropDirectory
    let filePathName  = System.IO.Path.Combine (dir, fileName)

    // code type
    let codeFilter = FSHARP_TYPES
   
    let codeElelements = getCodeElements 

    // the header for the top of the fs file
    let fileContentHeader = sprintf """
[<AutoOpen>]
module %s.DataAccess 

open FSharp.Data

""" 
                                    getProjectNameSpace

    let code =
        codeElelements 
        |> Seq.filter ( fun z -> z.Lang = codeFilter )
        |> Seq.map( fun x -> x.Code)
        |> Seq.fold (fun acc x -> sprintf """%s%s""" acc x ) fileContentHeader   

    System.IO.File.WriteAllText (filePathName, code)
    ()

/// F# DataAccessCrud
[<Fact>]
[<Trait("category", "DataAccessCrudFs")>]
let ``AutoGen F# FsCrud should do expected``() =
    // the file drop
    let fileName = sprintf "%s.DataAccessCrudAuto.fs" getProjectNameSpace 
    let dir = getFileDropDirectory
    let filePathName  = System.IO.Path.Combine (dir, fileName)

    // code type
    let codeFilter = FSHARP_CRUD
   
    let codeElelements = getCodeElements 

    let fileContentHeader = sprintf """
[<AutoOpen>]
module %s.Crud 

open FSharp.Data

""" 
                                    getProjectNameSpace

    let code =
        codeElelements 
        |> Seq.filter ( fun z -> z.Lang = codeFilter )
        |> Seq.map( fun x -> x.Code)
        |> Seq.fold (fun acc x -> sprintf """%s%s""" acc x ) fileContentHeader   

    System.IO.File.WriteAllText (filePathName, code)
    ()

