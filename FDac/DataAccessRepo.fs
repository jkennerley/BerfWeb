[<AutoOpen>]
module FDac.DataAccessRepo

open System

///// repo :: http://nut-cracker.azurewebsites.net/blog/2011/10/05/inlinefun/
//type Repo = Repo with
//    // insert
//    static member (==>) (d:Repo , be:Idea ) = insertIdea be     
//    static member (==>) (d:Repo , be:BerfClient ) = insertBerfClient be     
//    // update
//    static member (+=) (d:Repo , be:Idea ) = updateIdea be     
//    static member (+=) (d:Repo , be:BerfClient ) = updateBerfClient be     
//    // delete
//    static member (-=) (d:Repo , be:Idea ) = deleteIdea be     
//    static member (-=) (d:Repo , be:BerfClient ) = deleteBerfClient be     
//    // read
//    static member (<==) (d:Repo , be:Idea       ) = readIdea be     
//    static member (<==) (d:Repo , be:BerfClient ) = readBerfClient be 
//    // readNoLock
//    static member (<===) (d:Repo , be:Idea       ) = readNoLockIdea be    
//    static member (<===) (d:Repo , be:BerfClient ) = readNoLockBerfClient be 
//
//// 'overloads' by calling operator overloads of ( Repo , be<T> ) ; overload compiler check is at the call-site
//let inline insert       be = Repo ==>  be
//let inline update       be = Repo +=   be
//let inline delete       be = Repo -=   be
//let inline read         be = Repo <==  be
//let inline readNoLock   be = Repo <=== be
