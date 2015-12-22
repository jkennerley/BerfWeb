#r """..\packages\FSharp.Data.2.2.5\lib\net40\Fsharp.data.dll"""

open FSharp.Data

type KV = {key:string  ; value:float }

//type TestTimeLogDataFile  = JsonProvider< """C:\Users\John\OneDrive\BerfWeb\TestTimeLogsForTypeProvider.txt""">
type TestTimeLogDataFile  = JsonProvider< """C:\Users\john kennerley\Dropbox\BerfWeb\TestTimeLogsForTypeProvider.txt""">

let testTimeLogDataFilename  = """C:\Users\john kennerley\Dropbox\BerfWeb\TestTimeLogsForTypeProvider.txt"""

let ys = TestTimeLogDataFile.Load(testTimeLogDataFilename) |> Seq.sortByDescending (fun x ->x.Time )

// review data
for x in ys do printfn "%7.0f %s %s " ( float x.Time) x.Server x.Sig 

// filtering
// let xs = ys |> Seq.where (fun x ->  x.Server = "LPC" ) |> Seq.toList 
// let xs = ys |> Seq.where (fun x ->  x.Server = "DEVTEAM4" ) |> Seq.toList 
let xs = ys
 
// review data
for x in xs do printfn "%7.0f %s %s " ( float x.Time) x.Server x.Sig 

// group by server, sig
let serverTraitsGroups =
    xs
    |> Seq.groupBy (fun x -> (sprintf "%s, %s" x.Server x.Sig) )
    |> Seq.toList

// map to key,value and sort
let serverTraitAverages =
    serverTraitsGroups
    |> Seq.map ( fun (key,values) -> (key , values |> Seq.averageBy(fun x-> float x.Time ) ))
    |> Seq.map ( fun (k,v) -> {key=k ; value=v} )
    //|> Seq.sortBy (fun x -> x.key)
    |> Seq.sortByDescending (fun x -> x.value)
    |> Seq.toList

// millis per item
for x in serverTraitAverages do printfn "%7.1f :: %s" (x.value/1000. ) x.key



