[<AutoOpen>]
module Berf.DomainTypes

open System

[<CLIMutable>]
type BerfClient =
    { id : Guid
      sessionId : Guid
      renderId : Guid
      ord : int
      url : string
      entryType : string
      source : string
      created : DateTime
      unloadEventStart : float
      unloadEventEnd : float
      linkNegotiationStart : float
      linkNegotiationEnd : float
      redirectStart : float
      redirectEnd : float
      fetchStart : float
      domainLookupStart : float
      domainLookupEnd : float
      connectStart : float
      connectEnd : float
      secureConnectionStart : float
      requestStart : float
      responseStart : float
      responseEnd : float
      domLoading : float
      domInteractive : float
      domContentLoadedEventStart : float
      domContentLoadedEventEnd : float
      domComplete : float
      loadEventStart : float
      loadEventEnd : float
      prerenderSwitch : float
      redirectCount : int
      initiatorType : string
      name : string
      startTime : float
      duration : float
      navigationStart : float
      userName : string
      clientIP : string
      userAgent : string
      browser : string
      browserVersion : string
      hostMachineName : string }
