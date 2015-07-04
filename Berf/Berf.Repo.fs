[<AutoOpen>]
module Berf.DataAccessRepo

type Repo = Repo with
    // insert
    static member (==>) (d:Repo , be:BerfClient ) = insertBerfClient be     
    //static member (==>) (d:Repo , be:YOUR_TABLE_NAME) = insertYOUR_TABLE_NAME be     
    //// update
    //static member (+=) (d:Repo , be:YOUR_TABLE_NAME ) = updateYOUR_TABLE_NAME be     
    //// delete
    //static member (-=) (d:Repo , be:YOUR_TABLE_NAME ) = deleteYOUR_TABLE_NAME be     
    //// read
    //static member (<==) (d:Repo , be:YOUR_TABLE_NAME       ) = readYOUR_TABLE_NAME be     
    //// readNoLock
    //static member (<===) (d:Repo , be:YOUR_TABLE_NAME       ) = readYOUR_TABLE_NAMEWithNoLock be    



// 'overloads' by calling operator overloads of ( Repo , be<T> ) ; overload compiler check is at the call-site
let inline insert       be = Repo ==>  be
// let inline update       be = Repo +=   be
// let inline delete       be = Repo -=   be
// let inline read         be = Repo <==  be
// let inline readNoLock   be = Repo <=== be

