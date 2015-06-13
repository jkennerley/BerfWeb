[<AutoOpen>]
module FDac.DataAccessBespoke

open System

//let insertBerfClient (be : BerfClient) =
//    let cmd = new DataAccess.InsertBerfClient()
//    cmd.Execute
//        (be.id, be.sessionId, be.renderId, be.ord, be.url, be.entryType, be.source, be.created, be.unloadEventStart,
//         be.unloadEventEnd, be.linkNegotiationStart, be.linkNegotiationEnd, be.redirectStart, be.redirectEnd,
//         be.fetchStart, be.domainLookupStart, be.domainLookupEnd, be.connectStart, be.connectEnd,
//         be.secureConnectionStart, be.requestStart, be.responseStart, be.responseEnd, be.domLoading, be.domInteractive,
//         be.domContentLoadedEventStart, be.domContentLoadedEventEnd, be.domComplete, be.loadEventStart, be.loadEventEnd,
//         be.prerenderSwitch, be.redirectCount, be.initiatorType, be.name, be.startTime, be.duration, be.navigationStart,
//         be.userName, be.clientIP, be.userAgent, be.browser, be.browserVersion, be.hostMachineName)
//
//let updateBerfClient (be : BerfClient) =
//    let cmd = new DataAccess.UpdateBerfClient()
//    cmd.Execute
//        (be.id, be.sessionId, be.renderId, be.ord, be.url, be.entryType, be.source, be.created, be.unloadEventStart,
//         be.unloadEventEnd, be.linkNegotiationStart, be.linkNegotiationEnd, be.redirectStart, be.redirectEnd,
//         be.fetchStart, be.domainLookupStart, be.domainLookupEnd, be.connectStart, be.connectEnd,
//         be.secureConnectionStart, be.requestStart, be.responseStart, be.responseEnd, be.domLoading, be.domInteractive,
//         be.domContentLoadedEventStart, be.domContentLoadedEventEnd, be.domComplete, be.loadEventStart, be.loadEventEnd,
//         be.prerenderSwitch, be.redirectCount, be.initiatorType, be.name, be.startTime, be.duration, be.navigationStart,
//         be.userName, be.clientIP, be.userAgent, be.browser, be.browserVersion, be.hostMachineName)
//
//let deleteBerfClient (be : BerfClient) =
//    let cmd = new DataAccess.DeleteBerfClient()
//    cmd.Execute(be.id)
//
//let readBerfClient (be:BerfClient) : BerfClient option =
//    let id = be.id
//    let cmd = new DataAccess.ReadBerfClient()
//    let r = cmd.Execute(id)
//    match r with
//    | Some(x) -> Some({ BerfClient.Zero with id = x.id })
//    | _ -> None
//
//let readNoLockBerfClient (be:BerfClient) : BerfClient option =
//    let id = be.id
//    let cmd = new DataAccess.ReadBerfClientWithNoLock()
//    let r = cmd.Execute(id)
//    match r with
//    | Some(x) -> Some({ BerfClient.Zero with id = x.id })
//    | _ -> None
//
//// Idea
//let insertIdea (be : Idea) =
//    let cmd = new DataAccess.InsertIdea()
//    cmd.Execute
//        (be.Id, be.IdeaTypeEnum, be.ParentId, be.StageEnum, be.UserId, be.UiOrder, be.UiVisible, be.Title, be.Tags,
//         be.Body, be.Publish, be.Created, be.Updated)
//
//let updateIdea (be : Idea) =
//    let cmd = new DataAccess.UpdateIdea()
//    cmd.Execute
//        (be.Id, be.IdeaTypeEnum, be.ParentId, be.StageEnum, be.UserId, be.UiOrder, be.UiVisible, be.Title, be.Tags,
//         be.Body, be.Publish, be.Created, be.Updated)
//
//let deleteIdea (be : Idea) =
//    let cmd = new DataAccess.DeleteIdea()
//    cmd.Execute(be.Id)
//
//let readIdea (be:Idea) : Idea option =
//    let id = be.Id
//    let cmd = new DataAccess.ReadIdea()
//    let r = cmd.Execute(id)
//    match r with
//    | Some(x) -> Some({ Idea.Zero with Id = x.Id })
//    | _ -> None
//
//let readNoLockIdea (be:Idea) : Idea option =
//    let id = be.Id
//    let cmd = new DataAccess.ReadIdeaWithNoLock()
//    let r = cmd.Execute(id)
//    match r with
//    | Some(x) -> Some({ Idea.Zero with Id = x.Id })
//    | _ -> None



