
[<AutoOpen>]
module Berf.DataAccessCrud 

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
    cmd.Execute (be.id)
                        
///
let readBerfClientWithNoLock (be : BerfClient) =
    let cmd = new DataAccess.ReadBerfClientWithNoLock()
    cmd.Execute (be.id)
                        
///
let upsertBerfClient (be : BerfClient) =
    let cmd = new DataAccess.UpsertBerfClient()
    cmd.Execute
        (be.id,be.sessionId,be.renderId,be.ord,be.url,be.entryType,be.source,be.created,be.unloadEventStart,be.unloadEventEnd,be.linkNegotiationStart,be.linkNegotiationEnd,be.redirectStart,be.redirectEnd,be.fetchStart,be.domainLookupStart,be.domainLookupEnd,be.connectStart,be.connectEnd,be.secureConnectionStart,be.requestStart,be.responseStart,be.responseEnd,be.domLoading,be.domInteractive,be.domContentLoadedEventStart,be.domContentLoadedEventEnd,be.domComplete,be.loadEventStart,be.loadEventEnd,be.prerenderSwitch,be.redirectCount,be.initiatorType,be.name,be.startTime,be.duration,be.navigationStart,be.userName,be.clientIP,be.userAgent,be.browser,be.browserVersion,be.hostMachineName)
                        