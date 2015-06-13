[<AutoOpen>]
module Berf.DataAccessRepo

type Repo = Repo with
    // insert
    static member (==>) (d:Repo , be:BerfClient ) = insertBerfClient be     

// insert
let inline insert be = Repo ==> be
