--****************************
/*  
--
create database BerfDb;
go 

--
use BerfDb ; 
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
exec sp_addrolemember N'db_owner', N'berfUser'
go 

--****************************
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'BerfClient' AND TABLE_SCHEMA = 'dbo')
begin
	drop table [dbo].[BerfClient]
end
go 
create table [dbo].[BerfClient](
	[id]								[uniqueidentifier] NOT NULL DEFAULT (newid()),
	[sessionId]							[uniqueidentifier] NOT NULL,
	[renderId]							[uniqueidentifier] NOT NULL,
	[ord]								[int] not NULL default(0),
	[url]								[nvarchar](max) not null default(''),
	[entryType]							[nvarchar](max) not null default(''),
	[source]							[nvarchar](max) not null default(''),
	[created]							[nvarchar](40) NOT NULL default(  convert( varchar(30) , getdate() , 126)   ),
	[unloadEventStart]					[float] not null default(0.000001),
	[unloadEventEnd]					[float] not null default(0.000001),
	[linkNegotiationStart]				[float] not null default(0.000001),
	[linkNegotiationEnd]				[float] not null default(0.000001),
	[redirectStart]						[float] not null default(0.000001),
	[redirectEnd]						[float] not null default(0.000001),
	[fetchStart]						[float] not null default(0.000001),
	[domainLookupStart]					[float] not null default(0.000001),
	[domainLookupEnd]					[float] not null default(0.000001),
	[connectStart]						[float] not null default(0.000001),
	[connectEnd]						[float] not null default(0.000001),
	[secureConnectionStart]				[float] not null default(0.000001),
	[requestStart]						[float] not null default(0.000001),
	[responseStart]						[float] not null default(0.000001),
	[responseEnd]						[float] not null default(0.000001),
	[domLoading]						[float] not null default(0.000001),
	[domInteractive]					[float] not null default(0.000001),
	[domContentLoadedEventStart]		[float] not null default(0.000001),
	[domContentLoadedEventEnd]			[float] not null default(0.000001),
	[domComplete]						[float] not null default(0.000001),
	[loadEventStart]					[float] not null default(0.000001),
	[loadEventEnd]						[float] not null default(0.000001),
	[prerenderSwitch]					[float] not null default(0.000001),
	[redirectCount]						[int] not null default(0),
	[initiatorType]						[nvarchar](max) not null default(''),
	[name]								[nvarchar](max) not null default(''),
	[startTime]							[float] not null default(0.000001),
	[duration]							[float] not null default(0.000001),
	[navigationStart]					[float] not null default(0.000001),
	[userName]							[nvarchar](max) NOT NULL default(''),
	[clientIP]							[nvarchar](39) NOT NULL default(''),
	[userAgent]							[nvarchar](max) NOT NULL default(''),
	[browser]							[nvarchar](max) NOT NULL default(''),
	[browserVersion]					[nvarchar](max) NOT NULL default(''),
	[hostMachineName]					[nvarchar](max) NOT NULL default('')
) 
go 
alter table BerfClient add constraint pkBerfClient_Id primary key nonclustered (Id);
go 


--****************************
if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'BerfMvc' AND TABLE_SCHEMA = 'dbo')
begin
	drop table [dbo].[BerfMvc]
end

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
-- truncate table BerfClient ;
--
-- select * from BerfClient; 


                    



