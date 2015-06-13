[<AutoOpen>]
module Berf.DataAccess

open FSharp.Data

///
[<Literal>]
let lsp_InsertBerfClientSqlAutoString =
    "exec lsp_InsertBerfClient @id,@sessionId,@renderId,@ord,@url,@entryType,@source,@created,@unloadEventStart,@unloadEventEnd,@linkNegotiationStart,@linkNegotiationEnd,@redirectStart,@redirectEnd,@fetchStart,@domainLookupStart,@domainLookupEnd,@connectStart,@connectEnd,@secureConnectionStart,@requestStart,@responseStart,@responseEnd,@domLoading,@domInteractive,@domContentLoadedEventStart,@domContentLoadedEventEnd,@domComplete,@loadEventStart,@loadEventEnd,@prerenderSwitch,@redirectCount,@initiatorType,@name,@startTime,@duration,@navigationStart,@userName,@clientIP,@userAgent,@browser,@browserVersion,@hostMachineName"

type InsertBerfClient = SqlCommandProvider<lsp_InsertBerfClientSqlAutoString, DataAccessConfig.CnString>

