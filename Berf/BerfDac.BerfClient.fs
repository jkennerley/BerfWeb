[<AutoOpen>]
module BerfDac.BerfClient

open System
open System.Web

///
let Zero =
    { BerfClient.id = Guid.NewGuid()
      sessionId = Guid.Empty
      renderId = Guid.Empty
      ord = 0
      url = String.Empty
      entryType = String.Empty
      source = String.Empty
      created = DateTime.Now
      unloadEventStart = 0.
      unloadEventEnd = 0.
      linkNegotiationStart = 0.
      linkNegotiationEnd = 0.
      redirectStart = 0.
      redirectEnd = 0.
      fetchStart = 0.
      domainLookupStart = 0.
      domainLookupEnd = 0.
      connectStart = 0.
      connectEnd = 0.
      secureConnectionStart = 0.
      requestStart = 0.
      responseStart = 0.
      responseEnd = 0.
      domLoading = 0.
      domInteractive = 0.
      domContentLoadedEventStart = 0.
      domContentLoadedEventEnd = 0.
      domComplete = 0.
      loadEventStart = 0.
      loadEventEnd = 0.
      prerenderSwitch = 0.
      redirectCount = 0
      initiatorType = ""
      name = ""
      startTime = 0.
      duration = 0.
      navigationStart = 0.
      userName = String.Empty
      clientIP = String.Empty
      userAgent = String.Empty
      browser = String.Empty
      browserVersion = String.Empty
      hostMachineName = String.Empty }

///
let createBerfClient berfClient ord sessionId renderId (httpContext : HttpContext) =
    { BerfClient.id = Guid.NewGuid()
      sessionId = sessionId
      renderId = renderId
      ord = ord
      url = berfClient.url
      entryType = berfClient.entryType
      source = berfClient.source
      created = DateTime.Now
      unloadEventStart = berfClient.unloadEventStart
      unloadEventEnd = berfClient.unloadEventEnd
      linkNegotiationStart = berfClient.linkNegotiationStart
      linkNegotiationEnd = berfClient.linkNegotiationEnd
      redirectStart = berfClient.redirectStart
      redirectEnd = berfClient.redirectEnd
      fetchStart = berfClient.fetchStart
      domainLookupStart = berfClient.domainLookupStart
      domainLookupEnd = berfClient.domainLookupEnd
      connectStart = berfClient.connectStart
      connectEnd = berfClient.connectEnd
      secureConnectionStart = berfClient.secureConnectionStart
      requestStart = berfClient.requestStart
      responseStart = berfClient.responseStart
      responseEnd = berfClient.responseEnd
      domLoading = berfClient.domLoading
      domInteractive = berfClient.domInteractive
      domContentLoadedEventStart = berfClient.domContentLoadedEventStart
      domContentLoadedEventEnd = berfClient.domContentLoadedEventEnd
      domComplete = berfClient.domComplete
      loadEventStart = berfClient.loadEventStart
      loadEventEnd = berfClient.loadEventEnd
      prerenderSwitch = berfClient.prerenderSwitch
      redirectCount = berfClient.redirectCount
      initiatorType = berfClient.initiatorType
      name = berfClient.name
      startTime = berfClient.startTime
      duration = berfClient.duration
      navigationStart = berfClient.navigationStart
      userName = httpContext.User.Identity.Name
      clientIP = httpContext.Request.UserHostAddress
      userAgent = httpContext.Request.UserAgent
      browser = httpContext.Request.Browser.Browser
      browserVersion = httpContext.Request.Browser.Version
      hostMachineName = httpContext.Server.MachineName }

