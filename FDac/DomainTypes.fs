[<AutoOpen>]
module FDac.DomainTypes

open System

type Table =
    { Catalog : string
      TableName : string }

type Column =
    { Catalog : string
      TableName : string
      ColumnName : string
      DataType : string
      MaxLength : int }

type PKey =
    { Catalog : string
      TableName : string
      ColumnName : string
      ConstraintName : string
      Ord : int }

type DbMeta =
    { Tables : seq<Table>
      Pkeys : seq<PKey>
      Cols : seq<Column> }

type TableMeta =
    { Table : Table
      Pkeys : seq<PKey>
      Cols : seq<Column> }

type CodeElement =
    { Lang : string
      Type : string
      Code : string }

[<CLIMutable>]
type BerfClient =
    { id : Guid
      sessionId : Guid
      renderId : Guid
      ord : int
      url : string
      entryType : string
      source : string
      created : DateTime
      unloadEventStart : float
      unloadEventEnd : float
      linkNegotiationStart : float
      linkNegotiationEnd : float
      redirectStart : float
      redirectEnd : float
      fetchStart : float
      domainLookupStart : float
      domainLookupEnd : float
      connectStart : float
      connectEnd : float
      secureConnectionStart : float
      requestStart : float
      responseStart : float
      responseEnd : float
      domLoading : float
      domInteractive : float
      domContentLoadedEventStart : float
      domContentLoadedEventEnd : float
      domComplete : float
      loadEventStart : float
      loadEventEnd : float
      prerenderSwitch : float
      redirectCount : int
      initiatorType : string
      name : string
      startTime : float
      duration : float
      navigationStart : float
      userName : string
      clientIP : string
      userAgent : string
      browser : string
      browserVersion : string
      hostMachineName : string }

type Idea =
    { Id : Guid
      IdeaTypeEnum : int
      ParentId : Guid
      StageEnum : int
      UserId : string
      UiOrder : float
      UiVisible : int16
      Title : string
      Tags : string
      Body : string
      Publish : DateTime
      Created : DateTime
      Updated : DateTime }

[<CLIMutable>]
type HttpSummary =
    { Server : String
      Browser : String
      BrowserVersion : String
      controller : String
      action : String
      IP : String
      AuthUser : String
      LogonUser : String
      ClientSigVer : String
      UserAgent : String }
