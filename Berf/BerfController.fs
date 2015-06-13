namespace Berf.Controllers

open System
open System.Web
open System.Web.Mvc

open Berf.DomainTypes
open Berf.DataAccessRepo

type BerfController() =
    inherit Controller()

    ///
    let createBerfClient berfClient ord sessionId renderId (httpContext:HttpContext) =
        { 
            BerfClient.id               = Guid.NewGuid()
            sessionId                   = sessionId
            renderId                    = renderId
            ord                         = ord 
            url                         = berfClient.url
            entryType                   = berfClient.entryType
            source                      = berfClient.source
            created                     = DateTime.Now

            unloadEventStart            = berfClient.unloadEventStart            
            unloadEventEnd              = berfClient.unloadEventEnd              
            linkNegotiationStart        = berfClient.linkNegotiationStart        
            linkNegotiationEnd          = berfClient.linkNegotiationEnd          
            redirectStart               = berfClient.redirectStart               
            redirectEnd                 = berfClient.redirectEnd                 
            fetchStart                  = berfClient.fetchStart                  
            domainLookupStart           = berfClient.domainLookupStart           
            domainLookupEnd             = berfClient.domainLookupEnd             
            connectStart                = berfClient.connectStart                
            connectEnd                  = berfClient.connectEnd                  
            secureConnectionStart       = berfClient.secureConnectionStart       
            requestStart                = berfClient.requestStart                
            responseStart               = berfClient.responseStart               
            responseEnd                 = berfClient.responseEnd                 
            domLoading                  = berfClient.domLoading                  
            domInteractive              = berfClient.domInteractive              
            domContentLoadedEventStart  = berfClient.domContentLoadedEventStart  
            domContentLoadedEventEnd    = berfClient.domContentLoadedEventEnd    
            domComplete                 = berfClient.domComplete                 
            loadEventStart              = berfClient.loadEventStart              
            loadEventEnd                = berfClient.loadEventEnd                
            prerenderSwitch             = berfClient.prerenderSwitch             
            redirectCount               = berfClient.redirectCount               
            initiatorType               = berfClient.initiatorType               
            name                        = berfClient.name                        
            startTime                   = berfClient.startTime                   
            duration                    = berfClient.duration                    
            navigationStart             = berfClient.navigationStart             

            userName                    = httpContext.User.Identity.Name
            clientIP                    = httpContext.Request.UserHostAddress
            userAgent                   = httpContext.Request.UserAgent
            browser                     = httpContext.Request.Browser.Browser 
            browserVersion              = httpContext.Request.Browser.Version 
            hostMachineName             = httpContext.Server.MachineName 
        }

    member this.Index (modelBerfClients  : BerfClient[]) =

        // the id for the set of berfClients that will be saved
        let renderId = Guid.NewGuid()

        // get the berfSession, from the cookie if possible
        let cookie = HttpContext.Current.Request.Cookies.["berf"];
        let sessionId = if cookie = null then Guid.Empty else Guid.Parse cookie.Value

        if modelBerfClients <> null then

            // map the metrics to include the http context items
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
                    Cannot open database "Berf" requested by the login. The login failed.
                    Login failed for user 'IIS APPPOOL\.NET v4.5'.
                    *)
                    ignore()
            ()
        else
            ()

