#r """..\packages\FSharp.Data.2.2.5\lib\net40\Fsharp.data.dll"""

open FSharp.Data

type KV = { key:string ; mean:float ; n:int }

//type TestTimeLogDataFile  = JsonProvider< """C:\Users\John\OneDrive\BerfWeb\TestTimeLogsForTypeProvider.txt""">
type TestTimeLogDataFile  = JsonProvider< """C:\Users\john kennerley\Dropbox\BerfWeb\TestTimeLogsForTypeProvider.txt""">

let testTimeLogDataFilename  = """C:\Users\john kennerley\Dropbox\BerfWeb\TestTimeLogsForTypeProvider.txt"""

let ys = TestTimeLogDataFile.Load(testTimeLogDataFilename) |> Seq.sortByDescending (fun x ->x.Time )

// review data
for x in ys do printfn "%7.0f %s %s %s" (float x.Time) x.Server x.Sig x.SigId

// filtering
// let xs = ys |> Seq.where (fun x ->  x.Server = "LPC" ) |> Seq.toList 
// let xs = ys |> Seq.where (fun x ->  x.Server = "DEVTEAM4" ) |> Seq.toList 
let xs = ys
 
// review data
//for x in xs do printfn "%7.0f %s %s " ( float x.Time) x.Server x.Sig 
//for x in xs do printfn "%A" x 

// group by server, sig
let serverTraitsGroups =
    xs
    |> Seq.groupBy (fun x -> (sprintf "%s, %s, %s" x.Server x.SigId x.Sig  ) )
    |> Seq.toList

// map to key,value and sort
let serverTraitAverages =
    serverTraitsGroups
    |> Seq.map ( fun (key,values) -> (key , values |> Seq.averageBy(fun x-> float x.Time) , values |> Seq.length ) )
    |> Seq.map ( fun (k,v,n) -> { KV.key=k ; mean=v ; n = n } )
    //|> Seq.sortBy (fun x -> x.key)
    |> Seq.sortByDescending (fun x -> x.mean)
    |> Seq.toList


// for x in serverTraitAverages do printfn "%A" x 

// seconds per 1000
for x in serverTraitAverages do printfn "%7.1f  (n=%3i) ::  %s" (x.mean) (x.n ) x.key

// millis per item
for x in serverTraitAverages do printfn "%7.1f  (n=%3i) ::  %s" (x.mean/1000.) (x.n ) x.key
