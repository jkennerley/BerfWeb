namespace BerfDacIntegrationTest

open System.Configuration
open System.Reflection
open System.Diagnostics
open System.IO

open System 
open Newtonsoft.Json 
open Xunit
open Swensen.Unquote
open BerfDac.Repo
open System.Reflection
open System.Diagnostics
open System.IO
open System.Diagnostics

[<AutoOpen>]
module Helpers =

// get app config
let getAppConfig () =
                    {
                        DomainTypes.FileDropDirectory = ConfigurationManager.AppSettings.["FileDropDirectory"]
                        ProjectNameSpace = ConfigurationManager.AppSettings.["ProjectNameSpace"]
                        TablesWhiteList  = ConfigurationManager.AppSettings.["TablesWhiteList"]
                    }

let thisFunctionName () =
    let st:StackTrace = new StackTrace ()
    let sf = st.GetFrame(1)
    sf.GetMethod().Name;

let getTestTimeLogFilename() =
    let config = getAppConfig()
    config.FileDropDirectory + @"\"  + @"TestTimeLog.txt";

let saveTimedItem (timedItem:TimedItem) (stopWatch:Stopwatch) =
    let config = getAppConfig()
    let path = config.FileDropDirectory + @"\"  + @"TestTimeLog.txt";
    File.AppendAllText(getTestTimeLogFilename() , ( sprintf "%s%s" System.Environment.NewLine (JsonConvert.SerializeObject(timedItem)) ) );
    timedItem



