[<AutoOpen>]
module BerfDac.Repo

//
type RepoQuery = RepoQuery with
    // insert
    static member (==>) (d:RepoQuery , be:BerfClient ) = insertBerfClient be     
    // update
    static member (+=) (d:RepoQuery , be:BerfClient) = updateBerfClient be     
    // delete
    static member (-=) (d:RepoQuery , be:BerfClient) = deleteBerfClient be     

    //static member (==>) (d:Repo , be:YOUR_TABLE_NAME) = insertYOUR_TABLE_NAME be     
    //// update
    //static member (+=) (d:Repo , be:YOUR_TABLE_NAME ) = updateYOUR_TABLE_NAME be     

////
type RepoCommand = RepoCommand with
    // read
    static member (<==) (d:RepoCommand , be:BerfClient       ) = readBerfClient be     
    //// readNoLock
    //static member (<===) (d:Repo , be:YOUR_TABLE_NAME       ) = readYOUR_TABLE_NAMEWithNoLock be    




// 'overloads' by calling operator overloads of ( Repo , be<T> ) ; overload compiler check is at the call-site
let inline insert       be = RepoQuery ==>  be
let inline update       be = RepoQuery +=   be
let inline delete       be = RepoQuery -=   be
// let inline readNoLock   be = RepoCommand <=== be
let inline read         be = RepoCommand <==  be

//*)
