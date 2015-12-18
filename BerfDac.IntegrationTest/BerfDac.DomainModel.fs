namespace BerfDacIntegrationTest

open System

[<AutoOpen>]
module DomainTypes =
    type AppConfig =
        { FileDropDirectory : string
          ProjectNameSpace : string
          TablesWhiteList : string }

    type TimedItem = {
        Id      : string;
        RunSigId        : string;
        SigId           : string;
        Sig             : string;
        Time            : float;
        Count           : int;
        EventDt         : string;
        ClientSig       : string;
        ClientSigVer    : string;
        //IP              : string;
        //Username        : string;
        //Browser         : string;
        Server          : string;

    }

    let TimedItemZero () =
                        {
                            TimedItem.Id = Guid.NewGuid().ToString() ;
                            RunSigId = "" ;
                            Sig = "" ;
                            SigId = "" ;
                            Time = 0.
                            Count = 0
                            EventDt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\:mm\:ss")
                            ClientSig       = ""
                            ClientSigVer= ""
                            Server = System.Environment.MachineName
                        }

