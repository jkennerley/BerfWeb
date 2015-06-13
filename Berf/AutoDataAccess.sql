--****************************
/*  
--
create database Berf;
go 

--
use Berf ; 
*/
go 

--****************************
-- create sql server login
CREATE LOGIN berfUser WITH PASSWORD = 'B932172B' ;
GO

-- Creates a database user for the login created above.
CREATE USER berfUser FOR LOGIN berfUser;
GO

-- add user to database role 
EXEC sp_addrolemember N'db_owner', N'berfUser'
go 

--****************************
drop table [dbo].[BerfClient]
go 
create table [dbo].[BerfClient](
	[id]								[uniqueidentifier] NOT NULL DEFAULT (newid()),
	[sessionId]							[uniqueidentifier] NOT NULL,
	[renderId]							[uniqueidentifier] NOT NULL,
	[ord]								[int] not NULL default(0),
	[url]								[nvarchar](max) NULL,
	[entryType]							[nvarchar](max) NULL,
	[source]							[nvarchar](max) NULL,
	[created]							[datetime] NOT NULL default(getdate()),
	[unloadEventStart]					[float] NULL,
	[unloadEventEnd]					[float] NULL,
	[linkNegotiationStart]				[float] NULL,
	[linkNegotiationEnd]				[float] NULL,
	[redirectStart]						[float] NULL,
	[redirectEnd]						[float] NULL,
	[fetchStart]						[float] NULL,
	[domainLookupStart]					[float] NULL,
	[domainLookupEnd]					[float] NULL,
	[connectStart]						[float] NULL,
	[connectEnd]						[float] NULL,
	[secureConnectionStart]				[float] NULL,
	[requestStart]						[float] NULL,
	[responseStart]						[float] NULL,
	[responseEnd]						[float] NULL,
	[domLoading]						[float] NULL,
	[domInteractive]					[float] NULL,
	[domContentLoadedEventStart]		[float] NULL,
	[domContentLoadedEventEnd]			[float] NULL,
	[domComplete]						[float] NULL,
	[loadEventStart]					[float] NULL,
	[loadEventEnd]						[float] NULL,
	[prerenderSwitch]					[float] NULL,
	[redirectCount]						[int] NULL,
	[initiatorType]						[nvarchar](max) NULL,
	[name]								[nvarchar](max) NULL,
	[startTime]							[float] NULL,
	[duration]							[float] NULL,
	[navigationStart]					[float] NULL,
	[userName]							[nvarchar](max) NOT NULL default(''),
	[clientIP]							[nvarchar](39) NOT NULL default(''),
	[userAgent]							[nvarchar](max) NOT NULL default(''),
	[browser]							[nvarchar](max) NULL default(''),
	[browserVersion]					[nvarchar](max) NULL default(''),
	[hostMachineName]					[nvarchar](max) NOT NULL default('')
) 
go 
alter table BerfClient add constraint pkBerfClient_Id primary key nonclustered (Id);
go 



--****************************
drop table [dbo].[BerfMvc]
go 
create table [dbo].[BerfMvc](
	[id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[renderId] [uniqueidentifier] NOT NULL,
	[sessionId] [uniqueidentifier] NOT NULL,
	[action] [nvarchar](max) NOT NULL,
	[controller] [nvarchar](max) NOT NULL,
	[area] [nvarchar](max) NOT NULL,
	[actionStart] [datetime] NOT NULL,
	[actionEnd] [datetime] NOT NULL,
	[resultStart] [datetime] NOT NULL,
	[resultEnd] [datetime] NOT NULL,
	[actionDuration] [float] NOT NULL,
	[resultDuration] [float] NOT NULL,
	[created] [datetime] NOT NULL,
	[clientIP] [nvarchar](39) NOT NULL,
	[userName] [nvarchar](max) NOT NULL,
	[userAgent] [nvarchar](max) NOT NULL,
	[browser] [nvarchar](max) NULL,
	[browserVersion] [nvarchar](max) NULL,
	[hostMachineName] [nvarchar](max) NOT NULL,
	[headers] [nvarchar](max) NULL
) 
go 
alter table BerfMvc add constraint pkBerfMvc_Id primary key nonclustered (Id);
go 




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
-- truncate table BerfClient ;
--
-- select * from BerfClient; 


                    