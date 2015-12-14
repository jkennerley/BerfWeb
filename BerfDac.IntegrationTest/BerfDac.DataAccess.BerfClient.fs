﻿module BerfDacIntegrationTest.BerfClient

open System 
open Xunit
open Swensen.Unquote
open BerfDac.Repo

//
let getTestableInsert () =
    { BerfDac.BerfClient.Zero  with id = Guid.NewGuid() ; source  = "IntegrationTest" }

//
let getTestableInserts n =
    let xs = seq { for i in 1..n do yield { BerfDac.BerfClient.Zero  with id = Guid.NewGuid() ; source  = "IntegrationTest" } }
    xs |> Seq.toList


//
[<Fact>]
[<Trait("category", "BerfClient")>]
let ``insert should not except``() =
    // Arrange
    // a record to be inserted
    let be = { (getTestableInsert()) with source  = "ITG_IS_INSERTED_TEST_RECORD" }
    // Act
    // sut call
    let retInsert = insert be
    // Assert
    test <@ retInsert = 1 @>
    ()

//
[<Fact>]
[<Trait("category", "BerfClient")>]
let ``delete should not except``() =
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

//
[<Fact>]
[<Trait("category", "BerfClient")>]
let ``update should not except``() =
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

//
[<Fact>]
[<Trait("category", "BerfClient")>]
let ``read should not except``() =
    // Arrange
    // a record to be inserted and then read back
    let insertableBe = { (getTestableInsert()) with source  = "ITG_IS_READABLE_TEST_RECORD" }
    // insert new record
    let insertedReturn = insert insertableBe
    // Act
    // sut call
    let actualReadBackBe = read insertableBe
    // Assert
    // there should have been 1 record inserted
    test <@ insertedReturn = 1 @>
    // the record should have been read back into beActual
    let acBe =  match actualReadBackBe with
                    | Some(b) ->  b 
                    | _ -> BerfDac.BerfClient.Zero
    test <@ acBe = insertableBe @>
    //test <@ acBe.id                               = insertableBe.id                               @>
    //test <@ acBe.sessionId                        = insertableBe.sessionId                        @>
    //test <@ acBe.renderId                         = insertableBe.renderId                         @>
    //test <@ acBe.ord                              = insertableBe.ord                              @>
    //test <@ acBe.url                              = insertableBe.url                              @>
    //test <@ acBe.entryType                        = insertableBe.entryType                        @>
    //test <@ acBe.source                           = insertableBe.source                           @>
    //test <@ acBe.created                          = insertableBe.created                          @>
    //test <@ acBe.unloadEventStart                 = insertableBe.unloadEventStart                 @>
    //test <@ acBe.unloadEventEnd                   = insertableBe.unloadEventEnd                   @>
    //test <@ acBe.linkNegotiationStart             = insertableBe.linkNegotiationStart             @>
    //test <@ acBe.linkNegotiationEnd               = insertableBe.linkNegotiationEnd               @>
    //test <@ acBe.redirectStart                    = insertableBe.redirectStart                    @>
    //test <@ acBe.redirectEnd                      = insertableBe.redirectEnd                      @>
    //test <@ acBe.fetchStart                       = insertableBe.fetchStart                       @>
    //test <@ acBe.domainLookupStart                = insertableBe.domainLookupStart                @>
    //test <@ acBe.domainLookupEnd                  = insertableBe.domainLookupEnd                  @>
    //test <@ acBe.connectStart                     = insertableBe.connectStart                     @>
    //test <@ acBe.connectEnd                       = insertableBe.connectEnd                       @>
    //test <@ acBe.secureConnectionStart            = insertableBe.secureConnectionStart            @>
    //test <@ acBe.requestStart                     = insertableBe.requestStart                     @>
    //test <@ acBe.responseStart                    = insertableBe.responseStart                    @>
    //test <@ acBe.responseEnd                      = insertableBe.responseEnd                      @>
    //test <@ acBe.domLoading                       = insertableBe.domLoading                       @>
    //test <@ acBe.domInteractive                   = insertableBe.domInteractive                   @>
    //test <@ acBe.domContentLoadedEventStart       = insertableBe.domContentLoadedEventStart       @>
    //test <@ acBe.domContentLoadedEventEnd         = insertableBe.domContentLoadedEventEnd         @>
    //test <@ acBe.domComplete                      = insertableBe.domComplete                      @>
    //test <@ acBe.loadEventStart                   = insertableBe.loadEventStart                   @>
    //test <@ acBe.loadEventEnd                     = insertableBe.loadEventEnd                     @>
    //test <@ acBe.prerenderSwitch                  = insertableBe.prerenderSwitch                  @>
    //test <@ acBe.redirectCount                    = insertableBe.redirectCount                    @>
    //test <@ acBe.initiatorType                    = insertableBe.initiatorType                    @>
    //test <@ acBe.name                             = insertableBe.name                             @>
    //test <@ acBe.startTime                        = insertableBe.startTime                        @>
    //test <@ acBe.duration                         = insertableBe.duration                         @>
    //test <@ acBe.navigationStart                  = insertableBe.navigationStart                  @>
    //test <@ acBe.userName                         = insertableBe.userName                         @>
    //test <@ acBe.clientIP                         = insertableBe.clientIP                         @>
    //test <@ acBe.userAgent                        = insertableBe.userAgent                        @>
    //test <@ acBe.browser                          = insertableBe.browser                          @>
    //test <@ acBe.browserVersion                   = insertableBe.browserVersion                   @>
    //test <@ acBe.hostMachineName                  = insertableBe.hostMachineName                  @>
    ()

//
[<Fact>]
[<Trait("category", "BerfClient")>]
let ``read with nolock should not except``() =
    // Arrange
    // a record to be inserted and then read back
    let insertableBe = { (getTestableInsert()) with source  = "ITG_IS_READABLE_TEST_RECORD" }
    // insert new record
    let insertedReturn = insert insertableBe
    // Act
    // sut call
    let actualReadBackBe = readNoLock insertableBe
    // Assert
    // there should have been 1 record inserted
    test <@ insertedReturn = 1 @>
    // the record should have been read back into beActual
    let acBe =  match actualReadBackBe with
                    | Some(b) ->  b 
                    | _ -> BerfDac.BerfClient.Zero
    test <@ acBe = insertableBe @>
    ()

[<Fact>]
[<Trait("category", "performance test")>]
let ``performance test insert 1000``() =
    // Arrange
    // a record to be inserted and then read back
    let insertableBes = getTestableInserts 1000
    let results = 
        insertableBes
        |> Seq.map( fun insertableBe -> insert insertableBe)
        |> Seq.toList

    // Assert
    results
    |> List.iter(fun insertedReturn -> Assert.Equal(1, insertedReturn ) )
    ()


[<Fact>]
[<Trait("category", "performance test")>]
let ``performance test insert and update 1000``() =
    // Arrange
    // a record to be inserted and then read back
    let insertableBes = getTestableInserts 1000

    let results = 
        insertableBes
        |> Seq.map( fun insertableBe -> insert insertableBe)
        |> Seq.toList

    let updateResults = 
        insertableBes
        |> Seq.map( fun be -> { be with source  = "ITG_UPDATED" } )
        |> Seq.map( fun insertableBe -> update insertableBe)
        |> Seq.toList

    // Assert
    // results |> List.iter(fun insertedReturn -> Assert.Equal(1, insertedReturn ) )
    ()







[<Fact>]
[<Trait("category", "performance test")>]
let ``performance test insert then delete 1000 records``() =
    // Arrange
    // a record to be inserted and then read back
    let insertableBes = getTestableInserts 1000
    let insertResults = 
        insertableBes
        |> Seq.map( fun insertableBe -> insert insertableBe)
        |> Seq.toList

    let deleteResults = 
        insertableBes
        |> Seq.map( fun insertableBe -> delete insertableBe)
        |> Seq.toList
    
    // Assert
    //results |> List.iter(fun insertedReturn -> Assert.Equal(1, insertedReturn ) )
    ()

// 
[<Fact>]
[<Trait("category", "performance test")>]
let ``performance test read 1 record in 50,000 times from at least 1000 recs in the db``() =
    // Arrange
    // a record to be inserted and then read back
    let insertableBes = getTestableInserts 1000

    let results = 
        insertableBes
        |> Seq.map( fun insertableBe -> insert insertableBe)
        |> Seq.toList

    let insertedBe = ( List.nth insertableBes 0 )

    // Assert
    (*
        For Lenovo Yoga2 Core i7  
        :: 14s to read one record back in 50,000 times
        :: 0.14s / 500 records         
        :: .28ms/record ; 
    *)
    for i in 1..50000 do 
        let actualBe = defaultArg (read insertedBe) BerfDac.BerfClient.Zero
        Assert.Equal( insertedBe , actualBe )
        ()
    ()


// 
[<Fact>]
[<Trait("category", "performance test")>]
let ``performance test readNoLock 1 record in 50,000 times from at least 1000 recs in the db``() =
    // Arrange
    // a record to be inserted and then read back
    let insertableBes = getTestableInserts 1000

    let results = 
        insertableBes
        |> Seq.map( fun insertableBe -> insert insertableBe)
        |> Seq.toList

    let insertedBe = ( List.nth insertableBes 0 )

    // Assert
    (*
        For Lenovo Yoga2 Core i7  
        :: 14s to read one record back in 50,000 times
        :: 0.14s / 500 records         
        :: .28ms/record ; 
    *)
    for i in 1..50000 do 
        let actualBe = defaultArg (readNoLock insertedBe) BerfDac.BerfClient.Zero
        Assert.Equal( insertedBe , actualBe )
        ()
    ()




















