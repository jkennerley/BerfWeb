namespace BerfDac.IntegrationTest

[<AutoOpen>]
module DomainTypes = 
    type AppConfig = 
        { FileDropDirectory : string
          ProjectNameSpace : string
          TablesWhiteList : string }
