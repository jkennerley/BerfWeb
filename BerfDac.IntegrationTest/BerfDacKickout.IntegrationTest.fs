module BerfDacIntegrationTest.Kickout

open System.Configuration
open Xunit
open Swensen.Unquote
open FDac
open BerfDacIntegrationTest
open Helpers

// get configured list of tables to get auto crud
let getTablesWhiteList =
    getAppConfig()
        .TablesWhiteList
        .Split(';')
        |> Seq.toList

// the directory where auto-crud files will be dropped
let getFileDropDirectory = 
    let appConfig = getAppConfig()
    appConfig.FileDropDirectory 

// namespace for the auto crud
let getProjectNameSpace  = 
    let appConfig = getAppConfig()
    appConfig.ProjectNameSpace

//
let getCodeElements = 
    let whiteList = getTablesWhiteList 
    let codeElelements = getTableMetaCodeElementsForWhiteList whiteList 
    codeElelements

// 
[<Fact>]
[<Trait("category", "ConnectionSting")>]
let ``DataAccessConnectionString.CnString should do expected``() =
    let actual = DataAccessConfig.CnString
    test <@ actual.Length <> 0 @>
    // test <@ actual = "name=Berf" @>
    ()

// 
[<Fact>]
[<Trait("category", "KickoutSqlFiles")>]
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

// 
[<Fact>]
[<Trait("category", "KickoutFsTypes")>]
let ``AutoGen F# AccessTypes should do expected``() =
    // the file drop
    let fileName = sprintf "%s.DataAccessTypesAuto.fs" getProjectNameSpace 
    let dir = getFileDropDirectory
    let filePathName  = System.IO.Path.Combine (dir, fileName)

    // code type
    let codeFilter = FSHARP_TYPES
   
    let codeElelements = getCodeElements 

    // the header for the top of the F# file
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

// 
[<Fact>]
[<Trait("category", "KickoutFsCrud")>]
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

