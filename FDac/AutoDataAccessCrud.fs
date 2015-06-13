
[<AutoOpen>]
module FDac.DataAccessCrud

open FSharp.Data

(*
let insertBerfClient (be : BerfClient) =
    let cmd = new DataAccess.InsertBerfClient()
    cmd.Execute
        (be.id, be.sessionId, be.renderId, be.ord, be.url, be.entryType, be.source, be.created, be.unloadEventStart,
         be.unloadEventEnd, be.linkNegotiationStart, be.linkNegotiationEnd, be.redirectStart, be.redirectEnd,
         be.fetchStart, be.domainLookupStart, be.domainLookupEnd, be.connectStart, be.connectEnd,
         be.secureConnectionStart, be.requestStart, be.responseStart, be.responseEnd, be.domLoading, be.domInteractive,
         be.domContentLoadedEventStart, be.domContentLoadedEventEnd, be.domComplete, be.loadEventStart, be.loadEventEnd,
         be.prerenderSwitch, be.redirectCount, be.initiatorType, be.name, be.startTime, be.duration, be.navigationStart,
         be.userName, be.clientIP, be.userAgent, be.browser, be.browserVersion, be.hostMachineName)

*)


    
///
let AAA_insertBerfClient (be : BerfClient) =
    let cmd = new DataAccess.InsertBerfClient()
    cmd.Execute
        (be.id,be.sessionId,be.renderId,be.ord,be.url,be.entryType,be.source,be.created,be.unloadEventStart,be.unloadEventEnd,be.linkNegotiationStart,be.linkNegotiationEnd,be.redirectStart,be.redirectEnd,be.fetchStart,be.domainLookupStart,be.domainLookupEnd,be.connectStart,be.connectEnd,be.secureConnectionStart,be.requestStart,be.responseStart,be.responseEnd,be.domLoading,be.domInteractive,be.domContentLoadedEventStart,be.domContentLoadedEventEnd,be.domComplete,be.loadEventStart,be.loadEventEnd,be.prerenderSwitch,be.redirectCount,be.initiatorType,be.name,be.startTime,be.duration,be.navigationStart,be.userName,be.clientIP,be.userAgent,be.browser,be.browserVersion,be.hostMachineName)

                        
///
let AAA_insertIdea (be : Idea) =
    let cmd = new DataAccess.InsertIdea()
    cmd.Execute
        (be.Id,be.IdeaTypeEnum,be.ParentId,be.StageEnum,be.UserId,be.UiOrder,be.UiVisible,be.Title,be.Tags,be.Body,be.Publish,be.Created,be.Updated)

                        