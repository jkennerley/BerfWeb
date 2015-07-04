module FDac.DataAccess.BerfClientIntegrationTest

open FDac
open Xunit
open Swensen.Unquote

//let getTestableInsert() =
//    let be = BerfClient.createDefaultTest()
//    be
//
//[<Fact>]
//let ``Repo insert should do expected``() =
//    // Arrange
//    // a record to be inserted
//    let be = getTestableInsert()
//    // Act
//    // sut call
//    let retInsert = insert be
//    // Assert
//    test <@ retInsert = 1 @>
//    ()
//
//[<Fact>]
//let ``update should do expected``() =
//    // Arrange
//    // a record to be inserted
//    let be = getTestableInsert()
//    // insert new record
//    let retInsert = insert be
//    // change record value that will be updated
//    let beInserted = be
//    // Act
//    // sut call
//    let retUpdated = update beInserted
//    // Assert
//    test <@ retUpdated = 1 @>
//    ()
//
//[<Fact>]
//let ``delete should do expected``() =
//    // a record to be inserted
//    let be = getTestableInsert()
//    // insert new record
//    let retInsert = insert be
//    // Act
//    // sut call
//    let retDelete = delete be
//    // Assert
//    test <@ retDelete = 1 @>
//    ()
//
//[<Fact>]
//let ``read should do expected``() =
//    // a record to be inserted
//    let be = getTestableInsert()
//    // insert new record
//    let retInsert = insert be
//    // Act
//    // sut call
//    let beActual = read be
//    // Assert
//    // there should have been 1 record inserted
//    test <@ retInsert = 1 @>
//    // the record should have been read back into beAtual
//    match beActual with
//    | Some(x) -> test <@ x.id = be.id @>
//    | _ -> Assert.True("" = "failed to get expected from the database")
//    ()
//
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
