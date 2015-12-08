namespace BerfDac.IntegrationTest

[<AutoOpen>]
module DomainTypes =
    open System.Net

    type AppConfig =
        { FileDropDirectory : string }