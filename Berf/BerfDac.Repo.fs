[<AutoOpen>]
module BerfDac.Repo

//
type RepoQuery = RepoQuery with
    // insert
    static member (==>) (d:RepoQuery , be:BerfClient ) = insertBerfClient be     

    //static member (==>) (d:Repo , be:YOUR_TABLE_NAME) = insertYOUR_TABLE_NAME be     
    //// update
    //static member (+=) (d:Repo , be:YOUR_TABLE_NAME ) = updateYOUR_TABLE_NAME be     
    //// delete
    //static member (-=) (d:Repo , be:YOUR_TABLE_NAME ) = deleteYOUR_TABLE_NAME be     


    //// read
    //static member (<==) (d:Repo , be:YOUR_TABLE_NAME       ) = readYOUR_TABLE_NAME be     
    //// readNoLock
    //static member (<===) (d:Repo , be:YOUR_TABLE_NAME       ) = readYOUR_TABLE_NAMEWithNoLock be    

////
type RepoCommand = RepoCommand with

    //// read
    static member (<==) (d:RepoCommand , be:BerfClient       ) = readBerfClient be     
    //// readNoLock
    //static member (<===) (d:Repo , be:YOUR_TABLE_NAME       ) = readYOUR_TABLE_NAMEWithNoLock be    




// 'overloads' by calling operator overloads of ( Repo , be<T> ) ; overload compiler check is at the call-site
let inline insert       be = RepoQuery ==>  be
// let inline update       be = RepoQuery +=   be
// let inline delete       be = RepoQuery -=   be

// let inline readNoLock   be = RepoCommand <=== be
let inline read         be = RepoCommand <==  be

//*)
