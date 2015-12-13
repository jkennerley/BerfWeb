namespace Berf.Controllers

open System
open System.Web
open System.Web.Mvc

open BerfDac.DomainTypes
open BerfDac.Crud
open BerfDac.Repo
open BerfDac.BerfClient

type BerfController() =
    inherit Controller()

    member this.Index (modelBerfClients  : BerfClient[]) =

        // the id for the set of berfClients that will be saved
        let renderId = Guid.NewGuid()

        // get the berfSession, from the cookie if possible
        let cookie = HttpContext.Current.Request.Cookies.["berf"];
        let sessionId = if cookie = null then Guid.Empty else Guid.Parse cookie.Value

        if modelBerfClients <> null then

            // map the metrics to include the HTTP context items
            let berfClients = 
                modelBerfClients  
                |> Seq.mapi (fun i berfClient -> createBerfClient berfClient i sessionId renderId HttpContext.Current )

            // put the metrics in the db
            for berfClient in berfClients  do
                try
                    // insert browser metrics
                    insert berfClient |> ignore
                    ()
                with exn -> 
                    let message = exn.Message
                    (*
                    You may get 
                    Cannot open database "Berf" requested by the login. The login failed.
                    Login failed for user 'IIS APPPOOL\.NET v4.5'.
                    *)
                    ignore()
            ()
        else
            ()

