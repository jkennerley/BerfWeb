/*
--***********
go 
drop proc lsp_InsertBerfClient
go 
create proc lsp_InsertBerfClient  
@id uniqueidentifier,@sessionId uniqueidentifier,@renderId uniqueidentifier,@ord int,@url [nvarchar](MAX),@entryType [nvarchar](MAX),@source [nvarchar](MAX),@created datetime,@unloadEventStart float,@unloadEventEnd float,@linkNegotiationStart float,@linkNegotiationEnd float,@redirectStart float,@redirectEnd float,@fetchStart float,@domainLookupStart float,@domainLookupEnd float,@connectStart float,@connectEnd float,@secureConnectionStart float,@requestStart float,@responseStart float,@responseEnd float,@domLoading float,@domInteractive float,@domContentLoadedEventStart float,@domContentLoadedEventEnd float,@domComplete float,@loadEventStart float,@loadEventEnd float,@prerenderSwitch float,@redirectCount int,@initiatorType [nvarchar](MAX),@name [nvarchar](MAX),@startTime float,@duration float,@navigationStart float,@userName [nvarchar](MAX),@clientIP [nvarchar](39),@userAgent [nvarchar](MAX),@browser [nvarchar](MAX),@browserVersion [nvarchar](MAX),@hostMachineName [nvarchar](MAX)
as
begin
insert into BerfClient 
( id,sessionId,renderId,ord,url,entryType,source,created,unloadEventStart,unloadEventEnd,linkNegotiationStart,linkNegotiationEnd,redirectStart,redirectEnd,fetchStart,domainLookupStart,domainLookupEnd,connectStart,connectEnd,secureConnectionStart,requestStart,responseStart,responseEnd,domLoading,domInteractive,domContentLoadedEventStart,domContentLoadedEventEnd,domComplete,loadEventStart,loadEventEnd,prerenderSwitch,redirectCount,initiatorType,name,startTime,duration,navigationStart,userName,clientIP,userAgent,browser,browserVersion,hostMachineName ) 
values
( @id,@sessionId,@renderId,@ord,@url,@entryType,@source,@created,@unloadEventStart,@unloadEventEnd,@linkNegotiationStart,@linkNegotiationEnd,@redirectStart,@redirectEnd,@fetchStart,@domainLookupStart,@domainLookupEnd,@connectStart,@connectEnd,@secureConnectionStart,@requestStart,@responseStart,@responseEnd,@domLoading,@domInteractive,@domContentLoadedEventStart,@domContentLoadedEventEnd,@domComplete,@loadEventStart,@loadEventEnd,@prerenderSwitch,@redirectCount,@initiatorType,@name,@startTime,@duration,@navigationStart,@userName,@clientIP,@userAgent,@browser,@browserVersion,@hostMachineName )
end
go 
                    
--***********
go 
drop proc lsp_UpdateBerfClient
go 
create proc lsp_UpdateBerfClient  
@id uniqueidentifier,@sessionId uniqueidentifier,@renderId uniqueidentifier,@ord int,@url [nvarchar](MAX),@entryType [nvarchar](MAX),@source [nvarchar](MAX),@created datetime,@unloadEventStart float,@unloadEventEnd float,@linkNegotiationStart float,@linkNegotiationEnd float,@redirectStart float,@redirectEnd float,@fetchStart float,@domainLookupStart float,@domainLookupEnd float,@connectStart float,@connectEnd float,@secureConnectionStart float,@requestStart float,@responseStart float,@responseEnd float,@domLoading float,@domInteractive float,@domContentLoadedEventStart float,@domContentLoadedEventEnd float,@domComplete float,@loadEventStart float,@loadEventEnd float,@prerenderSwitch float,@redirectCount int,@initiatorType [nvarchar](MAX),@name [nvarchar](MAX),@startTime float,@duration float,@navigationStart float,@userName [nvarchar](MAX),@clientIP [nvarchar](39),@userAgent [nvarchar](MAX),@browser [nvarchar](MAX),@browserVersion [nvarchar](MAX),@hostMachineName [nvarchar](MAX)
as
begin
update BerfClient 
set sessionId = @sessionId, renderId = @renderId, ord = @ord, url = @url, entryType = @entryType, source = @source, created = @created, unloadEventStart = @unloadEventStart, unloadEventEnd = @unloadEventEnd, linkNegotiationStart = @linkNegotiationStart, linkNegotiationEnd = @linkNegotiationEnd, redirectStart = @redirectStart, redirectEnd = @redirectEnd, fetchStart = @fetchStart, domainLookupStart = @domainLookupStart, domainLookupEnd = @domainLookupEnd, connectStart = @connectStart, connectEnd = @connectEnd, secureConnectionStart = @secureConnectionStart, requestStart = @requestStart, responseStart = @responseStart, responseEnd = @responseEnd, domLoading = @domLoading, domInteractive = @domInteractive, domContentLoadedEventStart = @domContentLoadedEventStart, domContentLoadedEventEnd = @domContentLoadedEventEnd, domComplete = @domComplete, loadEventStart = @loadEventStart, loadEventEnd = @loadEventEnd, prerenderSwitch = @prerenderSwitch, redirectCount = @redirectCount, initiatorType = @initiatorType, name = @name, startTime = @startTime, duration = @duration, navigationStart = @navigationStart, userName = @userName, clientIP = @clientIP, userAgent = @userAgent, browser = @browser, browserVersion = @browserVersion, hostMachineName = @hostMachineName 
where id = @id

end
go 
                    
--***********
go 
drop proc lsp_DeleteBerfClient
go 
create proc lsp_DeleteBerfClient  
@id uniqueidentifier
as
begin
delete from BerfClient 
where id = @id									 
end
go 
                    
--***********
go 
drop proc lsp_ReadBerfClient
go 
create proc lsp_ReadBerfClient  
@id uniqueidentifier
as
begin
select id, sessionId, renderId, ord, url, entryType, source, created, unloadEventStart, unloadEventEnd, linkNegotiationStart, linkNegotiationEnd, redirectStart, redirectEnd, fetchStart, domainLookupStart, domainLookupEnd, connectStart, connectEnd, secureConnectionStart, requestStart, responseStart, responseEnd, domLoading, domInteractive, domContentLoadedEventStart, domContentLoadedEventEnd, domComplete, loadEventStart, loadEventEnd, prerenderSwitch, redirectCount, initiatorType, name, startTime, duration, navigationStart, userName, clientIP, userAgent, browser, browserVersion, hostMachineName 
from BerfClient  
where id = @id									 
end
go 
                    
--***********
go 
drop proc lsp_ReadBerfClientWithNoLock
go 
create proc lsp_ReadBerfClientWithNoLock  
@id uniqueidentifier
as
begin
select id, sessionId, renderId, ord, url, entryType, source, created, unloadEventStart, unloadEventEnd, linkNegotiationStart, linkNegotiationEnd, redirectStart, redirectEnd, fetchStart, domainLookupStart, domainLookupEnd, connectStart, connectEnd, secureConnectionStart, requestStart, responseStart, responseEnd, domLoading, domInteractive, domContentLoadedEventStart, domContentLoadedEventEnd, domComplete, loadEventStart, loadEventEnd, prerenderSwitch, redirectCount, initiatorType, name, startTime, duration, navigationStart, userName, clientIP, userAgent, browser, browserVersion, hostMachineName 
from BerfClient  with (nolock)  
where id = @id									 
end
go 
                    
--***********
go 
drop proc lsp_InsertIdea
go 
create proc lsp_InsertIdea  
@Id uniqueidentifier,@IdeaTypeEnum int,@ParentId uniqueidentifier,@StageEnum int,@UserId [nvarchar](128),@UiOrder float,@UiVisible smallint,@Title [nvarchar](MAX),@Tags [nvarchar](MAX),@Body [nvarchar](MAX),@Publish datetime2,@Created datetime2,@Updated datetime2
as
begin
insert into Idea 
( Id,IdeaTypeEnum,ParentId,StageEnum,UserId,UiOrder,UiVisible,Title,Tags,Body,Publish,Created,Updated ) 
values
( @Id,@IdeaTypeEnum,@ParentId,@StageEnum,@UserId,@UiOrder,@UiVisible,@Title,@Tags,@Body,@Publish,@Created,@Updated )
end
go 
                    
--***********
go 
drop proc lsp_UpdateIdea
go 
create proc lsp_UpdateIdea  
@Id uniqueidentifier,@IdeaTypeEnum int,@ParentId uniqueidentifier,@StageEnum int,@UserId [nvarchar](128),@UiOrder float,@UiVisible smallint,@Title [nvarchar](MAX),@Tags [nvarchar](MAX),@Body [nvarchar](MAX),@Publish datetime2,@Created datetime2,@Updated datetime2
as
begin
update Idea 
set IdeaTypeEnum = @IdeaTypeEnum, ParentId = @ParentId, StageEnum = @StageEnum, UserId = @UserId, UiOrder = @UiOrder, UiVisible = @UiVisible, Title = @Title, Tags = @Tags, Body = @Body, Publish = @Publish, Created = @Created, Updated = @Updated 
where Id = @Id

end
go 
                    
--***********
go 
drop proc lsp_DeleteIdea
go 
create proc lsp_DeleteIdea  
@Id uniqueidentifier
as
begin
delete from Idea 
where Id = @Id									 
end
go 
                    
--***********
go 
drop proc lsp_ReadIdea
go 
create proc lsp_ReadIdea  
@Id uniqueidentifier
as
begin
select Id, IdeaTypeEnum, ParentId, StageEnum, UserId, UiOrder, UiVisible, Title, Tags, Body, Publish, Created, Updated 
from Idea  
where Id = @Id									 
end
go 
                    
--***********
go 
drop proc lsp_ReadIdeaWithNoLock
go 
create proc lsp_ReadIdeaWithNoLock  
@Id uniqueidentifier
as
begin
select Id, IdeaTypeEnum, ParentId, StageEnum, UserId, UiOrder, UiVisible, Title, Tags, Body, Publish, Created, Updated 
from Idea  with (nolock)  
where Id = @Id									 
end
go 


*/
	                