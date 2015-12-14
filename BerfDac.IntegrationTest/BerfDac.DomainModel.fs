namespace BerfDacIntegrationTest

[<AutoOpen>]
module DomainTypes = 
    type AppConfig = 
        { FileDropDirectory : string
          ProjectNameSpace : string
          TablesWhiteList : string }
