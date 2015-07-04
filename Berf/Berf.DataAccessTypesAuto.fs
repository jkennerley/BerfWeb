
[<AutoOpen>]
module Berf.DataAccess 

open FSharp.Data


///
[<Literal>]
let lsp_InsertBerfClientSqlAutoString = "exec lsp_InsertBerfClient @id,@sessionId,@renderId,@ord,@url,@entryType,@source,@created,@unloadEventStart,@unloadEventEnd,@linkNegotiationStart,@linkNegotiationEnd,@redirectStart,@redirectEnd,@fetchStart,@domainLookupStart,@domainLookupEnd,@connectStart,@connectEnd,@secureConnectionStart,@requestStart,@responseStart,@responseEnd,@domLoading,@domInteractive,@domContentLoadedEventStart,@domContentLoadedEventEnd,@domComplete,@loadEventStart,@loadEventEnd,@prerenderSwitch,@redirectCount,@initiatorType,@name,@startTime,@duration,@navigationStart,@userName,@clientIP,@userAgent,@browser,@browserVersion,@hostMachineName"

type InsertBerfClient = SqlCommandProvider<lsp_InsertBerfClientSqlAutoString, DataAccessConfig.CnString>

                        
///
[<Literal>]
let lsp_UpdateBerfClientSqlAutoString = "exec [dbo].[lsp_UpdateBerfClient] @id,@sessionId,@renderId,@ord,@url,@entryType,@source,@created,@unloadEventStart,@unloadEventEnd,@linkNegotiationStart,@linkNegotiationEnd,@redirectStart,@redirectEnd,@fetchStart,@domainLookupStart,@domainLookupEnd,@connectStart,@connectEnd,@secureConnectionStart,@requestStart,@responseStart,@responseEnd,@domLoading,@domInteractive,@domContentLoadedEventStart,@domContentLoadedEventEnd,@domComplete,@loadEventStart,@loadEventEnd,@prerenderSwitch,@redirectCount,@initiatorType,@name,@startTime,@duration,@navigationStart,@userName,@clientIP,@userAgent,@browser,@browserVersion,@hostMachineName"

type UpdateBerfClient = SqlCommandProvider<lsp_UpdateBerfClientSqlAutoString, DataAccessConfig.CnString>

                        
///
[<Literal>]
let lsp_DeleteBerfClientSqlAutoString = "exec [dbo].[lsp_DeleteBerfClient] @id"


type DeleteBerfClient = SqlCommandProvider<lsp_DeleteBerfClientSqlAutoString, DataAccessConfig.CnString>

                        
///
[<Literal>]
let lsp_ReadBerfClient_SqlAutoString = "exec lsp_ReadBerfClient @id"

type ReadBerfClient = SqlCommandProvider<lsp_ReadBerfClient_SqlAutoString, DataAccessConfig.CnString,SingleRow=true>

                        
///
[<Literal>]
let lsp_ReadBerfClientWithNoLock_SqlAutoString = "exec lsp_ReadBerfClientWithNoLock @id"

type ReadBerfClientWithNoLock = SqlCommandProvider<lsp_ReadBerfClientWithNoLock_SqlAutoString, DataAccessConfig.CnString,SingleRow=true>

                        
///
[<Literal>]
let lsp_UpsertBerfClientSqlAutoString = "exec [dbo].[lsp_UpsertBerfClient] @id,@sessionId,@renderId,@ord,@url,@entryType,@source,@created,@unloadEventStart,@unloadEventEnd,@linkNegotiationStart,@linkNegotiationEnd,@redirectStart,@redirectEnd,@fetchStart,@domainLookupStart,@domainLookupEnd,@connectStart,@connectEnd,@secureConnectionStart,@requestStart,@responseStart,@responseEnd,@domLoading,@domInteractive,@domContentLoadedEventStart,@domContentLoadedEventEnd,@domComplete,@loadEventStart,@loadEventEnd,@prerenderSwitch,@redirectCount,@initiatorType,@name,@startTime,@duration,@navigationStart,@userName,@clientIP,@userAgent,@browser,@browserVersion,@hostMachineName"

type UpsertBerfClient = SqlCommandProvider<lsp_UpsertBerfClientSqlAutoString, DataAccessConfig.CnString>

                        