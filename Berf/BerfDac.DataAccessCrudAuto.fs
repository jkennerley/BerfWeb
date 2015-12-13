
[<AutoOpen>]
module BerfDac.Crud 

open FSharp.Data


///
let insertBerfClient (be : BerfClient) =
    let cmd = new DataAccess.InsertBerfClient()
    cmd.Execute
        (be.id,be.sessionId,be.renderId,be.ord,be.url,be.entryType,be.source,be.created,be.unloadEventStart,be.unloadEventEnd,be.linkNegotiationStart,be.linkNegotiationEnd,be.redirectStart,be.redirectEnd,be.fetchStart,be.domainLookupStart,be.domainLookupEnd,be.connectStart,be.connectEnd,be.secureConnectionStart,be.requestStart,be.responseStart,be.responseEnd,be.domLoading,be.domInteractive,be.domContentLoadedEventStart,be.domContentLoadedEventEnd,be.domComplete,be.loadEventStart,be.loadEventEnd,be.prerenderSwitch,be.redirectCount,be.initiatorType,be.name,be.startTime,be.duration,be.navigationStart,be.userName,be.clientIP,be.userAgent,be.browser,be.browserVersion,be.hostMachineName)

                        
///
let updateBerfClient (be : BerfClient) =
    let cmd = new DataAccess.UpdateBerfClient()
    cmd.Execute
        (be.id,be.sessionId,be.renderId,be.ord,be.url,be.entryType,be.source,be.created,be.unloadEventStart,be.unloadEventEnd,be.linkNegotiationStart,be.linkNegotiationEnd,be.redirectStart,be.redirectEnd,be.fetchStart,be.domainLookupStart,be.domainLookupEnd,be.connectStart,be.connectEnd,be.secureConnectionStart,be.requestStart,be.responseStart,be.responseEnd,be.domLoading,be.domInteractive,be.domContentLoadedEventStart,be.domContentLoadedEventEnd,be.domComplete,be.loadEventStart,be.loadEventEnd,be.prerenderSwitch,be.redirectCount,be.initiatorType,be.name,be.startTime,be.duration,be.navigationStart,be.userName,be.clientIP,be.userAgent,be.browser,be.browserVersion,be.hostMachineName)
                        
///
let deleteBerfClient (be : BerfClient) =
    let cmd = new DataAccess.DeleteBerfClient()
    cmd.Execute (be.id)
                        
///
let readBerfClient (be : BerfClient) =
    let cmd = new DataAccess.ReadBerfClient()
    let de = cmd.Execute (be.id)
    
    let be = match de with
        | Some(d) -> Some { BerfClient.Zero with id = d.id ; sessionId = d.sessionId ; renderId = d.renderId ; ord = d.ord ; url = d.url ; entryType = d.entryType ; source = d.source ; created = d.created ; unloadEventStart = d.unloadEventStart ; unloadEventEnd = d.unloadEventEnd ; linkNegotiationStart = d.linkNegotiationStart ; linkNegotiationEnd = d.linkNegotiationEnd ; redirectStart = d.redirectStart ; redirectEnd = d.redirectEnd ; fetchStart = d.fetchStart ; domainLookupStart = d.domainLookupStart ; domainLookupEnd = d.domainLookupEnd ; connectStart = d.connectStart ; connectEnd = d.connectEnd ; secureConnectionStart = d.secureConnectionStart ; requestStart = d.requestStart ; responseStart = d.responseStart ; responseEnd = d.responseEnd ; domLoading = d.domLoading ; domInteractive = d.domInteractive ; domContentLoadedEventStart = d.domContentLoadedEventStart ; domContentLoadedEventEnd = d.domContentLoadedEventEnd ; domComplete = d.domComplete ; loadEventStart = d.loadEventStart ; loadEventEnd = d.loadEventEnd ; prerenderSwitch = d.prerenderSwitch ; redirectCount = d.redirectCount ; initiatorType = d.initiatorType ; name = d.name ; startTime = d.startTime ; duration = d.duration ; navigationStart = d.navigationStart ; userName = d.userName ; clientIP = d.clientIP ; userAgent = d.userAgent ; browser = d.browser ; browserVersion = d.browserVersion ; hostMachineName = d.hostMachineName  } 
        | _ -> None
                        
    be
                        
///
let readBerfClientNoLock (be : BerfClient) =
    let cmd = new DataAccess.ReadBerfClientWithNoLock()
    let de = cmd.Execute (be.id)
    
    let be = match de with
        | Some(d) -> Some { BerfClient.Zero with id = d.id ; sessionId = d.sessionId ; renderId = d.renderId ; ord = d.ord ; url = d.url ; entryType = d.entryType ; source = d.source ; created = d.created ; unloadEventStart = d.unloadEventStart ; unloadEventEnd = d.unloadEventEnd ; linkNegotiationStart = d.linkNegotiationStart ; linkNegotiationEnd = d.linkNegotiationEnd ; redirectStart = d.redirectStart ; redirectEnd = d.redirectEnd ; fetchStart = d.fetchStart ; domainLookupStart = d.domainLookupStart ; domainLookupEnd = d.domainLookupEnd ; connectStart = d.connectStart ; connectEnd = d.connectEnd ; secureConnectionStart = d.secureConnectionStart ; requestStart = d.requestStart ; responseStart = d.responseStart ; responseEnd = d.responseEnd ; domLoading = d.domLoading ; domInteractive = d.domInteractive ; domContentLoadedEventStart = d.domContentLoadedEventStart ; domContentLoadedEventEnd = d.domContentLoadedEventEnd ; domComplete = d.domComplete ; loadEventStart = d.loadEventStart ; loadEventEnd = d.loadEventEnd ; prerenderSwitch = d.prerenderSwitch ; redirectCount = d.redirectCount ; initiatorType = d.initiatorType ; name = d.name ; startTime = d.startTime ; duration = d.duration ; navigationStart = d.navigationStart ; userName = d.userName ; clientIP = d.clientIP ; userAgent = d.userAgent ; browser = d.browser ; browserVersion = d.browserVersion ; hostMachineName = d.hostMachineName  } 
        | _ -> None
                        
    be
                        
///
let upsertBerfClient (be : BerfClient) =
    let cmd = new DataAccess.UpsertBerfClient()
    cmd.Execute
        (be.id,be.sessionId,be.renderId,be.ord,be.url,be.entryType,be.source,be.created,be.unloadEventStart,be.unloadEventEnd,be.linkNegotiationStart,be.linkNegotiationEnd,be.redirectStart,be.redirectEnd,be.fetchStart,be.domainLookupStart,be.domainLookupEnd,be.connectStart,be.connectEnd,be.secureConnectionStart,be.requestStart,be.responseStart,be.responseEnd,be.domLoading,be.domInteractive,be.domContentLoadedEventStart,be.domContentLoadedEventEnd,be.domComplete,be.loadEventStart,be.loadEventEnd,be.prerenderSwitch,be.redirectCount,be.initiatorType,be.name,be.startTime,be.duration,be.navigationStart,be.userName,be.clientIP,be.userAgent,be.browser,be.browserVersion,be.hostMachineName)
                        