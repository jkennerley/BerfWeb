# Berf - Browser Performance

Log browser timing data into a SQL server database.
See http://www.w3.org/TR/navigation-timing/ and http://www.w3.org/TR/navigation-timing-2/.


This repo has a project called FDac that will generate automatic F# crud that leverages FSharp.Data.SqlClient.


Berf is small project that saves the timing data in the browser to a SQL Server database.
Berf is a quick way of logging all that really useful browser timing data that is available in modern browsers without a big fuss over using a paid for external service or glimpse plugin that calls home.


The Projects :-

     - Berf : F# library that contains an MVC controller. 
     - BerfWeb : a C# asp.net project that referencing Berf.dll. It contains the JavaScript file Berf.js
     - FDac : enables creation of automatic crud that sits on top of FSharp.Data.SqlClient


Recipie For using Berf :

BerfWeb.dll is demonstration project included in the git repository solution.
It is the simplest out of the box visual studio project that exercises Berf.dll.
Below is the changes made to the vanilla BerfWeb to enable logging of browser timers to a database.

     1. Start new .Net asp.net project e.g. BerfWeb.dll.
     2. reference Berf.dll
     3. Add Berf.ts/Berf.js/Berf.min.js to your project.
     4. Make use of Berf.js with the addition of the following to your _Layout.cshtml. See the example in BerfWeb.
     5. You may have to add meta http-equiv="X-UA-Compatible" content="IE=Edge" meta tag for IE to play ball. See the example in BerfWeb.
     6. Alter the BerfWeb.dll web.config with an appropriate connection string.
     7. Alter the BerfWeb.dll web.config with a binding redirect so FSharp.Core 4.3.1 can be found.
     8. Alter the Berf.dll app.config with a connection string to your Berf database.
     9. Oh yes, the database, run the Berf.sql script to setup the database.  Note the berfUser that is mapped in and adjust you connection strings.
     10. Either F5 your project or add IIS application and set the appropriate directory permission to the BerfWeb disc directory.
     11. You should be getting browser timer data in a BerfClient table ...


Note :

[Berf.dll uses the FSharp.Sql.Client type provider](http://fsprojects.github.io/FSharp.Data.SqlClient/)
Actually Berf.dll is show-and-tell practical usage of FSharp.Data.SqlClient and FDac.

FDac was used kickout the F# and SQL crud code that is inside Berf.dll
 
FDac is project aimed at the automatic kickout of F# and T-SQL that leverages FSharp.Data.SqlClient.
You could use T4 templates, the Taligent free plugin, Linq-to-Sql, EntityFramework, and maybe even the SqlEntityConnection type provider, but hey, the time is now June 2015, exactly.


[The layout of Berf files is patterned in the way described here ](http://fsharpforfunandprofit.com/posts/recipe-part3/)

Berf and FDac is a practical, useful demonstration of FSharp.Data.SqlClient type provider with a module layout as described by Scott Wlaschin.
You may like to use Deedle on the collected data to exercise those statistical skills.


Next ...
FDac will be progressed with NCrunch usage in ordere make a tool which will automatically generate F# crud as part of a development cycle ...


Thanks to Jack Sowter for thw offline work on Berf.ts client side file.

