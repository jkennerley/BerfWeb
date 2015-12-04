# Berf - Browser Performance

Log browser timing data into a SQL server database.
See http://www.w3.org/TR/navigation-timing/ and http://www.w3.org/TR/navigation-timing-2/.

Berf is small project that saves the timing data in the browser to a SQL Server database.
Berf is a way of logging useful browser timing data available in modern browsers without using a paid for external service or glimpse plugin that calls home.


The Projects :-

     - BerfWeb : a C# asp.net project that referencing Berf.dll. It contains the JavaScript file Berf.js
     - Berf : F# library that contains an MVC controller. 
     - FDac : enables creation of automatic crud that sits on top of FSharp.Data.SqlClient.  Used by Berf.dll

Recipe For using Berf :

BerfWeb.dll is a simple out of the box visual studio project that exercises Berf.dll.
Below are the changes made to a vanilla Visual Studio Asp.Net project that enables logging of browser timers to a database.

     1. Start new .Net asp.net project e.g. BerfWeb.dll.
     2. reference Berf.dll
     3. Add Berf.ts/Berf.js/Berf.min.js to your project.
     4. Add Berf.js to your _Layout.cshtml, see the example in this prject at BerfWeb\Views\Shared\_Layout.cshtml.
     5. You may have to add meta http-equiv="X-UA-Compatible" content="IE=Edge" meta tag for IE to play ball. See the example in BerfWeb.
     6. Alter the BerfWeb.dll web.config with an appropriate connection string.
     7. Alter the BerfWeb.dll web.config with a binding redirect so FSharp.Core 4.3.1 can be found.
     8. Alter the Berf.dll app.config with a connection string to your Berf database. There are examples of connections string in the solution.
     9. The database, run the \BerfWeb\Berf\BerfSchema.sql script to setup the database.  Note the mapped user call 'berfUser' and adjust you connection strings.
     10. Either F5 your project or add IIS application and set the appropriate directory permission to the BerfWeb disc directory.
     11. You should be getting browser timer data in a BerfClient table.

Note :

[Berf.dll uses the FSharp.Sql.Client type provider](http://fsprojects.github.io/FSharp.Data.SqlClient/)
Berf.dll is show-and-tell practical usage of FSharp.Data.SqlClient and FDac.
Berf contains crud code for saving F# domain entities into the database. 
The Berf.dll crud code is really one insert into one table, but the Berf.dll contains other code which demonstrates crud via FSharp.Data.SqlClient.
FDac was used to create the Berf.dll crud code.

FDac is project aimed at the facilitating automatic kickout of F# and T-SQL that leverages FSharp.Data.SqlClient.
You could use T4 templates, the Taligent free plugin, Linq-to-Sql, EntityFramework, and maybe even the SqlEntityConnection type provider, is now June 2015, exactly.

Berf and FDac is a practical, useful demonstration of FSharp.Data.SqlClient type provider with a module layout as described by [Scott Wlaschin](http://fsharpforfunandprofit.com/posts/recipe-part3/).

You may like to use Deedle on the collected data to exercise those statistical skills.

Thanks to Jack Sowter for the work on Berf.ts client side file.

