// open FDac

(*
This is a recipe for setting up, progressing with FDac

:: Start a new data access project e.g. FDac.dll 

:: Install nuget package for type provider data access
Install-Package FSharp.Data.SqlClient

:: Add File DomainTypes.fs

:: Add Files that have functions per DomainType e.g. BerfClient.fs

:: Add ConnectionConfig.fs, and configure for connection string in the app config. 
e.g. 
[<Literal>]
let CnString = "name=MiDb"

:: Add a connection string to the appropriate app.config/web.config
e.g. 
  <connectionStrings>
    <add name="midb" connectionString="Data Source=.\sqlserver2014;Initial Catalog=midb;..." providerName="System.Data.SqlClient" />
  </connectionStrings>

:: Add DataAccessEnum.fs. Used for Enum configured from the database.

:: Add DataAccessSchema.fs. 
The types in here enable 'reflection' of types from your database, 
in order to auto generate t-sql and fsharp code.

:: An auto generated sql file will need to be generated here, see later.
Assume a blank autogen.sql file here on first pass

:: Add DataAccessTypes.fs. 
The content of this will be auto generated, depending on your database schema.

:: Add a reference to System.Data

:: The FDac project should now compile.


:: Start a new Project FDac.IntegrationTest.dll

Install-Package XUnit
Install-Package xunit.runner.console 
Install-Package xunit.runner.visualstudio

Add references to xunit.core, xunit.assert, xunit.absrractions.
Add reference to Fsharp.Data.SqlClient
Ad an app.config, and appropriate connection string.
Add reference to System.Data

AutoOpen the FDac.DomainTypes and any modules you have for those types e.g. [<AutoOpen>] at the top of DominTypes.fs and BerfClient.fs

Install-Package unquote and add reference to that library



*)
