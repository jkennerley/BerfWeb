
module FDac.DataAccess

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
let lsp_InsertIdeaSqlAutoString = "exec lsp_InsertIdea @Id,@IdeaTypeEnum,@ParentId,@StageEnum,@UserId,@UiOrder,@UiVisible,@Title,@Tags,@Body,@Publish,@Created,@Updated"

type InsertIdea = SqlCommandProvider<lsp_InsertIdeaSqlAutoString, DataAccessConfig.CnString>

                        
///
[<Literal>]
let lsp_UpdateIdeaSqlAutoString = "exec [dbo].[lsp_UpdateIdea] @Id,@IdeaTypeEnum,@ParentId,@StageEnum,@UserId,@UiOrder,@UiVisible,@Title,@Tags,@Body,@Publish,@Created,@Updated"

type UpdateIdea = SqlCommandProvider<lsp_UpdateIdeaSqlAutoString, DataAccessConfig.CnString>

                        
///
[<Literal>]
let lsp_DeleteIdeaSqlAutoString = "exec [dbo].[lsp_DeleteIdea] @Id"


type DeleteIdea = SqlCommandProvider<lsp_DeleteIdeaSqlAutoString, DataAccessConfig.CnString>

                        
///
[<Literal>]
let lsp_ReadIdea_SqlAutoString = "exec lsp_ReadIdea @Id"

type ReadIdea = SqlCommandProvider<lsp_ReadIdea_SqlAutoString, DataAccessConfig.CnString,SingleRow=true>

                        
///
[<Literal>]
let lsp_ReadIdeaWithNoLock_SqlAutoString = "exec lsp_ReadIdeaWithNoLock @Id"

type ReadIdeaWithNoLock = SqlCommandProvider<lsp_ReadIdeaWithNoLock_SqlAutoString, DataAccessConfig.CnString,SingleRow=true>

                        