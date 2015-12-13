--truncate table BerfClient
go 

-- select * from Client 

/*
select top 1000
	url, 
	Duration , 
    convert( char(30), [Created] , 126) as 'Created'
from BerfClient with (nolock) 
where Source = 'Navigation1' 
-- order by Created desc 
*/



select * from BerfClient
-- select top 10 * from BerfClient where source = 'Navigation1' order by created desc

select 
	BerfClient.url
	, round( avg( BerfClient.loadEventEnd), 1)		as 'Mean'
	, round( sum( BerfClient.loadEventEnd)	, 1)	as 'Sum'
	, round( count( BerfClient.loadEventEnd), 1)	as 'N'
	, round( STDEVP ( BerfClient.loadEventEnd), 1) as 'Std'

from BerfClient with (nolock) 
where source = 'Navigation1'
group by Url
order by 'Mean' desc

