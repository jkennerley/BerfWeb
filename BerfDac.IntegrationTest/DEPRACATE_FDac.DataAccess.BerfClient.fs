module FDac.DataAccess.BerfClientIntegrationTest

open FDac
open Xunit
open Swensen.Unquote
open System 
open BerfDac.Repo


let getTestableInsert () =
    { BerfDac.BerfClient.Zero  with id = Guid.NewGuid() ; source  = "IntegrationTest" }

let getTestableInserts n =
    let xs = seq { for i in n do yield { BerfDac.BerfClient.Zero  with id = Guid.NewGuid() ; source  = "IntegrationTest" } }
    xs |> Seq.toList


[<Fact>]
let ``Repo insert should do expected``() =
    // Arrange
    // a record to be inserted
    let be = { (getTestableInsert()) with source  = "ITG_IS_INSERTED_TEST_RECORD" }
    // Act
    // sut call
    let retInsert = insert be
    // Assert
    test <@ retInsert = 1 @>
    ()

[<Fact>]
let ``delete should do expected``() =
    // a record to be deleted 
    let be = { (getTestableInsert()) with source  = "ITG_IS_DELETABLE_TEST_RECORD" }
    // insert new record
    let retInsert = insert be
    // Act
    // sut call
    let retDelete = delete be
    // Assert
    test <@ retDelete = 1 @>
    ()


[<Fact>]
let ``update should do expected``() =
    // Arrange
    // a record to be updated 
    let be = { (getTestableInsert()) with source  = "ITG_IS_UPDATEABLE_TEST_RECORD" }
    // insert new record
    let retInsert = insert be
    // change record value that will be updated
    let beInserted = { be with source  = "ITG_UPDATED" }
    // Act
    // sut call
    let retUpdated = update beInserted
    // Assert
    //test <@ retUpdated = 1 @>
    ()

[<Fact>]
let ``read should do expected``() =
    // Arrange
    // a record to be inserted and then read back
    let be = { (getTestableInsert()) with source  = "ITG_IS_READABLE_TEST_RECORD" }
    // insert new record
    let retInsert = insert be
    // Act
    // sut call
    let beActual = read be
    // Assert
    // there should have been 1 record inserted
    test <@ retInsert = 1 @>
    // the record should have been read back into beActual
    match beActual with
        | Some(x) -> test <@ x.id = be.id @>
        | _ -> Assert.True("" = "failed to get expected from the database")
    //match beActual with
    //    | Some(x) -> test <@ x = be @>
    //    | _ -> Assert.True("" = "failed to get expected from the database")
    

    (*
    KEEP
    let readBerfClient (be : BerfClient) =
    let cmd = new DataAccess.ReadBerfClient()
    let de = cmd.Execute (be.id)
    match de with
        | Some(x) -> Some { BerfDac.BerfClient.Zero with id = x.id } 
        | _ -> None
    *)

    ()




//[<Fact>]
//let ``read with nolock should do expected``() =
//    // a record to be inserted
//    let be = getTestableInsert()
//    // insert new record
//    let retInsert = insert be
//    // Act
//    // sut call
//    let beActual = readNoLock be
//    // Assert
//    // there should have been 1 record inserted
//    test <@ retInsert = 1 @>
//    // the record should have been read back into beActual
//    match beActual with
//    | Some(x) -> test <@ x.id = be.id @>
//    | _ -> Assert.True("" = "failed to get expected from the database")
//    ()
